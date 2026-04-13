using System;

namespace ai_chat1
{
    // Handles user interaction (name input and greeting)
    public class UserInterface
    {
        // Store user name
        private string name = string.Empty;

        // Displays welcome banner
        public void DisplayWelcomeMessage()
        {
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine("===============================================================");
            Console.WriteLine("        CYBERSECURITY AWARENESS CHATBOT SYSTEM                ");
            Console.WriteLine("===============================================================");
            Console.ResetColor();
        }

        // Ask user for their name
        // Keeps the original void signature for compatibility with existing callers.
        public void AskName()
        {
            PrintBot("Hello! Welcome to the Cybersecurity Awareness Bot.");
            PrintBot("Please enter your name (type 'exit' to quit):");

            while (true)
            {
                SafeSetColor(ConsoleColor.Blue);
                console.Write("You: ");
                console.ResetColor();

                var input = console.ReadLine() ?? string.Empty;
                input = input.Trim();

                // Allow user to quit interaction
                if (string.Equals(input, "exit", StringComparison.OrdinalIgnoreCase) ||
                    string.Equals(input, "quit", StringComparison.OrdinalIgnoreCase))
                {
                    PrintBot("Goodbye!");
                    Name = string.Empty;
                    return;
                }

                Name = input;

                if (IsValidName(Name))
                {
                    GreetUser();
                    return;
                }

                // invalid -> loop again
            }
        }

        // Validate user name input
        private bool IsValidName(string name)
        {
            if (string.IsNullOrWhiteSpace(name))
            {
                PrintBot("Name cannot be empty. Please try again.");
                return false;
            }

            return true;
        }

        // Greet user after valid input
        private void GreetUser()
        {
            PrintBot($"Welcome {Name}! I'm here to help you stay safe online.");
        }

        // Standard chatbot output format
        private void PrintBot(string message)
        {
            SafeSetColor(ConsoleColor.Yellow);
            console.Write("ChatBot: ");

            SafeSetColor(ConsoleColor.Magenta);
            console.WriteLine(message);

            console.ResetColor();
        }

        // Return user's name (keeps existing API)
        public string GetName() => Name;

        // Helper that wraps color setting to avoid leaving console in wrong color if an exception occurs.
        private void SafeSetColor(ConsoleColor color)
        {
            try
            {
                console.SetForegroundColor(color);
            }
            catch
            {
                // If the underlying console does not support colors, ignore.
            }
        }
    }
}