using System;
using System.Collections.Generic;
using System.Text;
using Raylib_cs;
using static Raylib_cs.Raylib;
using static TankGame.Enemy;

namespace TankGame
{
    class SpawnPoint : SceneObject
    {
        SceneObject spawn = new SceneObject();
        
        Game game;
        public Enemy[] enemiesToSpawn = new Enemy[5];
        int x = 0;
        public static SpawnPoint spawnPoint;
        public SpawnPoint(Game Owner)
        {
            game = Owner;

            spawnPoint = this;

            spawn.SetPosition(GetScreenWidth() / 6, (float)GetScreenHeight() * 1.3f);

            for (int x = 0; x < enemiesToSpawn.Length; x++)
            {
                enemiesToSpawn[x] = new Enemy(game);
                enemiesToSpawn[x].SetPosition(GetScreenWidth() / 6, (float)GetScreenHeight() * 1.3f);
                enemiesToSpawn[x].direction = Enemy.Direction.up;
                enemiesToSpawn[x].isSpawnA = true;
            }

            foreach (Enemy e in spawnPoint.enemiesToSpawn)
            {
                e.enemyHealth = 3;
                
            }
        }
        public override void OnUpdate(float deltaTime)
        {
            if(!enemiesToSpawn[x].active)
            {
                if (spawnTime < 0)
                {


                    spawnTime = spawnTimeMax;

                    enemiesToSpawn[x].CopyTransformToLocal(spawn.GlobalTransform);

                    enemiesToSpawn[x].active = true;
                    game.AddSceneObject(enemiesToSpawn[x]);
                    Console.WriteLine(spawnTimeMax);
                    if (spawnTimeMax > 2)
                    {
                        Console.WriteLine(spawnTimeMax);
                        float playerV = -0.2f + ((Tank.playerHealth / Tank.playerMaxHealth) / 2);
                        float scoreV = Display.score / 50000;
                        scoreV = scoreV > 1 ? scoreV = 1 : scoreV;
                        spawnTimeMax = 20 - 18 * ((playerV + scoreV) / 1.3f);
                        Console.WriteLine(spawnTimeMax);
                    }
                    else
                    {
                        spawnTimeMax = 2;
                    }
                    x++;
                    if (x == enemiesToSpawn.Length)
                    {
                        x = 0;
                    }
                }
            }
            
            spawnTime -= deltaTime;
        }
    }
}
