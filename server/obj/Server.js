const ColorCode = require('../obj/ColorCode.js');
const Status = require('../obj/Status.js');
const StatusUpdate = require("../packets/StatusUpdate.js");

const JoinPacketHandler = require('../packetHandlers/Join.js');
const QuitPacketHandler = require('../packetHandlers/Quit.js');
const MovePacketHandler = require('../packetHandlers/Move.js');
const ColorUpdateHandler = require('../packetHandlers/ColorUpdate.js');

class Server {
    constructor(proxy, serverId, port) {
        this.status = Status.WAIT_FOR_OUTPUT;
        this.proxy = proxy;
        this.serverId = serverId;
        this.color = null;
        this.admin = null;
        this.output = null;
        this.connectedPlayers = [];
        this.port = port;
        this.isJoinable = false;

        this.gameStarted = false;

        this.io = require('socket.io')({
            transports: ['websocket'],
        });

        this.io.attach(this.port);
        console.log("Started listening on: " + this.port);

        //Start updating the server
        this.ServerLoop(this);
    }

    ServerLoop(server) {
        this.io.on('connection', function(socket) {
            socket.on('join', (data) => {
                JoinPacketHandler(server, socket, data);
            });
            
            socket.on('disconnect', function() {
                QuitPacketHandler(server, socket);
            });

            socket.on('appendagePositionUpdate', function(data) {
                MovePacketHandler(server, data);
            });

            socket.on('colorUpdate', function(data){
                ColorUpdateHandler(server, data);
            });

            socket.on('mapUpdate', function(data) {
                server.BroadCastToClients('mapUpdate', data);
            });
        });
    }

    Sleep(ms) {
        return new Promise(resolve => setTimeout(resolve, ms));
    }

    /** This will turn off the server and send the error message to the console.
     * @param {The error message} message 
     */
    async Error(message) {
        console.error(ColorCode.RED + message);
        console.error("Fatal error, will now close server: " + this.port + ColorCode.RESET);
        await this.MessageToClients("serverStopped");

        this.proxy.DestroyServer(this);
        this.io.close();
    }

    UpdateClientStatus() {
        this.BroadCastToClients('statusUpdate', new StatusUpdate(this.status));
    }

    Stop() {
        this.io.close();
    }

    BroadCastToClients(functionName, data) {
        this.io.sockets.clients().emit(functionName, data);
    }

    async MessageToClients(functionName) {
        this.io.sockets.clients().emit(functionName);
        return;
    }

    async CheckForEndGame() {
        var aliveIndex = 0;
        this.connectedPlayers.forEach(player => {
            if(!player.isDeath)
                aliveIndex++;
        });

        if(aliveIndex <= 1) {
            await this.MessageToClients("serverStopped");
            this.proxy.DestroyServer(this);
            this.io.close();
        }
    }
}

module.exports = Server;