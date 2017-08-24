using UnityEngine;


public partial class DragonController
{
    #region Variables 

    public enum DragoType
    {
        Tiger = 0, Mouse = 1, Sea = 2, Coming_Soon = 3
    }
    public enum Ground
    {
        walk = 1, trot = 2, run = 3
    }
    public enum ActionsEmotions //Every Int value represents the IDAction on the Animator
    {
        Dig = 1,
        Eat = 2,
        Pet = 3,
        LevelUp = 4,
        Talk = 5,
        Sleep = 6,
        Happy = 101,
        Sad = 102,
        Angry = 103,
        Scared = 104,
        Sneeze = 105,
        Confuse = 106
    }

    #region Drago Components 
    private Animator anim;
    private Transform DragoTransform;
    private Rigidbody dragoRigidBody;
    private CapsuleCollider dragoCollider;
    #endregion

    #region Animator Parameters Variables
    private bool
        speed1,
        speed2,
        speed3,
        jump,
        shift,
        down,
        damage,
        fly,
        dodge,
        fall,
        death,
        swim, isInWater, underWater,
        grounded,
        attack1,
        attack2,
        stun,
        action,
        stand = true;

    private float
        jumpPoint,
        dragoFloat,
        speed,
        direction,
        groundSpeed = 1f,
        flyspeedanimator,
        waterlevel,
        dragoHeight;

    private int
        dragoInt = 1,
        actionID = -1,
        tired;

    protected Vector3 movementAxis;
    #endregion

    #region Inspector Entries
    public DragoType DragonType = DragoType.Tiger;
    [Tooltip("Activate Camera Y Axis also while flying and underwater swimming")]
    public bool UpDownAxis;

    [Header("Ground")]

    [Tooltip("Specify wich layer is the ground")]
    public LayerMask GroundLayer;
    public Ground StartSpeed;
    [Space]
    [Tooltip("Add Walk Speed greater than 1 the dragon will Slide")]
    public float WalkSpeed = 1f;
    [Tooltip("Add Trot Speed greater than 1 the dragon will Slide")]
    public float TrotSpeed = 1f;
    [Tooltip("Add Run Speed greater than 1 the dragon will Slide")]
    public float RunSpeed = 1f;
    [Space]
    [Tooltip("Add Turn Speed .... Zero will rotate with the default animation rotation")]
    public float TurnSpeed = 0f;
    [Space]
    [Space]
    public int GotoSleep;


    [Header("Air")]
    public float flySpeed = 1f;
    public float flyTurn = 0f;
    [Range(0.2f, 1f)]
    public float flyAnimationSpeed = 1;


    [Header("Water")]

    [Tooltip("Water Level for the dragon to Swim on the water")]
    public float waterLine = 0f;
    public float swimSpeed = 1f;
    public float swimTurn = 0f;

    [Header("Underwater")]
    public float UnderSpeed = 1f;
    public float UnderTurn = 0f;
    #endregion

    [Header("Water")]

    #region Modify_the_Position_Variables
    RaycastHit hit_Hip, hit_Chest;
    Vector3 Drago_Hip, Drago_Chest;
    float
        turnAmount,
        forwardAmount,
        scaleFactor,
        maxHeight;
    Pivots[] pivots;
    #endregion

    #region Properties

    public float JumpPoint
    {
        set { jumpPoint = value; }
        get { return this.jumpPoint; }
    }

    public float GroundSpeed
    {
        set { groundSpeed = value; }
        get { return this.groundSpeed; }
    }

    public float MaxHeight
    {
        set { maxHeight = value; }
        get { return this.maxHeight; }
    }

    public int DragoInt
    {
        set { dragoInt = value; }
        get { return this.dragoInt; }
    }

    public int Tired
    {
        set { tired = value; }
        get { return this.tired; }
    }

    public float DragoFloat
    {
        set { dragoFloat = value; }
        get { return this.dragoFloat; }
    }

    public bool IsInWater
    {
        set { isInWater = value; }
        get { return this.isInWater; }
    }

    public bool UnderWater
    {
        set { underWater = value; }
        get { return this.underWater; }
    }

    public bool Speed1
    {
        get { return speed1; }
        set { speed1 = value; }
    }

    public bool Speed2
    {
        get { return speed2; }
        set { speed2 = value; }
    }

    public bool Speed3
    {
        get { return speed3; }
        set { speed3 = value; }
    }

    public bool Jump
    {
        get { return jump; }
        set { jump = value; }
    }
    public bool Shift
    {
        get { return shift; }
        set { shift = value; }
    }
    public bool Down
    {
        get { return down; }
        set { down = value; }
    }

    public bool Damaged
    {
        get { return damage; }
        set { damage = value; }
    }
    public bool Fly
    {
        get { return fly; }
        set
        {
            if (value) fly = !fly; //Toogle Fly
        }
    }
    public bool Dodge
    {
        get { return dodge; }
        set { dodge = value; }
    }
    public bool Death
    {
        get { return death; }
        set { death = value; }
    }

    public bool Attack1
    {
        get { return attack1; }
        set { attack1 = value; }
    }
    public bool Attack2
    {
        get { return attack2; }
        set { attack2 = value; }
    }

    public bool Stun
    {
        get { return stun; }
        set { stun = value; }
    }

    public bool Action
    {
        get { return action; }
        set { action = value; }
    }

    public int ActionID
    {
        get { return actionID; }
        set { actionID = value; }
    }

    public Vector3 MovementAxis
    {
        get { return movementAxis; }
        set { movementAxis = value; }
    }

    #endregion

    #endregion
}

