using Godot;
using System;

public partial class Shark : WaterObject
{
    public const float Speed = 300.0f;
    private Vector2 velocity = new Vector2();
    private Timer randomMovementTimer;

	[Export] private PackedScene sharkScene = ResourceLoader.Load<PackedScene>("res://Scenes/shark.tscn");

    public override void _Ready()
    {
        base._Ready();
        velocity = new Vector2(-Speed, 0);

 
        randomMovementTimer = new Timer();
        AddChild(randomMovementTimer);
        randomMovementTimer.WaitTime = 1.0f;
        randomMovementTimer.Connect("timeout", new Callable(this, nameof(OnRandomMovementTimerTimeout)));
        randomMovementTimer.Start();
    }

    public override void _PhysicsProcess(double delta)
    {

        velocity.X = -Speed/4;

        Velocity = velocity;
        MoveAndSlide();

		if (GlobalPosition.X < -GetViewportRect().Size.X / 2)
        {
			QueueFree();
        }

		
    }

    private void OnRandomMovementTimerTimeout()
    {
		
        velocity.Y = (float)GD.RandRange(-50, 50);
		// spawn_shark();
	
    }

	// private void spawn_shark()
	// {
		// Shark sharkInstance = sharkScene.Instantiate<Shark>();
        // GetTree().Root.GetChild(0).AddChild(sharkInstance);
// 
		// 
		// sharkInstance.GlobalPosition = GlobalPosition;
// 
	// }


}
