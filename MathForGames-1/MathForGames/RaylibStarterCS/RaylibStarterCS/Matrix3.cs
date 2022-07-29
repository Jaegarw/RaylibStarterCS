using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;




namespace MathClasses
{
   
    public class Matrix3
    {
        public float m00, m01, m02;
        public float m10, m11, m12;
        public float m20, m21, m22;

        public Matrix3()
        {

        }
        public Matrix3(int mI)
        {

        }

        public Matrix3(
            float m1, float m2, float m3,
            float m4, float m5, float m6,
            float m7, float m8, float m9)
        {
            m00 = m1;
            m01 = m2;
            m02 = m3;
            m10 = m4;
            m11 = m5;
            m12 = m6;
            m20 = m7;
            m21 = m8;
            m22 = m9;
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
                return new Vector3(m02, m22, 0);
            }
        }
        public static Matrix3 identity = new Matrix3(1, 0, 0, 0, 1, 0, 0, 0, 1);
        public static Matrix3 operator *(Matrix3 m1, Matrix3 m2)
        {
            return new Matrix3(
                m1.m00 * m2.m00 + m1.m10 * m2.m01 + m1.m20 * m2.m02,
                m1.m01 * m2.m00 + m1.m11 * m2.m01 + m1.m21 * m2.m02,
                m1.m02 * m2.m00 + m1.m12 * m2.m01 + m1.m22 * m2.m02,

                m1.m00 * m2.m10 + m1.m10 * m2.m11 + m1.m20 * m2.m12,
                m1.m01 * m2.m10 + m1.m11 * m2.m11 + m1.m21 * m2.m12,
                m1.m02 * m2.m10 + m1.m12 * m2.m11 + m1.m22 * m2.m12,

                m1.m00 * m2.m20 + m1.m10 * m2.m21 + m1.m20 * m2.m22,
                m1.m01 * m2.m20 + m1.m11 * m2.m21 + m1.m21 * m2.m22,
                m1.m02 * m2.m20 + m1.m12 * m2.m21 + m1.m22 * m2.m22);
        }
        public Matrix3 GetTransposed()
        {
            return new Matrix3(m00, m10, m20, m01, m11, m21, m02, m12, m22);
        }
        public void SetTranslation(float x, float y)
        {
            Set(identity);

            m20 = x;
            m21 = y;

        }

        public void Translate(float x, float y)
        {
            Matrix3 m = new Matrix3();
            m.SetTranslation(x, y);
            Set(this * m);


        }

        public void SetRotateX(double radians)
        {
            Set(1, 0, 0, 0, (float)Math.Cos(radians), (float)Math.Sin(radians), 0, (float)-Math.Sin(radians), (float)Math.Cos(radians));
        }
        public void RotateX(double radians)
        {
            Matrix3 m = new Matrix3();
            m.SetRotateX(radians);
            Set(this * m);
        }
        public void SetRotateY(double radians)
        {
            Set((float)Math.Cos(radians), 0, (float)-Math.Sin(radians), 0, 1, 0, (float)Math.Sin(radians), 0, (float)Math.Cos(radians));
        }
        public void RotateY(double radians)
        {
            Matrix3 m = new Matrix3();
            m.SetRotateY(radians);
            Set(this * m);
        }
        public void SetRotateZ(double radians)
        {
            Set((float)Math.Cos(radians), (float)Math.Sin(radians), 0, (float)-Math.Sin(radians), (float)Math.Cos(radians), 0, 0, 0, 1);
        }
        public void RotateZ(double radians)
        {
            Matrix3 m = new Matrix3();
            m.SetRotateZ(radians);
            Set(this * m);
        }
        void SetEuler(float pitch, float yaw, float roll)
        {
            Matrix3 x = new Matrix3();
            Matrix3 y = new Matrix3();
            Matrix3 z = new Matrix3();
            x.SetRotateX(pitch);
            y.SetRotateY(yaw);
            z.SetRotateZ(roll);
        }
        public void SetScale(float x, float y, float z)
        {
            m00 = x; m01 = 0; m02 = 0;
            m10 = 0; m11 = y; m12 = 0;
            m20 = 0; m21 = 0; m22 = z;
        }
        public void SetScale(Vector3 v)
        {
            m00 = v.x; m01 = 0; m02 = 0;
            m10 = 0; m11 = v.y; m12 = 0;
            m20 = 0; m21 = 0; m22 = v.z;
        }
        public void Scale(float x, float y, float z)
        {
            Matrix3 m = new Matrix3();
            m.SetScale(x, y, z);

            Set(this * m);
        }

        void Scale(Vector3 v)
        {
            Matrix3 m = new Matrix3();
            m.SetScale(v.x, v.y, v.z);
            Set(this * m);
        }
        public void Set(Matrix3 m)
        {
            m00 = m.m00;
            m01 = m.m01;
            m02 = m.m02;
            m10 = m.m10;
            m11 = m.m11;
            m12 = m.m12;
            m20 = m.m20;
            m21 = m.m21;
            m22 = m.m22;
        }
        void Set(float m1, float m2, float m3, float m4, float m5, float m6, float m7, float m8, float m9)
        {
            m00 = m1;
            m01 = m2;
            m02 = m3;
            m10 = m4;
            m11 = m5;
            m12 = m6;
            m20 = m7;
            m21 = m8;
            m22 = m9;
        }
    }


}