using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class numpadButton : MonoBehaviour
{
    public GameObject self;
    public int buttonNumber;
    Camera cam;
    // Start is called before the first frame update
    void Start()
    {
        cam = GameObject.FindGameObjectWithTag("MainCamera").GetComponent<Camera>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        { // if left button pressed...
            Ray ray = cam.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;
            if (Physics.Raycast(ray, out hit))
            {
                Debug.Log(buttonNumber);
                //commented out for now, but below is the logic for actually adding numbers to the passcode
                //Lockscreen.currentPass = Lockscreen.currentPass + buttonNumber.ToString();
            }
        }
    }

    /*private void OnMouseDown()
    {
        Debug.Log(buttonNumber);
        Destroy(self);
    }*/
}
