using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QRDimensionBridge {

    ///<summary>
    ///This class takes the 2d QR codes and transforms
    ///them into 3D vectors.
    ///</summary>

    private QRHandler main;
    private PixelGrouper pixelGrouper;
    private List<QRCode> qrCodes2d = new List<QRCode>();

    public QRDimensionBridge(QRHandler main, PixelGrouper pixelGrouper) {
        this.main = main;
        this.pixelGrouper = pixelGrouper;

        GenerateQRCodes();
        Generate3DMap();
    }
    
    private void GenerateQRCodes() {

        foreach(QRSquare qrSquare in this.pixelGrouper.QRSquares()) {
            if(qrSquare.QRCode != null)
                continue;

            //Generate new QRCode
            QRCode qrCode = new QRCode(this, this.pixelGrouper, qrSquare);
            qrCode.ScanSurrounding(qrSquare, main.QRSkeleton);
            qrCodes2d.Add(qrCode);
        }
    }

    private void Generate3DMap() {
        List<Vector3> pos = new List<Vector3>();

        foreach(QRCode code in qrCodes2d) {
            pos.Add(code.Position + new Vector3(0, code.Size, 0));
        }

        QRToMap.Debug.instance.GenerateMap(pos);
    }

}
