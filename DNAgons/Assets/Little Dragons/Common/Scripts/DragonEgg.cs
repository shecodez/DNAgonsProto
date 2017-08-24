using UnityEngine;
using System.Collections;

public class DragonEgg : MonoBehaviour
{
    public enum HatchType {Key,Time,Click,Input,Event };
    Animator anim;
    [Header("Use Baby Dragons or scale the egg")]
    public GameObject Dragon;
    public float removeShells = 10f;
    bool crack_egg;


    [Space]
    [Header("Material Options")]
    public Transform EggMesh;
    public Transform EggMeshInside;
    public Material[] EggColor;
    private int dragmaterial;

    [HideInInspector]
    public KeyCode key = KeyCode.Alpha5;
    [HideInInspector]
    public string input = "HatchEgg";
    [HideInInspector]
    public float seconds;

    public HatchType hatchtype;

    // Use this for initialization

    void Start()
    {
        anim = GetComponent<Animator>();

        if (Dragon)
        {
            if (!Dragon.activeInHierarchy)  Dragon = Instantiate(Dragon);

            Dragon.transform.position = transform.position;
            Dragon.GetComponent<Animator>().SetInteger("DragoInt", -10); //Set the egg State
        }

        if (hatchtype == HatchType.Time)
        {
            StartCoroutine(TimeCrackEgg());
        }
    }

    void Update()
    {
        switch (hatchtype)
        {
            case HatchType.Key:
                if (Input.GetKey(key))  crack_egg = true;
                    break;
            case HatchType.Time:
                break;
            case HatchType.Click:
                break;
            case HatchType.Input:
                if (Input.GetButton(input)) crack_egg = true;
                break;
            case HatchType.Event:
                break;
            default:
                break;
        }

        if (crack_egg)
        {
            CrackEgg();
        }
    }

    IEnumerator TimeCrackEgg()
    {
        yield return new WaitForSeconds(seconds);
        CrackEgg();
    }

    public void CrackEgg()
    {
        anim.SetInteger("State", 1);
        if (Dragon)
        {
            Dragon.transform.gameObject.SetActive(true);
            Dragon.GetComponent<Animator>().SetInteger("DragoInt", -1 * Random.Range(1, 4));
        }
        StartCoroutine(EggDisapear(removeShells));
    }

    
    
    //Destroy the Game Object
    IEnumerator EggDisapear(float seconds)
    {
        yield return new WaitForSeconds(seconds);
        anim.SetInteger("State", 2);
        yield return new WaitForSeconds(1f);
        Destroy(transform.gameObject);
    }




    public void ChangeColor(Transform egg, Transform eggin)
    {
        egg.GetComponent<SkinnedMeshRenderer>().material = EggColor[dragmaterial];
        eggin.GetComponent<SkinnedMeshRenderer>().material = EggColor[dragmaterial];

        dragmaterial++;
        if (dragmaterial == EggColor.Length) dragmaterial = 0;

    }


    void OnMouseDown()
    {
        if (hatchtype == HatchType.Click)
        {
            CrackEgg();
        }
    }

}
