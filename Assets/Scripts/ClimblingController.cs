using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClimblingController : MonoBehaviour
{
    [SerializeField] private Rigidbody body, rightHand, leftHand;
    public static Action<Rigidbody> onGrab;

    // Start is called before the first frame update
    private void Awake()
    {
        body.isKinematic = true;
        Hand.onGrab += (name, hand) => Grab(name, hand);
    }

    private void Grab(string name, Rigidbody hand)
    {
        if (name == this.transform.name)
        {
            body.isKinematic = false;
            hand.isKinematic = true;
            if (hand != rightHand) rightHand.isKinematic = false;
            else leftHand.isKinematic = false;
        }
    }
}