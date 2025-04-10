using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;


namespace BusinessApplication
{
    class Program
    { 
        static string checkUserName;
        static string checkPassword;
        static int count = -1;
        static int option;
        

        static void Main(string[] args)
        {
            int[] userCount = new int[10];
            string[] userName = new string[10];
            string[] password = new string[10];
            string[] names = new string[10];
            string[] degree = new string[10];
            string[] totalMarks = new string[10];
            string[] obtMarks = new string[10];
            string[] fee = new string[10];
            bool[] deleteInfo = new bool[10];
            deleteInfo[count + 1] = false;
            bool[] innerCount = new bool[10];
            innerCount[count + 1] = false;
            bool flag = true;
            while(flag)
            {
                string userPath = "F:\\2nd Semester\\OOP\\PD\\Week01\\BusinessApplication\\userFile";
                string userInfoPath = "F:\\2nd Semester\\OOP\\PD\\Week01\\BusinessApplication\\userInfoFile";
                LoadUser(userPath, userName, password, userCount);
                LoadUserInfo(userInfoPath, names, degree, totalMarks, obtMarks, fee, innerCount, deleteInfo, userCount);
                Console.Clear();
                option = MainMenu();
                if(option == 1 )
                {
                    Console.Clear();
                    SignUpMenu(userName, password, userCount);
                    StoreUser(userPath, userName, password, userCount);
                    Console.ReadKey();
                    Console.WriteLine("Press Any Key To Continue...");
                }
                if(option == 2)
                {
                    bool flag01 = true;
                    while (flag01)
                    {
                        int countValue;
                        Console.Clear();
                        SignInMenu();
                        countValue = CheckUserExist(userName, password, userCount);
                        if(countValue == -1)
                        {
                            flag01 = false;
                        }
                        else
                        {
                            bool flag02 = true;
                            while (flag02)
                            {
                                Console.Clear();
                                option = UserMenu();
                                if (option == 1)
                                {
                                    Console.Clear();
                                    CreateUserInfo(names, degree, totalMarks, obtMarks, fee, innerCount, deleteInfo, countValue);
                                    StoreUserInfo(userInfoPath, names, degree, totalMarks, obtMarks, fee, innerCount, deleteInfo, userCount);
                                }
                                if (option == 2)
                                {
                                    Console.Clear();
                                    ViewUserInfo(names, degree, totalMarks, obtMarks, fee, innerCount, deleteInfo, countValue);
                                }
                                if (option == 3)
                                {
                                    bool flag03 = true;
                                    while (flag03)
                                    {
                                        Console.Clear();
                                        flag03 = UpdateInfoMenu(names, degree, totalMarks, obtMarks, fee, innerCount, deleteInfo, countValue);
                                    }
                                    StoreUserInfo(userInfoPath, names, degree, totalMarks, obtMarks, fee, innerCount, deleteInfo, userCount);
                                }
                                if (option == 4)
                                {
                                    Console.Clear();
                                    DeleteUserInfo(names, degree, totalMarks, obtMarks, fee, innerCount, deleteInfo, countValue);
                                    StoreUserInfo(userInfoPath, names, degree, totalMarks, obtMarks, fee, innerCount, deleteInfo, userCount);
                                }
                                if (option == 5)
                                {
                                    flag01 = false;
                                    break;
                                }
                            }
                        }
                        
                    }   
                }
                if(option == 3)
                {
                    flag = false;
                }
            }
        }
        static int MainMenu()
        {
            Console.WriteLine("1.Sign Up.");
            Console.WriteLine("2.Sign In.");
            Console.WriteLine("3.Exit.");
            do
            {
                Console.Write("Enter Option.");
                option = int.Parse(Console.ReadLine());
                if (option >= 1 && option <= 3)
                {
                    break;
                }
                else
                {
                    Console.WriteLine("Option is not valid.");
                }
            } while (!(option == 1 && option == 3));
            return option;
        }
        static void SignUpMenu(string[] userName, string[] password ,int[] userCount)    
        {
            count++;
            userCount[count] = count;
            Console.Write("Enter Username: ");
            userName[userCount[count]] = Console.ReadLine();
            Console.Write("Enter Password: ");
            password[userCount[count]] = Console.ReadLine();
            
        }
        static void SignInMenu()
        {
            Console.Write("Enter Username: ");
            checkUserName = Console.ReadLine();
            Console.Write("Enter Password: ");
            checkPassword = Console.ReadLine();
        }
        static int CheckUserExist(string[] userName, string[] password, int[] userCount)
        {
            for(int idx = 0; idx <= count; idx++)
            {
                if(checkUserName == userName[idx] && checkPassword == password[idx])
                {
                    return userCount[idx];
                }
            }
            Console.WriteLine("Try Again.");
            Console.ReadKey();
            Console.WriteLine("Press Any Key To Continue...");
            return -1;
        }
        static int UserMenu()
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
        static void CreateUserInfo(string[] names, string[] degree, string[] totalMarks, string[] obtMarks, string[] fee, bool[] innerCount,bool[] deleteInfo, int countValue)
        {
            if (innerCount[countValue] == false || deleteInfo[countValue] == true)
            {
                Console.Write("=> Name:  ");
                names[countValue] = Console.ReadLine();
                Console.Write("=> Dgree Name:  ");
                degree[countValue] = Console.ReadLine();
                Console.Write("=> Total Marks:  ");
                totalMarks[countValue] = Console.ReadLine();
                Console.Write("=> Obtained Marks:  ");
                obtMarks[countValue] = Console.ReadLine();
                Console.Write("=> Total Fee:  ");
                fee[countValue] = Console.ReadLine();
                innerCount[countValue] = true;
                deleteInfo[countValue] = false;
            }
            else
            {
                Console.WriteLine("You have already created Your information.");
                Console.WriteLine("If you want to update it than goto UPDATE MENU.");
                Console.ReadKey();
                Console.WriteLine("Press Any Key To Continue...");
            }
            innerCount[count + 1] = false;
        }
        static bool UpdateInfoMenu(string[] names, string[] degree, string[] totalMarks, string[] obtMarks, string[] fee, bool[] innerCount,bool[] deleteInfo, int countValue)
        {
            if (innerCount[count] == true && deleteInfo[countValue] == false)
            {
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
                    names[countValue] = Console.ReadLine();
                    Console.WriteLine("Your name is updated.");
                    Console.ReadKey();
                    Console.WriteLine("Press Any Key To Continue...");
                }
                else if (option == 2)
                {
                    Console.Write("=> Degree Name:  ");
                    degree[countValue] = Console.ReadLine();
                    Console.WriteLine("Your Degree name is updated.");
                    Console.ReadKey();
                    Console.WriteLine("Press Any Key To Continue...");
                }
                else if (option == 3)
                {
                    Console.Write("=> Total Marks:  ");
                    totalMarks[countValue] = Console.ReadLine();
                    Console.WriteLine("Your Total Marks are updated.");
                    Console.ReadKey();
                    Console.WriteLine("Press Any Key To Continue...");
                }
                else if (option == 4)
                {
                    Console.Write("=> Obtained Marks:  ");
                    obtMarks[countValue] = Console.ReadLine();
                    Console.WriteLine("Your Obtained Marks are updated.");
                    Console.ReadKey();
                    Console.WriteLine("Press Any Key To Continue...");
                }
                else if (option == 5)
                {
                    Console.Write("=> Fee:  ");
                    fee[countValue] = Console.ReadLine();
                    Console.WriteLine("Your fee is updated.");
                    Console.ReadKey();
                    Console.WriteLine("Press Any Key To Continue...");
                }
                else if (option == 6)
                {
                    Console.Write("=> Your Name:   ");
                    names[countValue] = Console.ReadLine();
                    Console.Write("=> Dgree Name:   ");
                    degree[countValue] = Console.ReadLine();
                    Console.Write("=> Total Marks:   ");
                    totalMarks[countValue] = Console.ReadLine();
                    Console.Write("=> Obtained Marks:   ");
                    obtMarks[countValue] = Console.ReadLine();
                    Console.Write("=> Total Fee:  ");
                    fee[countValue] = Console.ReadLine();
                    Console.WriteLine("Your information is updated.");
                    Console.ReadKey();
                    Console.WriteLine("Press Any Key To Continue...");
                }
                else if (option == 7)
                {
                    return false;
                }
            }
            else 
            {
                Console.WriteLine("First You have to create your Information. ");
                Console.ReadKey();
                Console.WriteLine("Press Any Key To Continue...");
                return false;
            }
            return true;
        }
        static void DeleteUserInfo(string[] names, string[] degree, string[] totalMarks, string[] obtMarks, string[] fee, bool[] innerCount, bool[] deleteInfo, int countValue)
        {
            if (innerCount[countValue] == true && deleteInfo[countValue] == false)
            {
                names[countValue] = "_";
                degree[countValue] = "_";
                totalMarks[countValue] = "_";
                obtMarks[countValue] = "_";
                fee[countValue] = "_";
                deleteInfo[countValue] = true;
                Console.WriteLine("Your had deleted your all information.");
                Console.ReadKey();
                Console.WriteLine("Press Any Key To Continue...");
            }
            else
            {
                Console.WriteLine("There is No Information.");
                Console.ReadKey();
                Console.WriteLine("Press Any Key To Continue...");
            }

        }
        static void ViewUserInfo(string[] names, string[] degree, string[] totalMarks, string[] obtMarks, string[] fee, bool[] innerCount, bool[] deleteInfo, int countValue)
        {
            if (innerCount[countValue] == true && deleteInfo[countValue] == false)
            {
                Console.WriteLine("=> Your Name:  {0}", names[countValue]);
                Console.WriteLine("=> Degree Name: {0}", degree[countValue]);
                Console.WriteLine("=> Total Marks: {0}", totalMarks[countValue]);
                Console.WriteLine("=> Obtained Marks: {0}", totalMarks[countValue]);
                Console.WriteLine("=> Total Fee: {0}", fee[countValue]);
                Console.ReadKey();
                Console.WriteLine("Press Any Key To Continue...");
            }
            else
            {
                Console.WriteLine("There is no information of yours.");
                Console.ReadKey();
                Console.WriteLine("Press Any Key To Continue...");
            }

        }
        static string ParseData(string record, int field)
        {
            int comma = 1;
            string item = "";
            for(int x = 0; x < record.Length; x++)
            {
                if(record[x] == ',')
                {
                    comma++;
                }
                else if(comma == field)
                {
                    item = item + record[x];
                }
            }
            return item;
        }
        static void StoreUser(string path, string[] userName, string[] password, int[] userCount)
        {
            StreamWriter file = new StreamWriter(path, true);
            file.WriteLine(userName[userCount[count]] + "," + password[userCount[count]] + "," + userCount[count] + "," + count);
            file.Flush();
            file.Close();
        }
        static void LoadUser(string path, string[] userName, string[] password, int[] userCount)
        {
            int x = 0;
            if(File.Exists(path))
            {
                StreamReader fileVariable = new StreamReader(path);
                string record;
                while((record = fileVariable.ReadLine()) != null)
                {
                    userName[x] = ParseData(record, 1);
                    password[x] = ParseData(record, 2);
                    userCount[x] = int.Parse(ParseData(record, 3));
                    count = int.Parse(ParseData(record, 4));
                    x++;
                    if(x >= 10)
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
        static void StoreUserInfo(string path, string[] names, string[] degree, string[] totalMarks, string[] obtMarks, string[] fee, bool[] innerCount, bool[] deleteInfo, int[] userCount)
        {
            StreamWriter file = new StreamWriter(path);
            int idx = 0;
            while (idx < count)
            {
                file.WriteLine(names[userCount[count]] + "," + degree[userCount[count]] + "," + totalMarks[userCount[count]] + "," + obtMarks[userCount[count]] + "," + fee[userCount[count]] + "," + innerCount[userCount[count]] + "," + deleteInfo[userCount[count]] + "," + userCount[userCount[count]] + "," + count);
            }
            file.Flush();
            file.Close();
        }
        static void LoadUserInfo(string path, string[] names, string[] degree, string[] totalMarks, string[] obtMarks, string[] fee, bool[] innerCount, bool[] deleteInfo, int[] userCount)
        {
            int x = 0;
            if (File.Exists(path))
            {
                StreamReader fileVariable = new StreamReader(path);
                string record;
                while ((record = fileVariable.ReadLine()) != null)
                {
                    names[x] = ParseData(record, 1);
                    degree[x] = ParseData(record, 2);
                    totalMarks[x] = ParseData(record, 3);
                    obtMarks[x] = ParseData(record, 4);
                    fee[x] = ParseData(record, 5);
                    innerCount[x] = bool.Parse(ParseData(record, 6));
                    deleteInfo[x] = bool.Parse(ParseData(record, 7));
                    userCount[x] =int.Parse(ParseData(record, 8));
                    count = int.Parse(ParseData(record, 9));
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
    }
}
