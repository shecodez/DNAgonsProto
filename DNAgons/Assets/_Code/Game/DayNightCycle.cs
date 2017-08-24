using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// https://www.youtube.com/watch?v=h5GFoI38DOg
// TODO: Fix it! It is Not working as intended
public class DayNightCycle : MonoBehaviour {

    public Gradient skyColor;
    public Transform stars;

    public float maxIntensity = 3;
    public float minIntensity = 0;
    public float minPoint = -0.2f;

    public float maxAmbient = 0;
    public float minAmbient = 0;
    public float minAmbientPoint = -0.2f;

    public Gradient fogColor;
    public AnimationCurve fogDensity;
    public float fogScale = 1;

    public float dayAtmosphericThickness = 1.2f;
    public float nightAtmosphericThickness = 1.4f;

    Vector3 dayRotationSpeed = new Vector3(-2, 0, 0);
    Vector3 nightRotationSpeed = new Vector3(-3, 0, 0);

    float skySpeed = 1;

    Light mainLight;
    Skybox sky;
    Material skyMat;

    void Start()
    {
        mainLight = GetComponent<Light>();
        skyMat = RenderSettings.skybox;
    }

    void Update()
    {
        stars.transform.rotation = transform.rotation;
        // 1  to  sun
        // ^       |
        // |       V
        //sun     -1
        float tRange = 1 - minPoint;
        float dot = Mathf.Clamp01((Vector3.Dot(mainLight.transform.forward, Vector3.down) - minPoint) / tRange);
        float i = ((maxIntensity - minIntensity) * dot) + minIntensity;

        mainLight.intensity = i;

        tRange = 1 - minAmbientPoint;
        dot = Mathf.Clamp01((Vector3.Dot(mainLight.transform.forward, Vector3.down) - minAmbientPoint) / tRange);
        i = ((maxAmbient - minAmbient) * dot) + minAmbient;
        RenderSettings.ambientIntensity = i;

        mainLight.color = skyColor.Evaluate(dot);
        RenderSettings.ambientLight = mainLight.color;

        RenderSettings.fogColor = fogColor.Evaluate(dot);
        RenderSettings.fogDensity = fogDensity.Evaluate(dot) * fogScale;

        i = ((dayAtmosphericThickness - nightAtmosphericThickness) * dot) + nightAtmosphericThickness;
        skyMat.SetFloat("_AtmosphereThickness", i);

        if (dot > 0)
            transform.Rotate(dayRotationSpeed * Time.deltaTime * skySpeed);
        else
            transform.Rotate(nightRotationSpeed * Time.deltaTime * skySpeed);

        if (Input.GetKeyDown(KeyCode.Q)) skySpeed *= .5f;
        if (Input.GetKeyDown(KeyCode.E)) skySpeed *= 2f;
        
    }
}
