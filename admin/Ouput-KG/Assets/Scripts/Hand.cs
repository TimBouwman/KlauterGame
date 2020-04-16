using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Rigidbody))]
[RequireComponent(typeof(Collider))]
public class Hand : MonoBehaviour
{
    [SerializeField] private Image coolDownIcon;
    [SerializeField] private float gripTime;
    private float currentGripTime;
    private Camera camera;
    public static Action<String ,Rigidbody> onGrab;
    private Rigidbody rb;
    private bool canGrab = true;
    private Collider grabedObject;

    private void Awake()
    {
        rb = this.GetComponent<Rigidbody>();
        currentGripTime = gripTime;
        camera = Camera.main;
    }

    private void Update()
    {
        GripCountDown();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (canGrab)
        {
            Debug.Log(transform.parent.name + " grabed " + other.name + " with there " + this.name);
            onGrab(transform.parent.name, rb);
            canGrab = false;
            grabedObject = other;
            currentGripTime = gripTime;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (grabedObject == other)
            canGrab = true;
    }

    private void GripCountDown()
    {
        if (currentGripTime < 0 && !canGrab) rb.isKinematic = false;
        else if (!canGrab) currentGripTime -= Time.deltaTime;
        else if (currentGripTime < gripTime) currentGripTime += Time.deltaTime;
        else currentGripTime = gripTime;

        coolDownIcon.fillAmount = currentGripTime / gripTime;
    }
}