using System;
using System.Collections.Generic;
using System.Text;
using System.Diagnostics;
using System.Numerics;
using Raylib_cs;
using static Raylib_cs.Raylib;
using MathClasses;
using static TankGame.Display;

namespace TankGame
{
    class Bullet : SceneObject
    {
        SpriteObject bulletSprite = new SpriteObject();
        
        float speed = 750;
        Game game;
        public static Bullet bullet;
        public static Vector2 hitPos;
        

        public Bullet(Game owner)
        {
            game = owner;
            bullet = this;
            bulletSprite.Load("../Images/bulletGreenSilver_outline.png");
            bulletSprite.SetPosition(-bulletSprite.Width / 2f, 0);

           

            AddChild(bulletSprite);
            
        }

        public override void OnUpdate(float deltaTime)
        {
            

            TranslateLocal(0, speed * deltaTime);

            if((globalTransform.X < 0) || (globalTransform.X > GetScreenWidth()) || 
                (globalTransform.Y < 0) || (globalTransform.Y > GetScreenHeight()))
            {
                display.textTimer = 3;
                display.comboMultiplier = 1;
                game.RemoveSceneObject(this);

            }

            foreach(Enemy e in SpawnPoint.spawnPoint.enemiesToSpawn)
            {
                if(e.active)
                {
                    
                    if (CheckCollisionCircles(new Vector2(e.GlobalTransform.X, e.GlobalTransform.Y), 90, 
                        new Vector2(GlobalTransform.X, GlobalTransform.Y), 28))
                    {
                        
                        hitPos = new Vector2(e.GlobalTransform.X, e.GlobalTransform.Y);
                        display.scoreAdded = 0;
                        display.score += (10 * display.comboMultiplier);
                        display.scoreAdded += 10;
                        display.textTimer = 0;
                        e.enemyHealth--;
                        game.RemoveSceneObject(this);

                    }

                    
                }
                if (e.enemyHealth <= 0)
                {
                    if(display.comboMultiplier < 20)
                    {
                        display.comboMultiplier++;
                    }
                    Console.WriteLine(e.speed);
                    display.score += (100 * display.comboMultiplier);
                    display.scoreAdded += 100;
                    display.textTimer = 0;

                    Recycle(e);
                    
                    //e.SetPosition(GetScreenWidth() * 2, GetScreenHeight() * 2);
                }

            }

            

            

        }
        public void Recycle(Enemy enemyR)
        {
            enemyR.speed += 20f;
            game.RemoveSceneObject(enemyR);
            display.textTimer = 3;
            display.textTimer = 0;


            enemyR.enemyHealth = 3;

            enemyR.active = false;
            //enemyR.SetPosition(SpawnPoint.spawnPoint.GlobalTransform.X, SpawnPoint.spawnPoint.GlobalTransform.Y);
            enemyR.direction = Enemy.Direction.up;
        }
    }
}
