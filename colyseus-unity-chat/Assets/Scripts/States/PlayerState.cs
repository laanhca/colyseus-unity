// 
// THIS FILE HAS BEEN GENERATED AUTOMATICALLY
// DO NOT CHANGE IT MANUALLY UNLESS YOU KNOW WHAT YOU'RE DOING
// 
// GENERATED USING @colyseus/schema 1.0.44
// 

using Colyseus.Schema;

public partial class PlayerState : Schema {
	[Type(0, "string")]
	public string name = default(string);

	[Type(1, "string")]
	public string message = default(string);

	[Type(2, "number")]
	public float x = default(float);

	[Type(3, "number")]
	public float y = default(float);

	[Type(4, "boolean")]
	public bool dir = default(bool);
}

