const Disconnect = require('../packets/Disconnect.js');

function HandleQuitPacket(server, socket) {
    var index = 0;
    server.connectedPlayers.forEach(player => {
        if(player.clientId == socket.id) {
            server.connectedPlayers.splice(index);
            server.CheckForEndGame();
        }
        index++;
    });

    var dataObject = new Disconnect(socket.id);

    server.BroadCastToClients('quit', dataObject);
    console.log(dataObject.clientId + " left the server (Server: " + server.port + ")");

    //Incase the admin disconnects
    if(server.admin.clientId == dataObject.clientId) {
        server.Error("Server can't run without an admin!");
    }

    //Incase the output device leaves
    if(server.output != null && server.output.clientId == dataObject.clientId) {
        server.output = null;
    }
}

module.exports = HandleQuitPacket;