using System.Text;

namespace DinoGameTeam
{
    public class Window
    {
        public int _width;
        public int _height;
        private ConsolePixel[,] _consoleBuffer;
        private byte[,] _depthBuffer;
        public Window(int width, int height)
        {
            _width = width;
            _height = height;
            _consoleBuffer = new ConsolePixel[width, height];
            for (int x = 0; x < width; x++)
            {
                for (int y = 0; y < height; y++)
                {
                    _consoleBuffer[x, y] = new ConsolePixel();
                }
            }
            _depthBuffer = new byte[width, height];
            Console.CursorVisible = false;
            Console.SetWindowSize(_width, _height + 1);
            Console.OutputEncoding = Encoding.UTF8;
        }

        public void Draw(params IDrawable[] drawables)
        {
            // Clear the console and depth buffers from the previous frame
            ClearConsoleBuffer();
            ClearDepthBuffer();

            StringBuilder consoleString = new StringBuilder();

            // Update the console buffer with each pixel
            foreach (var drawableItem in drawables)
            {
                foreach (Pixel pixel in drawableItem.Pixels)
                {
                    int absolutePixelX = (int)drawableItem.X + pixel.X;
                    int absolutePixelY = (int)drawableItem.Y + pixel.Y;
                    if (absolutePixelX >= 0 && absolutePixelX < _width
                        && absolutePixelY >= 0 && absolutePixelY < _height
                        && pixel.Depth <= _depthBuffer[absolutePixelX, absolutePixelY])
                    {
                        ConsolePixel cbPixel = _consoleBuffer[absolutePixelX, absolutePixelY];
                        // If the pixel doesn't want to use it's own background use the consoles
                        if (!pixel.UseConsoleBackground)
                        {
                            cbPixel.BackGroundColor = pixel.BackGroundColor;
                        }
                        cbPixel.TextColor = pixel.TextColor;
                        cbPixel.Representation = pixel.Representation;
                        cbPixel.BackgroundNecessary = pixel.BackgroundNecessary;
                        
                        // Update the depth buffer with the pixels depth value
                        _depthBuffer[absolutePixelX, absolutePixelY] = pixel.Depth;
                    }
                }
            }

            // Covert the console buffer to a string so we can output it all at once
            for (int y = 0; y < _height; ++y)
            {
                for (int x = 0; x < _width; ++x)
                {
                    consoleString.Append(_consoleBuffer[x, y].ToString());
                }
                if (y < _height - 1)
                {
                    consoleString.Append("\n");
                }
            }

            
            Console.SetCursorPosition(0, 0);

            // Draw to the console
            Console.Write(consoleString.ToString());
        }

        private void ClearConsoleBuffer()
        {
            for (int x = 0; x < _width; ++x)
            {
                for (int y = 0; y < _height; ++y)
                {
                    ConsolePixel cbPixel = _consoleBuffer[x, y];
                    cbPixel.Representation = ' ';
                    cbPixel.BackgroundNecessary = false;
                }
            }
        }

        private void ClearDepthBuffer()
        {
            for (int x = 0; x < _width; ++x)
            {
                for (int y = 0; y < _height; ++y)
                {
                    _depthBuffer[x, y] = byte.MaxValue;
                }
            }
        }
    }
}
