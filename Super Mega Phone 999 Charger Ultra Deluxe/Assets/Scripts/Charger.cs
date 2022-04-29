using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = System.Random;


public class Charger : MonoBehaviour
{
    int Charge; //total phone charge, will be randomised upon initialisation
    Random rand = new Random();
    public static bool isCharging = false; //tells the phone to start charging, will be controlled by a dialer script.
    int policeMeter = 0; //counts up by one every frame, check callThePolice() for max count
    bool isFullCharge = false;
    public static bool hungUp = true; //tells the phone whether or not the call has been ended.

    // Start is called before the first frame update
    void Start()
    {
        Charge = rand.Next(0, 90); //randomise the charge between 0 and 90

    }

    // Update is called once per frame
    void Update()
    {
        if (isCharging == true)
        {
            chargeNow();
        }

        if (isFullCharge == true && hungUp == false)
        {
            callThePolice();
        }

        if (isFullCharge == true && hungUp == true)
        {
            clearPhone();
        }
    }

    void chargeNow()
    {
        if (Charge < 100)
        {
            Charge++;
        }
        if (Charge == 100)
        {
            isCharging = false;
            isFullCharge = true;
        }
    }

    void callThePolice()
    {
        if (policeMeter < 60)
        {
            policeMeter++;
        }
        if (policeMeter == 60)
        {
            //game over here
        }
    }

    void clearPhone()
    {
        //blah blah get rid of the phone here
    }
}
