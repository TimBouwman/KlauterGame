using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClimblingController : MonoBehaviour
{
    [SerializeField] private Rigidbody body, rightHand, leftHand;
    [SerializeField] private float radius;
    [SerializeField] private LayerMask layer;
    public static Action<Rigidbody> onGrab;

    // Start is called before the first frame update
    private void Awake()
    {
        body.isKinematic = true;
        Hand.onGrab += (hand) => Grab(hand);
    }

    private void Grab(Rigidbody hand)
    {
        body.isKinematic = false;
        hand.isKinematic = true;
        if (hand != rightHand) rightHand.isKinematic = false;
        else leftHand.isKinematic = false;
    }
}