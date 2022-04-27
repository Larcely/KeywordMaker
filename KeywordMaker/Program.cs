using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.IO;

namespace KeywordMaker
{
    class Program
    {
        // Variables;
        public static string[] keywords = new string[512]; // For keyword storage, this's can be increased.
        public static string filepath; // File path for keywords save.
        public static int keywordslength = 0; //  For number of keywords.
        public static int totalkeyword = 0;

        public static void saveFile()
        {
            if (keywordslength <= 0)
            {
                Console.WriteLine("Please enter a keyword.");
            }
            else
            {
                if (filepath == "" || filepath == null)
                {
                    Console.WriteLine("Please enter file path.");
                }
                else
                {
                    StreamWriter stw = new StreamWriter(@filepath);
                    for (int z = 0; z < keywordslength; z++)
                    {
                        totalkeyword++;
                        Console.WriteLine(keywords[z]);
                        stw.WriteLine(keywords[z]);
                        for (int t = 0; t < keywordslength; t++)
                        {
                            totalkeyword++;
                            Console.WriteLine(keywords[z] + keywords[t]);
                            stw.WriteLine(keywords[z] + keywords[t]);
                            for (int e = 0; e < keywordslength; e++)
                            {
                                totalkeyword++;
                                Console.WriteLine(keywords[z] + keywords[t] + keywords[e]);
                                stw.WriteLine(keywords[z] + keywords[t] + keywords[e]);
                                for (int o = 0; o < keywordslength; o++)
                                {
                                    totalkeyword++;
                                    Console.WriteLine(keywords[z] + keywords[t] + keywords[e] + keywords[o]);
                                    stw.WriteLine(keywords[z] + keywords[t] + keywords[e] + keywords[o]);
                                }
                            }
                        }
                    }
                    stw.Dispose();
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.Write(totalkeyword.ToString());
                    Console.ForegroundColor = ConsoleColor.White;
                    Console.Write(" keyword created");
                }
            }
            Console.ReadKey();
        }

        public static void keywordSelect()
        {
            // Keyword menu
            Console.WriteLine("|------------------------------|");
            Console.WriteLine("|         Keyword List         |");
            Console.Write("|     Total keywords : "); Console.ForegroundColor = ConsoleColor.Red; Console.Write(keywordslength.ToString()); Console.ForegroundColor = ConsoleColor.White; Console.WriteLine("       |");
            Console.WriteLine("|------------------------------|");
            Console.WriteLine();
            for (int i = 0; i < keywordslength; i++)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.Write(i.ToString() + ". "); Console.ForegroundColor = ConsoleColor.White; Console.WriteLine(keywords[i]);
            }
            Console.WriteLine();
            Console.ForegroundColor = ConsoleColor.Magenta;
            Console.Write("1. ");
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine("Add keyword");
            Console.ForegroundColor = ConsoleColor.Magenta;
            Console.Write("2. ");
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine("Edit keyword");
            Console.ForegroundColor = ConsoleColor.Magenta;
            Console.Write("3. ");
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine("Remove keyword");
            Console.WriteLine();
            Console.ForegroundColor = ConsoleColor.Magenta;
            Console.Write("99. ");
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine("Back");
            Console.Write("Choose : ");
            Console.ForegroundColor = ConsoleColor.Magenta;
            string keywordinput = Console.ReadLine();
            Console.ForegroundColor = ConsoleColor.White;
            Console.Clear();
            if (keywordinput == "1" || keywordinput == "1.")
            {
                // ADD KEYWORD
                Console.ForegroundColor = ConsoleColor.Magenta;
                Console.Write(keywordslength.ToString());
                Console.ForegroundColor = ConsoleColor.White;
                Console.Write(".Keyword : ");
                string addkeyword = Console.ReadLine();
                Console.Clear();
                if (addkeyword == null || addkeyword == "")
                {
                    Console.WriteLine("Wrong input, please try again.");
                    Console.ReadKey();
                }
                else
                {
                    keywords[keywordslength] = addkeyword;
                    keywordslength++;
                }
            }
            else if (keywordinput == "2" || keywordinput == "2.")
            {
                // EDIT KEYWORD
                if (keywordslength <= 0)
                {
                    Console.Write("Please enter a keyword.");
                    Console.ReadKey();
                }
                else
                {
                    for (int i = 0; i < keywordslength; i++)
                    {
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.Write(i.ToString() + ". "); Console.ForegroundColor = ConsoleColor.White; Console.WriteLine(keywords[i]);
                    }
                    Console.Write("Please select keyword : ");
                    Console.ForegroundColor = ConsoleColor.Red;
                    string whichkeyword = Console.ReadLine();
                    Console.ForegroundColor = ConsoleColor.White;
                    Console.Clear();
                    try
                    {
                        // Here's user only can enter a number.
                        Convert.ToInt32(whichkeyword);
                        if (Convert.ToInt32(whichkeyword) >= keywordslength)
                        {
                            Console.WriteLine("Please enter a number in between 0 and " + keywordslength.ToString());
                        }
                        else
                        {
                            Console.ForegroundColor = ConsoleColor.Red;
                            Console.Write("Old");
                            Console.ForegroundColor = ConsoleColor.White;
                            Console.WriteLine(" value : " + keywords[Convert.ToInt32(whichkeyword)]);
                            Console.Write("New value : ");
                            Console.ForegroundColor = ConsoleColor.Red;
                            string newvalue = Console.ReadLine();
                            Console.Clear();
                            Console.ForegroundColor = ConsoleColor.White;
                            if (newvalue == "" || newvalue == null)
                            {
                                Console.WriteLine("Please try again.");
                            }
                            else
                            {
                                keywords[Convert.ToInt32(whichkeyword)] = newvalue;
                                Console.Write("Successful, it's has been changed to ");
                                Console.ForegroundColor = ConsoleColor.Red;
                                Console.Write(keywords[Convert.ToInt32(whichkeyword)]);
                                Console.ForegroundColor = ConsoleColor.White;
                            }
                        }
                        Console.ReadKey();
                    }
                    catch (Exception)
                    {
                        Console.Write("Please enter a ");
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.Write("NUMBER");
                        Console.ReadKey();
                    }
                }
            }
            else if (keywordinput == "3" || keywordinput == "3.")
            {
                // REMOVE KEYWORD
                if (keywordslength <= 0)
                {
                    Console.Write("Please enter a keyword.");
                    Console.ReadKey();
                }
                else
                {
                    for (int i = 0; i < keywordslength; i++)
                    {
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.Write(i.ToString() + ". "); Console.ForegroundColor = ConsoleColor.White; Console.WriteLine(keywords[i]);
                    }
                    Console.Write("Which keyword do you want remove? : ");
                    Console.ForegroundColor = ConsoleColor.Magenta;
                    string whichremove = Console.ReadLine();
                    Console.ForegroundColor = ConsoleColor.White;
                    Console.Clear();
                    try
                    {
                        Convert.ToInt32(whichremove);
                        if (Convert.ToInt32(whichremove) >= keywordslength)
                        {
                            Console.WriteLine("Please enter a number in between 0 and " + keywordslength.ToString());
                        }
                        else
                        {
                            for (int y = Convert.ToInt32(whichremove) + 1; y < keywordslength; y++)
                            {
                                keywords[y - 1] = keywords[y];
                            }
                            keywordslength--;
                            Console.WriteLine("Successful!");
                        }
                    }
                    catch (Exception)
                    {
                        Console.Write("Please enter a ");
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.Write("NUMBER");
                    }
                    Console.ReadKey();
                }
            }
            else if (keywordinput == "99" || keywordinput == "99.")
            {

            }
            else
            {
                Console.WriteLine("Wrong choose, please try again.");
                Console.ReadKey();
            }
        }

        public static void filePathSelect()
        {
            Console.Write("Please select file path : ");
            Console.ForegroundColor = ConsoleColor.Magenta;
            filepath = Console.ReadLine();
            Console.ForegroundColor = ConsoleColor.White;
        }

        static void Main(string[] args)
        {
            Console.Title = "Keyword Maker v1.0";
            while (true)
            {
                Console.Clear();

                // Interface;
                Console.ForegroundColor = ConsoleColor.White;
                Console.WriteLine("|------------------------------|");
                Console.WriteLine("|        Keyword Maker         |");
                Console.Write("|             "); Console.ForegroundColor = ConsoleColor.Magenta;
                Console.Write("v1.0"); Console.ForegroundColor = ConsoleColor.White;
                Console.WriteLine("             |");
                Console.Write("|       Coded by "); Console.ForegroundColor = ConsoleColor.Magenta;
                Console.Write("Larcely"); Console.ForegroundColor = ConsoleColor.White;
                Console.WriteLine("       |");
                Console.WriteLine("|------------------------------|");
                Console.WriteLine();
                Console.Write("Number of keywords : "); Console.ForegroundColor = ConsoleColor.Magenta;
                Console.WriteLine(keywordslength.ToString());
                Console.WriteLine(); Console.ForegroundColor = ConsoleColor.White;
                Console.Write("File path : "); Console.ForegroundColor = ConsoleColor.Magenta;
                Console.WriteLine(filepath); Console.ForegroundColor = ConsoleColor.White;

                // Menu
                Console.WriteLine();
                Console.WriteLine();
                Console.WriteLine("|            MENU            |"); Console.ForegroundColor = ConsoleColor.Magenta; Console.WriteLine();
                Console.Write("1. "); Console.ForegroundColor = ConsoleColor.White;
                Console.WriteLine("File path"); Console.ForegroundColor = ConsoleColor.Magenta;
                Console.Write("2. "); Console.ForegroundColor = ConsoleColor.White;
                Console.WriteLine("Keywords");
                Console.ForegroundColor = ConsoleColor.Magenta;
                Console.WriteLine();
                Console.Write("9. ");
                Console.ForegroundColor = ConsoleColor.White;
                Console.WriteLine("Save");
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.Write("99. ");
                Console.ForegroundColor = ConsoleColor.White;
                Console.WriteLine("Exit");
                Console.WriteLine();
                Console.Write("Choose : "); Console.ForegroundColor = ConsoleColor.Magenta;
                string choose = Console.ReadLine();
                Console.ForegroundColor = ConsoleColor.White;
                Console.Clear();
                if (choose == "1" || choose == "1.")
                {
                    filePathSelect();
                }
                else if (choose == "2" || choose == "2.")
                {
                    keywordSelect();
                }
                else if (choose == "9" || choose == "9.")
                {
                    saveFile();
                }
                else if (choose == "99" || choose == "99.")
                {

                }
                else
                {
                    Console.Write("Wrong choose, please try again.");
                    Console.ReadKey();
                }
            }
        }
    }
}
