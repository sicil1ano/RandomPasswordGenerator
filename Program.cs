using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;

namespace RandomPasswordGenerator
{
    class Program
    {
        static string newPassword;
        static PasswordGenerator passGen = new PasswordGenerator();
        static bool newPasswordCreation = true;
        static bool exitApplication;

        [STAThread] // this is neeeded to avoid the exception : "Current thread must be set to single thread apartment (sta) mode before ole calls can be made"
        //just when executing System.Windows.Forms.Clipboard.SetText(); to copy the password to clipboard!
        static void Main(string[] args)
        {
            while (!exitApplication && newPasswordCreation)
            {
                DisplayWelcomeMessage();
                Console.WriteLine("A strong password must have at least 8 characters.");
                newPassword = PasswordCreation();
                DisplayPassword(newPassword);
                DisplayPasswordMD5Hash(newPassword);
                ShowCopyToClipboardHint();
                CreateNewPasswordHint();
            }
            Console.WriteLine();
            Console.WriteLine("Press any key to exit the application..");
            Console.ReadKey();
        }

        static void DisplayWelcomeMessage()
        {
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("RANDOM PASSWORD GENERATOR!");
            Console.WriteLine("=========================");
            Console.WriteLine();
            Console.ForegroundColor = ConsoleColor.White; 
        }

        static void DisplayPassword(string password)
        {
            Console.WriteLine("New random password created! --> " + password);
        }

        static void DisplayPasswordMD5Hash(string password)
        {
            Console.WriteLine("With an MD5 hash of --> " + passGen.calcMD5Hash(password));
        }

        static string PasswordCreation()
        {
            string password = passGen.createPassword();
            return password;
        }

        static void CreateNewPasswordHint()
        {
            Console.WriteLine("Would you like to create a new random password?");
            Console.WriteLine("Y : Yes - N: No, thanks!");
            ConsoleKeyInfo key = Console.ReadKey();
            Console.Write("\b");
            switch (key.Key)
            {
                case ConsoleKey.Y:
                    newPasswordCreation = true;
                    Console.Clear();
                    break;

                case ConsoleKey.N:
                    Console.WriteLine("Ok, another password won't be created. The application will exit..");
                    newPasswordCreation = false;
                    exitApplication = true;
                    break;
                default:
                    Console.WriteLine("Wrong key pressed, man!");
                    break;
            }
        }

        static void ShowCopyToClipboardHint()
        {
            Console.WriteLine("Do you want to copy the password to the clipboard?");
            Console.WriteLine("Y : Yes - N: No, thanks!");
            ConsoleKeyInfo key = Console.ReadKey();
            Console.Write("\b");
            switch (key.Key)
            {
                case ConsoleKey.Enter: // Assume Enter = Y
                case ConsoleKey.Y:
                    CopyPasswordToClipboard(newPassword);
                    Console.WriteLine("The password has been copied to your clipboard!");
                    break;

                case ConsoleKey.N:
                    Console.WriteLine("Ok, no password copied!");
                    break;
                default:
                    Console.WriteLine("Wrong key pressed, man!");
                    break;
            }
        }

        static void CopyPasswordToClipboard(string stringToCopy)
        {
            System.Windows.Forms.Clipboard.SetText(stringToCopy);
        }

    }
}
