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
            Console.WriteLine(Enemy.enemy.GlobalTransform.X);
            Console.WriteLine(Enemy.enemy.GlobalTransform.Y);

            TranslateLocal(0, speed * deltaTime);

            if((globalTransform.X < 0) || (globalTransform.X > GetScreenWidth()) || 
                (globalTransform.Y < 0) || (globalTransform.Y > GetScreenHeight()))
            {
                game.RemoveSceneObject(this);
            }
            if(((globalTransform.X > Enemy.enemy.GlobalTransform.X - 100f) && (globalTransform.X < Enemy.enemy.GlobalTransform.X + 100F)
            && (globalTransform.Y > Enemy.enemy.GlobalTransform.Y - 100f) && (globalTransform.Y < Enemy.enemy.GlobalTransform.Y + 100F)))
            {
                Enemy.enemyHealth--;
                game.RemoveSceneObject(this);
                
            }
        }
    }
}
