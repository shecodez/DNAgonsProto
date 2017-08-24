using UnityEngine;
using System.Collections;

public class DragoFire : MonoBehaviour {

    private Animator anim;
    private Transform cam;

    [Header("Dragon Fire")]
   
    public float FireBallSpeed = 500;
    public Transform FirePoint;
         
    public GameObject FireBall;
    public GameObject FireBreath;
  
    ParticleSystem.EmissionModule emision;
    [Space]
  
    public bool aimMode;
    public float maxAngle = 110;
    bool active;
    float angle;
    Vector3 dir = Vector3.zero;

    Quaternion[] aa;//, initialrotations;
    public Transform[] Bones;
    public float Smoothness = 5;

    // Use this for initialization

    void Start () {

        anim = GetComponent<Animator>();
        //Set the Fire Breath
        GameObject firebreathinstance = Instantiate(FireBreath);
        firebreathinstance.transform.parent = FirePoint;
        firebreathinstance.transform.position = FirePoint.position;
        firebreathinstance.transform.rotation = FirePoint.rotation;
        emision = firebreathinstance.GetComponent<ParticleSystem>().emission;
#if UNITY_5_5_OR_NEWER
        emision.rateOverTime = new ParticleSystem.MinMaxCurve(0);
#else
        emision.rate = new ParticleSystem.MinMaxCurve(0);
#endif

        if (Camera.main != null)  cam = Camera.main.transform;

        active = true;
      //  initialrotations = new Quaternion[Bones.Length];
        aa = new Quaternion[Bones.Length];

    //    for (int i = 0; i < Bones.Length; i++)
        //    initialrotations[i] = Quaternion.Inverse(transform.rotation) * Bones[i].rotation;
    }

    void CalculateDir()
    {
        
        Vector3 rayOrigin = cam.GetComponent<Camera>().ViewportToWorldPoint(new Vector3(0.5f, 0.5f, 0));

        RaycastHit hit;

        if (Physics.Raycast(rayOrigin, cam.forward, out hit, 50f))
        {
            dir = (hit.point - FirePoint.position).normalized; // Get the direction from the firepoint to the Hit Point
        }
        else
        {
            dir = cam.forward;
        }

        angle = Vector3.Angle(transform.forward, dir);
    }

    public void FireAttack(int type)
    {

        //Fire ball Throw
        if (FireBall && type == 1)
        {
            //This if  exist because then it will shoot 2 fire balls
            if (anim.GetCurrentAnimatorStateInfo(0).IsTag("Attack Fire") || anim.GetNextAnimatorStateInfo(0).IsTag("Attack Fire") ||
                anim.GetCurrentAnimatorStateInfo(1).IsTag("Attack Fire") || anim.GetNextAnimatorStateInfo(1).IsTag("Attack Fire"))
            {
                GameObject fireball = Instantiate(FireBall);
                fireball.transform.position = FirePoint.transform.position;
            
                //Get the direction from the camera
                CalculateDir();


                if (angle > maxAngle)  dir = FirePoint.forward;

                if (!active || !aimMode || angle > maxAngle)
                {
                    if (anim.GetFloat("UpDown") <= 0.1 && anim.GetFloat("UpDown") >= -0.1)
                    {
                        dir = new Vector3(FirePoint.forward.x, transform.forward.y, FirePoint.forward.z); //Shoot Foward if is not in the air or swimming
                    }
                }

                fireball.GetComponent<Rigidbody>().AddForce(dir * FireBallSpeed);
            }
        }

        //Activate the fire breath by adding more rating
        if (FireBreath && type == 2)
        {
#if UNITY_5_5_OR_NEWER
            emision.rateOverTime = new ParticleSystem.MinMaxCurve(500f);
#else
            emision.rate = new ParticleSystem.MinMaxCurve(500f);
#endif 
        }

        //Deactivate the fire breath
        if (FireBreath && type == 3)
        {

#if UNITY_5_5_OR_NEWER
            emision.rateOverTime = new ParticleSystem.MinMaxCurve(0);
#else
            emision.rate = new ParticleSystem.MinMaxCurve(0);
#endif
        }
    }

    void Update()
    {
        CalculateDir();
        bonechains();
        fireBreathFix();
    }

    void fireBreathFix()
    {
        if (FirePoint.GetChild(0))
        {
            if (angle < maxAngle)
            {
                FirePoint.GetChild(0).transform.rotation = Quaternion.LookRotation(dir);
            }
            else
            {
                FirePoint.GetChild(0).transform.rotation = FirePoint.rotation;
            }
        }
    }

    //------------------This make the Head Look at towards the camera center point
    void bonechains()
    {
        if (Bones.Length > 0)
        {
            for (int i = 0; i < Bones.Length; i++)
            {
                if (Vector3.Angle(transform.forward,cam.forward) < maxAngle && active && aimMode)
                {
                    float percent = (float)(1 + i) / Bones.Length;
                    Quaternion next = Quaternion.Lerp(aa[i], Quaternion.LookRotation(cam.forward, Vector3.up) * Quaternion.Euler(0,-90,-90), percent); //get the -percent of each bones, lower get less rotation final bone (Head get full rotation) 

                    aa[i] = Quaternion.Lerp(aa[i], next, Time.deltaTime * Smoothness * 2);
                }
                else
                {
                    aa[i] = Quaternion.Lerp(aa[i], Bones[i].rotation, Time.deltaTime * Smoothness * 2);
                }
                Bones[i].rotation = aa[i];
            }
        }
    }

    //This is call by the Animator Behaviors to activate and deactivate the head aim in certain animations, (Die, Fall, Sleep)
    public void Activate(bool value)
    {
        active = value;
    }
}
