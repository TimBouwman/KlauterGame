class Appandage {
    /** Constructor,
     * This one needs the joint rotations.
     * 
     * @param {The x value (as a string) of the player} x 
     * @param {The y value (as a string) of the player} y 
     * @param {The z value (as a string) of the player} z
     */
    constructor(x, y, z) {
        this.x = parseFloat(x);
        this.y = parseFloat(y);
        this.z = parseFloat(z);
    }
}

module.exports = Appandage;