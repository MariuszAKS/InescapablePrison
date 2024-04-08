using Godot;
using System;

public partial class Player : CharacterBody2D
{
	[Signal] public delegate void AllowMovementEventHandler(bool value);
	[Signal] public delegate void DirectionUpdateEventHandler(Vector2 direction);
	[Signal] public delegate void InteractionEventHandler();

	private float _runSpeed = 100.0f;
	private float _walkSpeed = 50.0f;
	private float _sneakSpeed = 20.0f;

	private Vector2 _prevDirection = Vector2.Zero;

	bool _canMove = true;



	public override void _PhysicsProcess(double delta)
	{
		if (_canMove)
		{
			HandleMovement();
			HandleInteraction();
			return;
		}

		HandleReading();
	}



	private void HandleMovement()
	{
		Vector2 direction = Input.GetVector("move_left", "move_right", "move_up", "move_down");
		float speed = Input.IsActionPressed("move_sneak") ? _sneakSpeed : Input.IsActionPressed("move_run") ? _runSpeed : _walkSpeed;

		Velocity = direction * speed;
		MoveAndSlide();



		if (direction != _prevDirection)
		{
			EmitSignal(SignalName.DirectionUpdate, direction);
			_prevDirection = direction;
		}
	}

	private void HandleInteraction()
	{
		if (Input.IsActionJustPressed("interact"))
		{
			EmitSignal(SignalName.Interaction);
		}
	}

	private void HandleReading()
	{
		if (Input.IsActionJustPressed("interact"))
		{
			EmitSignal(UI.SignalName.SwitchToNextText);
		}
	}
}
