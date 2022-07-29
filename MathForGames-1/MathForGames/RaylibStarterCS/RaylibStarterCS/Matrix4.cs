using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;

namespace MathClasses
{
    public struct Matrix4
    {
        public float m00, m01, m02, m03;
        public float m10, m11, m12, m13;
        public float m20, m21, m22, m23;
        public float m30, m31, m32, m33;

        public Matrix4(
                float mx1, float mx2, float mx3, float mx4,
                float mx5, float mx6, float mx7, float mx8,
                float mx9, float mx10, float mx11, float mx12,
                float mx13, float mx14, float mx15, float mx16
                )
        {
            m00 = mx1;
            m01 = mx2;
            m02 = mx3;
            m03 = mx4;
            m10 = mx5;
            m11 = mx6;
            m12 = mx7;
            m13 = mx8;
            m20 = mx9;
            m21 = mx10;
            m22 = mx11;
            m23 = mx12;
            m30 = mx13;
            m31 = mx14;
            m32 = mx15;
            m33 = mx16;
        }
        public float X
        {
            get => m20;
        }
        public float Y
        {
            get => m21;
        }
        public Vector3 Forward
        {
            get
            {
                return new Vector3(m10, m11, 0);
            }
        }
        public static Matrix4 identity = new Matrix4(1, 0, 0, 0, 0, 1, 0, 0, 0, 0, 1, 0, 0, 0, 0, 1);
        public static Matrix4 operator *(Matrix4 m1, Matrix4 m2)
        {
            return new Matrix4(
                m1.m00 * m2.m00 + m1.m10 * m2.m01 + m1.m20 * m2.m02 + m1.m30 * m2.m03,
                m1.m01 * m2.m00 + m1.m11 * m2.m01 + m1.m21 * m2.m02 + m1.m31 * m2.m03,
                m1.m02 * m2.m00 + m1.m12 * m2.m01 + m1.m22 * m2.m02 + m1.m32 * m2.m03,
                m1.m03 * m2.m00 + m1.m13 * m2.m01 + m1.m23 * m2.m02 + m1.m33 * m2.m03,

                m1.m00 * m2.m10 + m1.m10 * m2.m11 + m1.m20 * m2.m12 + m1.m30 * m2.m13,
                m1.m01 * m2.m10 + m1.m11 * m2.m11 + m1.m21 * m2.m12 + m1.m31 * m2.m13,
                m1.m02 * m2.m10 + m1.m12 * m2.m11 + m1.m22 * m2.m12 + m1.m32 * m2.m13,
                m1.m03 * m2.m10 + m1.m13 * m2.m11 + m1.m23 * m2.m12 + m1.m33 * m2.m13,

                m1.m00 * m2.m20 + m1.m10 * m2.m21 + m1.m20 * m2.m22 + m1.m30 * m2.m23,
                m1.m01 * m2.m20 + m1.m11 * m2.m21 + m1.m21 * m2.m22 + m1.m31 * m2.m23,
                m1.m02 * m2.m20 + m1.m12 * m2.m21 + m1.m22 * m2.m22 + m1.m32 * m2.m23,
                m1.m03 * m2.m20 + m1.m13 * m2.m21 + m1.m23 * m2.m22 + m1.m33 * m2.m23,

                m1.m00 * m2.m30 + m1.m10 * m2.m31 + m1.m20 * m2.m32 + m1.m30 * m2.m33,
                m1.m01 * m2.m30 + m1.m11 * m2.m31 + m1.m21 * m2.m32 + m1.m31 * m2.m33,
                m1.m02 * m2.m30 + m1.m12 * m2.m31 + m1.m22 * m2.m32 + m1.m32 * m2.m33,
                m1.m03 * m2.m30 + m1.m13 * m2.m31 + m1.m23 * m2.m32 + m1.m33 * m2.m33
                );
        }
        public static Vector4 operator *(Matrix4 m, Vector4 v)
        {
            return new Vector4(
                m.m00 * v.x + m.m10 * v.y + m.m20 * v.z + m.m30 * v.w,
                m.m01 * v.x + m.m11 * v.y + m.m21 * v.z + m.m31 * v.w,
                m.m02 * v.x + m.m12 * v.y + m.m22 * v.z + m.m32 * v.w,
                m.m03 * v.x + m.m13 * v.y + m.m23 * v.z + m.m33 * v.w);
        }
        public Matrix4 GetTransposed()
        {
            return new Matrix4(m00, m10, m20, m30, m01, m11, m21, m31, m02, m12, m22, m32, m03, m12, m23, m33);
        }
        public void SetTranslation(float x, float y)
        {
            Set(identity);

            m20 = x;
            m21 = y;

        }

        public void Translate(float x, float y)
        {
            Matrix4 m = new Matrix4();
            m.SetTranslation(x, y);
            Set(this * m);


        }

        public void SetRotateX(double radians)
        {
            Set(1, 0, 0, 0, 0, (float)Math.Cos(radians), (float)Math.Sin(radians), 0, 0, (float)-Math.Sin(radians), (float)Math.Cos(radians), 0, 0, 0, 0, 1);
        }
        public void RotateX(double radians)
        {
            Matrix4 m = new Matrix4();
            m.SetRotateX(radians);
            Set(this * m);
        }
        public void SetRotateY(double radians)
        {
            Set((float)Math.Cos(radians), 0, (float)-Math.Sin(radians), 0, 0, 1, 0, 0, (float)Math.Sin(radians), 0, (float)Math.Cos(radians), 0, 0, 0, 0, 1);
        }
        public void RotateY(double radians)
        {
            Matrix4 m = new Matrix4();
            m.SetRotateY(radians);
            Set(this * m);
        }
        public void SetRotateZ(double radians)
        {
            Set((float)Math.Cos(radians), (float)Math.Sin(radians), 0, 0, (float)-Math.Sin(radians), (float)Math.Cos(radians), 0, 0, 0, 0, 1, 0, 0, 0, 0, 1);
        }
        public void RotateZ(double radians)
        {
            Matrix4 m = new Matrix4();
            m.SetRotateZ(radians);
            Set(this * m);
        }
        void SetEuler(float pitch, float yaw, float roll)
        {
            Matrix4 x = new Matrix4();
            Matrix4 y = new Matrix4();
            Matrix4 z = new Matrix4();
            x.SetRotateX(pitch);
            y.SetRotateY(yaw);
            z.SetRotateZ(roll);
            
        }
        public void SetScale(float x, float y, float z, float w)
        {
            m00 = x; m01 = 0; m02 = 0; m03 = 0;
            m10 = 0; m11 = y; m12 = 0; m13 = 0;
            m20 = 0; m21 = 0; m22 = z; m23 = 0;
            m30 = 0; m31 = 0; m32 = 0; m33 = w;
        }
        public void SetScale(Vector4 v)
        {
            m00 = v.x; m01 = 0; m02 = 0; m03 = 0;
            m10 = 0; m11 = v.y; m12 = 0; m13 = 0;
            m20 = 0; m21 = 0; m22 = v.z; m23 = 0;
            m30 = 0; m31 = 0; m32 = 0; m33 = v.w;
        }
        public void Scale(float x, float y, float z, float w)
        {
            Matrix4 m = new Matrix4();
            m.SetScale(x, y, z, w);

            Set(this * m);
        }

        void Scale(Vector4 v)
        {
            Matrix4 m = new Matrix4();
            m.SetScale(v.x, v.y, v.z, v.w);
            Set(this * m);
        }
        void Set(Matrix4 m)
        {
            m00 = m.m00;
            m01 = m.m01;
            m02 = m.m02;
            m03 = m.m03;
            m10 = m.m10;
            m11 = m.m11;
            m12 = m.m12;
            m13 = m.m13;
            m20 = m.m20;
            m21 = m.m21;
            m22 = m.m22;
            m23 = m.m23;
            m30 = m.m30;
            m31 = m.m31;
            m32 = m.m32;
            m33 = m.m33;
        }
        void Set(float ms1, float ms2, float ms3, float ms4, 
            float ms5, float ms6, float ms7, float ms8, 
            float ms9, float ms10, float ms11, float ms12, 
            float ms13, float ms14, float ms15, float ms16)
        {
            m00 = ms1;
            m01 = ms2;
            m02 = ms3;
            m03 = ms4;
            m10 = ms5;
            m11 = ms6;
            m12 = ms7;
            m13 = ms8;
            m20 = ms9;
            m21 = ms10;
            m22 = ms11;
            m23 = ms12;
            m30 = ms13;
            m31 = ms14;
            m32 = ms15;
            m33 = ms16;
        }
    }
}
