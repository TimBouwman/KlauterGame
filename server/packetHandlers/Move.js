function HandleMovePacket(server, data) {
    server.connectedPlayers.forEach(player => {
        player.appandages[parseInt(data.id)].x = parseFloat(data.x);
        player.appandages[parseInt(data.id)].y = parseFloat(data.y);
        player.appandages[parseInt(data.id)].z = parseFloat(data.z);
    });

    server.BroadCastToClients('appendagePositionUpdate', data);
}

module.exports = HandleMovePacket;