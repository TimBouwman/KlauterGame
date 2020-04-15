const Quaternion = require('../obj/Quaternion.js');

class Player {
    /** Constructor,
     * This one needs the joint rotations.
     * 
     * @param {The client Id of this player} clientId 
     * @param {The x value (as a string) of the player} x 
     * @param {The y value (as a string) of the player} y 
     * @param {The z value (as a string) of the player} z 
     * @param {An array of left arm joint rotations (nullable)} lA 
     * @param {An array of right arm joint rotations (nullable)} rA 
     * @param {An array of left leg joint rotations (nullable)} lL 
     * @param {An array of right leg joint rotations (nullable)} rL 
     */
    constructor(clientId, x, y, z, lA, rA, lL, rL) {
        this.clientId = clientId;
        this.x = parseFloat(x);
        this.y = parseFloat(y);
        this.z = parseFloat(z);

        this.lA = lA || new Quaternion(0, 0, 0, 0);
        this.rA = rA || new Quaternion(0, 0, 0, 0);
        this.lL = lL || new Quaternion(0, 0, 0, 0);
        this.rL = rL || new Quaternion(0, 0, 0, 0);
    }
}

module.exports = Player;