using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace challenge2
{
    class Program
    {
        class credentials
        {
            public string username;
            public string password;
        }
        static void Main(string[] args)
        {
            string path = @"F:\2nd Semester\OOP\PD\Week02";
            int size = 100;
            credentials[] arr = new credentials[size];
            credentials sign = new credentials();

            int count = 0;
            int option;
            do
            {
                ReadData(arr, path, ref count, size);
                Console.Clear();
                option = menu();
                Console.Clear();
                if (option == 1)
                {
                    Console.WriteLine("Enter name: ");
                    string n = Console.ReadLine();
                    Console.WriteLine("Enter password: ");
                    string p = Console.ReadLine();
                    SignIn(count, n, p, arr);
                    Console.ReadKey();
                }
                else if (option == 2)
                {
                    Console.WriteLine("Enter name: ");
                    string n = Console.ReadLine();
                    Console.WriteLine("Enter password: ");
                    string p = Console.ReadLine();
                    signUp(path, n, p);
                    Console.WriteLine("Press any key to continue...");
                    Console.ReadKey();
                }
            }
            while (option < 3);
            {
                Console.Read();


            }
        }
        static int menu()
        {
            int option;
            Console.WriteLine("1. SignIn ");
            Console.WriteLine("2.SignUp ");
            Console.WriteLine("Enter option: ");
            option = int.Parse(Console.ReadLine());
            return option;
        }

        static string ParseData(string record, int field)
        {
            int comma = 1;
            string item = "";
            for (int x = 0; x < record.Length; x++)
            {
                if (record[x] == ',')
                {
                    comma++;

                }
                else if (comma == field)
                {
                    item = item + record[x];
                }

            }
            return item;

        }
        static void ReadData(credentials[] arr, string path, ref int count, int size)
        {
            if (File.Exists(path))
            {
                StreamReader fileVariable = new StreamReader(path);
                string record;
                while ((record = fileVariable.ReadLine()) != null)
                {
                    credentials s1 = new credentials();
                    s1.username = ParseData(record, 1);
                    s1.password = ParseData(record, 2);
                    arr[count] = s1;
                    count++;
                    if (count >= 5)
                    {
                        break;
                    }

                }
                fileVariable.Close();
            }


            else
            {
                Console.WriteLine("Not Exists");
            }
        }

        static void SignIn(int count, string n, string p, credentials[] arr)
        {
            bool flag = false;
            credentials s1 = new credentials();
            for (int x = 0; x < count; x++)
            {
                if (n == arr[x].username && p == arr[x].password)
                {
                    Console.WriteLine("YOU ARE SIGNED IN!!");
                    flag = true;
                }
            }
            if (flag == false)
            {
                Console.WriteLine("Invalid user! Try again");
            }
            Console.ReadKey();
        }
        static void signUp(string path, string nam, string pass)
        {
            StreamWriter file = new StreamWriter(path, true);
            file.WriteLine(nam + "," + pass);
            file.Flush();
            file.Close();

        }
    }
}


