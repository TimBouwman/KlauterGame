class MapReposition {
    /** When the map position gets changed by the admin computer.
     * 
     * @param {The new X position of the map} x 
     * @param {The new Y position of the map} y 
     * @param {The new Z position of the map} z 
     * @param {The new quaternion rotation of the map} rotation
     */
    constructor(x, y, z, rotation) {
        this.x = x;
        this.y = y;
        this.z = z;

        this.rotation = rotation;
    }
}

module.exports = MapReposition;