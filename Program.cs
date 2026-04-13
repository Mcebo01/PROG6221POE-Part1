using System;

namespace ai_chat1
{
    public class Program
    {
        static void Main(string[] args)
        {
            // Play sound + display logo
            new voice_logo();

            // User interface
            UserInterface ui = new UserInterface();
            ui.DisplayWelcomeMessage();
            ui.AskName();

            string name = ui.GetName(); // only once

            // Chatbot
            ChatBot bot = new ChatBot();
            bot.StartChat(name);
        }
    }
}