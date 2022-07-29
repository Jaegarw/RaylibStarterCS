using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MathClasses
{
    public struct Vector4
    {
        public float x, y, z, w;

        public Vector4(float X, float Y, float Z, float W)
        {
            x = X;
            y = Y;
            z = Z;
            w = W;
        }
        public static Vector4 operator +(Vector4 left, Vector4 right)
        {
            return new Vector4(left.x + right.x, left.y + right.y, left.z + right.z, left.w + right.w);
        }

        public static Vector4 operator -(Vector4 left, Vector4 right)
        {
            return new Vector4(left.x - right.x, left.y - right.y, left.z - right.z, left.w - right.w);
        }

        public static Vector4 operator *(Vector4 left, float s)
        {
            return new Vector4(left.x * s, left.y * s, left.z * s, left.w * s);
        }

        public static Vector4 operator *(float s, Vector4 right)
        {
            return new Vector4(s * right.x, s * right.y, s * right.z, s * right.w);
        }

        public float Dot(Vector4 right)
        {
            return x * right.x + y * right.y + z * right.z + w * right.w;
        }
        public Vector4 Cross(Vector4 right)
        {
            return new Vector4(
                y * right.z - z * right.y,
                z * right.x - x * right.z,
                x * right.y - y * right.x, 0);
        }

        public float Magnitude()
        {
            return (float)Math.Sqrt(x * x + y * y + z * z + w * w);
        }

        public void Normalize()
        {
            float m = Magnitude();
            x /= m;
            y /= m;
            z /= m;
            w /= m;
        }
    }
}
