using System;
using System.Collections.Generic;
using System.Text;
using System.Numerics;
using MathClasses;

namespace MathClasses
{
    public class Matrix3
    {
        public float m01, m02, m03;
        public float m11, m12, m13;
        public float m21, m22, m23;

        public Matrix3()
        {

        }

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

        void Set(Matrix3 m)
        {
            m01 = m.m01;
            m02 = m.m02;
            m03 = m.m03;
            m11 = m.m11;
            m12 = m.m12;
            m13 = m.m13;
            m21 = m.m21;
            m22 = m.m22;
            m23 = m.m23;
        }

        void Set(float m1, float m2, float m3, float m4, float m5, float m6, float m7, float m8, float m9)
        {

        }

        public void SetRotateZ(double radians)
        {
            Set(1, 0, 0, 0, (float)Math.Cos(radians), (float)Math.Sin(radians), 0, (float)-Math.Sin(radians), (float)Math.Cos(radians));
        }

        public void RotateZ(double radians)
        {
            Matrix3 m = new Matrix3();
            m.SetRotateZ(radians);
            Set(this * m);
        }

        public void SetScaled(float x, float y, float z)
        {
            m01 = x; m02 = 0; m03 = 0; m11 = 0; m12 = y; m13 = 0; m21 = 0; m22 = 0; m23 = z;
        }

        public void Scale(float x, float y, float z)
        {
            Matrix3 m = new Matrix3();
            m.SetScaled(x, y, z);
            Set(this * m);
        }


        public void SetTranslation(float x, float y)
        {
            
            m21 = x; m22 = y;
        }

        internal void Translate(float x, float y)
        {   // apply vector offset
            Matrix3 m = new Matrix3();
            m.SetTranslation(x, y);

            Set(this * m);
        }

        public Vector3 Forward
        {
            get
            {
                return new Vector3(m11, m12, 0);
            }
        }


    }
}
