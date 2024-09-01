using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Maces;

class AssetsGenerator
{
    public Texture2D CreateGrayscaleTexture(GraphicsDevice graphicsDevice, int width, int height, byte grayValue)
    {
        Texture2D texture = new Texture2D(graphicsDevice, width, height);
        Color[] colorData = new Color[width * height];

        for (int i = 0; i < colorData.Length; i++)
        {
            colorData[i] = new Color(grayValue, grayValue, grayValue);
        }

        texture.SetData(colorData);
        return texture;
    }
}
