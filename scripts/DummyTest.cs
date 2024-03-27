using Godot;
using System;

public partial class DummyTest : Area2D
{
	// Called when the node enters the scene tree for the first time.
	public override void _Ready()
	{
		AreaEntered += (aera2D) => GD.Print("Touched");
	}
}
