using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class TimeManager : MonoBehaviour {

    public static TimeManager Instance { get; private set; }

    public DateTime AppStartTime { get; private set; }

    //public static DateTime CurrentTime { get; private set; }

    void Awake() { Instance = this; }
	
	void Start ()
    {
        AppStartTime = DateTime.Now;
        GetTimeSinceApplicationQuit();
	}

    // ref: https://msdn.microsoft.com/en-us/library/system.datetime.ticks(v=vs.110).aspx
    public TimeSpan GetTimeSinceApplicationQuit ()
    {
        DateTime _appStoredTime = SaveManager.Instance.data.TimeOnExit;
        long _elapsedTicks = _appStoredTime.Ticks - AppStartTime.Ticks;

        return new TimeSpan(_elapsedTicks);
    }

    /*void Update ()
    {
        CurrentTime = DateTime.Now;
    }*/

    // **Note** that iOS applications are usually suspended and do not quit. 
    // Tick "Exit on Suspend" in Player settings for iOS builds to cause the game to quit and not suspend, otherwise you may not see this call. 
    // If "Exit on Suspend" is not ticked then you will see calls to OnApplicationPause instead.

    void OnApplicationQuit()
    {
        SaveManager.Instance.SetTimeOnExit();
        //Debug.Log("Application ending after " + Time.time + " seconds");
        Debug.Log("Sec since app Quit: " + GetTimeSinceApplicationQuit().Minutes);
    }
}
