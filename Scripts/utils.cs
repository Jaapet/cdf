using Godot;
using System;

public static class Utils
{
   public static void SetParent(Node obj, Node newParent)
   {
      obj.GetParent().RemoveChild(obj);
      newParent.AddChild(obj);
   }

   public static double GetRandomNumber(double minimum, double maximum)
   {
      Random random = new Random();
      return random.NextDouble() * (maximum - minimum) + minimum;
   }

   public static Vector2 GetRandomPointInsideCircle(Vector2 origin, float radius)
   {
      double radialCoordonnate;
      double angularCoordonnate;

      radialCoordonnate = GetRandomNumber(0, radius);
      angularCoordonnate = GetRandomNumber(0, 2 * Mathf.Pi);

      return new Vector2((float)(radialCoordonnate * Mathf.Cos(angularCoordonnate)) + origin.X, (float)(radialCoordonnate * Mathf.Sin(angularCoordonnate)) + origin.Y);
   }

   public static Vector2 GetRandomPointInsideCircle(Vector2 origin, float radius, float minDistanceFromCentre)
   {
      if (minDistanceFromCentre >= radius)
      {
         GD.PrintErr("minDistanceFromCentre superior to radius"); return Vector2.Inf;
      }

      double radialCoordonnate;
      double angularCoordonnate;

      radialCoordonnate = GetRandomNumber(minDistanceFromCentre, radius);
      angularCoordonnate = GetRandomNumber(0, 2 * Mathf.Pi);

      return new Vector2((float)(radialCoordonnate * Mathf.Cos(angularCoordonnate)) + origin.X, (float)(radialCoordonnate * Mathf.Sin(angularCoordonnate)) + origin.Y);
   }
}