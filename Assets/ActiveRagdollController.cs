using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActiveRagdollController : MonoBehaviour
{
    [SerializeField] private AppendagePositionReader positionReader;
    [SerializeField] private Transform[] appendageIndexes;

    // Update is called once per frame
    void Update()
    {
        for (int i = 0; i < appendageIndexes.Length; i++)
        {
            appendageIndexes[i].localPosition = positionReader.AppendagePositions[i];
        }
    }
}