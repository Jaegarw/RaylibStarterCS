using System;
using System.Collections.Generic;
using System.Text;
using System.Diagnostics;
using System.Numerics;
using Raylib_cs;
using static Raylib_cs.Raylib;
using MathClasses;

namespace RaylibStarterCS
{
    class Tank : SceneObject
    {
        SpriteObject tankSprite = new SpriteObject();
        SceneObject turret = new SceneObject();
        SpriteObject turretSprite = new SpriteObject();

        

        float tankRotation = 0f;
        float speed = 100f;

        public Image tankBody;
        public Texture2D tankBTexture;

        public Vector2 tankPosition = new Vector2(0f, 0f);
        public Vector3 direction = new Vector3(1f, 1f, 1f);

        public Tank()
        {
            

            tankSprite.Load("../../Images/tank-body.png");

            tankSprite.SetPosition(-tankSprite.Width / 2f, -tankSprite.Height / 2f);

            AddChild(tankSprite);

            tankBody = LoadImage("../Images/tank-body.png");
            tankBTexture = LoadTextureFromImage(tankBody);

            
        }

        


        public override void OnUpdate(float deltaTime)
        {
           

            if(IsKeyDown(KeyboardKey.KEY_Q))
            {
                turret.Rotate(-deltaTime);
            }
            if (IsKeyDown(KeyboardKey.KEY_E))
            {
                turret.Rotate(deltaTime);
            }

            if(IsKeyDown(KeyboardKey.KEY_A))
            {
                this.Rotate(-(tankRotation * deltaTime));
                
            }

            if (IsKeyDown(KeyboardKey.KEY_D))
            {
                this.Rotate(tankRotation * deltaTime);
            }

            if(IsKeyDown(KeyboardKey.KEY_W))
            {
                TranslateLocal(LocalTransform.Forward.X * (speed * deltaTime), LocalTransform.Forward.Y * (speed * deltaTime));
                

            }
            if (IsKeyDown(KeyboardKey.KEY_S))
            {
                TranslateLocal(-direction.X * (speed * deltaTime), -direction.Y * (speed * deltaTime));
                direction = LocalTransform.Forward;
            }
        }

    }
}
