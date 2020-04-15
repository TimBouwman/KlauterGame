class Quaternion {
    /** Constructor,
     *  Puts a quaternion rotation into one data object.
     * 
     * @param {x rotation as a string} x 
     * @param {y rotation as a string} y 
     * @param {z rotation as a string} z 
     * @param {w scalar as a string} w 
     */
    constructor(x, y, z, w) {
        this.x = parseFloat(x);
        this.y = parseFloat(y);
        this.z = parseFloat(z);
        
        this.w = parseFloat(w);
    }
}

module.exports = Quaternion;