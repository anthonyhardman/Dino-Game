using System.IO;

namespace DinoGameTeam
{
    public class Utils
    {
        // This function is specifically for loading pixels from my special pixel file format
        // If you want to use that let me know and I'll send you the github repo to clone and tell you how it works
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

        // This function is for loading pixels from your standard text file. Essentially you type up whatever you want to draw in a text file such as
        /*          ########
                   ## ######
                   #########
            #    ###########
            ##  #######
            ################
             ##########    #
              #########
              ####  ##
              ###   ##
              ##    ##
              ####  ####      */
        // pass the file path to this function as well as the text color aka (frontR, frontG, and frontB) if you want to specify depth and background 
        // colors you can but they have default values if you don't want to worry about that. If you don't provide a background color it will use the windows
        // background color.
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


        // This function is for loading pixels from a string. You need only provide the string and text color aka (frontG, frontB, frontG) 
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

        // If you want to change a pixels color directly this will be the easiest way to do it
        // You need do something like this somePixel.TextColor = Utils.RGBtoTextColor(255,255,255);
        public static string RGBtoTextColor(int r, int g, int b)
        {
            return $"\x1b[38;2;{r};{g};{b}m";
        }

        // If you want to change a pixels background color directly this will be the easiest way to do it
        // You need do something like this somePixel.TextColor = Utils.RGBtoTextColor(255,255,255);
        public static string RGBtoBackgroundColor(int r, int g, int b)
        {
            return $"\u001b[48;2;{r};{g};{b}m";
        }
    }
}
