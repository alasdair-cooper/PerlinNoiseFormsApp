using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Numerics;

using System.Diagnostics;

namespace PerlinNoise
{
    public static class PerlinNoise
    {
        private static float Interpolate(float a0, float a1, float w)
        {
            return (a1 - a0) * w + a0;
        }

        private static Vector2 RandomGradient(int ix, int iy)
        {
            float random = 2920f * (float)Math.Sin(ix * 21942f + iy * 171324f + 8912f) * (float)Math.Cos(ix * 23157f * iy * 217832f + 9758f);
            return new Vector2((float)Math.Cos(random), (float)Math.Sin(random));
        }

        private static float DotGridGradient(int ix, int iy, float x, float y)
        {
            Vector2 gradient = RandomGradient(ix, iy);

            float dx = x - (float)ix;
            float dy = y - (float)iy;

            return dx * gradient.X + dy * gradient.Y;
        }

        public static float Perlin(float x, float y)
        {
            int x0 = (int)x;
            int x1 = x0 + 1;
            int y0 = (int)y;
            int y1 = y0 + 1;

            float sx = x - (float)x0;
            float sy = y - (float)y0;

            float n0, n1, ix0, ix1, value;

            n0 = DotGridGradient(x0, y0, x, y);
            n1 = DotGridGradient(x1, y0, x, y);
            ix0 = Interpolate(n0, n1, sx);

            n0 = DotGridGradient(x0, y1, x, y);
            n1 = DotGridGradient(x1, y1, x, y);
            ix1 = Interpolate(n0, n1, sx);

            value = Interpolate(ix0, ix1, sy);
            return value;
        }

        static readonly int[] P = new int[] {
            151,160,137,91,90,15,
            131,13,201,95,96,53,194,233,7,225,140,36,103,30,69,142,8,99,37,240,21,10,23,
            190, 6,148,247,120,234,75,0,26,197,62,94,252,219,203,117,35,11,32,57,177,33,
            88,237,149,56,87,174,20,125,136,171,168, 68,175,74,165,71,134,139,48,27,166,
            77,146,158,231,83,111,229,122,60,211,133,230,220,105,92,41,55,46,245,40,244,
            102,143,54, 65,25,63,161, 1,216,80,73,209,76,132,187,208, 89,18,169,200,196,
            135,130,116,188,159,86,164,100,109,198,173,186, 3,64,52,217,226,250,124,123,
            5,202,38,147,118,126,255,82,85,212,207,206,59,227,47,16,58,17,182,189,28,42,
            223,183,170,213,119,248,152, 2,44,154,163, 70,221,153,101,155,167, 43,172,9,
            129,22,39,253, 19,98,108,110,79,113,224,232,178,185, 112,104,218,246,97,228,
            251,34,242,193,238,210,144,12,191,179,162,241, 81,51,145,235,249,14,239,107,
            49,192,214, 31,181,199,106,157,184, 84,204,176,115,121,50,45,127, 4,150,254,
            138,236,205,93,222,114,67,29,24,72,243,141,128,195,78,66,215,61,156,180,
            151,160,137,91,90,15,
            131,13,201,95,96,53,194,233,7,225,140,36,103,30,69,142,8,99,37,240,21,10,23,
            190, 6,148,247,120,234,75,0,26,197,62,94,252,219,203,117,35,11,32,57,177,33,
            88,237,149,56,87,174,20,125,136,171,168, 68,175,74,165,71,134,139,48,27,166,
            77,146,158,231,83,111,229,122,60,211,133,230,220,105,92,41,55,46,245,40,244,
            102,143,54, 65,25,63,161, 1,216,80,73,209,76,132,187,208, 89,18,169,200,196,
            135,130,116,188,159,86,164,100,109,198,173,186, 3,64,52,217,226,250,124,123,
            5,202,38,147,118,126,255,82,85,212,207,206,59,227,47,16,58,17,182,189,28,42,
            223,183,170,213,119,248,152, 2,44,154,163, 70,221,153,101,155,167, 43,172,9,
            129,22,39,253, 19,98,108,110,79,113,224,232,178,185, 112,104,218,246,97,228,
            251,34,242,193,238,210,144,12,191,179,162,241, 81,51,145,235,249,14,239,107,
            49,192,214, 31,181,199,106,157,184, 84,204,176,115,121,50,45,127, 4,150,254,
            138,236,205,93,222,114,67,29,24,72,243,141,128,195,78,66,215,61,156,180
        };

        /// <summary>
        /// Linearly interpolate a value between a min value and a max value
        /// </summary>
        /// <param name="w">Value</param>
        /// <param name="a">Min</param>
        /// <param name="b">Max</param>
        /// <returns></returns>
        static double Lerp(double t, double a, double b)
        {
            return a + t * (b - a);
        }

        static double Fade(double t)
        {
            return t * t * t * (t * (6 * t - 15) + 10);
        }

        static double Grad(int hash, double x, double y, double z)
        {
            hash &= 15;
            double u = (hash < 8) ? x : y;
            double v = (hash < 4) ? y : ((hash == 12 || hash == 14) ? x : z);
            return ((hash & 1) == 0 ? u : -u) + ((hash & 2) == 0 ? v : -v);
        }

        public static double Perlin(double X, double Y, double Z)
        {
            double Xfl = Math.Floor(X);
            double Yfl = Math.Floor(Y);
            double Zfl = Math.Floor(Z);
            int Xi = (int)(Xfl) & 255;
            int Yi = (int)(Yfl) & 255;
            int Zi = (int)(Zfl) & 255;
            X -= Xfl;
            Y -= Yfl;
            Z -= Zfl;
            double Xm1 = X - 1.0f;
            double Ym1 = Y - 1.0f;
            double Zm1 = Z - 1.0f;

            int A = P[Xi] + Yi;
            int AA = P[A] + Zi; int AB = P[A + 1] + Zi;

            int B = P[Xi + 1] + Yi;
            int BA = P[B] + Zi; int BB = P[B + 1] + Zi;

            double U = Fade(X);
            double V = Fade(Y);
            double W = Fade(Z);

            return
                Lerp(W,
                    Lerp(V,
                        Lerp(U,
                            Grad(P[AA], X, Y, Z),
                            Grad(P[BA], Xm1, Y, Z)),
                        Lerp(U,
                            Grad(P[AB], X, Ym1, Z),
                            Grad(P[BB], Xm1, Ym1, Z))),
                    Lerp(V,
                        Lerp(U,
                            Grad(P[AA + 1], X, Y, Zm1),
                            Grad(P[BA + 1], Xm1, Y, Zm1)),
                        Lerp(U,
                            Grad(P[AB + 1], X, Ym1, Zm1),
                            Grad(P[BB + 1], Xm1, Ym1, Zm1))));
        }
    }
}
