const ConnectionType = require('../obj/ConnectionType.js');
const Player = require('../obj/Player.js');
const Admin = require('../obj/Admin.js');
const Output = require('../obj/Output.js');
const Status = require('../obj/Status.js');

/** This shall be called when a device does an attempt to connect with the server.
 * 
 * @param {The server that we can call back to.} server 
 * @param {The socket we received the data from.} socket 
 * @param {The actual data in JSON format that has been received by the server.} data 
 */
function HandleJoinPacket(server, socket, data) {
    /** We need to sort our connection by the type of the devices,
     *  because we obviously don't want to send unnecessary extra data.
     */
    switch(data.connectionType) {

        case ConnectionType.PLAYER: {
            if(!server.isJoinable)
                //TODO send a packet where we inform the user about the server's setup.
                return;

            var newPlayer = new Player(socket.id, data.playerTypeId, data.x, data.y, data.z);
            server.connectedPlayers.push(newPlayer);
        
            //We need to send the new player all the other players! Otherwise he will be alone forever!!
            server.connectedPlayers.forEach(player => {
                socket.emit('join', player);
            });
        
            server.BroadCastToClients('join', newPlayer);
            console.log(newPlayer.clientId + " Joined the game (Server: " + server.port + ")");

            break;
        }

        case ConnectionType.ADMIN: {
            if(server.admin != null) {
                server.Error("Server can't have more than one admin!");
                return;
            }
            
            server.admin = new Admin(socket.id);
            console.log(server.port + " now has an admin: " + server.admin.clientId);
            server.UpdateClientStatus();

            break;
        }

        case ConnectionType.OUTPUT: {
            if(server.output != null) {
                server.Error("Server can't have more than one output device!");
                return;
            }
            
            server.output = new Output(socket.id);
            server.status = Status.SELECT_COLOR;
            console.log(server.port + " now has a output device: " + server.output.clientId);
            server.UpdateClientStatus();

            break;
        }
    }
}

module.exports = HandleJoinPacket;