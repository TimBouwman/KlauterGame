const Appandage = require('./Appandage.js');

class Player {
    /** Constructor,
     * This one needs the joint rotations.
     * 
     * @param {The client Id of this player} clientId
     */
    constructor(clientId) {
        this.clientId = clientId;
        this.appandages = [];
        for(var i = 0; i < 4; i++) {
            this.appandages[i] = new Appandage("0", "0", "0");
        }
    }
}

module.exports = Player;