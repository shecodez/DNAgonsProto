using UnityEngine;
using System.Collections;

[ExecuteInEditMode]
public class EditDragoBlendShapes : MonoBehaviour
{
    public SkinnedMeshRenderer BlendShapes;

    [Range(0, 100)]
    public float[] blendShapes;

#if UNITY_EDITOR
    // Update is called once per frame
    void Update()
    {
        if (BlendShapes && blendShapes.Length>0)
        {
            for (int i = 0; i < blendShapes.Length; i++)
            {
                BlendShapes.SetBlendShapeWeight(i, blendShapes[i]);
            }
        }
    }
#endif
}
