const Color = require('../obj/Color.js');

function HandleColorUpdate(server, data) {
    var color = new Color(data.r, data.g, data.b);
    server.color = color;

    server.BroadCastToClients('colorUpdate', color);
}

module.exports = HandleColorUpdate;