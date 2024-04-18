using Godot;
using System;

public partial class Guard : CharacterBody2D
{
	//private delegate void PhysicsProcessFunction(float delta);
	//private PhysicsProcessFunction _PhysicsProcessFunction;
	
	private NavigationAgent2D _navigationAgent2D;
	[Export] private Node2D _target;
	Timer _loosingInterestTimer;
	[Export] private PathFollow2D _pathFollow2D;

	private Area2D _sightArea;
	private Area2D _attackArea;
	
	private float _moveSpeed = 30.0f;



	public override void _Ready()
	{
		Node2D navigation = GetNode<Node2D>("Navigation");
		_navigationAgent2D = navigation.GetChild<NavigationAgent2D>(0);
		navigation.GetChild<Timer>(1).Timeout += () => _navigationAgent2D.TargetPosition = _target.GlobalPosition;

		_loosingInterestTimer = GetNode<Timer>("LoosingInterestTimer");
		_loosingInterestTimer.Timeout += () => _target = _pathFollow2D;

		_sightArea = GetNode<Area2D>("SightArea");
		_attackArea = GetNode<Area2D>("AttackArea");

		_sightArea.BodyEntered += SeenSomething;
		_sightArea.BodyExited += LostSight;
		_attackArea.BodyEntered += BodyEnteredAttackArea;

		//_PhysicsProcessFunction = HandleStateFollowingTarget;
	}

	public override void _PhysicsProcess(double delta)
	{
		//_PhysicsProcessFunction((float)delta);
		Velocity = (_navigationAgent2D.GetNextPathPosition() - GlobalPosition).Normalized() * _moveSpeed;
		_sightArea.RotationDegrees = MathF.Atan2(Velocity.Y, Velocity.X) * 180 / MathF.PI;
		
		MoveAndSlide();
	}



	private void SeenSomething(Node2D body)
	{
		if (body is Player)
		{
			_target = body;
			_loosingInterestTimer.Stop();
		}
	}

	private void LostSight(Node2D body)
	{
		if (body is Player)
			_loosingInterestTimer.Start();
	}

	private void BodyEnteredAttackArea(Node2D body)
	{
		if (body is Player && _target is Player)
		{
			GD.Print("Attack Player");
		}
	}
}
