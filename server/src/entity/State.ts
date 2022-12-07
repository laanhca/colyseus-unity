import { Schema, MapSchema, type } from "@colyseus/schema";
import { Client } from "colyseus";
import { Player } from "./Player";

export class State extends Schema {

@type({map:Player})
players = new MapSchema<Player>();

onAddPlayer(client: Client){
    let player = new Player(0,0);
    this.players.set(client.sessionId, player);
}

onRemovePlayer(client: Client){
    this.players.delete(client.sessionId);
}

}