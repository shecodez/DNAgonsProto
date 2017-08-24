using System;

public class SaveData
{
    public int brokenScales = 0;
    public int intactScales = 0;

    // IDs correspond to a 0-based binary struct
    public int itemBought_01_32 = 0;

    public int totalItemsPlaced = 0;
    public int itemsPlacedMaxCapacity = 10;
    public int itemPlaced_01_32 = 0;
    /*public Dictionary<int, Transform> itemLocation 
        = new Dictionary<int, Transform>();*/

    public int DNAgonGenotypesKnown_Gen1 = 0;
    public int DNAgonGenotypesVisited_Gen1 = 0;
    public int totalDNAgonsCaptured_Gen1 = 0;

    // This will need to be moved to server for production
    public DateTime TimeOnExit = DateTime.Now; //.MinValue
}
