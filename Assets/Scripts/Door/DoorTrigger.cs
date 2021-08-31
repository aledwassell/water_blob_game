using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorTrigger : MonoBehaviour
{
    public int id;
    private void OnTriggerEnter(Collider other)
    {
        print("Door enter");

        EventManager.current.DoorEnter(id);
    }

    private void OnTriggerExit(Collider other)
    {
        EventManager.current.DoorExit(id);
    }
}
