using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightController : MonoBehaviour
{
    public Light light1;
    private void OnMouseDown()
    {
        print("Mouse Down");
        if(light1.enabled == false)
        light1.enabled = true;
        else
        light1.enabled = false;
        }

}
