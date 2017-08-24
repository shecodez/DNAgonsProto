using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Indicator : MonoBehaviour
{

    public float Speed = 0;
    public Color Color;
    public Texture Texture;

    Projector projector;

    void Start()
    {
        Color = Color.cyan; //0084FFFF//
        projector = GetComponent<Projector>();
    }

    void Update()
    {
        projector.material.SetColor("_Color", Color);

        if (Texture != null)
            projector.material.SetTexture("_ShadowTex", Texture);
    }

    void FixedUpdate()
    {
        transform.Rotate(0f, 0f, Speed * Time.deltaTime);
    }

}