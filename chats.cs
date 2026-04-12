using System;
using System.Collections.Generic;
using System.Threading;

namespace ai_chat1
{
    
    // Handles all chatbot interaction and responses
    public class ChatBot
    {
        // Dictionary to store keywords and responses
        private Dictionary<string, string> responses;

        // Constructor to initialize chatbot responses
        public ChatBot()
        {
            responses = new Dictionary<string, string>()
            {
                { "how are you", "I'm functioning perfectly! Ready to help you stay safe online." },
                { "purpose", "My purpose is to educate you about cybersecurity and online safety." },
                { "password", "Use strong passwords with at least 8 characters, including numbers, symbols, and uppercase letters." },
                { "phishing", "Phishing is a scam where attackers trick you into revealing personal information via fake emails or websites." },
                { "link", "Avoid clicking suspicious links. Always check if the URL is legitimate before opening it." },
                { "safe browsing", "Always use secure websites (https), avoid downloads from unknown sources, and keep your browser updated." }
            };
        }
        // Main chat loop
        public void StartChat(string userName)
        {
            DisplayHeader();

            string userInput;

            do
            {
                Console.ForegroundColor = ConsoleColor.Blue;
                Console.Write(userName + " : ");
                Console.ResetColor();

                userInput = Console.ReadLine();

            } while (ProcessInput(userInput));

            ExitMessage();
        }
        // Processes user input and returns false if user exits
        private bool ProcessInput(string input)
        {
            // Input validation
            if (string.IsNullOrWhiteSpace(input))
            {
                BotResponse("Please enter a valid question.");
                return true;
            }

            input = input.ToLower();

            // Exit condition
            if (input == "exit")
            {
                return false;
            }

            // Check for matching keywords
            foreach (var item in responses)
            {
                if (input.Contains(item.Key))
                {
                    BotResponse(item.Value);
                    return true;
                }
            }

            // Default response
            BotResponse("I didn’t quite understand that. Try asking about passwords, phishing, or safe browsing.");

            return true;
        }
        // Displays chatbot response with typing effect
        private void BotResponse(string message)
        {
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.Write("ChatBot : ");
            Console.ForegroundColor = ConsoleColor.White;

            TypeEffect(message);

            Console.ResetColor();
        }
        // Adds typing animation for better UI experience
        private void TypeEffect(string text)
        {
            foreach (char c in text)
            {
                Console.Write(c);
                Thread.Sleep(20); // small delay
            }
            Console.WriteLine();
        }
        // Displays header UI
        private void DisplayHeader()
        {
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("\n========================================");
            Console.WriteLine("     CYBERSECURITY AWARENESS BOT        ");
            Console.WriteLine("========================================\n");
            Console.ResetColor();
        }
        // Exit message
        private void ExitMessage()
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("\nChatBot: Goodbye! Stay safe online.");
            Console.ResetColor();
        }
    }
}