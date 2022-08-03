using System;
using System.Collections.Generic;
using System.Text;
using System.Diagnostics;
using Raylib_cs;
using static Raylib_cs.Raylib;
using MathClasses;
using static TankGame.Display;

namespace TankGame
{
    class Bullet : SceneObject
    {
        SpriteObject bulletSprite = new SpriteObject();
        
        float speed = 300;
        Game game;
        
        
        public Bullet(Game owner)
        {
            game = owner;

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
                game.RemoveSceneObject(this);
            }

            foreach(Enemy e in SpawnPoint.spawnPoint.enemiesToSpawn)
            {
                if(e != null)
                {
                    
                    if (CheckCollisionCircles(new System.Numerics.Vector2(e.GlobalTransform.X, e.GlobalTransform.Y), 90, 
                        new System.Numerics.Vector2(GlobalTransform.X, GlobalTransform.Y), 28))
                    {
                        display.score += (10 * display.comboMultiplier);
                        display.scoreAdded += 10;
                        display.textTimer = 0;
                        e.enemyHealth--;
                        game.RemoveSceneObject(this);

                    }

                    
                }
                if (e.enemyHealth <= 0)
                {
                    if(display.comboMultiplier < 21)
                    {
                        display.comboMultiplier++;
                    }
                    
                    display.score += (100 * display.comboMultiplier);
                    display.scoreAdded += 100;
                    display.textTimer = 0;
                    
                    

                    game.RemoveSceneObject(e);
                    display.textTimer = 3;
                    display.textTimer = 0;
                    

                    e.enemyHealth = 3;

                    e.direction = Enemy.Direction.up;

                    e.SetPosition(GetScreenWidth() * 2, GetScreenHeight() * 2);
                }

            }

            

            

        }
        
    }
}
