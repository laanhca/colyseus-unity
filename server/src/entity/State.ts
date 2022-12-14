import { Schema, MapSchema, type } from "@colyseus/schema";
import { Client } from "colyseus";
import { PlayerState } from "./PlayerState";

export class State extends Schema {

@type({map:PlayerState})
players = new MapSchema<PlayerState>();

onAddPlayer(client: Client){
    let player = new PlayerState(Math.random()* (5 + 5) -5,0, client.sessionId);
    this.players.set(client.sessionId, player);
}

onRemovePlayer(client: Client){
    this.players.delete(client.sessionId);
}

}