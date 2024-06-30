using Godot;
using System;

public partial class poop : WaterObject
{
    private Vector2 direction;
    public const float Speed = 100.0f;
    private Area2D collisionArea;

    public override void _Ready()
    {
        base._Ready();

		AddToGroup("poop");
		
        // collisionArea = GetNode<Area2D>("CollisionArea2D");
        // collisionArea.Connect("body_entered", new Callable(this, nameof(OnBodyEntered)));
    }

    public override void _PhysicsProcess(double delta)
    {
        // Move the poop towards the set direction
        Velocity = direction * Speed;
        MoveAndSlide();

        if (GlobalPosition.X < -GetViewportRect().Size.X / 2)
        {
            QueueFree();
        }
    }

    public void SetDirection(Vector2 dir)
    {
        direction = dir;
    }

    // private void OnBodyEntered(Node2D body)
    // {
        // if (body is Player player)
        // {
            // player.TakeDamage();
            // QueueFree(); // Remove poop after it hits the player
        // }
    // }
}
