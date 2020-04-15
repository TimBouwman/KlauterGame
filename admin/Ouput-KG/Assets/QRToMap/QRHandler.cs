using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QRHandler : MonoBehaviour {

    /// <summary>
    /// This class acts like the QR to map hub.
    /// It connects all the QR related stuff.
    /// </summary>

    [SerializeField] private QRSkeleton qrSkeleton;
    [SerializeField] private Filter filter;
    [SerializeField] private Transform map;

    private PixelGrouper pixelGrouper;
    private QRDimensionBridge qrDimensionBridge;

    private void Awake() {
        qrSkeleton.Init();
    }

    public QRSquare GetQRSquare(PixelSquare pixelSquare) {
        QRSquare square = new QRSquare(map, pixelSquare.Corners);
        return square;
    }

    //Properties
    public PixelGrouper PixelGrouper { 
        set { this.pixelGrouper = value; }
        get { return this.pixelGrouper; } 
    }

    public QRDimensionBridge QRDimensionBridge {
        set { this.qrDimensionBridge = value; }
        get { return this.qrDimensionBridge; }
    }

    public QRSkeleton QRSkeleton {
        get { return this.qrSkeleton; }
    }
}
