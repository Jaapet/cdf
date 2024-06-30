using Godot;
using System;

public partial class Spawner : Node2D
{
   #region Components
   private Timer timer;
   #endregion

   [Export] private PackedScene objScene;
   [Export] private float minTime = 5f;
   [Export] private float maxTime = 8f;
   [Export] private float upY = -50;
   [Export] private float downY = 50;


   public override void _Ready()
   {
      base._Ready();

      timer = GetNode<Timer>("Timer");
      timer.Start();
   }

   private void OnTimerTimeout()
   {
      Spawn();
   }

   private void Spawn()
   {
      timer.WaitTime = Utils.GetRandomNumber(minTime, maxTime);
      timer.Start();

      // Shark shark = objScene.Instantiate<Shark>();
      Node2D obj = objScene.Instantiate() as Node2D;
      GetTree().Root.GetChild(0).AddChild(obj);

      obj.GlobalPosition = new Vector2(GlobalPosition.X, GlobalPosition.Y + (float)Utils.GetRandomNumber(upY, downY));
   }
}
