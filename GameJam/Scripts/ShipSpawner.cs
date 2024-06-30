using Godot;
using System;

public partial class ShipSpawner : Spawner
{
   private void EasySpawnPattern01()
   {
      Spawn(GlobalPosition.X, GlobalPosition.Y - 50);
      Spawn(GlobalPosition.X, GlobalPosition.Y);
      Spawn(GlobalPosition.X, GlobalPosition.Y + 50);
   }

   private void EasySpawnPattern02()
   {
      Spawn(GlobalPosition.X, GlobalPosition.Y - 75);
      Spawn(GlobalPosition.X, GlobalPosition.Y);
      Spawn(GlobalPosition.X, GlobalPosition.Y + 75);
   }

   private void EasySpawnPattern03()
   {
      Spawn(GlobalPosition.X, GlobalPosition.Y - 75);
      Spawn(GlobalPosition.X + 200, GlobalPosition.Y);
      Spawn(GlobalPosition.X, GlobalPosition.Y + 75);
   }

   private void EasySpawnPattern04()
   {
      Spawn(GlobalPosition.X, GlobalPosition.Y - 75);
      Spawn(GlobalPosition.X, GlobalPosition.Y - 50);
      Spawn(GlobalPosition.X, GlobalPosition.Y);
   }

   private void EasySpawnPattern05()
   {
      Spawn(GlobalPosition.X, GlobalPosition.Y);
      Spawn(GlobalPosition.X, GlobalPosition.Y + 50);
      Spawn(GlobalPosition.X, GlobalPosition.Y + 75);
   }


   protected override void OnTimerTimeout()
   {
      StartTimer();

      switch (GameManager.difficulty)
      {
         case E_Difficulty.EASY:
            SpawnRandomEasy();
            break;
         default:
            break;
      }
   }

   private void SpawnRandomEasy()
   {
      int random = (int)Utils.GetRandomNumber(0, 5);
      switch (random)
      {
         case 0:
            EasySpawnPattern01();
            break;
         case 1:
            EasySpawnPattern02();
            break;
         case 2:
            EasySpawnPattern03();
            break;
         case 3:
            EasySpawnPattern04();
            break;
         case 4:
            EasySpawnPattern05();
            break;
         default:
            break;
      }
   }
}
