using Godot;
using System;

public partial class Animation : AnimatedSprite2D
{
	private CharacterBody2D _parent;
	private Vector2 _prevDirection;

	public override void _Ready()
	{
		_parent = GetParent() as CharacterBody2D;
	}

	public override void _Process(double delta)
	{
		Vector2 direction = _parent.Velocity;

		if (direction == _prevDirection)
		{
			return;
		}
		_prevDirection = direction;

		if (direction == Vector2.Zero)
		{
			Stop();
			Frame = 3;
			return;
		}

		if (direction.X < 0)
		{
			Animation = "walk_left";
		}
		else if (direction.X > 0)
		{
			Animation = "walk_right";
		}
		else if (direction.Y < 0)
		{
			Animation = "walk_up";
		}
		else if (direction.Y > 0)
		{
			Animation = "walk_down";
		}

		if (IsPlaying())
		{
			return;
		}
		Play();
	}
}
