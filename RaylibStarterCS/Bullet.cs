using System;
using System.Collections.Generic;
using System.Text;
using System.Diagnostics;
using static Raylib_cs.Raylib;

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
                    if (((globalTransform.X > e.GlobalTransform.X - 100f) && (globalTransform.X < e.GlobalTransform.X + 100F)
                    && (globalTransform.Y > e.GlobalTransform.Y - 100f) && (globalTransform.Y < e.GlobalTransform.Y + 100F)))
                    {
                        Display.display.score += 10;
                        e.enemyHealth--;
                        game.RemoveSceneObject(this);

                    }
                }
                       
                    
            }
                    
                
                
            
            
        }
    }
}
