using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float speed = 1f;
    public float rotSpeed = 10f;
    float newRatY=0;
    void Update()
    {   
        float newX = transform.position.x; 
        float newY = transform.position.y; 
        float newZ = transform.position.z; 

        if(Input.GetKey(KeyCode.UpArrow))
        {
          newZ = transform.position.z-speed*Time.deltaTime;
          newRatY=0;
        }
        if(Input.GetKey(KeyCode.DownArrow))
        {
          newZ = transform.position.z+speed*Time.deltaTime;
          newRatY=180;
        }
        if(Input.GetKey(KeyCode.LeftArrow))
        {
          newX = transform.position.x+speed*Time.deltaTime;
          newRatY=-90;
        }
        if(Input.GetKey(KeyCode.RightArrow))
        {
          newX = transform.position.x-speed*Time.deltaTime;
          newRatY=90;
        }
        transform.position = new Vector3(newX,newY,newZ);
        transform.rotation = Quaternion.Lerp(Quaternion.Euler(0,newRatY,0),
        transform.rotation,
        rotSpeed * Time.deltaTime);
    }
    private void OnCollisionEnter(Collision collision)
    {
        print(collision.gameObject.name);
        if(collision.gameObject.name == "Sphere")
        {
            transform.localScale = new Vector3(2,2,2);
        }
        if(collision.gameObject.name == "Cube")
        {
            transform.localScale = new Vector3(1,1,1);
        }
    }
}
