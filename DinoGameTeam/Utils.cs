using System.IO;

namespace DinoGameTeam
{
    public class Utils
    {
        public static Pixel[] LoadPixelsFromFile(string pixelFilePath, char rep, byte depth = 0, int backR = -1, int backG = -1, int backB = -1)
        {
            string[] pixelData = File.ReadAllLines(pixelFilePath);
            List<Pixel> pixels = new List<Pixel>();
            bool useConsoleBack= true;
            if (backR + backG + backB != -3)
            {
                useConsoleBack = false;
            }

            foreach (string pixel in pixelData)
            {
                string[] pixelComponents = pixel.Split(' ');
                pixels.Add(new Pixel()
                {
                    X = int.Parse(pixelComponents[0]),
                    Y = int.Parse(pixelComponents[1]),
                    TextColor = $"\x1b[38;2;{pixelComponents[2]};{pixelComponents[3]};{pixelComponents[4]}m",
                    BackGroundColor = $"\u001b[48;2;{backR};{backG};{backB}m",
                    Representation = rep,
                    Depth = depth,
                    UseConsoleBackground = useConsoleBack
                });
            }

            return pixels.ToArray();
        }

        public static Pixel[] LoadPixelsFromFile(string textFilePath, int frontR, int frontG, int frontB, byte depth = 0, int backR = -1, int backG = -1, int backB = -1)
        {
            string[] pixelData = File.ReadAllLines(textFilePath);
            List<Pixel> pixels = new List<Pixel>();
            bool useConsoleBack = true;
            if (backR + backG + backB != -3)
            {
                useConsoleBack = false;
            }


            for (int x = 0; x < pixelData.Length; x++)
            {
                for (int y= 0; y < pixelData[x].Length; y++)
                {
                    if (pixelData[x][y] != '\n' && pixelData[x][y] != ' ' && pixelData[x][y] != '\t')
                    {
                        pixels.Add(new Pixel()
                        {
                            X = y,
                            Y = x,
                            TextColor = $"\x1b[38;2;{frontR};{frontG};{frontB}m",
                            BackGroundColor = $"\u001b[48;2;{backR};{backG};{backB}m",
                            Representation = pixelData[x][y],
                            Depth = depth,
                            UseConsoleBackground = useConsoleBack
                        });
                    }
                }
            }

            return pixels.ToArray();
        }

        public static Pixel[] LoadPixelsFromString(string text, int frontR, int frontG, int frontB, byte depth = 0, int backR = -1, int backG = -1, int backB = -1)
        {
            List<Pixel> pixels = new List<Pixel>();
            bool useConsoleBack = true;
            if (backR + backG + backB != -3)
            {
                useConsoleBack = false;
            }

            for (int x = 0; x < text.Length; x++)
            {
                pixels.Add(new Pixel
                {
                    X = x,
                    Y = 0,
                    TextColor = $"\x1b[38;2;{frontR};{frontG};{frontB}m",
                    BackGroundColor = $"\u001b[48;2;{backR};{backG};{backB}m",
                    Representation = text[x],
                    Depth = depth,
                    UseConsoleBackground = useConsoleBack
                });
            }

            return pixels.ToArray();
        }

        public static string RGBtoTextColor(int r, int g, int b)
        {
            return $"\x1b[38;2;{r};{g};{b}m";
        }

        public static string RGBtoBackgroundColor(int r, int g, int b)
        {
            return $"\u001b[48;2;{r};{g};{b}m";
        }
    }
}
