import { Schema, Context, type } from "@colyseus/schema";
export class Player extends Schema {
    @type("string")
    name: string;  
    @type("number")
    x: number;    
    @type("number")
    y: number;   
    @type("boolean")
    dir: boolean; 
    constructor(x: number, y: number, name?: string) {
        super();
        this.x = x;
        this.y = y;
        this.name = name;
        this.dir = true;
    }
}