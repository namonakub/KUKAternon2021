using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorController : MonoBehaviour
{
    public bool doorOpen = false;
    Animator animator;
    public GameObject door;

    private void Start()
    {
        animator = GetComponent<Animator>();
    }

    void Update()
    {
        //animator.SetBool("DoorOpen", doorOpen);
        door.SetActive(!doorOpen);
    }
}
