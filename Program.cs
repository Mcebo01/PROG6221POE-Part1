using System;

namespace ai_chat1
{//start of namespace
    public class Program
    {//start of class
        static void Main(string[] args)
        {//start of main method

            // Create an instance of the class voice_logo
            //without an object name but a constructor (with parameters)
            new voice_logo() { };

            //creating an instance for the class prompt_user 
            //with an object name collect_name
            prompt_user collect_name = new prompt_user();

            //call the welcome message method from the prompt_user class
            collect_name.DisplayWelcomeMessage();
            collect_name.asking_name();

            //instance for the class ai_response
            //with an object name chatting chatting
            ChatBot chatting = new ChatBot();

            //get the returned name of the user
            string name = collect_name.return_name();

            //now start the chatting
            chatting.StartChat(name);

        }//end of main method
    }//end of class
}//end of namespace
 //C:\Users\Student\source\repos\ai_chat1\bin\Debug\