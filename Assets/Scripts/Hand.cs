using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class Hand : MonoBehaviour
{
    public static Action<Rigidbody> onGrab;
    private Rigidbody rb;
    private bool canGrab = true;
    private Collider grabedObject;

    private void Awake()
    {
        rb = this.GetComponent<Rigidbody>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (canGrab)
        {
            Debug.Log(transform.parent.name + " grabed " + other.name + " with there " + this.name);
            onGrab(rb);
            canGrab = false;
            grabedObject = other;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (grabedObject == other)
            canGrab = true;
    }
}