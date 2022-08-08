using System;
using System.Collections.Generic;
using System.Text;
using System.Numerics;
using Raylib_cs;
using static Raylib_cs.Raylib;
using MathClasses;

namespace TankGame
{
    class Enemy : SceneObject
    {
        public enum Direction
        {
            down, right, up, left, none
        }
        public Direction direction = Direction.up;

        
        
        public SpriteObject enemySprite = new SpriteObject();
        Game game;
        public Enemy enemy;
        public float speed = 150f;
        public float maxSpeed = 300f;
        public float rotation = 1f;
        
        public bool active;
        float badBulletTime = 2;
        public int enemyHealth;
        public bool turning = false;
        public bool directionChange;
        public Enemy(Game _game)
        {
            game = _game;
            enemy = this;

            

            enemySprite.Load("../Images/ship.png");
            
            enemySprite.SetPosition(SpawnPoint.spawnPoint.GlobalTransform.X, SpawnPoint.spawnPoint.GlobalTransform.Y);

            AddChild(enemySprite);
        }

        

        public override void OnUpdate(float deltaTime)
        {
            if ((globalTransform.X < 0) || (globalTransform.X > GetScreenWidth()) ||
                (globalTransform.Y < 0 - ((float)GetScreenHeight() * 2)) || (globalTransform.Y > (float)GetScreenHeight() * 2))
            {
                if(active)
                Bullet.bullet.Recycle(this);

            }
            if (speed > maxSpeed)
                speed = maxSpeed;
            TranslateLocal(localTransform.Forward.x * (speed * deltaTime), -localTransform.Forward.y * (speed * deltaTime));
            if (turning == false)
            {
                
                if (rotation > 32)
                {
                    while(directionChange)
                    {
                        if(direction == Direction.down)
                        {
                            direction = Direction.left;
                            directionChange = false;
                            return;
                        }
                        if (direction == Direction.left)
                        {
                            direction = Direction.up;
                            directionChange = false;
                            return;
                        }
                        if (direction == Direction.up)
                        {
                            direction = Direction.right;
                            directionChange = false;
                            return;
                        }
                        if (direction == Direction.right)
                        {
                            direction = Direction.down;
                            directionChange = false;
                            return;
                        }
                    }
                    rotation--;
                }
                if (rotation == 32)
                {
                    rotation = 0;
                }
            }


            
            
            
            
            if(rotation < 31)
            {

                
                
                if (globalTransform.Y > (GetScreenHeight() - 90f))
                {
                    
                    if (direction == Direction.down)
                    {
                        turning = true;
                        Rotate((1.5708f * deltaTime * 2));
                        rotation++;
                    }
                    
                }
                if (globalTransform.Y < 90f)
                {
                   

                    if (direction == Direction.up)
                    {
                        turning = true;
                        Rotate((1.5708f * deltaTime * 2));
                        rotation++;
                    }
                    
                }
                if (globalTransform.X > (GetScreenWidth() - 150f))
                {
                    

                    if (direction == Direction.right)
                    {
                        turning = true;
                        Rotate((1.5708f * deltaTime * 2));
                        rotation++;
                    }
                    
                }
                if (globalTransform.X < 90f)
                {
                    if (direction == Direction.left)
                    {
                        turning = true;
                        Rotate((1.5708f * deltaTime * 2));
                        rotation++;

                    }
                        

                        
                    
                }
                else
                {
                    //rotation = 0;
                    
                }
                        
            }
            else if(rotation == 31)
            {
                turning = false;
                rotation = 76;

                directionChange = true;
            }

            if (badBulletTime < 0)
            {
                EnemyBullet badBite = new EnemyBullet(game);

                badBulletTime = 2;

                badBite.CopyTransformToLocal(enemySprite.GlobalTransform);

                badBite.Rotate(MathF.PI / 2);

                //badBite.TranslateLocal(0, 0);

                game.AddSceneObject(badBite);
            }
            badBulletTime -= deltaTime;
            
        }
    }
}
