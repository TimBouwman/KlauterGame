using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class test : MonoBehaviour
{
    [SerializeField] private ConfigurableJoint joint;

    // Update is called once per frame
    void Update()
    {
        Debug.Log(getJointRotation(joint));
    }

    public Quaternion getJointRotation(ConfigurableJoint joint)
    {
        return (Quaternion.FromToRotation(joint.axis, joint.connectedBody.transform.rotation.eulerAngles));
    }
}
