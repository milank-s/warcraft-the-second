using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraControls : MonoBehaviour {

  //  public Transform target;
     Camera cam;
    float height = Screen.height;
    float width = Screen.width;
    void Start()
    {
       
        cam = GetComponent<Camera>();
    }

    void Update()
    {
        Debug.Log("Height: " + height + "\n Width: " + width);
        Vector3 screenPos = cam.WorldToScreenPoint(Input.mousePosition);
        Debug.Log("ScreenPos X: " + screenPos.x + "\n ScreenPos Y: "+ screenPos.x+ "    ScreenPos Z: " + screenPos.z);
    }
}
