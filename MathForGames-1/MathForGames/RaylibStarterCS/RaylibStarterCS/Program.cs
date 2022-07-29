using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Raylib_cs;
using TankGame;

namespace RaylibStarterCS
{
    class Program
    {
        static void Main(string[] args)
        {
            Game game = new Game();

            Raylib.InitWindow(1280, 720, "Hello World");

            game.Init();

            while (!Raylib.WindowShouldClose())
            {
                game.Update();
                game.Draw();
            }

            game.Shutdown();

            Raylib.CloseWindow();
        }

    }
}
