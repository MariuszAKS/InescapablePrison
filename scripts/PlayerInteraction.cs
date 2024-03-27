using Godot;
using System;

public partial class PlayerInteraction : Area2D
{
	CollisionShape2D _collision;


	public override void _Ready()
	{
		_collision = GetChild(0) as CollisionShape2D;

		//AreaEntered += (area) => 
	}

	public override void _Process(double delta)
	{
		if (Input.IsActionJustPressed("interact"))
		{
			_collision.SetDeferred("Disabled", true);
			_collision.SetDeferred("Disabled", false);
		}
	}
}
