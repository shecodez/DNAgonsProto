using UnityEngine;
using System.Collections;
using MalbersAnimations;

public partial class DragonController 
{
    // Use this for initialization
    void Start()
    {
        anim = GetComponent<Animator>();
        DragoTransform = transform;
        dragoCollider = GetComponent<CapsuleCollider>();
        dragoRigidBody = GetComponent<Rigidbody>();
        pivots = GetComponentsInChildren<Pivots>(); //Pivots are Strategically Transform objects use to cast rays used by the drago
        scaleFactor = DragoTransform.localScale.y;  //TOTALLY SCALABE DRAGO
        dragoHeight = pivots[1].transform.localPosition.y;
        groundSpeed = (int)StartSpeed;
        flyspeedanimator = flyAnimationSpeed;
        anim.SetInteger("Type", (int)DragonType);
    }

    /// <summary>
    /// Gets the movement from the Input Script or AI
    /// </summary>
    /// <param name="move"></param>
    /// <param name="active">Active = true means that is taking the Camera Input</param>
    public virtual void Move(Vector3 move, bool active = true)
    {
        if (active)
        {
            // convert the world relative moveInput vector into a local-relative
            // turn amount and forward amount required to head in the desired
            // direction.
            if (move.magnitude > 1f) move.Normalize();
            move = transform.InverseTransformDirection(move);

            turnAmount = Mathf.Atan2(move.x, move.z);
            forwardAmount = move.z;

           movementAxis = new Vector3(turnAmount, movementAxis.y, Mathf.Abs(forwardAmount));

            

            if (UpDownAxis && !jump && !down)                   //Up & Down movement while flying or swiming;
            {
                if (fly || underWater)
                {
                    float a = move.y;
                    if (a > 0) a = a * 1.8f;
                    movementAxis.y = Mathf.Lerp(movementAxis.y, a, Time.deltaTime * 5f);
                }
            }

            if (!stand)
                DragoTransform.Rotate(Vector3.up, movementAxis.x * Time.deltaTime * 40f);
        }
        else
            movementAxis = new Vector3(move.x, movementAxis.y, move.z); //Do not convert to Direction Input Mode (Camera or AI)
    }

    //----------------------Linking  the Parameters to the Animator-----------------------------------------------------------------------------
    public virtual void LinkingAnimator(Animator anim_)
    {
        anim_.SetFloat(HashIDsDragons.verticalHash, movementAxis.z * speed);
        anim_.SetFloat(HashIDsDragons.horizontalHash, direction);
        anim_.SetFloat(HashIDsDragons.updownHash, movementAxis.y);
        anim_.SetFloat(HashIDsDragons.flySpeedHash, Mathf.Lerp(anim_.GetFloat(HashIDsDragons.flySpeedHash), flyspeedanimator, Time.deltaTime * 5f));
        anim_.SetBool(HashIDsDragons.shiftHash, shift);
        anim_.SetBool(HashIDsDragons.standHash, stand);
        anim_.SetBool(HashIDsDragons.jumpHash, jump);
        anim_.SetBool(HashIDsDragons.attack1Hash, attack1);
        anim_.SetBool(HashIDsDragons.attack2Hash, attack2);
        anim_.SetBool(HashIDsDragons.injuredHash, damage);
        anim_.SetBool(HashIDsDragons.flyHash, fly);
        anim_.SetBool(HashIDsDragons.fallHash, fall);
        anim_.SetBool(HashIDsDragons.dodgeHash, dodge);
        anim_.SetBool(HashIDsDragons.stunnedHash, stun);
        anim_.SetBool(HashIDsDragons.swimHash, swim);
        anim_.SetBool(HashIDsDragons.underWaterHash, underWater);
        anim_.SetBool(HashIDsDragons.action, action);
        anim_.SetInteger(HashIDsDragons.actionID, actionID);

        if (fly)
        {
            anim_.SetFloat(HashIDsDragons.floatDragonHash, dragoFloat);
        }
        anim_.SetBool(HashIDsDragons.groundedHash, grounded);

        if (death)
            anim_.SetTrigger(HashIDsDragons.deathHash); //Triggers the Death
    }

    //--Add more Rotations to the current Turn animations -------------------------------------------
    public virtual void TurnAmount()
    {
        float Turn;

        if (fly)
        {
            Turn = flyTurn;
        }
        else if (swim)
        {
            Turn = swimTurn;
        }
        else
        {
            Turn = TurnSpeed;
            if (!anim.GetCurrentAnimatorStateInfo(0).IsTag("Locomotion")) Turn = 0;
          
        }

        if (movementAxis.z >= 0)
        {
            DragoTransform.Rotate(DragoTransform.up, Turn * 3 * movementAxis.x * Time.deltaTime);
        }
        else
        {
            DragoTransform.Rotate(DragoTransform.up, Turn * 3 * -movementAxis.x * Time.deltaTime);
        }

        //More Rotation when jumping and falling... in air rotation------------------
        if (isJumping() || fall && !fly && !swim && !stun)
        {
            if (movementAxis.z >= 0)
                DragoTransform.Rotate(DragoTransform.up, 100 * movementAxis.x * Time.deltaTime);
            else
                DragoTransform.Rotate(DragoTransform.up, 100 * -movementAxis.x * Time.deltaTime);
        }
    }

    //--Add more Speed to the current Move animations--------------------------------------------
    public virtual void SpeedAmount()
    {
        float amount = 0;
        float axis = movementAxis.z;
        Vector3 direction = DragoTransform.forward;

        if (swim && !underWater || anim.GetCurrentAnimatorStateInfo(0).IsName("Swim Jump"))
        {
            amount = swimSpeed;
        }
        else if (underWater)
        {
            amount = UnderSpeed;
        }
        else if (fly)
        {
            amount = flySpeed;

            if (movementAxis.y >= 0.1)
            {
                if (jump) direction = (DragoTransform.forward + DragoTransform.up).normalized;
                if (down) direction = (DragoTransform.forward - DragoTransform.up).normalized;
            }
            else
            {
                axis = movementAxis.y;
                if (jump || down) direction = Vector3.up;
            }
        }
        else
        {
            if (groundSpeed == 1) amount = WalkSpeed;
            if (groundSpeed == 2) amount = TrotSpeed;
            if (groundSpeed == 3) amount = RunSpeed;

            if (!anim.GetCurrentAnimatorStateInfo(0).IsTag("Locomotion"))
            {
                amount = 0;
            }
        }

        DragoTransform.position = Vector3.Lerp(DragoTransform.position, DragoTransform.position + direction * amount * axis / 5f, Time.deltaTime);
    }

    //------------------------------------------Terrain Logic----------------------------------
    public virtual void FixPosition()
    {
        Drago_Hip = pivots[0].transform.position;
        Drago_Chest = pivots[1].transform.position;

        //Ray From Hip to the ground
        if (Physics.Raycast(Drago_Hip, -DragoTransform.up, out hit_Hip, 0.5f * scaleFactor, GroundLayer))
        {
            Debug.DrawRay(hit_Hip.point, hit_Hip.normal * 0.02f, Color.blue);
        }
        //Ray From Chest to the ground
        if (Physics.Raycast(Drago_Chest, -DragoTransform.up, out hit_Chest, 0.5f * scaleFactor, GroundLayer))
        {
            Debug.DrawRay(hit_Chest.point, hit_Chest.normal * 0.02f, Color.red);
        }

        //Smoothy rotate until is Aling with the Horizontal
        if (fly || swim && !underWater)
        {
            float amount = 10f;
            if (swim) amount = 8;

            Quaternion finalRot = Quaternion.FromToRotation(DragoTransform.up, Vector3.up) * dragoRigidBody.rotation;

            if (Vector3.Angle(DragoTransform.up, Vector3.up) > 0.1f)
                DragoTransform.rotation = Quaternion.Lerp(DragoTransform.rotation, finalRot, Time.deltaTime * amount);
            else
                DragoTransform.rotation = finalRot;
        }
        else
        {
            //------------------------------------------------Terrain Adjusment--------------------------------------------

            //---------------------------------Calculate the Align vector of the terrain-----------------------------------
            Vector3 direction = (hit_Chest.point - hit_Hip.point).normalized;
            Vector3 Side = Vector3.Cross(Vector3.up, direction).normalized;
            Vector3 SurfaceNormal = Vector3.Cross(direction, Side).normalized;
            float angleTerrain = Vector3.Angle(DragoTransform.up, SurfaceNormal);

            // ------------------------------------------Orient To Terrain--------------------------------------------------  
            Quaternion finalRot = Quaternion.FromToRotation(DragoTransform.up, SurfaceNormal) * dragoRigidBody.rotation;

            // If the dragon is falling, jumping or flying smoothly aling with the horizontal
            if (fall || isJumping(0.7f, true))
            {
                finalRot = Quaternion.FromToRotation(DragoTransform.up, Vector3.up) * dragoRigidBody.rotation;
                DragoTransform.rotation = Quaternion.Lerp(DragoTransform.rotation, finalRot, Time.deltaTime * 10f);
            }
            else
            {
                // if the terrain changes hard smoothly adjust to the terrain  ground
                if (angleTerrain > 0.2f)
                {
                    DragoTransform.rotation = Quaternion.Lerp(DragoTransform.rotation, finalRot, Time.deltaTime * 10f);
                }
                else
                {
                    DragoTransform.rotation = finalRot;
                }
            }
        }
    }

    //--------------------------------------Falling Logic----------------------------------------------------------
    public virtual void Falling()
    {
        RaycastHit hitpos;
        
        if (Physics.Raycast(dragoCollider.bounds.center, -DragoTransform.up, out hitpos, 0.9f * scaleFactor, GroundLayer))
        {
            //This will avoid to go UpHill
            if (hitpos.normal.y > .707f)
            {
                fall = false;
            }
            else
            {
                fall = true;
            }
        }
        else
        {
            fall = true;
        }
    }

    public virtual void Swimming()
    {
        RaycastHit WaterHitCenter;

        //Front RayWater Cast
        if (Physics.Raycast(pivots[2].transform.position, -DragoTransform.up, out WaterHitCenter, dragoHeight * scaleFactor * 3, LayerMask.GetMask("Water")))
        {
            waterlevel = WaterHitCenter.transform.position.y; //get the water level when find water
            isInWater = true;
        }
       else
        {
            isInWater = false;
        }

        if (isInWater) //if we hit water
        {
            if ((Drago_Chest.y < waterlevel && !swim) || (fall && !fly && !isJumping()))
            {
                swim = true;
                dragoRigidBody.constraints = RigidbodyConstraints.FreezeRotationZ | RigidbodyConstraints.FreezeRotationX | RigidbodyConstraints.FreezeRotationY | RigidbodyConstraints.FreezePositionY;
            }
            //Stop swimming when he is coming out of the water
            if (hit_Chest.distance < dragoHeight * scaleFactor)
            {
                swim = false;
                dragoRigidBody.constraints = RigidbodyConstraints.FreezeRotationZ | RigidbodyConstraints.FreezeRotationX | RigidbodyConstraints.FreezeRotationY;
                dragoRigidBody.useGravity = true;
            }
        }

        if (swim)
        {
            fall = false;
            fly = false;
            
            //Smoothy Move until is Aling with the Water
            if (!isJumping())
            {
                dragoRigidBody.useGravity = true;
                DragoTransform.position = Vector3.Lerp(DragoTransform.position, new Vector3(DragoTransform.position.x, waterlevel - dragoHeight + waterLine, DragoTransform.position.z), Time.deltaTime * 5f);
            }
            else
            {
                dragoRigidBody.useGravity = false;
                dragoRigidBody.constraints = RigidbodyConstraints.FreezeRotationZ | RigidbodyConstraints.FreezeRotationX | RigidbodyConstraints.FreezeRotationY;
            }

            if (movementAxis.y != 0) movementAxis.y = Mathf.Lerp(movementAxis.y, 0, Time.fixedDeltaTime * 5);

            //-------------------Go UnderWater---------------
            if (down && !isJumping())
            {
                underWater = true;
                anim.applyRootMotion = false;
                dragoRigidBody.constraints = RigidbodyConstraints.FreezeRotationZ | RigidbodyConstraints.FreezeRotationX | RigidbodyConstraints.FreezeRotationY;
            }

            if (isJumping(0.5f, true) && !isInWater)
            {
                swim = false;
                dragoRigidBody.constraints = RigidbodyConstraints.FreezeRotationZ | RigidbodyConstraints.FreezeRotationX | RigidbodyConstraints.FreezeRotationY;
            }
        }
    }

    public virtual void UnderWaterMovement()
    {
        if (jump) down = false;

        YAxisMovement(2);

        dragoRigidBody.drag = 100;
        int shiftpeed = 1;
        if (shift) shiftpeed = 3;
       
        //Forwards Movement
        if (movementAxis.z > 0 || movementAxis.y != 0)
        {
            DragoTransform.position = Vector3.Lerp(DragoTransform.position, DragoTransform.position + DragoTransform.forward * UnderSpeed * shiftpeed * Mathf.Max(movementAxis.z, Mathf.Abs(movementAxis.y)) / 2, Time.fixedDeltaTime) ;
        }
        //Rotation left/right

        transform.RotateAround(DragoTransform.position, Vector3.up, UnderTurn * movementAxis.x * Time.fixedDeltaTime * 50f);

        if ((Vector3.Angle(transform.forward, Vector3.up) > 30 && jump) || (Vector3.Angle(transform.forward, Vector3.up) < 170 && down) || UpDownAxis) //Limit Up Down Axis
        {
            transform.RotateAround( DragoTransform.position,transform.right, 2 * -movementAxis.y * Time.fixedDeltaTime * 50);
        }

        if (!jump && !down)
        {
            movementAxis.y = Mathf.Lerp(movementAxis.y, 0, Time.fixedDeltaTime * 2);
        }

        //To Get Out of the Water---------------------------------
        RaycastHit UnderWaterHit;

        if (Physics.Raycast(pivots[2].transform.position, -Vector3.up, out UnderWaterHit, scaleFactor * 1, LayerMask.GetMask("Water")))
        {
            Debug.DrawRay(pivots[2].transform.position, -Vector3.up * scaleFactor * 1, Color.blue);
            if (!down)
            {
                underWater = false;
                anim.applyRootMotion = true;
                dragoRigidBody.drag = 0;
            }
        }
    }

    public virtual void ActionEmotion(int ID)
    {
        actionID = ID;
    }

    public virtual void YAxisMovement(float v)
    {
        if (jump)
        {
            movementAxis.y = Mathf.Lerp(movementAxis.y, 1, Time.deltaTime * v);
        }
        else if (down)
        {
            movementAxis.y = Mathf.Lerp(movementAxis.y, -1, Time.deltaTime * v);
        }
        else
        {
            movementAxis.y = Mathf.Lerp(movementAxis.y, 0, Time.deltaTime * v);
        }
    }

    public virtual void Grounded()
    {
        RaycastHit hitGrounded;

        if (Physics.Raycast(pivots[1].transform.position, -DragoTransform.up, out hitGrounded, dragoHeight * 1.1f * scaleFactor, GroundLayer))
        {
            Debug.DrawRay(pivots[1].transform.position, -DragoTransform.up * dragoHeight * scaleFactor, Color.blue);
            if (isJumping(0.5f, true))
            {
                grounded = false;
            }
            else
            {
                grounded = true;
            }
        }
        else
        {
            grounded = false;
        }
    }

    //--------------------------------------------------------------------Check if the in the Jumping State-------------------------------------------------------------------------------------
    //***------------------------------------------ this will return false if is not in the Jumping state or if is not in the desired half of the jump***------------------------------------------
    bool isJumping(float normalizedtime, bool half)
    {
        if (half)  //if is jumping the first half
        {

            if (anim.GetCurrentAnimatorStateInfo(0).IsTag("Jump"))
            {
                if (anim.GetCurrentAnimatorStateInfo(0).normalizedTime < normalizedtime)
                    return true;
            }

            if (anim.GetNextAnimatorStateInfo(0).IsTag("Jump"))  //if is transitioning to jump
            {
                if (anim.GetNextAnimatorStateInfo(0).normalizedTime < normalizedtime)
                    return true;
            }
        }
        else //if is jumping the second half
        {
            if (anim.GetCurrentAnimatorStateInfo(0).IsTag("Jump"))
            {
                if (anim.GetCurrentAnimatorStateInfo(0).normalizedTime > normalizedtime)
                    return true;
            }

            if (anim.GetNextAnimatorStateInfo(0).IsTag("Jump"))  //if is transitioning to jump
            {
                if (anim.GetNextAnimatorStateInfo(0).normalizedTime > normalizedtime)
                    return true;
            }
        }
        return false;
    }
    bool isJumping()
    {
        if (anim.GetCurrentAnimatorStateInfo(0).IsTag("Jump"))
        {
            return true;
        }
        if (anim.GetNextAnimatorStateInfo(0).IsTag("Jump"))
        {
            return true;
        }
        return false;
    }

    //--------------------------------------------------------------------------------------------------------------------------
    void FixedUpdate()
    {
        if (!underWater)
        {
            FixPosition();
            Falling();
            Swimming();
        }
        else
        {
            UnderWaterMovement();
        }
    }

    void Update()
    {
        Grounded();
        TurnAmount();
        SpeedAmount();

        ////If CameraInput Mode is Activated
        //if (cameraMove)
        //{
        //    movementAxis.z = forwardAmount;
        //    movementAxis.x = turnAmount;

        //    //More Rotation While aiming with the camera
        //    if (!underWater && anim.GetCurrentAnimatorStateInfo(0).IsTag("Locomotion") || anim.GetCurrentAnimatorStateInfo(0).IsTag("Fly"))
        //    {
        //        transform.Rotate(Vector3.up, movementAxis.x * Time.deltaTime * 150);
        //    }
        //}


        //Check if the Dragon is Stand
        if ((movementAxis.x != 0) || (movementAxis.z != 0) || Tired >= GotoSleep)
            stand = false;
        else stand = true;

        //Change velocity on ground
        if (!fly && !swim)
        {  
            if (speed1) groundSpeed = 1f;
            if (speed2) groundSpeed = 2f;
            if (speed3) groundSpeed = 3f;
        }
        else if (fly)
        {
            if (speed1) flyspeedanimator = flyAnimationSpeed;
            if (speed2) flyspeedanimator = flyAnimationSpeed + 0.25f;
            if (speed3) flyspeedanimator = flyAnimationSpeed + 0.35f;
        }
       
        int shiftSpeed = 1;

        float directionmult = 1; // for Strafe in air in horizontal 
       
        //Shift Key Changes Fly mode    
        if (shift)
        {
           shiftSpeed = 2;
            
            if (fly)
            {
                directionmult = 2; //changue in the animator fly blendtree to horizontal :2f: that stores the strafe animation while flying
                DragoFloat = Mathf.Lerp(DragoFloat, 1, Time.deltaTime * 5f); // .... Press Shift input to Glide
            }
        }
        else
        {
            if (fly)
                DragoFloat = Mathf.Lerp(DragoFloat, 0, Time.deltaTime * 5f); //Glide off
        }

        float maxspeed = groundSpeed;

        if (swim) maxspeed =1;

        speed = Mathf.Lerp(speed, maxspeed * shiftSpeed, Time.deltaTime * 2f);            //smoothly transitions bettwen velocities


        direction = Mathf.Lerp(direction, movementAxis.x * directionmult, Time.deltaTime * 8f);    //smoothly transitions bettwen directions

        if (fly)
            YAxisMovement(2f); //--------------------Controls the Fly Movement Up and Down

        if (jump || attack2 || damage || stun) stand = false; //Stand False when doing some action

        //Fly close to the ground;
        if (grounded) fly = false;

        //Reset Sleep
        if (!stand || attack1 || attack2 || jump || shift || swim || fly) Tired = 0;

        if (!swim && !fly) movementAxis.y = 0;

        LinkingAnimator(anim);
    }
}

