using System;
using System.Collections.Generic;
using System.Text;

using OpenTK;
using OpenTK.Graphics.OpenGL;

namespace SVNE.Core {
    class Functions {
        public static void Draw(int texture, int x, int y, int width, int height) {
            GL.MatrixMode(MatrixMode.Modelview);
            GL.LoadIdentity();
            GL.BindTexture(TextureTarget.Texture2D, texture);

            GL.Begin(PrimitiveType.Quads);

            GL.TexCoord2(0.0f, 1.0f); GL.Vertex2(PixelToGL(x, y + height)[0], PixelToGL(x, y + height)[1]);
            GL.TexCoord2(1.0f, 1.0f); GL.Vertex2(PixelToGL(x + width, y + height)[0], PixelToGL(x + width, y + height)[1]);
            GL.TexCoord2(1.0f, 0.0f); GL.Vertex2(PixelToGL(x + width, y)[0], PixelToGL(x + width, y)[1]);
            GL.TexCoord2(0.0f, 0.0f); GL.Vertex2(PixelToGL(x, y)[0], PixelToGL(x, y)[1]);

            GL.End();
        }

        public static void DrawGFX(int texture) {
            GL.MatrixMode(MatrixMode.Modelview);
            GL.LoadIdentity();

            GL.Enable(EnableCap.Texture2D);
            GL.BindTexture(TextureTarget.Texture2D, texture);
            GL.Begin(PrimitiveType.Quads);

            GL.TexCoord2(0.0f, 1.0f); GL.Vertex2(-1f, -1f);
            GL.TexCoord2(1.0f, 1.0f); GL.Vertex2(1f, -1f);
            GL.TexCoord2(1.0f, 0.0f); GL.Vertex2(1f, 1f);
            GL.TexCoord2(0.0f, 0.0f); GL.Vertex2(-1f, 1f);

            GL.End();
        }

        public static float[] PixelToGL(int x, int y) {
            float[] coord = new float[2];

            coord[0] = ((x + 0.5f) / DisplayDevice.Default.Width) * 2.0f - 1.0f;
            coord[1] = 1.0f - ((y + 0.5f) / DisplayDevice.Default.Height) * 2.0f;

            return coord;
        }

        public Bitmap TakeScreenshot() {
            if (GraphicsContext.CurrentContext == null) {
                throw new GraphicsContextMissingException();
            }

            int w = glControl1.ClientSize.Width;
            int h = glControl1.ClientSize.Height;
            Bitmap bmp = new Bitmap(w, h);
            System.Drawing.Imaging.BitmapData data = bmp.LockBits(glControl1.ClientRectangle, System.Drawing.Imaging.ImageLockMode.WriteOnly, System.Drawing.Imaging.PixelFormat.Format24bppRgb);
            GL.ReadPixels(0, 0, w, h, PixelFormat.Bgr, PixelType.UnsignedByte, data.Scan0);
            bmp.UnlockBits(data);

            bmp.RotateFlip(RotateFlipType.RotateNoneFlipY);
            return bmp;
        }
    }
}
