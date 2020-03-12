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

    [SerializeField] private Joints transformJoints, rigidbodyJoints;
    private Quaternion LA0, LA1, RA0, RA1, LL0, LL1, RL0, RL1;

    // Update is called once per frame
    void Update()
    {
        LA0 = GetJointRotation(transformJoints.leftArm0);
        LA1 = GetJointRotation(transformJoints.leftArm1);
        RA0 = GetJointRotation(transformJoints.rightArm0);
        RA1 = GetJointRotation(transformJoints.rightArm1);
        LL0 = GetJointRotation(transformJoints.leftLeg0);
        LL1 = GetJointRotation(transformJoints.leftLeg1);
        RL0 = GetJointRotation(transformJoints.rightLeg0);
        RL1 = GetJointRotation(transformJoints.rightLeg1);

        transformJoints.leftArm0.targetRotation = GetJointRotation(transformJoints.leftArm0);
        transformJoints.leftArm1.targetRotation = LA1;
        transformJoints.rightArm0.targetRotation = RA0;
        transformJoints.rightArm1.targetRotation = RA1;
        transformJoints.leftLeg0.targetRotation = LL0;
        transformJoints.leftLeg1.targetRotation = LL1;
        transformJoints.rightLeg0.targetRotation = RL0;
        transformJoints.rightLeg1.targetRotation = RL1;
    }

    private Quaternion GetJointRotation(ConfigurableJoint joint)
    {
        return (Quaternion.FromToRotation(joint.axis, joint.connectedBody.transform.rotation.eulerAngles));
    }
}
