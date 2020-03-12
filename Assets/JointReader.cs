using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JointReader : MonoBehaviour
{
    [System.Serializable]
    public class Joints
    {
        public ConfigurableJoint leftArm0, leftArm1, rightArm0, rightArm1, leftLeg0, leftLeg1, rightLeg0, rightLeg1;
    }

    [SerializeField] private Joints joints;
    private Quaternion LA0, LA1, RA0, RA1, LL0, LL1, RL0, RL1;

    // Update is called once per frame
    void Update()
    {
        
    }

    public Quaternion getJointRotation(ConfigurableJoint joint)
    {
        return (Quaternion.FromToRotation(joint.axis, joint.connectedBody.transform.rotation.eulerAngles));
    }
}
