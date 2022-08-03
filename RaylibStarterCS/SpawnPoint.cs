using System;
using System.Collections.Generic;
using System.Text;

namespace TankGame
{
    class SpawnPoint : SceneObject
    {
        SceneObject spawn = new SceneObject();
        float spawnTime = 3;
        Game game;
        public Enemy[] enemiesToSpawn = new Enemy[8];
        int x = 0;
        public static SpawnPoint spawnPoint;
        public SpawnPoint(Game Owner)
        {
            game = Owner;

            spawnPoint = this;

            spawn.SetPosition(240, 300);
        }

        public override void OnUpdate(float deltaTime)
        {
            if (spawnTime < 0)
            {
                enemiesToSpawn[x] = new Enemy(game);

                spawnTime = 8;

                enemiesToSpawn[x].CopyTransformToLocal(spawn.GlobalTransform);

                game.AddSceneObject(enemiesToSpawn[x]);
                x++;
                if(x == enemiesToSpawn.Length)
                {
                    x = 0;
                }
            }
            spawnTime -= deltaTime;
        }
    }
}
