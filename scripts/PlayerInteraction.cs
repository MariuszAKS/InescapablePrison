using Godot;
using System;
using System.Collections.Generic;

public partial class PlayerInteraction : RayCast2D
{
	private int _lengthInPixels = 16;



	public override void _Ready()
	{
		Player player = GetParent() as Player;
		player.DirectionUpdate += UpdateRayDirection;
		player.Interaction += HandleInteraction;
	}



	private void HandleInteraction()
	{
		if (IsColliding())
		{
			(GetCollider() as IInteractable)?.Interaction();
		}
	}

	private void UpdateRayDirection(Vector2 direction)
	{
		if (direction != Vector2.Zero)
		{
			TargetPosition = direction * _lengthInPixels;
		}
	}
}
