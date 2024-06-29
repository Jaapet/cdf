using Godot;
using System;

public partial class Shark : WaterObject
{
    public const float Speed = 300.0f;
    private Vector2 velocity = new Vector2();
    private Timer randomMovementTimer;

    public override void _Ready()
    {
        base._Ready();
        // Initialize velocity to move left at a constant speed
        velocity = new Vector2(-Speed, 0);

        // Initialize and start the random movement timer
        randomMovementTimer = new Timer();
        AddChild(randomMovementTimer);
        randomMovementTimer.WaitTime = 1.0f; // Adjust this value for how often you want to change direction
        randomMovementTimer.Connect("timeout", new Callable(this, nameof(OnRandomMovementTimerTimeout)));
        randomMovementTimer.Start();
    }

    public override void _PhysicsProcess(double delta)
    {
        // Move the shark to the left
        velocity.X = -Speed/4;

        // Apply the velocity
        Velocity = velocity;
        MoveAndSlide();

		
    }

    private void OnRandomMovementTimerTimeout()
    {
        // Randomly change vertical velocity
        velocity.Y = (float)GD.RandRange(-100, 100); // Adjust range as needed
    }

    public void SetInitialPosition(Vector2 position)
    {
        GlobalPosition = position;
    }
}
