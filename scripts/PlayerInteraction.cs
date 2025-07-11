using Godot;
using System;
using System.Collections.Generic;

public partial class PlayerInteraction : RayCast2D
{
	Player player;

	private int _lengthInPixels = 16;
	private bool _isReading = false;
	private bool _isHiding = false;



	public override void _Ready()
	{
		player = GetParent() as Player;
		player.DirectionChanged += UpdateRayDirection;
		player.TriedToInteract += Interaction;
	}



	private void Interaction()
	{
		GodotObject collider = GetCollider();
		PlayerState playerState;

		if (collider is null)
			playerState = PlayerState.Movable;
		else if (collider is Readable)
		{
			playerState = PlayerState.Reading;
			(collider as Readable).Read();
		}
		else if (collider is Hideable)
		{
			playerState = PlayerState.Hiding;
			(collider as Hideable).HideIn();
		}
		else playerState = PlayerState.Movable;

		player.EmitSignal(Player.SignalName.PassNewState, (int)playerState);
	}

	private void UpdateRayDirection(Vector2 direction)
	{
		if (direction != Vector2.Zero)
		{
			TargetPosition = direction * _lengthInPixels;
		}
	}
}
