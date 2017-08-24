using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class LayerDefinition
{
    public float inputRange;
    public float outputRange;
}

public class TerrainGenerator : MonoBehaviour {

    public float level1Div = 1, level2Div = 4;
    public float level1Step = 200, level2Step = 50;
    public float offsetX = 0, offsetZ = 0;

    //InputRange OutputRange    Description
    //  0.20        0.10        Underwater layer; we will squeeze this layer a bit (divided by 2)
    //  0.20	    0.02	    Grass layer; we divide the values in this range by 10 to get flat riversides.
    //  0.20	    0.15	    Hill layer; we’ll squeeze it just a bit
    //  0.40	    0.73	    Mountain layer; values are almost doubled
    public LayerDefinition[] layerDefinitions;

    Terrain terrain;    
    TerrainData terrainData;
    float[,] heights;

    void Start() {
        terrain = GetComponent<Terrain>();
        terrainData = terrain.terrainData;//GetComponent<TerrainData>();
        heights = new float[terrainData.heightmapWidth, terrainData.heightmapHeight];
        GeneratePerlinTerrain();
        PostProcessTerrain();
        NormalizeHeightMap();
        terrainData.SetHeights(0, 0, heights);
    }

    void Update() { }

    public void GeneratePerlinTerrain()
    {
        for (int z = 0; z < terrainData.heightmapHeight; ++z)
        {
            for (int x = 0; x < terrainData.heightmapWidth; ++x)
            {
                float _height1 = 0f;
                float _height2 = 0f;

                _height1 = Mathf.PerlinNoise(x / level1Step + offsetX, 
                    z / level1Step + offsetZ) / level1Div;
                _height2 = Mathf.PerlinNoise(x / level2Step + offsetX,
                    z / level2Step + offsetZ) / level2Div;

                heights[x, z] = _height1 + _height2;
            }
        }
    }

    void NormalizeHeightMap()
    {
        float _minVal = float.MaxValue;
        float _maxVal = float.MinValue;

        for (int z = 0; z < terrainData.heightmapHeight; ++z)
        {
            for (int x = 0; x < terrainData.heightmapWidth; ++x)
            {
                if (heights[x, z] < _minVal) _minVal = heights[x, z];
                if (heights[x, z] > _maxVal) _maxVal = heights[x, z];
            }
        }

        float diff = _maxVal - _minVal;

        for (int z = 0; z < terrainData.heightmapHeight; ++z)
        {
            for (int x = 0; x < terrainData.heightmapWidth; ++x)
            {
                float _height = heights[x, z];
                _height -= _minVal;
                _height /= diff;
                heights[x, z] = _height;
            }
        }
    }

    private void PostProcessTerrain()
    {
        float _curInputMin = 0;
        float _curInputMax;
        float _curOutputMin = 0;
        float _curOutputMax;

        NormalizeHeightMap();

        foreach (LayerDefinition layerDef in layerDefinitions)
        {
            _curInputMax = _curInputMin + layerDef.inputRange;
            _curOutputMax = _curOutputMin + layerDef.outputRange;
            float _mult = (_curOutputMax - _curOutputMin) / (_curInputMax - _curInputMin);

            for (int z = 0; z < terrainData.heightmapHeight; ++z)
            {
                for (int x = 0; x < terrainData.heightmapWidth; ++x)
                {
                    float _height = heights[x, z];
                    if (_height >= _curInputMin && _height < _curInputMax)
                    {
                        _height -= _curInputMin;
                        _height = _height * _mult;
                        _height += _curOutputMin;
                    }
                    heights[x, z] = _height;
                }
            }
            _curInputMin += layerDef.inputRange;
            _curOutputMin += layerDef.outputRange;
        }
    }
}
