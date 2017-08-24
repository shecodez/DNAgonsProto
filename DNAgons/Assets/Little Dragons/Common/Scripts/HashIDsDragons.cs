using UnityEngine;

public class HashIDsDragons : MonoBehaviour
{

    [HideInInspector]    public static int verticalHash = Animator.StringToHash("Vertical");
    [HideInInspector]    public static int horizontalHash = Animator.StringToHash("Horizontal");
    [HideInInspector]    public static int updownHash = Animator.StringToHash("UpDown");

    [HideInInspector]    public static int standHash = Animator.StringToHash("Stand");

    [HideInInspector]    public static int jumpHash = Animator.StringToHash("Jump");
    [HideInInspector]    public static int flyHash = Animator.StringToHash("Fly");
    [HideInInspector]    public static int dodgeHash = Animator.StringToHash("Dodge") ;
    [HideInInspector]    public static int fallHash = Animator.StringToHash("Fall");
    [HideInInspector]    public static int groundedHash = Animator.StringToHash("Grounded");
    [HideInInspector]    public static int shiftHash = Animator.StringToHash("Shift");
    [HideInInspector]    public static int flySpeedHash = Animator.StringToHash("FlySpeed");

    [HideInInspector]    public static int attack1Hash = Animator.StringToHash("Attack1");
    [HideInInspector]    public static int attack2Hash = Animator.StringToHash("Attack2");
    [HideInInspector]    public static int deathHash = Animator.StringToHash("Death");
    
    [HideInInspector]    public static int injuredHash = Animator.StringToHash("Damaged");
    [HideInInspector]    public static int stunnedHash = Animator.StringToHash("Stunned");

    [HideInInspector]    public static int intDragonHash = Animator.StringToHash("DragoInt");
    [HideInInspector]    public static int floatDragonHash = Animator.StringToHash("DragoFloat");
    [HideInInspector]    public static int swimHash = Animator.StringToHash("Swim");
    [HideInInspector]    public static int underWaterHash = Animator.StringToHash("Underwater");
    [HideInInspector]    public static int action = Animator.StringToHash("Action");
    [HideInInspector]    public static int actionID = Animator.StringToHash("ActionID");



}

