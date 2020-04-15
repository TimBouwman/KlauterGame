using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QRCode {

    private QRDimensionBridge main;
    private PixelGrouper pixelGrouper;
    private List<QRSquare> squares;
    private Vector3 position;
    private float size;

    public QRCode(QRDimensionBridge main, PixelGrouper pixelGrouper, QRSquare square) {
        this.main = main;
        this.pixelGrouper = pixelGrouper;

        this.squares = new List<QRSquare>();
        this.squares.Add(square);
    }

    public void ScanSurrounding(QRSquare square, QRSkeleton qRSkeleton) {
        float distance = qRSkeleton.GetSquareDistanceFromSize(square.WorldPointSize);
        float lienance = distance * 2;
        //if(!Debug.locations.ContainsKey(square.GetScreenSquareCenter()))
            //Debug.locations.Add(square.GetScreenSquareCenter(), distance + lienance);

        foreach(QRSquare qrSquare in this.pixelGrouper.QRSquares()) {
            if(qrSquare.QRCode != null)
                continue;

            float currentDistance = Vector3.Distance(qrSquare.GetScreenSquareCenter(), square.GetScreenSquareCenter());

            if(currentDistance >= distance - lienance && currentDistance <= distance + lienance) {
                qrSquare.QRCode = this;
                squares.Add(qrSquare);

                if(distance + lienance > size)
                    size = distance + lienance;

                Vector3 top = squares[0].GetScreenSquareCenter();
                Vector3 bottom = squares[0].GetScreenSquareCenter();

                foreach(QRSquare corner in squares) {
                    if(Vector2.Distance(corner.GetScreenSquareCenter(), top) > Vector3.Distance(bottom, top))
                        bottom = corner.GetScreenSquareCenter();
                }

                this.position = top + new Vector3(0, 0, Vector3.Distance(bottom, top) / 2);
            }
        }
    }

    public List<QRSquare> QRSquares {
        get { return this.squares; }
    }

    public Vector3 Position { get { return position; } }

    public float Size { get { return this.size; } }
}
