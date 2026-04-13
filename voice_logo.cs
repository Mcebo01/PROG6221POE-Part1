using System;
using System.Drawing;
using System.Media;
using System.IO;
using System.Threading;

namespace ai_chat1
{
    public class voice_logo
    {
        string basePath = AppDomain.CurrentDomain.BaseDirectory;
        string projectPath;

        public voice_logo()
        {
            projectPath = Directory.GetParent(basePath).Parent.Parent.FullName;

            greetings();
            Thread.Sleep(2000);
            asci();
        }

        private void greetings()
        {
            string audioPath = Path.Combine(projectPath, "greeting.wav"); //  correct file name

            try
            {
                SoundPlayer greet = new SoundPlayer(audioPath);
                greet.Play();
            }
            catch (Exception ex)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Error loading audio: " + ex.Message);
                Console.ResetColor();
            }
        }

        private void asci()
        {
            string imagePath = Path.Combine(projectPath, "logo.jpg");

            try
            {
                Bitmap image = new Bitmap(imagePath); // fixed

                int width = 100;
                int height = 70;

                Bitmap resized = new Bitmap(image, new Size(width, height));

                string asciiChars = "@#S%?*+;:,. ";

                Console.ForegroundColor = ConsoleColor.DarkGreen;

                for (int y = 0; y < resized.Height; y++)
                {
                    for (int x = 0; x < resized.Width; x++)
                    {
                        Color pixel = resized.GetPixel(x, y);
                        int gray = (pixel.R + pixel.G + pixel.B) / 3;
                        int index = (gray * (asciiChars.Length - 1)) / 255;

                        Console.Write(asciiChars[index]);
                    }
                    Console.WriteLine();
                }

                Console.ResetColor();
            }
            catch (Exception ex)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Error loading image: " + ex.Message);
                Console.ResetColor();
            }
        }
    }
}