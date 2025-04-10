using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace ApplicationUsingClass
{
    class Program
    {
        static int option;
        static void Main(string[] args)
        {
            List<userInfo> user = new List<userInfo>();
            LoadUserInfo(user);
            do
            {

                Console.Clear();
                option = MainMenu();
                if (option == 1)
                {
                    Console.Clear();
                    user.Add(CreateInfo());
                    storeData(user);
                }
                if (option == 2)
                {
                    Console.Clear();
                    ViewInfo(user);
                    Console.ReadKey();
                }
                if (option == 3)
                {
                    Console.Clear();
                    UpdateInfo(user);
                    storeData(user);
                }
                if (option == 4)
                {
                    Console.Clear();
                    DeleteInfo(user);
                    storeData(user);
                }
                if (option == 5)
                {
                    break;
                }
            } while (option < 6);

        }
        static int MainMenu()
        {
            Console.WriteLine("1.Create your information.");
            Console.WriteLine("2.View your information.");
            Console.WriteLine("3.Update your information.");
            Console.WriteLine("4.Delete your information.");
            Console.WriteLine("5.Exit.");
            do
            {
                Console.Write("Enter Option.");
                option = int.Parse(Console.ReadLine());
                if (option >= 1 && option <= 5)
                {
                    break;
                }
                else
                {
                    Console.WriteLine("Option is not valid.");
                }
            } while (!(option >= 1 && option <= 5));
            return option;
        }
        static userInfo CreateInfo()
        {
            userInfo u = new userInfo();
            Console.Write("Enter Name: ");
            u.names = Console.ReadLine();
            Console.Write("Enter Degree: ");
            u.degree = Console.ReadLine();
            Console.Write("Enter Total Marks: ");
            u.totalMarks = Console.ReadLine();
            Console.Write("Enter Obtained: ");
            u.obtMarks = Console.ReadLine();
            Console.Write("Enter Fee: ");
            u.fee = Console.ReadLine();
            return u;
        }
        static void ViewInfo(List<userInfo> user)
        {
            
            for (int idx = 0; idx < user.Count; idx++)
            {
                Console.WriteLine("Name: {0}     Degree: {1}     TotalMarks: {2}     ObtainedMarks: {3}        Fee: {4}", user[idx].names, user[idx].degree, user[idx].totalMarks, user[idx].obtMarks, user[idx].fee);
            }
            Console.ReadKey();
        }
        static bool UpdateInfo(List<userInfo> user)
        {
            int idx;
            Console.Write("Enter Record number you want to update: ");
            idx = int.Parse(Console.ReadLine());
            idx--;
            Console.Clear();
            Console.WriteLine("You want to update:  ");
            Console.WriteLine("\t1. Name");
            Console.WriteLine("\t2. Dgree Name");
            Console.WriteLine("\t3. Total Marks");
            Console.WriteLine("\t4. Obtained Marks");
            Console.WriteLine("\t5. Total Fee");
            Console.WriteLine("\t6. All");
            Console.WriteLine("\t7. Exit");
            do
            {
                Console.Write("=> Enter Option: ");
                option = int.Parse(Console.ReadLine());
                if (option >= 1 && option <= 7)
                {
                    break;
                }
                else
                {
                    Console.WriteLine("Option is not valid.");
                }
            } while (!(option >= 1 && option <= 7));
            if (option == 1)
            {
                Console.Write("=> Name:  ");
                user[idx].names = Console.ReadLine();
                Console.WriteLine("Your name is updated.");
                Console.ReadKey();
                Console.WriteLine("Press Any Key To Continue...");
            }
            else if (option == 2)
            {
                Console.Write("=> Degree Name:  ");
                user[idx].degree = Console.ReadLine();
                Console.WriteLine("Your Degree name is updated.");
                Console.ReadKey();
                Console.WriteLine("Press Any Key To Continue...");
            }
            else if (option == 3)
            {
                Console.Write("=> Total Marks:  ");
                user[idx].totalMarks = Console.ReadLine();
                Console.WriteLine("Your Total Marks are updated.");
                Console.ReadKey();
                Console.WriteLine("Press Any Key To Continue...");
            }
            else if (option == 4)
            {
                Console.Write("=> Obtained Marks:  ");
                user[idx].obtMarks = Console.ReadLine();
                Console.WriteLine("Your Obtained Marks are updated.");
                Console.ReadKey();
                Console.WriteLine("Press Any Key To Continue...");
            }
            else if (option == 5)
            {
                Console.Write("=> Fee:  ");
                user[idx].fee = Console.ReadLine();
                Console.WriteLine("Your fee is updated.");
                Console.ReadKey();
                Console.WriteLine("Press Any Key To Continue...");
            }
            else if (option == 6)
            {
                Console.Write("=> Your Name:   ");
                user[idx].names = Console.ReadLine();
                Console.Write("=> Dgree Name:   ");
                user[idx].degree = Console.ReadLine();
                Console.Write("=> Total Marks:   ");
                user[idx].totalMarks = Console.ReadLine();
                Console.Write("=> Obtained Marks:   ");
                user[idx].obtMarks = Console.ReadLine();
                Console.Write("=> Total Fee:  ");
                user[idx].fee = Console.ReadLine();
                Console.WriteLine("Your information is updated.");
                Console.ReadKey();
                Console.WriteLine("Press Any Key To Continue...");
            }
            else if (option == 7)
            {
                return false;
            }
            return true;
        }
        static void DeleteInfo(List<userInfo> user)
        {
            int idx;
            Console.Write("Enter Record number you want to delete: ");
            idx = int.Parse(Console.ReadLine());
            idx--;
            user.RemoveAt(idx);
        }
        static void storeData(List<userInfo> user)
        {
            string path = @"F:\2nd Semester\OOP\PD\Week02\userInfo";
            StreamWriter file = new StreamWriter(path);
            int idx = 0;
            while(idx < user.Count)
            {
                file.WriteLine(user[idx].names + "," + user[idx].degree + "," + user[idx].totalMarks + "," + user[idx].obtMarks + "," + user[idx].fee);
                idx++;
            }
            file.Flush();
            file.Close();
        }
        static void LoadUserInfo(List<userInfo> user)
        {
            string path = @"F:\2nd Semester\OOP\PD\Week02\userInfo";
            int x = 0;
            if (File.Exists(path))
            {
                StreamReader fileVariable = new StreamReader(path);
                string record;
                while ((record = fileVariable.ReadLine()) != null)
                {
                    userInfo obj = new userInfo();
                    obj.names = ParseData(record, 1);
                    obj.degree = ParseData(record, 2);
                    obj.totalMarks = ParseData(record, 3);
                    obj.obtMarks = ParseData(record, 4);
                    obj.fee = ParseData(record, 5);
                    x++;
                    if (x >= 10)
                    {
                        break;
                    }
                }
                fileVariable.Close();
            }
            else
            {
                Console.WriteLine("Not exists.");
            }
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
    }
}
