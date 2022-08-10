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
        public float startDir = -1f;
        public static float spawnTime = 5;
        public static float spawnTimeB = 4;
        public static float spawnTimeMax = 20;
        public bool active;
        public bool isSpawnA;
        float badBulletTime = 2;
        public int enemyHealth;
        public bool turning = false;
        public bool directionChange;
        public Enemy(Game _game)
        {
            game = _game;
            enemy = this;

            

            enemySprite.Load("../Images/ship.png");

            switch(direction)
            {
                case Direction.up:
                    enemySprite.SetPosition(SpawnPoint.spawnPoint.GlobalTransform.X, SpawnPoint.spawnPoint.GlobalTransform.Y);
                    
                    break;
                case Direction.down:
                    enemySprite.SetPosition(SpawnPointB.spawnPointB.GlobalTransform.X, SpawnPointB.spawnPointB.GlobalTransform.Y);
                    
                    break;
            }
            
            

            AddChild(enemySprite);
        }

        

        public override void OnUpdate(float deltaTime)
        {
            if ((globalTransform.X < -300) || (globalTransform.X > GetScreenWidth() + 300) ||
                (globalTransform.Y < -300) || (globalTransform.Y > GetScreenHeight() + 300))
            {

                if(active)
                {
                    Console.WriteLine(globalTransform.X);
                    Console.WriteLine(globalTransform.Y);
                    Console.WriteLine("out of bounds");
                    Bullet.bullet.Recycle(this);
                }
                    

            }
            if (speed > maxSpeed)
                speed = maxSpeed;
            TranslateLocal(localTransform.Forward.x * (speed * deltaTime), -startDir * -localTransform.Forward.y * (speed * deltaTime));
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

                //if(!isSpawnA)
                //{
                //    badBite.bulletDir *= -1;
                //    //badBite.badBulletSprite.Rotate(MathF.PI);
                //}

                //badBite.TranslateLocal(0, 0);

                game.AddSceneObject(badBite);
            }
            badBulletTime -= deltaTime;
            
        }
    }
}
