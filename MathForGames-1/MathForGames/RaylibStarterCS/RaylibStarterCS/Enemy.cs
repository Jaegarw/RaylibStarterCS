using System;
using System.Collections.Generic;
using System.Text;
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


        SpriteObject enemySprite = new SpriteObject();
        Game game;
        public static Enemy enemy;
        public float speed = 120f;
        public float rotation = 119;

        public bool turning = false;
        public bool directionChange;
        public Enemy(Game _game)
        {
            game = _game;
            enemy = this;
            enemySprite.Load("../Images/ship.png");
            
            enemySprite.SetPosition(0, 0);

            AddChild(enemySprite);
        }

        

        public override void OnUpdate(float deltaTime)
        {
            


            if(turning == false)
            {
                TranslateLocal(localTransform.Forward.x * (speed * deltaTime), -localTransform.Forward.y * (speed * deltaTime));
                if (rotation > 61)
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
                if (rotation == 61)
                {
                    rotation = 0;
                }
            }


            Console.WriteLine(direction);
            
            
            
            if(rotation < 60)
            {

                
                
                if (globalTransform.Y > (GetScreenHeight() - 90f))
                {
                    
                    if (direction == Direction.down)
                    {
                        turning = true;
                        Rotate((1.5708f * deltaTime));
                        rotation++;
                    }
                    
                }
                if (globalTransform.Y < 90f)
                {
                   

                    if (direction == Direction.up)
                    {
                        turning = true;
                        Rotate((1.5708f * deltaTime));
                        rotation++;
                    }
                    
                }
                if (globalTransform.X > (GetScreenWidth() - 150f))
                {
                    

                    if (direction == Direction.right)
                    {
                        turning = true;
                        Rotate((1.5708f * deltaTime));
                        rotation++;
                    }
                    
                }
                if (globalTransform.X < 90f)
                {
                    if (direction == Direction.left)
                    {
                        turning = true;
                        Rotate((1.5708f * deltaTime));
                        rotation++;

                    }
                        

                        
                    
                }
                else
                {
                    //rotation = 0;
                    
                }
                        
            }
            else if(rotation == 60)
            {
                turning = false;
                rotation = 150;

                directionChange = true;
            }
            
        }
    }
}
