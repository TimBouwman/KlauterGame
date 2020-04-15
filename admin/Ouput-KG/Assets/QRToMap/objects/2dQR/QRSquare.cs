using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QRSquare {

    private Transform map;
    private QRCode qrCode;
    private Vector3 center;
    private List<Vector2> corners;

    private float worldPointSize = 0;

    public QRSquare(Transform map, List<Vector2> corners) {
        this.map = map;
        this.corners = corners;

        FilterCorners();
    }
    
    public List<Vector3> GetScreenCorners() {
        List<Vector3> worldPointCorners = new List<Vector3>();

        Bounds bounds = map.gameObject.GetComponent<Renderer>().bounds;
        float width = map.gameObject.GetComponent<Renderer>().material.mainTexture.width;
        float height = map.gameObject.GetComponent<Renderer>().material.mainTexture.height;

        foreach(Vector2 corner in corners) {
            Vector3 worldPointCorner = new Vector3(0, 0);

            worldPointCorner.x = bounds.min.x + (bounds.size.x / width) * corner.x;
            worldPointCorner.z = bounds.min.z + (bounds.size.z / height) * corner.y;

            worldPointCorners.Add(-worldPointCorner);
        }

        return worldPointCorners;
    }

    public Vector3 GetScreenSquareCenter() {
        Vector3 worldPointCenter = new Vector3(0, 0);

        Bounds bounds = map.gameObject.GetComponent<Renderer>().bounds;
        float width = map.gameObject.GetComponent<Renderer>().material.mainTexture.width;
        float height = map.gameObject.GetComponent<Renderer>().material.mainTexture.height;

        worldPointCenter.x = bounds.min.x + (bounds.size.x / width) * center.x;
        worldPointCenter.z = bounds.min.z + (bounds.size.z / height) * center.z;

        return -worldPointCenter;
    }

    private void GetWorldPointSize() {
        List<Vector3> worldPointCorners = GetScreenCorners();

        for(int i = 0; i < worldPointCorners.Count; i++) {
            for(int j = i; j < worldPointCorners.Count; j++) {

                float distance = Vector3.Distance(worldPointCorners[i], worldPointCorners[j]);

                if(distance > this.worldPointSize)
                    this.worldPointSize = distance;

            }
        }
    }

    /*
     * Since we only need 4 corners we'll need to filter 
     * them from a possibly bigger list.
     * We do this by checking for the biggest and smallest x and y coords
     */
    private void FilterCorners() {
        /* tL = top left
         * bL = bottom left
         * 
         * Doing this instead of an array to make it more readable :)
         */

        List<Vector2> newCorners = new List<Vector2>();

        Vector2 center = GetCenter();

        while(newCorners.Count < 4 && corners.Count > 0) {
            Vector2 newCorner = center;
            float currentBestCombinedDistance = 0f;

            foreach(Vector2 corner in corners) {
                float combinedDistance = GetCombinedDistance(center, newCorners, corner);

                if(combinedDistance > currentBestCombinedDistance) {

                    currentBestCombinedDistance = combinedDistance;
                    newCorner = corner;

                }
            }

            corners.Remove(newCorner);
            newCorners.Add(newCorner);
        }

        //Also translate the width and height to world width and height
        GetWorldPointSize();

        center = new Vector2(0, 0);
        foreach(Vector2 corner in newCorners) {
            center += corner * 0.25f;
        }

        this.center = new Vector3(center.x, 0, center.y);
        this.corners = newCorners;
    }

    private float GetCombinedDistance(Vector2 center, List<Vector2> vectors, Vector2 compare) {
        float distance = Vector2.Distance(center, compare);
        foreach(Vector2 vector in vectors)
            distance += Vector2.Distance(vector, compare);

        return distance;
    }

    private Vector2 GetCenter() {
        Vector2 top = corners[0];
        Vector2 bottom = corners[0];

        foreach(Vector2 corner in corners) {
            if(Vector2.Distance(corner, top) > Vector2.Distance(bottom, top))
                bottom = corner;
        }

        return top + new Vector2(0, Vector2.Distance(bottom, top) / 2);
    }

    /*
    private void Debug() {
        string debug = "QRSquare: \n";

        foreach(Vector3 corner in GetScreenCorners()) {
            debug += corner.x + " " + corner.y + "\n";
            debugObjects.Add(MonoBehaviour.Instantiate(Resources.Load("test"), corner, map.rotation, null));
        }

        debugObjects.Add(MonoBehaviour.Instantiate(Resources.Load("test"), GetScreenSquareCenter(), map.rotation, null));
        debug += "center: " + GetScreenSquareCenter().x + " " + GetScreenSquareCenter().y + "\n";

        //MonoBehaviour.print(debug + "\n " + corners.Count);
    }
    */
    
    //Properties
    public QRCode QRCode { 
        get { return qrCode; }
        set { this.qrCode = value; }
    }

    public float WorldPointSize {
        get { return this.worldPointSize; }
    }

}
