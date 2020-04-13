using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AppendagePositionReader : MonoBehaviour
{
    [SerializeField] private Transform hips, hipsIndex;
    [SerializeField] private Transform[] appendages, appendageIndexes;
    private Vector3[] appendagePositions; 
    public Vector3[] AppendagePositions { get { return this.appendagePositions; } }

    private void Start()
    {
        appendagePositions = new Vector3[appendages.Length];
    }

    private void Update()
    {
        hipsIndex.position = hips.position;

        for (int i = 0; i < appendages.Length; i++)
        {
            appendageIndexes[i].position = appendages[i].position;
            appendagePositions[i] = appendageIndexes[i].localPosition;
        }
    }
}