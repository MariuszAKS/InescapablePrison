using Godot;
using System;

public partial class Player : CharacterBody2D
{
	private float _runSpeed = 100.0f;
	private float _walkSpeed = 50.0f;
	private float _sneakSpeed = 20.0f;



	public override void _PhysicsProcess(double delta)
	{
		HandleMovement();
	}

	private void HandleMovement()
	{
		Vector2 direction = Input.GetVector("move_left", "move_right", "move_up", "move_down");
		float speed = Input.IsActionPressed("move_sneak") ? _sneakSpeed : Input.IsActionPressed("move_run") ? _runSpeed : _walkSpeed;

		Velocity = direction * speed;
		MoveAndSlide();
	}
}
