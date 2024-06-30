using Godot;
using System;

public partial class Water : ParallaxBackground
{
   private Node2D water;

   public override void _Ready()
   {
      base._Ready();

      water = GetNode<Node2D>("ParallaxLayer/Sprite2D");
   }

   public override void _Process(double delta)
   {
      base._Process(delta);

      water.Position = new Vector2(water.Position.X - GameManager.scrollingSpeed, water.Position.Y);
   }
}
