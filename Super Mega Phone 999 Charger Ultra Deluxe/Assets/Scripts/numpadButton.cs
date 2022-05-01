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
                Debug.Log($"Raycast hit {hit.transform.name}");
                if(hit.transform.name == buttonNumber.ToString())
                {
                    Debug.Log(buttonNumber);
                    Lockscreen.currentPass = Lockscreen.currentPass + buttonNumber.ToString();
                }
                else
                {
                    Debug.LogError($"Didn't pick up a button! What it actually hit: {hit.transform.name}");
                }
            }
        }
    }

    /*private void OnMouseDown()
    {
        Debug.Log(buttonNumber);
        Destroy(self);
    }*/
}
