class PlayerPositionUpdate {
    /** When a player moves.
     * 
     * @see {@link http://maclout.com/klautergame/jointmodel/jointmodel.png} for a visual representation of the jointmodel.
     * 
     * @see {@link Quaternion.js} for more info about the quaternion rotations.
     * 
     * @param {The client id of the player} clientId
     * @param {Left arm 0 (Can only be a quaternion rotation)} LA0 
     * @param {Left arm 1 (Can only be a quaternion rotation)} LA1 
     * @param {Right arm 0 (Can only be a quaternion rotation)} RA0 
     * @param {Right arm 1 (Can only be a quaternion rotation)} RA1 
     * @param {Left leg 0 (Can only be a quaternion rotation)} LL0 
     * @param {Left leg 1 (Can only be a quaternion rotation)} LL1 
     * @param {Right leg 0 (Can only be a quaternion rotation)} RL0 
     * @param {Right leg 1 (Can only be a quaternion rotation)} RL1 
     * @param {The X position of the player} xPos
     * @param {The Y position of the player} yPos
     * @param {The Z position of the player} zPos
     */
    constructor(clientId, LA0, LA1, RA0, RA1, LL0, LL1, RL0, RL1, xPos, yPos, zPos) {
        this.clientId = clientId;
        this.lA = [LA0, LA1];
        this.rA = [RA0, RA1];
        this.lL = [LL0, LL1];
        this.rL = [RL0, RL1];

        this.xPos = parseFloat(xPos);
        this.yPos = parseFloat(yPos);
        this.zPos = parseFloat(zPos);
    }
}

module.exports = PlayerPositionUpdate;