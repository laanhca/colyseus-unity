import { Client, Room } from "colyseus";
import { State } from "../entity/State";

export class GameRoom extends Room<State>{

    onCreate (options: any) {
        this.setState(new State());
    
        this.onMessage("chat", (client, message) => {
          //
          // handle "chat" message
          //
        });
    
      }
    
      onJoin (client: Client, options: any) {
        console.log(client.sessionId, "joined!");
        this.state.onAddPlayer(client);
      }
    
      onLeave (client: Client, consented: boolean) {
        console.log(client.sessionId, "left!");
        this.state.onRemovePlayer(client);
      }
    
      onDispose() {
        console.log("room", this.roomId, "disposing...");
      }

}