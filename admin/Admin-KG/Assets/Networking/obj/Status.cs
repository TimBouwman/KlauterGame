using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Status {

    public static readonly Status ERROR = new Status(-1, "ERROR", "Something went very wrong, try to restart the system");
    public static readonly Status WAIT_FOR_OUTPUT = new Status(0, "Waiting for output device", "Start the output device and connect it to the server to continue.");
    public static readonly Status SELECT_COLOR = new Status(1, "Select the QR color.", "Pick the color you want to convert into a 3D map.");
    public static readonly Status SET_MAP_POSITION = new Status(2, "Set the map position.", "Set the map to a position where it fits the physical map.");
    public static readonly Status WAIT_FOR_PLAYERS = new Status(3, "Waiting for players", "Setup process has finished, players are able to connect to the server.");
    public static readonly Status GAMEPLAY = new Status(4, "Ingame", "The game is now running.");

    public static IEnumerable<Status> Values {
        get {
            yield return WAIT_FOR_OUTPUT;
            yield return SELECT_COLOR;
            yield return SET_MAP_POSITION;
            yield return WAIT_FOR_PLAYERS;
            yield return GAMEPLAY;
        }
    }

    public static Status GetById(int id) {
        foreach(Status status in Values) {
            if (status.ID == id)
                return status;
        }

        return ERROR;
    }

    private int id;
    private string name;
    private string description;

    Status(int id, string name, string description) {
        this.id = id;
        this.name = name;
        this.description = description;
    }

    public int ID { get { return this.id; } }

    public string Name { get { return this.name; } }

    public string Description { get { return this.description; } }

}
