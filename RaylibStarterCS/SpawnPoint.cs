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

            spawn.SetPosition(240, 720);

            for (int x = 0; x < enemiesToSpawn.Length; x++)
            {
                enemiesToSpawn[x] = new Enemy(game);
            }

            foreach (Enemy e in spawnPoint.enemiesToSpawn)
            {
                e.enemyHealth = 3;
            }
        }
        public override void OnUpdate(float deltaTime)
        {
            if (spawnTime < 0)
            {
                

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
