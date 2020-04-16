using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActiveRagdollController : MonoBehaviour {
    [SerializeField] private Rigidbody hips;
    [SerializeField] private ConfigurableJoint[] joints;

    // Update is called once per frame
    public void UpdateApandages(int id, Vector3 position) {
        joints[id].targetPosition = position;
        print(id + "updated");
    }
}