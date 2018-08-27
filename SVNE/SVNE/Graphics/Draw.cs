using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenTK.Graphics.OpenGL;

namespace SVNE.Graphics {
    class Draw {
        public static void DrawTexture(int texture) {
            GL.BindTexture(TextureTarget.Texture2D, texture);

            GL.Begin(PrimitiveType.Quads);

            GL.TexCoord2(0.0f, 1.0f); GL.Vertex2(-0.5f, -0.5f);
            GL.TexCoord2(1.0f, 1.0f); GL.Vertex2(0.5f, -0.5f);
            GL.TexCoord2(1.0f, 0.0f); GL.Vertex2(0.5f, 0.5f);
            GL.TexCoord2(0.0f, 0.0f); GL.Vertex2(-0.5f, 0.5f);

            GL.End();
        }

        public static void DrawTexture(int texture, float x, float y, float width, float height) {
            GL.BindTexture(TextureTarget.Texture2D, texture);

            GL.Begin(PrimitiveType.Quads);

            GL.TexCoord2(0.0f, 1.0f); GL.Vertex2(x, y);
            GL.TexCoord2(1.0f, 1.0f); GL.Vertex2(x + width, y);
            GL.TexCoord2(1.0f, 0.0f); GL.Vertex2(x + width, y + height);
            GL.TexCoord2(0.0f, 0.0f); GL.Vertex2(x, y + height);

            GL.End();
        }
    }
}
