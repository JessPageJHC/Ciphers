﻿using System;
using System.Text;
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
                bool upper = Char.IsUpper(buffer[i]);
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
                if (upper)
                {
                    letter = Char.ToUpper(letter);
                }
                buffer[i] = letter;
            }
            return new string(buffer);
        }
    }

    class Atbash
    {
        public string GetAtbash(string s)
        {
            var charArray = s.ToCharArray();

            for (int i = 0; i < charArray.Length; i++)
            {
                char c = charArray[i];

                if (c >= 'a' && c <= 'z')
                {
                    charArray[i] = (char) (96 + (123 - c));
                }

                if (c >= 'A' && c <= 'Z')
                {
                    charArray[i] = (char) (64 + (91 - c));
                }
            }

            return new String(charArray);
        }
    }

    class Binary
    {
        public string Encode(string message)
        {
            StringBuilder sb = new StringBuilder();
        
            foreach (char c in message.ToCharArray())
            {
                sb.Append(Convert.ToString(c, 2).PadLeft(8, '0'));
            }
            return sb.ToString();
        }

        public string Decode(string message)
        {
            List<Byte> byteList = new List<Byte>();
        
            for (int i = 0; i < message.Length; i += 8)
            {
                byteList.Add(Convert.ToByte(message.Substring(i, 8), 2));
            }
            return Encoding.ASCII.GetString(byteList.ToArray());
        }
    }

    class Base64
    {
        public string Encode(string message)
        {
            var valueBytes = Encoding.UTF8.GetBytes(message);
            return Convert.ToBase64String(valueBytes);
        }

        public string Decode(string message)
        {
            var valueBytes = System.Convert.FromBase64String(message);
            return Encoding.UTF8.GetString(valueBytes);
        }
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
            Atbash atbash = new Atbash();
            Binary binary = new Binary();
            Base64 base64 = new Base64();
            if (mode == 1)
            {
                if (cipher == 1)
                {
                    decodedMessage = caesar.Decode(message, 1);
                }
                else if (cipher == 2)
                {
                    decodedMessage = atbash.GetAtbash(message);
                }
                else if (cipher == 3)
                {
                    try
                    {
                        decodedMessage = binary.Decode(message);
                    }
                    catch
                    {
                        decodedMessage = "Invalid binary message.\n(Binary messages can only consist of 0 and 1!)";
                    }
                }
                else if (cipher == 4)
                {
                    try
                    {
                        decodedMessage = base64.Decode(message);
                    }
                    catch
                    {
                        decodedMessage = "Invalid Base 64 message.";
                    }
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
                    decodedMessage = atbash.GetAtbash(message);
                }
                else if (cipher == 3)
                {
                    decodedMessage = binary.Encode(message);
                }
                else if (cipher == 4)
                {
                    decodedMessage = base64.Encode(message);
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