using Godot;
using System;

public enum PlayerState {
	Immovable, Movable, Reading, StartHiding, Hiding
}

public partial class Player : CharacterBody2D
{
	[Signal] public delegate void DirectionChangedEventHandler(Vector2 direction);
	[Signal] public delegate void TriedToInteractEventHandler();
	[Signal] public delegate void PassNewStateEventHandler(PlayerState state);
	[Signal] public delegate void GotOutOfHidingEventHandler();

	private float _runSpeed = 100.0f;
	private float _walkSpeed = 50.0f;
	private float _sneakSpeed = 20.0f;

	private Vector2 _prevDirection = Vector2.Zero;

	private PlayerState _state = PlayerState.Movable;



    public override void _Ready()
    {
        PassNewState += (value) => _state = value;
		SignalBus.Instance.UI_DialogFinish += () => { _state = PlayerState.Movable; };
    }

    public override void _PhysicsProcess(double delta)
	{
		switch (_state)
		{
			case PlayerState.Immovable: {} break;
			case PlayerState.Movable:{
				HandleStateMovable();
			} break;
			case PlayerState.Reading: {
				HandleStateReading();
			} break;
			case PlayerState.StartHiding: {
				HandleStateStartHiding();
			} break;
			case PlayerState.Hiding: {
				HandleStateHiding();
			} break;
			default: {} break;
		}
	}

	private void HandleStateMovable()
	{
		Vector2 direction = Input.GetVector("move_left", "move_right", "move_up", "move_down");
		float speed = Input.IsActionPressed("move_sneak") ? _sneakSpeed : Input.IsActionPressed("move_run") ? _runSpeed : _walkSpeed;
		Velocity = direction * speed;
		MoveAndSlide();

		if (direction != _prevDirection)
			EmitSignal(SignalName.DirectionChanged, direction);
		_prevDirection = direction;

		if (Input.IsActionJustPressed("interact"))
			EmitSignal(SignalName.TriedToInteract);
	}

	private void HandleStateReading()
	{
		if (Input.IsActionJustPressed("interact"))
			SignalBus.Instance.EmitSignal(SignalBus.SignalName.UI_DialogNext);
		else if (Input.IsActionJustPressed("dialog_skip"))
			SignalBus.Instance.EmitSignal(SignalBus.SignalName.UI_DialogFinish);
		else if (Input.GetVector("move_left", "move_right", "move_up", "move_down") != Vector2.Zero)
			SignalBus.Instance.EmitSignal(SignalBus.SignalName.UI_DialogFinish);
	}

	private void HandleStateStartHiding()
	{
		Visible = false;
		_state = PlayerState.Hiding;
	}

	private void HandleStateHiding()
	{
		if (Input.IsActionJustPressed("interact"))
		{
			_state = PlayerState.Movable;
			EmitSignal(SignalName.GotOutOfHiding);
			Visible = true;
		}
	}
}
