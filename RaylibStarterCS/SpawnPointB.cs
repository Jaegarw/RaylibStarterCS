using System;
using System.Collections.Generic;
using System.Text;
using Raylib_cs;
using static Raylib_cs.Raylib;
using static TankGame.Enemy;

namespace TankGame
{
    class SpawnPointB : SceneObject
    {
        SceneObject spawnB = new SceneObject();
        
        Game game;
        public Enemy[] enemiesToSpawnB = new Enemy[5];
        int x = 0;
        public static SpawnPointB spawnPointB;
        
        public SpawnPointB(Game Owner)
        {
            game = Owner;

            spawnPointB = this;

            spawnB.SetPosition(GetScreenWidth() - 150, -150);

            for (int x = 0; x < enemiesToSpawnB.Length; x++)
            {
                enemiesToSpawnB[x] = new Enemy(game);
                enemiesToSpawnB[x].SetPosition(GetScreenWidth() - 150, -150);
                enemiesToSpawnB[x].direction = Direction.down;
                enemiesToSpawnB[x].isSpawnA = false;
                enemiesToSpawnB[x].enemySprite.Rotate(MathF.PI);
            }

            foreach (Enemy e in spawnPointB.enemiesToSpawnB)
            {
                e.enemyHealth = 3;
                
            }
        }
        public override void OnUpdate(float deltaTime)
        {
            if(!enemiesToSpawnB[x].active)
            {
                if (spawnTimeB < 0)
                {
                    //enemiesToSpawnB[x].SetRotate(MathF.PI);



                    enemiesToSpawnB[x].startDir *= -1f;

                    enemiesToSpawnB[x].direction = Direction.down;

                    enemiesToSpawnB[x].SetPosition(spawnB.GlobalTransform.X, spawnB.GlobalTransform.Y);

                    Console.WriteLine(enemiesToSpawnB[x].GlobalTransform.X);
                    enemyCount++;
                    enemiesToSpawnB[x].active = true;
                    game.AddSceneObject(enemiesToSpawnB[x]);
                    Console.WriteLine(spawnTimeMax);
                    if (spawnTimeMax > 2)
                    {
                        Console.WriteLine(spawnTimeMax);
                        //Console.WriteLine(Display.score / 50000);
                        float playerV = -0.2f + ((Tank.playerHealth / Tank.playerMaxHealth) / 2);
                        float scoreV = Display.score / 50000;
                        scoreV = scoreV > 1 ? scoreV = 1 : scoreV;
                        spawnTimeMax = 15 - 13 * ((playerV + scoreV) / 1.3f);
                        Console.WriteLine(spawnTimeMax);
                    }
                    else
                    {
                        spawnTimeMax = 2;
                    }
                    spawnTimeB = spawnTimeMax;
                    x++;
                    if (x == enemiesToSpawnB.Length)
                    {
                        x = 0;
                    }
                }
            }


            spawnTimeB -= deltaTime;
        }
    }
}

