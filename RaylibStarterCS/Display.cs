using System;
using System.Collections.Generic;
using System.Text;
using Raylib_cs;
using static Raylib_cs.Raylib;
using static TankGame.Bullet;
using MathClasses;

namespace TankGame
{
    class Display : SceneObject
    {
        SceneObject _HUD = new SceneObject();
        public int score = 0;
        public int scoreAdded;
        public int bonus = 1;
        public static Display display;
        Game game;
        public int comboMultiplier = 1;
        public float textTimer = 10;

        public Display(Game owner)
        {
            game = owner;

            
        }
            


        public override void OnUpdate(float deltaTime)
        {
            if(score > 999 * bonus)
            {
                Tank.playerHealth++;
                bonus++;
            }

            float barWidth = 75 - ((75 / (Tank.playerMaxHealth)) * -(Tank.playerHealth - (Tank.playerMaxHealth + 1)));

            Rectangle healthBar = new Rectangle(Tank.tank.LocalTransform.X - 37.5f, Tank.tank.LocalTransform.Y - (GetScreenHeight() / 10), barWidth, 10);

            display = this;
            DrawText("SCORE", GetScreenWidth() - (GetScreenWidth() / 5), GetScreenHeight() / 40, GetScreenWidth() / 24, Color.BLACK);
            DrawText(score.ToString(), GetScreenWidth() - (GetScreenWidth() / 6), GetScreenHeight() / 10, GetScreenWidth() / 18, Color.BLACK);
            
            DrawRectangleRec(healthBar, Color.RED);

            if(hitPos != System.Numerics.Vector2.Zero)
            {
                if (textTimer < 2)
                {
                    if ((int)hitPos.Y < 0)
                        hitPos.Y = GetScreenHeight() / 30;
                    if (((int)hitPos.X + (GetScreenWidth() / 21) + (GetScreenWidth() / 24)) > GetScreenWidth())
                        hitPos.X = GetScreenWidth() - ((GetScreenWidth() / 10) + (GetScreenWidth() / 12));
                    DrawText(scoreAdded.ToString(), (int)hitPos.X, (int)(hitPos.Y - 20), GetScreenWidth() / 21, Color.BLACK);
                    DrawText("x" + display.comboMultiplier.ToString(), (int)hitPos.X + 100, (int)(hitPos.Y - 20), GetScreenWidth() / 24, Color.RED);
                }
                
            }
            
            textTimer += deltaTime;
        }
    }
}
