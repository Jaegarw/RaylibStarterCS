using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using System.Threading.Tasks;
using System.Diagnostics;
using MathClasses;

namespace TankGame
{
    class SceneObject
    {
        protected SceneObject parent = null;
        protected List<SceneObject> children = new List<SceneObject>();
        protected Matrix3 localTransform = new Matrix3();
        protected Matrix3 globalTransform = new Matrix3();

        public Matrix3 LocalTransform
        {
            get => localTransform;
        }

        public Matrix3 GlobalTransform
        {
            get => globalTransform;
        }

        public virtual void OnUpdate(float deltaTime)
        {


        }

        public virtual void OnDraw()
        {

        }

        public void Update(float deltaTime)
        {
            OnUpdate(deltaTime);

            foreach (SceneObject child in children)
            {
                child.Update(deltaTime);
            }
        }

        public void Draw()
        {
            OnDraw();

            foreach (SceneObject child in children)
            {
                child.Draw();
            }
        }
        public void CopyTransformToLocal(Matrix3 t)
        {
            LocalTransform.Set(t);
            UpdateTransform();
        }
        public void UpdateTransform()
        {
            if (parent != null)
            {
                globalTransform = parent.globalTransform * localTransform;
            }
            else
            {
                globalTransform = localTransform;
            }
            foreach (SceneObject child in children)
            {
                child.UpdateTransform();
            }
        }

        public void SetPosition(float x, float y)
        {
            localTransform.SetTranslation(x, y);
            UpdateTransform();
        }

        public SceneObject Parent
        {
            get { return parent; }
        }
        public SceneObject()
        {

        }
        public int GetChildCount()
        {
            return children.Count;
        }
        public SceneObject GetChild(int index)
        {
            return children[index];
        }

        public void AddChild(SceneObject child)
        {
            Debug.Assert(child.parent == null);
            child.parent = this;
            child.UpdateTransform();
            children.Add(child);
            
        }
        public void RemoveChild(SceneObject child)
        {
            if (children.Remove(child) == true)
            {
                child.parent = null;
            }
        }
        public void TranslateLocal(float x, float y)
        {
            localTransform.Translate(x, y);
            UpdateTransform();
        }
        public void SetScale(float width, float height)
        {
            LocalTransform.SetScale(width, height, 1);
            UpdateTransform();
        }
        public void Scale(float width, float height)
        {
            localTransform.Scale(width, height, 1);
            UpdateTransform();
        }
        public void SetRotate(float radians)
        {
            LocalTransform.SetRotateZ(radians);
            UpdateTransform();
        }
        public void Rotate(float radians)
        {
            localTransform.RotateZ(radians);
            UpdateTransform();
        }
    }
}
