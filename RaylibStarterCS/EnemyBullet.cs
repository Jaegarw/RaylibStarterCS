using System;
using System.Collections.Generic;
using System.Text;
using static Raylib_cs.Raylib;
using MathClasses;

namespace TankGame
{
    class EnemyBullet : SceneObject
    {
        public SpriteObject badBulletSprite = new SpriteObject();
        public float speed = 0.6f;
        public float duration;

        public int bulletDir = 1;

        Enemy enemy;

        static Game game;
        
        public EnemyBullet(Game owner)
        {
            game = owner;

            enemy = new Enemy(game);

            
            

            

            badBulletSprite.Load("../Images/bulletRedSilver_outline.png");
            badBulletSprite.SetPosition(-badBulletSprite.Width / 2f, 0);

            AddChild(badBulletSprite);
        }

        public override void OnUpdate(float deltaTime)
        {
            duration++;
            
            
            
            switch (enemy.direction)
            {
                case Enemy.Direction.up:
                    TranslateLocal(0, 
                        400f * bulletDir * (deltaTime * -speed));
                    break;
                case Enemy.Direction.right:
                    TranslateLocal(0,
                        400f * bulletDir * (deltaTime * -speed));
                    break;
                case Enemy.Direction.down:
                    TranslateLocal(0,
                        400f * bulletDir * (deltaTime * -speed));
                    break;
                case Enemy.Direction.left:
                    TranslateLocal(0,
                        400f * bulletDir * (deltaTime * -speed));
                    break;
            }
            
            
            
            
            

            if ((globalTransform.X < 0) || (globalTransform.X > GetScreenWidth()) ||
                (globalTransform.Y < 0) || (globalTransform.Y > GetScreenHeight()) || duration > 120f)
            {
                duration = 0;
                game.RemoveSceneObject(this);
            }
            if (((globalTransform.X > Tank.tank.GlobalTransform.X - 100f) && (globalTransform.X < Tank.tank.GlobalTransform.X + 100F)
            && (globalTransform.Y > Tank.tank.GlobalTransform.Y - 100f) && (globalTransform.Y < Tank.tank.GlobalTransform.Y + 100F)))
            {
                Tank.playerHealth--;
                
                Display.display.textTimer = 3;
                    
                
                
                Display.display.comboMultiplier = 1;
                
                duration = 0;
                game.RemoveSceneObject(this);

            }
        }
    }
}
