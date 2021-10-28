using System;
using System.Collections.Generic;
using System.Text;
using MathClasses;

namespace RaylibStarterCS
{
    class SpriteObject : SceneObject
    {
        Raylib_cs.Texture2D texture = new Raylib_cs.Texture2D();

        public float Width
        {
            get { return texture.width; }
        }
        public float Height
        {
            get { return texture.height; }
        }
        public override void OnUpdate(float deltaTime)
        {
            //base.OnUpdate(deltaTime);
        }

        public override void OnDraw()
        {
            float rotation = (float)Math.Atan2(globalTransform.m02, globalTransform.m01);
            
        }
        public SpriteObject()
        {

        }

        public void Load(string filename)
        {
            Raylib_cs.Image img = Raylib_cs.Raylib.LoadImage(filename);
            texture = Raylib_cs.Raylib.LoadTextureFromImage(img);
        }
    }
}
