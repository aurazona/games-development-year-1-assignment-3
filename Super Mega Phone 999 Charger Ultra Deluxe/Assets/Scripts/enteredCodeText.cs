using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class enteredCodeText : MonoBehaviour
{

    public static Text txt; //controls what is shown on the code note
    // Start is called before the first frame update
    void Start()
    {
        txt = GameObject.Find("Entered Code").GetComponent<Text>();
    }

    // Update is called once per frame
    void Update()
    {
        txt.text = Lockscreen.currentPass;
    }
}
