using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor.Networking.PlayerConnection;
using UnityEngine;

public class EventManager : MonoBehaviour
{
    public static EventManager current;

    private void Awake()
    {
        current = this;
    }

    /** Door events. */
    public event Action<int> onDoorEnter;
    public void DoorEnter(int id)
    {
        if (onDoorEnter != null)
        {
            onDoorEnter(id);
        }
    }
    
    public event Action<int> onDoorExit;
    public void DoorExit(int id)
    {
        if (onDoorExit != null)
        {
            onDoorExit(id);
        }
    }

    /** Player events. */
    // public event Action onPlayerGrounded;
    // public void IsGrounded()
    // {
    //     onPlayerGrounded();
    // }
    
    // public event Action onPlayerAirbourne;
    // public void IsAirborne()
    // {
    //     onPlayerAirbourne();
    // }
}
