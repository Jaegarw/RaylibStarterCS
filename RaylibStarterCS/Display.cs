using System;
using System.Collections.Generic;
using System.Text;
using Raylib_cs;
using static Raylib_cs.Raylib;
using MathClasses;

namespace TankGame
{
    class Display : SceneObject
    {
        SceneObject _HUD = new SceneObject();
        public int score = 0;
        public static Display display;
        Game game;
        
        
        public Display(Game owner)
        {
            game = owner;
        }
            


        public override void OnUpdate(float deltaTime)
        {
            float barWidth = 75 - ((75 / (Tank.playerMaxHealth)) * -(Tank.playerHealth - (Tank.playerMaxHealth + 1)));

            Rectangle healthBar = new Rectangle(Tank.tank.LocalTransform.X - 37.5f, Tank.tank.LocalTransform.Y - (GetScreenHeight() / 10), barWidth, 10);

            display = this;
            DrawText("SCORE", GetScreenWidth() - (GetScreenWidth() / 5), GetScreenHeight() / 40, GetScreenWidth() / 24, Color.BLACK);
            DrawText(score.ToString(), GetScreenWidth() - (GetScreenWidth() / 6), GetScreenHeight() / 10, GetScreenWidth() / 18, Color.BLACK);

            DrawRectangleRec(healthBar, Color.RED);
        }
    }
}
