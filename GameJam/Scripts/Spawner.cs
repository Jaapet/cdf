using Godot;
using System;

public partial class Spawner : Node2D
{
   #region Components
   private Timer timer;
   #endregion

   [Export] private PackedScene objScene;
   [Export] private float minTime = 10f;
   [Export] private float maxTime = 20f;
   [Export] private float upY = -50;
   [Export] private float downY = 50;


   public override void _Ready()
   {
      base._Ready();

      timer = GetNode<Timer>("Timer");
      timer.Start();
   }

   protected virtual void OnTimerTimeout()
   {
      StartTimer();
      Spawn(new Vector2(GlobalPosition.X, GlobalPosition.Y + (float)Utils.GetRandomNumber(upY, downY)));
   }

   protected void StartTimer()
   {
      timer.WaitTime = Utils.GetRandomNumber(minTime, maxTime);
      timer.Start();
   }

   protected void Spawn(Vector2 position)
   {
      Node2D obj = objScene.Instantiate() as Node2D;
      GetTree().Root.GetChild(0).AddChild(obj);
      obj.GlobalPosition = position;
   }

   protected void Spawn(float x, float y)
   {
      Node2D obj = objScene.Instantiate() as Node2D;
      GetTree().Root.GetChild(0).AddChild(obj);
      obj.GlobalPosition = new Vector2(x, y);
   }
}
