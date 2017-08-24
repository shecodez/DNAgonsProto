using UnityEngine;
using System.Collections;

public class DragoEyes : MonoBehaviour {
    [Space]
    [Header("Manage the Eyes animation by anims events")]
    [Space]

    public Animator DragoEyesAnims;
    public Transform EyesMesh;
    public Material[] EyesColors;
    private int dragmaterial;
	
    //----------------------------This method is called by animation clips events, this will open an close the dragon's eyes--------------------------------------
    public void Eyes(int dragoEyes)
    {
        DragoEyesAnims.SetInteger("DragoEyes", dragoEyes);
    }

    //----------------------------This method is called by the button in the inspector cycling the eyes materials on the array you can add more custom eyes shapes--------------------------------------
    public void ChangeColor(Transform eyes)
    {
        eyes.GetComponent<MeshRenderer>().material = EyesColors[dragmaterial];
        dragmaterial++;

        if (dragmaterial == EyesColors.Length) dragmaterial = 0;
        
    }
}

