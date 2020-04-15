using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PixelGrouper {

    private QRHandler main;
    private Filter filter;
    private Transform map;

    private Dictionary<Vector2, Pixel> pixelMap;
    private List<PixelSquare> pixelSquares;

    private List<QRSquare> qrSquares = new List<QRSquare>();

    public PixelGrouper(QRHandler main, Dictionary<Vector2, Pixel> pixelMap, Filter filter, Transform map) {
        this.main = main;
        this.filter = filter;
        this.pixelMap = pixelMap;
        this.pixelSquares = new List<PixelSquare>();
        this.map = map;

        GenerateSquares();
        main.QRDimensionBridge = new QRDimensionBridge(main, this);
    }

    private void GenerateSquares() {
        foreach(Pixel pixel in pixelMap.Values) {
            bool colided = false;

            foreach(PixelSquare pixelSquare in pixelSquares) {
                if(pixelSquare.colided(pixel.Position))
                    colided = true;
            }

            if(!colided) {
                GetSquareFromStart(pixel);
            }
        }
    }

    private void GetSquareFromStart(Pixel startPixel) {
        PixelSquare pixelSquare = new PixelSquare(new Dictionary<Vector2, Pixel>());
        startPixel.GetConnectedPixels(this, pixelSquare);
        pixelSquares.Add(pixelSquare);

        qrSquares.Add(main.GetQRSquare(pixelSquare));
    }

    //Properties
    public Dictionary<Vector2, Pixel> PixelMap { get { return pixelMap; } }

    public QRSquare[] QRSquares() {
        QRSquare[] qrList = new QRSquare[this.qrSquares.Count];
        for(int i = 0; i < qrList.Length; i++) {
            qrList[i] = this.qrSquares[i];
        }

        return qrList;
    }
}
