using System;
using static System.Console;

class Program
{
    class Caesar
    {
        public string Encode(string message, int key)
        {
            char[] buffer = message.ToCharArray();
            for (int i = 0; i < buffer.Length; i++)
            {
                bool upper = Char.IsUpper(buffer[i]);
                char letter = Char.ToLower(buffer[i]);
                if (Char.IsLetter(letter))
                {
                    letter = (char)(letter + key);
                    if (letter > 'z')
                    {
                        letter = (char)(letter - 26);
                    }
                    else if (letter < 'a')
                    {
                        letter = (char)(letter + 26);
                    }
                }
                if (upper)
                {
                    letter = Char.ToUpper(letter);
                }
                buffer[i] = letter;
            }
            return new string(buffer);
        }

        public string Decode(string message, int key)
        {
            char[] buffer = message.ToCharArray();
            for (int i = 0; i < buffer.Length; i++)
            {
                char letter = Char.ToLower(buffer[i]);
                if (Char.IsLetter(letter))
                {
                    letter = (char)(letter - key);
                    if (letter > 'z')
                    {
                        letter = (char)(letter - 26);
                    }
                    else if (letter < 'a')
                    {
                        letter = (char)(letter + 26);
                    }
                }
                buffer[i] = letter;
            }
            return new string(buffer);
        }
    }

    class Atbash
    {

    }

    static void Main()
    {
        OutputEncoding = System.Text.Encoding.UTF8;
        bool repeatProgram = true;

        while (repeatProgram)
        {
            Clear();
            CursorVisible = true;

            WriteLine("Would you like to decode a cipher or encode a message?");
            WriteLine("   Decode");
            WriteLine("   Encode");
            int selection = 1;
            bool selected = false;
            int mode = 0; // 1 = decode  2 = encode

            while (!selected)
            {
                SetCursorPosition(1,selection);
                switch (ReadKey(true).Key)
                {
                    case ConsoleKey.UpArrow:
                    {
                        if (selection > 1) { selection--; }
                        break;
                    }
                    case ConsoleKey.DownArrow:
                    {
                        if (selection < 2) { selection++; }
                        break;
                    }
                    case ConsoleKey.Enter:
                    {
                        selected = true;
                        mode = selection;
                        break;
                    }
                }
            }

            Clear();
            string message;
            if (mode == 1)
            {
                WriteLine("Enter the message you would like to decode.");
            }
            else
            {
                WriteLine("Enter the message you would like to encode.");
            }
            message = ReadLine();

            Clear();
            WriteLine("Select which cipher you would like to use.");
            WriteLine("   Caesar");
            WriteLine("   Atbash");
            WriteLine("   Binary");
            WriteLine("   Base64");
            selection = 1;
            selected = false;
            int cipher = 0; // 1 = Caesar  2 = Atbash  3 = Binary  4 = Base64

            while (!selected)
            {
                SetCursorPosition(1,selection);
                switch (ReadKey(true).Key)
                {
                    case ConsoleKey.UpArrow:
                    {
                        if (selection > 1) { selection--; }
                        break;
                    }
                    case ConsoleKey.DownArrow:
                    {
                        if (selection < 4) { selection++; }
                        break;
                    }
                    case ConsoleKey.Enter:
                    {
                        selected = true;
                        cipher = selection;
                        break;
                    }
                }
            }

            Clear();
            string decodedMessage = "Default message";
            Caesar caesar = new Caesar();
            if (mode == 1)
            {
                if (cipher == 1)
                {
                    decodedMessage = caesar.Decode(message, 1);
                }
                else if (cipher == 2)
                {
                    decodedMessage = "Not implemented yet.";
                }
                else if (cipher == 3)
                {
                    decodedMessage = "Not implemented yet.";
                }
                else if (cipher == 4)
                {
                    decodedMessage = "Not implemented yet.";
                }
                else
                {
                    decodedMessage = "Invalid cipher.";
                }
            }
            else
            {
                if (cipher == 1)
                {
                    decodedMessage = caesar.Encode(message, 1);
                }
                else if (cipher == 2)
                {
                    decodedMessage = "Not implemented yet.";
                }
                else if (cipher == 3)
                {
                    decodedMessage = "Not implemented yet.";
                }
                else if (cipher == 4)
                {
                    decodedMessage = "Not implemented yet.";
                }
                else
                {
                    decodedMessage = "Invalid cipher.";
                }
            }
            
            if (cipher == 1)
            {
                int key = 1;
                selected = false;
                while (!selected)
                {
                    Clear();
                    WriteLine(decodedMessage);
                    WriteLine("\nKey: " + key);
                    WriteLine("Press UP/DOWN to change the key.");
                    WriteLine("\nPress SPACE to decode/encode another message.");
                    WriteLine("Press ENTER to exit the program.");
                    selected = false;
                    CursorVisible = false;
                    switch (ReadKey(true).Key)
                    {
                        case ConsoleKey.UpArrow:
                        {
                            if (key < 25) { key++; }
                            if (mode == 1)
                            {
                                decodedMessage = caesar.Decode(message, key);
                            }
                            else
                            {
                                decodedMessage = caesar.Encode(message, key);
                            }
                            break;
                        }
                        case ConsoleKey.DownArrow:
                        {
                            if (key > 1) { key--; }
                            decodedMessage = caesar.Encode(message, key);
                            break;
                        }
                        case ConsoleKey.Spacebar:
                        {
                            selected = true;
                            break;
                        }
                        case ConsoleKey.Enter:
                        {
                            selected = true;
                            repeatProgram = false;
                            break;
                        }
                    }
                }

            }
            else
            {
                WriteLine(decodedMessage);
                WriteLine("\nPress SPACE to decode/encode another message.");
                WriteLine("Press ENTER to exit the program.");
                selected = false;
                CursorVisible = false;
                while (!selected)
                {
                    switch (ReadKey(true).Key)
                    {
                        case ConsoleKey.Spacebar:
                        {
                            selected = true;
                            break;
                        }
                        case ConsoleKey.Enter:
                        {
                            selected = true;
                            repeatProgram = false;
                            break;
                        }
                    }
                }
            }
        }

        Clear();
        WriteLine("Thanks for using this program.");
    }
}