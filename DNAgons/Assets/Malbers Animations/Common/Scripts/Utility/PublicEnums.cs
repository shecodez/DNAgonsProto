namespace MalbersAnimations
{
    public enum StateTransition
    {
        First = 0,
        Last = 1
    }

    public enum TypeMessage
    {
        Bool = 0,
        Int = 1,
        Float = 2,
        String = 3,
        Void = 4
    }

    public enum WeaponType 
    {
        None = 0,
        Melee = 1,
        Bow = 2,
        Pistol = 4,
        Rifle = 5
    }

    public enum WeaponHolder
    {
        None = 0,
        Left = 1,
        Right = 2,
        Back = 3
    }

    //Weapons Actions ... positive values are equal to the attacks
    public enum WeaponActions
    {
        None = 0,
        DrawFromRight = -1,
        DrawFromLeft = -2,
        StoreToRight = -3,
        Idle = -4,
        AimRight = -5,
        AimLeft = -6,
        StoreToLeft = -7,
        Reload  = -8,
        Equip = -100,
        Unequip = -101,

        //Positive Values are the Attack IDS
        //Attacks With Right Hand 
        Atk_RSide_RHand_Forward = 1,
        Atk_RSide_RHand_Backward = 2,
        Atk_LSide_RHand_Forward = 3,
        Atk_LSide_RHand_Backward = 4,

        //Attacks With Right Hand 
        Atk_RSide_LHand_Forward = 5,
        Atk_RSide_LHand_Backward = 6,
        Atk_LSide_LHand_Forward = 7,
        Atk_LSide_LHand_Backward = 8,

        //Ranged
        Fire_Proyectile = 9,
    }

    public enum MountSide
    {
        Left = 1,
        Right = 2,
        Back = 3,
        FrontRight = 4,
        FrontLeft = 5
    }
}