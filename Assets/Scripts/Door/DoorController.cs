using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class DoorController : MonoBehaviour
{
    public int id;
    private void Start()
    {
        EventManager.current.onDoorEnter += onOpenDoor;
        EventManager.current.onDoorExit += onCloseDoor;
    }

    void onOpenDoor(int id)
    {
        if (id == this.id)
        {
        transform.position = new Vector3(transform.position.x, transform.position.y + 5, transform.position.z);
        }
    }
    
    void onCloseDoor(int id)
    {
        if (id == this.id)
        {
            transform.position = new Vector3(transform.position.x, transform.position.y - 5, transform.position.z);
        }
    }

    private void OnDestroy()
    {
        EventManager.current.onDoorEnter -= onOpenDoor;
        EventManager.current.onDoorExit -= onCloseDoor;
    }
}
