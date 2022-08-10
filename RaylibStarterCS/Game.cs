using System;
using System.Diagnostics;
using System.Numerics;
using System.Collections.Generic;
using Raylib_cs;
using static Raylib_cs.Raylib;


namespace TankGame
{
    class Game
    {
        SceneObject tankObject = new SceneObject();


        Stopwatch stopwatch = new Stopwatch();

        private long currentTime = 0;
        private long lastTime = 0;
        private float timer = 0;
        private int fps = 1;
        private int frames;

        private float deltaTime = 0.005f;

        public List<SceneObject> sceneObjects = new List<SceneObject>();
        private List<SceneObject> sceneObjectsToAdd = new List<SceneObject>();
        private List<SceneObject> sceneObjectsToRemove = new List<SceneObject>();

        public Game()
        {
        }

        public void AddSceneObject(SceneObject o)
        {
            sceneObjectsToAdd.Add(o);
        }
        public void RemoveSceneObject(SceneObject o)
        {
            sceneObjectsToRemove.Add(o);
        }
        public void Init()
        {
            stopwatch.Start();
            lastTime = stopwatch.ElapsedMilliseconds;

            if (Stopwatch.IsHighResolution)
            {
                Console.WriteLine("Stopwatch high-resolution frequency: {0} ticks per second", Stopwatch.Frequency);
            }

            

            SetTargetFPS(60);       // Set our game to run at 60 frames-per-second

            Tank tank = new Tank(this);
            
            SpawnPoint spawn = new SpawnPoint(this);
            SpawnPointB spawnB = new SpawnPointB(this);
            Display display = new Display(this);

            tank.SetPosition(GetScreenWidth() / 2, GetScreenHeight() / 2);
            
            spawn.SetPosition(GetScreenWidth() / 6, (float)GetScreenHeight() * 1.3f);
            spawnB.SetPosition(GetScreenWidth() - 150, -150);

            sceneObjects.Add(tank);
            
            sceneObjects.Add(spawn);
            sceneObjects.Add(spawnB);
            sceneObjects.Add(display);
        }

        public void Shutdown()
        {
        }

        public void Update()
        {
            lastTime = currentTime;
            currentTime = stopwatch.ElapsedMilliseconds;
            deltaTime = (currentTime - lastTime) / 1000.0f;
            timer += deltaTime;
            if (timer >= 1) 
            {
                fps = frames;
                frames = 0;
                timer -= 1;
            }
            frames++;

            foreach (SceneObject objectS in sceneObjectsToRemove)
            {
                sceneObjects.Remove(objectS);
            }
            sceneObjectsToRemove.Clear();
            foreach (SceneObject objectS in sceneObjectsToAdd)
            {
                sceneObjects.Add(objectS);
            }
            sceneObjectsToAdd.Clear();

            // SceneObjects Update code
            foreach (SceneObject objectS in sceneObjects)
            {
                objectS.Update(deltaTime);
            }
            
        }

        public void Draw()
        {
            BeginDrawing();
                

            ClearBackground(Color.WHITE);

			//SceneObjects Draw 
            foreach(SceneObject objectS in sceneObjects)
            {
                objectS.Draw();
            }
            
            // Display FPS
            DrawText(fps.ToString(), 10, 10, 14, Color.RED);

            

            EndDrawing();
        }

    }
}
