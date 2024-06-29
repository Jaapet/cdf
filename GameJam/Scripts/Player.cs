using Godot;
using System;

public partial class Player : CharacterBody2D
{
   public static Player instance;

   #region Components
   private Sprite2D sprite;
   private Area2D damageArea;
   private AudioStreamPlayer2D damageSoundPlayer;
   private Timer invincibilityTimer;
   #endregion

   [Signal] public delegate void TakedDamageEventHandler();

   [Export] private float verticalSpeed = 20f;
   [Export] private float horizontalSpeed = 20f;
   private Vector2 direction;

   private int maxHealth = 3;
   public int currentHealth;

   private float leftLimit = 20;

   private bool isInvincibible = false;


   public override void _Ready()
   {
      base._Ready();
      instance = this; // Singleton, ne pas toucher svp

      sprite = GetNode<Sprite2D>("Sprite2D");
      damageArea = GetNode<Area2D>("DamageArea2D");
      damageSoundPlayer = GetNode<AudioStreamPlayer2D>("DamageStreamPlayer2D");
      invincibilityTimer = GetNode<Timer>("InvincibilityTimer");

      currentHealth = maxHealth;
   }

   public override void _Process(double delta)
   {
      base._Process(delta);

      ReadInput();
   }

   public override void _PhysicsProcess(double delta)
   {
      base._PhysicsProcess(delta);

      Move();
      InvincibilityBlinking();
   }

   private void ReadInput()
   {
      this.direction = Input.GetVector("Left", "Right", "Up", "Down");
   }

   protected void ApplyVelocity(Vector2 velocity)
   {
      Velocity = velocity;
      MoveAndSlide();
   }

   protected Vector2 MoveToward(Vector2 direction, float speed, bool applyVelocity)
   {
      Vector2 velocity = this.Velocity;

      // Velocity
      velocity.X = direction.X != 0 ? direction.X * speed : Mathf.MoveToward(velocity.X, 0, speed);
      velocity.Y = direction.Y != 0 ? direction.Y * speed : Mathf.MoveToward(velocity.Y, 0, speed);

      if (applyVelocity) ApplyVelocity(velocity);
      return velocity;
   }
   protected Vector2 MoveToward(Vector2 direction, float verticalSpeed, float horizontalSpeed, bool applyVelocity)
   {
      Vector2 velocity = this.Velocity;

      // Velocity
      velocity.X = direction.X * horizontalSpeed;
      velocity.Y = direction.Y * verticalSpeed;

      if (applyVelocity) ApplyVelocity(velocity);
      return velocity;
   }

   private void Move()
   {
      Vector2 velocity = MoveToward(direction, verticalSpeed, horizontalSpeed, false);
      // if ((GlobalPosition.X + velocity.X > GetViewportRect().Size.X / 4)
      // || (GlobalPosition.X + velocity.X) < 0)
      //    velocity.X = 0;
      velocity = new Vector2(velocity.X - 20, velocity.Y);
      ApplyVelocity(velocity);
   }

   private void TakeDamage()
   {
      if (isInvincibible)
         return;

      // Decreased Health
      currentHealth--;
      if (currentHealth <= 0)
         Death();

      // Invincibility
      isInvincibible = true;
      invincibilityTimer.Start();

      // Sound
      damageSoundPlayer.Play();

      // Screen Shake
      EmitSignal(SignalName.TakedDamage);
   }

   private void Death()
   {
      GD.Print("Death");
   }

   private void InvincibilityBlinking()
   {
      if (!isInvincibible)
         return;

      sprite.Modulate = sprite.Modulate.A == 0 ? new Color(1, 1, 1, 1) : new Color(1, 1, 1, 0);
   }

   private void OnDamageAreaBodyEntered(Node2D body)
   {
      // For Obstacles
      if (body.IsInGroup("water_object"))
      {
         WaterObject waterObject = (WaterObject)body;
         waterObject.Death();
         TakeDamage();
      }
   }

   private void OnInvincibilityTimerTimeout()
   {
      isInvincibible = false;
      sprite.Modulate = new Color(1, 1, 1, 1);
   }

}