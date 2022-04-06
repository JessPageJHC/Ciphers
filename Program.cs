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
                char letter = buffer[i];
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
                buffer[i] = letter;
            }
            return new string(buffer);
        }
    }

    static void Main()
    {
        OutputEncoding = System.Text.Encoding.UTF8;
        Clear();

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
        Caesar caesar = new Caesar();
        WriteLine(caesar.Encode(message, 1));
    }
}