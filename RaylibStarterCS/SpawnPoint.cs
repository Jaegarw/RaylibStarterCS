using System;
using System.Collections.Generic;
using System.Text;

namespace TankGame
{
    class SpawnPoint : SceneObject
    {
        SceneObject spawn = new SceneObject();
        float spawnTime = 10;
        Game game;
        public SpawnPoint(Game Owner)
        {
            game = Owner;

            spawn.SetPosition(240, 300);
        }

        public override void OnUpdate(float deltaTime)
        {
            if (spawnTime < 0)
            {
                Enemy enemy = new Enemy(game);

                spawnTime = 8;

                enemy.CopyTransformToLocal(spawn.GlobalTransform);

                game.AddSceneObject(enemy);
            }
            spawnTime -= deltaTime;
        }
    }
}
