using Godot;
using System;

public partial class PlayerAnimation : AnimatedSprite2D
{
	public override void _Ready()
	{
	}



	public override void _Process(double delta)
	{
		if (Input.IsActionPressed("move_down"))
		{
			this.Animation = "walk_down";
			this.Play();
		}
		else if (Input.IsActionPressed("move_up"))
		{
			this.Animation = "walk_up";
			this.Play();
		}
		else if (Input.IsActionPressed("move_left"))
		{
			this.Animation = "walk_left";
			this.Play();
		}
		else if (Input.IsActionPressed("move_right"))
		{
			this.Animation = "walk_right";
			this.Play();
		}
		else
		{
			this.Stop();
			this.Frame = 3;
		}
	}
}
