using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActiveRagdollController : MonoBehaviour
{
    [SerializeField] private AppendagePositionReader positionReader;
    [SerializeField] private Rigidbody hips;
    [SerializeField] private ConfigurableJoint[] joints;

    // Update is called once per frame
    void FixedUpdate()
    {
        hips.transform.rotation = positionReader.HipsRotation;

        for (int i = 0; i < joints.Length; i++)
        {
            float x = positionReader.AppendagePositions[i].x;
            float y = positionReader.AppendagePositions[i].y;
            float z = positionReader.AppendagePositions[i].z;
            Vector3 pos = new Vector3(x, z, y);

            joints[i].targetPosition = pos;
        }
    }
}