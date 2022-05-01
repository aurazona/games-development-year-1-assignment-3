using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = System.Random;

public class Lockscreen : MonoBehaviour
{
    Random rand = new Random(); //RNG for code generator & deciding which lock type to choose
    int lockChoice; //used with RNG to decide which lock type the phone uses.
    bool isFingerprint; //checks if the phone uses a fingerprint lock or not.
    public static int Passcode = 0; //Code is stored here 
    int codeGenSanity = 0; //used for code generator sanity check, if it don't get a valid passcode within 50 tries, default to fingerprint.
    public static string currentPass = ""; //used to store the player's passcode inputs.
    GameObject Numpad; //used to reference the numberpad for the code lock
    GameObject Fingerprint; //used to reference the fingerprint scanner
    public GameObject self; //used to get rid of the lockscreen
    // Start is called before the first frame update
    void Start()
    {
        Numpad = GameObject.FindGameObjectWithTag("Numpad");
        Fingerprint = GameObject.FindGameObjectWithTag("Fingerprint");

        lockChoice = rand.Next(0, 1); //chooses between 0 or 1, 0 is code lock, 1 is fingerprint lock.
        if (lockChoice == 0)
        {
            isFingerprint = false;
            Fingerprint.SetActive(false);
            generatePass();
        }
        else if (lockChoice == 1)
        {
            isFingerprint = true;
            Numpad.SetActive(false);
        }


    }

    // Update is called once per frame
    void Update()
    {
        if (isFingerprint == false)
        {
            passcodeCheck();
        }
        else if (isFingerprint == true)
        {
            //FingerprintLogic()
        }
    }

    void generatePass()
    {
        if (isFingerprint == false)
        {
            while (Passcode.ToString().Contains("0"))
            {
                if (!Passcode.ToString().Contains("0"))
                {
                    Debug.Log($"Valid passcode generated! Current code: {Passcode}");
                    Fingerprint.SetActive(false);
                    Numpad.SetActive(true);
                    break;
                }
                if (codeGenSanity == 50)
                {
                    Debug.Log($"Code generator failed sanity check! current code: {Passcode}");
                    isFingerprint = true;
                    break;
                }
                Passcode = rand.Next(1111, 9999); //chooses a number between 1111 and 9999
                Debug.Log($"Current code: {Passcode}"); //DEV STUFF, REMOVE BEFORE FINAL BUILD
                codeGenSanity++;
            }
        }
    }

    void passcodeCheck()
    {
        if (currentPass.Length >= 4) //if the passcode's maxed out
        {
            if (currentPass == Passcode.ToString()) //if the entered code is equal to the actual passcode
            {
                //play a sound or something to indicate the lockscreen has been unlocked
                Destroy(self);
            }
            else
            {
                Debug.Log($"Wrong code! Entered code: {currentPass}");
                currentPass = "";
            }
        }
    }
}
