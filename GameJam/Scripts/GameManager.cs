using Godot;
using System;

public partial class GameManager : Node2D
{
   private double time = 0;
   [Export] public static float scrollingSpeed = 1f;


   PackedScene shipScene = ResourceLoader.Load<PackedScene>("res://Scenes/water_ship.tscn");
   private bool hasSpawned = false;

   public override void _Ready()
   {
      base._Ready();
   }

   public override void _Process(double delta)
   {
      base._Process(delta);

      time += delta;
      if (time > 3 && !hasSpawned)
      {
         Node2D ship = shipScene.Instantiate() as Node2D;
         GetTree().Root.GetChild(0).AddChild(ship);
         ship.GlobalPosition = new Vector2(800, 0);
         hasSpawned = true;
      }
   }
}
