using System;
using System.Collections.Generic;
using System.Text;
using System.Numerics;
using Raylib_cs;
using MathClasses;

namespace TankGame
{
    class SpriteObject : SceneObject
    {
        Raylib_cs.Texture2D texture = new Raylib_cs.Texture2D();
        Image image = new Image();

        public float Width
        {
            get { return texture.width; }
        }
        public float Height
        {
            get { return texture.height; }
        }
        public SpriteObject()
        {

        }
        public SpriteObject(string fileName)
        {
            Load(fileName);
        }
        public void Load(string fileName)
        {
            Raylib_cs.Image image = Raylib_cs.Raylib.LoadImage(fileName);
            texture = Raylib_cs.Raylib.LoadTextureFromImage(image);
        }
        public override void OnUpdate(float deltaTime)
        {
            
        }
        public override void OnDraw()
        {
            float rotation = (float)Math.Atan2(globalTransform.m01, globalTransform.m00);
            Raylib_cs.Raylib.DrawTextureEx(texture, new Vector2(globalTransform.m20, globalTransform.m21), rotation * (float)(180f / Math.PI), 1, Raylib_cs.Color.WHITE);
        } 
    }
    
}
