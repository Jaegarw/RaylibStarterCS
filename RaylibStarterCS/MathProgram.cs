using System;

namespace MathClasses
{
    class MathProgram
    {
        

        public class Vector3
        {
            public float x;
            public float y;
            public float z;

            Vector3(float x, float y, float z)
            {

            }
            
            public static Vector3 operator +(Vector3 left, Vector3 right)
            {
                return new Vector3(left.x + right.x, left.y + right.y, left.z + right.z);
            }

            public static Vector3 operator -(Vector3 left, Vector3 right)
            {
                return new Vector3(left.x - right.x, left.y - right.y, left.z - right.z);
            }

            public static Vector3 operator *(Vector3 left, float s)
            {
                return new Vector3(left.x * s, left.y * s, left.z * s);
            }

            public static Vector3 operator *(float s, Vector3 right)
            {
                return new Vector3(s + right.x, s + right.y, s + right.z);
            }

            public static Vector3 operator *(Matrix3 m, Vector3 v)
            {
                return new Vector3(
                    v.x * m.m01 + v.y * m.m02 + v.z * m.m03,
                    v.x * m.m11 + v.y * m.m12 + v.z * m.m13,
                    v.x * m.m21 + v.y * m.m22 + v.z * m.m23);
            }

            public float Dot(Vector3 right)
            {
                return x * right.x + y * right.y + z * right.z;
            }

            public Vector3 Cross(Vector3 right)
            {
                return new Vector3(
                    y * right.z - z * right.y,
                    z * right.x - x * right.z,
                    x * right.y - y * right.x);
            }

            public float Magnitude()
            {
                return (float)Math.Sqrt(x * x + y * y + z * z); 
            }

            public void Normalize()
            {
                float m = Magnitude();
                x /= m;
                y /= m;
                z /= m;
            }
        }

        public class Vector4
        {
            Vector4(float x, float y, float z, float w)
            {

            }
        }

        public class Matrix3
        {
            public float m01, m02, m03;
            public float m11, m12, m13;
            public float m21, m22, m23;
            public Matrix3( 
                float m1, float m2, float m3,
                float m4, float m5, float m6,
                float m7, float m8, float m9)
            {
                m01 = m1;
                m02 = m2;
                m03 = m3;
                m11 = m4;
                m12 = m5;
                m13 = m6;
                m21 = m7;
                m22 = m8;
                m23 = m9;
            }
            //maybe simplify this?
            public static Matrix3 operator *(Matrix3 m1, Matrix3 m2)
            {
                return new Matrix3(
                    m1.m01 * m2.m01 + m1.m11 * m2.m02 + m1.m21 * m2.m03,
                    m1.m02 * m2.m01 + m1.m12 * m2.m02 + m1.m22 * m2.m03,
                    m1.m03 * m2.m01 + m1.m13 * m2.m02 + m1.m23 * m2.m03,

                    m1.m01 * m2.m11 + m1.m11 * m2.m12 + m1.m21 * m2.m13,
                    m1.m02 * m2.m11 + m1.m12 * m2.m12 + m1.m22 * m2.m13,
                    m1.m03 * m2.m11 + m1.m13 * m2.m12 + m1.m23 * m2.m13,

                    m1.m01 * m2.m21 + m1.m11 * m2.m22 + m1.m21 * m2.m23,
                    m1.m02 * m2.m21 + m1.m12 * m2.m22 + m1.m22 * m2.m23,
                    m1.m03 * m2.m21 + m1.m13 * m2.m22 + m1.m23 * m2.m23);
            }


        }

        public class Matrix4
        {
            Matrix4(
                float m1, float m2, float m3, float m4,
                float m5, float m6, float m7, float m8,
                float m9, float m10, float m11, float m12,
                float m13, float m14, float m15, float m16
                )
            {

            }
        }

        public class Color
        {
            public UInt32 color;

            public Color() { }

            Color(byte r, byte g, byte b, byte a)
            {

            }

            
        }
    }
}
