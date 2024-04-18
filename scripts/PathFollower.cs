using Godot;
using System;

public partial class PathFollower : PathFollow2D
{
	private float _followSpeed = 32.0f;

	public override void _Process(double delta)
	{
		Progress += _followSpeed * (float)delta;
	}
}
