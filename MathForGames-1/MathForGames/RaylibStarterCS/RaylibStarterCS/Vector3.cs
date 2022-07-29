using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MathClasses
{
    public struct Vector3
    {
        public float x, y, z;

        public Vector3(float X, float Y, float Z)
        {
            x = X;
            y = Y;
            z = Z;
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
            return new Vector3(s * right.x, s * right.y, s * right.z);
        }

        public static Vector3 operator *(Matrix3 m, Vector3 v)
        {
            return new Vector3(
                v.x * m.m00 + v.y * m.m10 + v.z * m.m20,
                v.x * m.m01 + v.y * m.m11 + v.z * m.m21,
                v.x * m.m02 + v.y * m.m12 + v.z * m.m22);
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

}
