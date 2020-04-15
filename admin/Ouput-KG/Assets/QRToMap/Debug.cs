using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace QRToMap {
    public class Debug : MonoBehaviour {

        public static Debug instance;

        public static Dictionary<Vector3, float> locations = new Dictionary<Vector3, float>();
        public GameObject plane;

        [SerializeField] private float lenience = 0.5f;

        private void Awake() {
            instance = this;
        }

        public void GenerateMap(List<Vector3> points) {
            MeshFilter mf = plane.GetComponent<MeshFilter>();
            Vector3[] vertices = mf.mesh.vertices;
            for (int i = 0; i < vertices.Length; i++) {
                vertices[i].y = -1;

                foreach (Vector3 point in points) {

                    if (Vector3.Distance(vertices[i], new Vector3(-point.x, vertices[i].y, -point.z)) < lenience) {

                        float xDiff = -point.x - vertices[i].x;
                        float zDiff = -point.z - vertices[i].z;

                        vertices[i].y = (Mathf.PerlinNoise((vertices[i].x + xDiff), (vertices[i].z + zDiff))) * point.y;

                        points.Remove(point);
                        break;
                    }

                }
            }

            mf.mesh.vertices = vertices;
            mf.mesh.RecalculateBounds();
            mf.mesh.RecalculateNormals();
        }

        private void OnDrawGizmos() {
            foreach (Vector3 loc in locations.Keys) {
                Gizmos.DrawWireSphere(loc, locations[loc]);
            }
        }
    }
}
