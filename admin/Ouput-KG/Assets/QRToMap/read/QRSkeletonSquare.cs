using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QRSkeletonSquare : MonoBehaviour {

    [SerializeField] private List<Transform> cornerTransforms;
    private List<Vector2> corners = new List<Vector2>();
    private float size;

    private Vector3 center = new Vector2(0.5f, 0.5f);

    public void Init() {
        //First convert transforms into vectors
        foreach(Transform transform in cornerTransforms) {
            if(transform != null)
                corners.Add(transform.position);
        }

        for(int i = 0; i < corners.Count; i++) {
            for(int j = i; j < corners.Count; j++) {

                float distance = Vector3.Distance(corners[i], corners[j]);

                if(distance > this.size)
                    this.size = distance;
            }
        }

        Vector2 top = corners[0];
        Vector2 bottom = corners[0];

        foreach(Vector2 corner in corners) {
            if(Vector2.Distance(corner, top) > Vector2.Distance(bottom, top))
                bottom = corner;
        }

        this.center = top + new Vector2(0, Vector2.Distance(bottom, top) / 2);
    }

    public float Size { get { return this.size; } }

    public Vector3 Center { get { return this.center; } }
}
