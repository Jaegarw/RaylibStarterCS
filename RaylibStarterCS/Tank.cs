using System;
using System.Collections.Generic;
using System.Text;
using Raylib_cs;
using static Raylib_cs.Raylib;
using MathClasses;

namespace TankGame
{
    class Tank : SceneObject
    {
        SpriteObject tankSprite = new SpriteObject();
        SceneObject turret = new SceneObject();
        SpriteObject turretSprite = new SpriteObject();

        Game game;
        public static Tank tank;
        public static int playerHealth = 10;
        public static int playerMaxHealth = 10;
        public float rotation = 2f;
        public float turretRotation = 1.5f;
        public float speed = 160;
        float bulletTime = 0;
        

        public Tank(Game owner)
        {
            game = owner;
            tank = this;
            tankSprite.Load("../Images/tankGreen.png");

            tankSprite.SetPosition(-tankSprite.Width / 2f, -tankSprite.Height / 2f);

            AddChild(tankSprite);

            turret.SetPosition(globalTransform.X, globalTransform.Y);

            turretSprite.Load("../Images/barrelGreen.png");

            turretSprite.SetPosition(-turretSprite.Width / 2f, 0);

            AddChild(turret);

            turret.AddChild(turretSprite);

            
        }

        public override void OnUpdate(float deltaTime)
        {
            if ((globalTransform.X < 0) || (globalTransform.X > GetScreenWidth()) ||
                (globalTransform.Y < 0) || (globalTransform.Y > GetScreenHeight()))
            {
                SetPosition(GetScreenWidth() / 2, GetScreenHeight() / 2);
                playerHealth--;
                

            }

            if (playerHealth <= 0)
            {
                game.RemoveSceneObject(this);
            }

            if (IsKeyDown(KeyboardKey.KEY_A))
            {
                this.Rotate(-(rotation * deltaTime));
            }
            if (IsKeyDown(KeyboardKey.KEY_D))
            {
                this.Rotate(rotation * deltaTime);
            }

            if (IsKeyDown(KeyboardKey.KEY_W))
            {
                TranslateLocal(localTransform.Forward.x * (speed * deltaTime), localTransform.Forward.y * (speed * deltaTime));
                
            }
            if (IsKeyDown(KeyboardKey.KEY_S))
            {
                TranslateLocal(-localTransform.Forward.x * (speed * deltaTime), -localTransform.Forward.y * (speed * deltaTime));
                

            }
            if (IsKeyDown(KeyboardKey.KEY_Q))
            {
                turret.Rotate(-(turretRotation * deltaTime));
            }
            if (IsKeyDown(KeyboardKey.KEY_E))
            {
                turret.Rotate(turretRotation * deltaTime);
            }

            if(bulletTime < 0 && IsKeyReleased(KeyboardKey.KEY_SPACE))
            {
                Bullet bite = new Bullet(game);

                bulletTime = 0.5f;

                bite.CopyTransformToLocal(turret.GlobalTransform);

                bite.TranslateLocal(0, 40);

                game.AddSceneObject(bite);
            }
            bulletTime -= deltaTime;
        }
    }
}
