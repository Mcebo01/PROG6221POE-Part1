using System;
using System.Drawing;
using System.Media;

namespace ai_chat1
{//start of namespace
    public class voice_logo
    {//start of class

        //Auto get the path directory of the project
        private string full_path = AppDomain.CurrentDomain.BaseDirectory;
        public voice_logo()
        {//start of constructor
            //]play the sound
            greetings();
            //wait for 2 second
            System.Threading.Thread.Sleep(2000);
            //turn logo to ascii
            asci();


        }//end of constructor

        //method to play the sound
        private void greetings()
        {
            string corrected_path = full_path.Replace(@"\bin\Debug\", @"\greeting.wav");

            try
            {
                SoundPlayer greet = new SoundPlayer(corrected_path);
                greet.Play();
            }
            catch (Exception ex)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Error loading audio: " + ex.Message);
                Console.ResetColor();
            }
        

            //use the soundPlay class to play audio
            //creating an instance of the SoundPlayer class
            //with an object name "greet"
            try
            {
                SoundPlayer greet = new SoundPlayer(corrected_path);
                greet.Play();
            }
            catch
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Audio file not found.");
                Console.ResetColor();
            }
        }//end of method

        //method to turn logo to ascii
        private void asci()
        {
            string path = full_path.Replace(@"\bin\Debug\", @"\logo.jpg");

            try
            {
                Bitmap image = new Bitmap(path);

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
    } //end of class
}//end of namespace