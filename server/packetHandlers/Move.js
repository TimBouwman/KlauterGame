function HandleMovePacket(server, data) {
    server.connectedPlayers.forEach(player => {
        if(player.clientId == data.clientId){
            player.x = parseFloat(data.x);
            player.y = parseFloat(data.y);
            player.rotZ = parseFloat(data.rotZ);
            player.rotY = parseFloat(data.rotY);
        }
    });

    server.BroadCastToClients('move', data);
}

module.exports = HandleMovePacket;