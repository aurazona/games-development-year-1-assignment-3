using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class inputHandler : MonoBehaviour
{
    Camera cam;
    public static bool inputsAllowed = true; //used to disable interaction for stuff like entering a wrong code
    // Start is called before the first frame update
    void Start()
    {
        cam = GameObject.FindGameObjectWithTag("MainCamera").GetComponent<Camera>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0) && inputsAllowed == true)
        { // if left button pressed...
            Ray ray = cam.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;
            if (Physics.Raycast(ray, out hit))
            {
                Debug.Log($"Raycast hit {hit.transform.name}");
                if (hit.transform.CompareTag("numpadButton"))
                {
                    Debug.Log($"Hit a numpadButton: {hit.transform.name}");
                    if(hit.transform.name.StartsWith("lock"))
                    {
                        Lockscreen.currentPass = Lockscreen.currentPass + hit.transform.name.ToString().Replace("lock", "");
                        Debug.Log($"Hit lock {hit.transform.name.ToString().Replace("lock", "")}");
                    }
                    else
                    {
                        Lockscreen.currentPass = Lockscreen.currentPass + hit.transform.name.ToString();
                    }
                }
                else
                {
                    Debug.LogError($"Didn't pick up a button! What it actually hit: {hit.transform.name}");
                }
            }
        }
    }
}
