using Godot;
using System;

public partial class Player : CharacterBody2D
{
	[Export] private float _runSpeed = 300.0f;
	[Export] private float _walkSpeed = 300.0f;
	[Export] private float _sneakSpeed = 300.0f;



	public override void _PhysicsProcess(double delta)
	{
		Vector2 velocity = Velocity;

		Vector2 direction = Input.GetVector("move_left", "move_right", "move_up", "move_down");
		float speed = Input.IsActionPressed("move_sneak") ? _sneakSpeed : Input.IsActionPressed("move_run") ? _runSpeed : _walkSpeed;

		velocity.X = direction == Vector2.Zero ? Mathf.MoveToward(Velocity.X, 0, speed) : direction.X * speed;



		Velocity = velocity;
		MoveAndSlide();
	}
}
