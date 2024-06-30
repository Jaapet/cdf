using Godot;
using System;

public partial class Parallax : ParallaxBackground
{
   private ParallaxLayer parallaxLayer;
   public static float Speed_parallax;
   public override void _Ready()
   {
      base._Ready();

      parallaxLayer = GetNode<ParallaxLayer>("ParallaxLayer");
   }

   public override void _Process(double delta)
   {
      base._Process(delta);
      
      Speed_parallax = (float)(GameManager.scrollingSpeed * 150 * delta);
      ScrollBaseOffset = new Vector2((float)(ScrollBaseOffset.X - GameManager.scrollingSpeed * 150 * delta), ScrollBaseOffset.Y);
      
   }
}
