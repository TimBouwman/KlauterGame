class PlayerMove {
    /** When a player moves.
     * 
     * @param {The client id of the player} clientId
     * @param {Left arm 0} LA0 
     * @param {Left arm 1} LA1 
     * @param {Right arm 0} RA0 
     * @param {Right arm 1} RA1 
     * @param {Left leg 0} LL0 
     * @param {Left leg 1} LL1 
     * @param {Right leg 0} RL0 
     * @param {Right leg 1} RL1 
     */
    constructor(clientId, LA0, LA1, RA0, RA1, LL0, LL1, RL0, RL1) {
        this.clientId = clientId;
        this.lA = [parseFloat(LA0), parseFloat(LA1)];
        this.rA = [parseFloat(RA0), parseFloat(RA1)];
        this.lL = [parseFloat(LL0), parseFloat(LL1)];
        this.rL = [parseFloat(RL0), parseFloat(RL1)];
    }
}

module.exports = PlayerMove;