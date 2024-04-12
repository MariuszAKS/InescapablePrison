using Godot;
using System;

public partial class PlayerAnimation : AnimatedSprite2D
{
	public override void _Ready()
	{
		Player player = GetParent() as Player;
		player.DirectionChanged += UpdateMovementAnimation;
	}



	private void HandleAnimations()
	{
		// Here will be handling of animations when there will be more than movement
		//MovementAnimation(direction);
	}

	private void UpdateMovementAnimation(Vector2 direction)
	{
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
