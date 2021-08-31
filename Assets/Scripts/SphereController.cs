using System;
using System.Collections;
using System.Collections.Generic;
using Cinemachine;
using Unity.VisualScripting;
using UnityEngine;

public class SphereController : MonoBehaviour
{
    public Transform player;
    public int speed = 12;
    
    private Material m;

    private void Start()
    {
        m = GetComponent<Renderer>().material;
    }

    private void Update()
    {
        Vector3 displacement = player.position - transform.position;
        Vector3 dir = displacement.normalized;
        Vector3 velocity = dir * speed;
        float distance = displacement.magnitude;

        if (distance > 1.5f)
        {
            transform.Translate(velocity * Time.deltaTime);
        }
    }
}
