using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QRSkeleton : MonoBehaviour {

    [SerializeField] private QRSkeletonSquare topRight;
    [SerializeField] private QRSkeletonSquare bottomRight;
    [SerializeField] private QRSkeletonSquare bottomLeft;

    private float avarageSize;
    private float squareDistance;

    public void Init() {

        topRight.Init();
        bottomRight.Init();
        bottomLeft.Init();

        //Get the avarage square distance
        squareDistance = (Vector3.Distance(topRight.Center, bottomRight.Center) +
                          Vector3.Distance(bottomLeft.Center, bottomRight.Center)) / 2;

        avarageSize = (topRight.Size + bottomRight.Size + bottomLeft.Size) / 3;
    }

    public float GetSquareDistanceFromSize(float size) {
        return (squareDistance / (1+avarageSize)) * (1+size);
    }

}
