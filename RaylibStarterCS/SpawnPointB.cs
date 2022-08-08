using System;
using System.Collections.Generic;
using System.Text;
using Raylib_cs;
using static Raylib_cs.Raylib;

namespace TankGame
{
    class SpawnPointB : SceneObject
    {
        SceneObject spawnB = new SceneObject();
        float spawnTime = 3;
        Game game;
        public Enemy[] enemiesToSpawnB = new Enemy[5];
        int x = 0;
        public static SpawnPointB spawnPointB;
        public SpawnPointB(Game Owner)
        {
            game = Owner;

            spawnPointB = this;

            spawnB.SetPosition(GetScreenWidth() - (GetScreenWidth() / 6), 0 - (float)GetScreenHeight() * 1.3f);

            for (int x = 0; x < enemiesToSpawnB.Length; x++)
            {
                enemiesToSpawnB[x] = new Enemy(game);
                enemiesToSpawnB[x].SetPosition(GetScreenWidth() - (GetScreenWidth() / 6), 0 - (float)GetScreenHeight() * 1.3f);
                enemiesToSpawnB[x].direction = Enemy.Direction.down;
            }

            foreach (Enemy e in spawnPointB.enemiesToSpawnB)
            {
                e.enemyHealth = 3;
            }
        }
        public override void OnUpdate(float deltaTime)
        {
            if (spawnTime < 0)
            {
                enemiesToSpawnB[x].SetRotate(MathF.PI);

                spawnTime = 8;

                enemiesToSpawnB[x].CopyTransformToLocal(spawnB.GlobalTransform);

                enemiesToSpawnB[x].active = true;
                game.AddSceneObject(enemiesToSpawnB[x]);

                x++;
                if (x == enemiesToSpawnB.Length)
                {
                    x = 0;
                }
            }
            spawnTime -= deltaTime;
        }
    }
}

