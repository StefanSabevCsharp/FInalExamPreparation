using System;
using System.Linq;

namespace FInalExamPreparation
{
    class Program
    {
        static void Main(string[] args)
        {
            string message = Console.ReadLine();
            string input = Console.ReadLine();

            while (input != "Decode")
            {
                string[] info = input.Split("|", StringSplitOptions.RemoveEmptyEntries);
                string command = info.First();
                if (command == "Move")
                {
                    int numberOfLetters = int.Parse(info[1]);
                    string letters = message.Substring(0, numberOfLetters);
                    message = message.Remove(0, numberOfLetters);
                    message = message.Insert(message.Length, letters);
                }
                else if (command == "Insert")
                {
                    int indexForInser = int.Parse(info[1]);
                    string valueToInsert = info[2];

                    message = message.Insert(indexForInser, valueToInsert);


                }
                else if (command == "ChangeAll")
                {
                    string oldMessage = info[1];
                    string newMessage = info[2];
                    message = message.Replace(oldMessage, newMessage);
                }

                input = Console.ReadLine();
            }
            Console.WriteLine($"The decrypted message is: {message}");
        }
    }
}
