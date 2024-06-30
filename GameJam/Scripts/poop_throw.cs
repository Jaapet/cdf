using Godot;
using System;

public partial class poop_throw : WaterObject
{
    [Export] private PackedScene poopScene = ResourceLoader.Load<PackedScene>("res://Scenes/poop.tscn");
	// public  float Speed = 10.5f * GameManager.scrollingSpeed;
	// GD.Print(Speed);
    private Timer throwTimer;

    public override void _Ready()
    {
        base._Ready();
        // Initialize and start the throw timer
        throwTimer = new Timer();
        AddChild(throwTimer);
        throwTimer.WaitTime = 0.5f; // Adjust this value for how often you want to throw
        throwTimer.Connect("timeout", new Callable(this, nameof(OnThrowTimerTimeout)));
        throwTimer.Start();
    }

	public override void _Process(double delta)
   {
      base._Process(delta);
	  
	  GlobalPosition = new Vector2((float)GlobalPosition.X - Parallax.Speed_parallax * 0.20f , GlobalPosition.Y);

   }
    private void OnThrowTimerTimeout()
    {
        ThrowPoop();
    }

    private void ThrowPoop()
    {
        if (poopScene == null)
        {
            GD.PrintErr("poopScene is not assigned!");
            return;
        }

        // Instance a new poop from the packed scene
        poop poopInstance = poopScene.Instantiate<poop>();
        GetTree().Root.GetChild(0).AddChild(poopInstance);

        // Set the initial position of the poop
        poopInstance.GlobalPosition = GlobalPosition;

        // Calculate a random direction within a 100-degree range towards the bottom
        float minAngle = -50 * (Mathf.Pi / 180.0f); // -50 degrees in radians
        float maxAngle = 50 * (Mathf.Pi / 180.0f); // 50 degrees in radians
        float randomAngle = (float)GD.RandRange(minAngle, maxAngle);

        Vector2 direction = new Vector2(Mathf.Sin(randomAngle), Mathf.Cos(randomAngle)).Normalized();
        poopInstance.SetDirection(direction);
    }
}
