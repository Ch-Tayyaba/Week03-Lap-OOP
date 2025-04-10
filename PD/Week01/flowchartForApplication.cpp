#include<iostream>
using namespace std;

void main()
{

}
void signInSubMenu()
{
    x = 57, y = 14;
    gotoxy(x, y);
    y = y + 1;
    cout << "=> Username:";
    gotoxy(x, y);
    y = y + 1;
    cout << "=> Password:";
}
void signUpSubMenu()
{
    x = 57, y = 14;
    gotoxy(x, y);
    y = y + 1;
    cout << "=> Enter User Name: " << endl;
    gotoxy(x, y);
    y = y + 1;
    cout << "=> Enter Password:" << endl;
}
void inputForSignUp()
{
    x = 76, y = 14;
    gotoxy(x, y);
    y = y + 1;
    cin >> userName[userCount];
    gotoxy(x, y);
    y = y + 5;
    cin >> password[userCount];
    gotoxy(x, y);
    userCount++;
}
void inputForSignIn()
{
    x = 76, y = 14;
    gotoxy(x, y);
    y = y + 1;
    cin >> checkUsername;
    gotoxy(x, y);
    y = y + 1;
    cin >> checkPassword;
}
bool isValid(string name)
{
    bool flag = true;
    for(int idx = 0; idx < userCount; idx++)
    {
        if(userName[idx] == checkUsername)
        {
            flag = false;
            break;
        }
    }
    return flag;
}
bool checkUserExist()
{
    for (int idx = 1; idx <= 3; idx++)
    {
        for (int idx = 0; idx < userCount; idx++)
        {
            if (checkUsername == userName[idx] && checkPassword == password[idx])
            {
                return true;
                break;
            }
            cout << "Try Again";
        }
    }
    return false;
}
int takerMenu()
{
    x = 57, y = 14;
    gotoxy(x, y);
    y = y + 1;
    cout << "1.Create your information.";
    gotoxy(x, y);
    y = y + 1;
    cout << "2.View from your information";
    gotoxy(x, y);
    y = y + 1;
    cout << "3.Update your information.";
    gotoxy(x, y);
    y = y + 1;
    cout << "4.Delete your information.";
    gotoxy(x, y);
    y = y + 1;
    cout << "Enter Option: ";
    cin >> option;
    gotoxy(x, y);
    y01 = y + 1;
    y02 = y - 1;
    int i = 1;
    while (!(option >= 1 && option <= 4) && (i <= 3))
    {
        cin >> option;
        if (option >= 1 && option <= 4)
        {
            break;
        }
        else
        {
            gotoxy(x, y01);
            cout << "Option is not valid.";
        }
        gotoxy(71, y02);
        cout << "         ";
        i++;
    }
    return option;
}
void userInfomenu()
{
    
    "=> Name:";
    "=> Dgree Name:";
    "=> Total Marks:";
    "=> Obtained Marks";
    "=> Total Fee:";
}
void takeMeritBaseTakerPersonalInfoMenu()
{
    x = 76, y = 14;
    gotoxy(x, y);
    y = y + 1;
    cin >> meritBaseTakerName[meritBaseTakerCount];
    gotoxy(x, y);
    y = y + 1;
    cin >> meritBaseTakerCNIC[meritBaseTakerCount];
    gotoxy(x, y);
    y = y + 1;
    cin >> meritBaseTakerDegreeName[meritBaseTakerCount];
    gotoxy(x, y);
    y = y + 1;
    cin >> meritBaseTakerTotalMarks[meritBaseTakerCount];
    gotoxy(x, y);
    y = y + 1;
    cin >> meritBaseTakerObtMarks[meritBaseTakerCount];
    gotoxy(x, y);
    y = y + 1;
    cin >> meritBaseTakerFee[meritBaseTakerCount];
    meritBaseTakerUpdateCount++;
}
void updateMeritBaseTakerPersonalInfoMenu()
{
    Console.WriteLine( "You want to update: ");
    Console.WriteLine( "\t 1. Name");
    Console.WriteLine( "\t2. Dgree Name:");
    Console.WriteLine( "\t3. Total Marks:");
    Console.WriteLine( "\t4. Obtained Marks");
    Console.WriteLine( "\t5. Total Fee:");
    Console.WriteLine( "\t6. All");
    Console.WriteLine( "\t7. Exit");
    Console.Write( "=> Enter Option: ");
    Console.ReadLine  option;
    do
    {
        Console.ReadLine  option;
        if (option >= 1 && option <= 8)
        {
            break;
        }
        else
        {
            Console.WriteLine( "Option is not valid.");
        }
    }while (!(option >= 1 && option <= 8));
    if (option == 1)
    {
        name[count] = Console.ReadLine();
    }
    else if (option == 2)
    {
        degree[count] = Console.ReadLine();
    }
    else if (option == 3)
    {
        totalMarks[count] = Console.ReadLine();
    }
    else if (option == 4)
    {
        obtMarks[count] = Console.ReadLine();
    }
    else if (option == 5)
    {
        fee[count] = Console.ReadLine();
    }
    else if (option == 6)
    {
    
    }
}
void viewMeritBaseTakerOwnPersonalInfo()
{
    if (meritBaseTakerUpdateCount == 0)
    {
        x = 57, y = 14;
        gotoxy(x, y);
        y = y + 1;
        cout << "There is no record of Yours.";
    }
    else
    {
        x = 57, y = 14;
        gotoxy(x, y);
        y = y + 1;
        cout << "Name             : " << meritBaseTakerName[meritBaseTakerCount];
        gotoxy(x, y);
        y = y + 1;
        cout << "CNIC             : " << meritBaseTakerCNIC[meritBaseTakerCount];
        gotoxy(x, y);
        y = y + 1;
        cout << "Degree Name      : " << meritBaseTakerDegreeName[meritBaseTakerCount];
        gotoxy(x, y);
        y = y + 1;
        cout << "Total Marks      : " << meritBaseTakerTotalMarks[meritBaseTakerCount];
        gotoxy(x, y);
        y = y + 1;
        cout << "Obtained Marks   : " << meritBaseTakerObtMarks[meritBaseTakerCount];
        gotoxy(x, y);
        y = y + 1;
        cout << "Total Fee        : " << meritBaseTakerFee[meritBaseTakerCount];
    }
}
void RemoveDonator()
{
    bool flag = false;
    x = 57, y = 14;
    gotoxy(x, y);
    cout << "=> Enter User Name: " << endl;
    gotoxy(76, y);
    y = y + 1;
    cin >> checkUsername;
    gotoxy(x, y);
    y = y + 1;
    cout << "=> Enter Password:" << endl;
    gotoxy(76, y);
    y = y + 1;
    cin >> checkPassword;
    for (int idx = 0; idx < userCount; idx++)
    {
        if (checkUsername == userName[idx] && checkPassword == password[idx] && typeOfUser[idx] == 1)
        {
            userName[idx] = "_";
            password[idx] = "_";
            flag = true;
        }
    }
    if(flag)
    {
        cout << "There is no such donator exist.";
    }
    else
    {
        gotoxy(x, y);
        cout << "You have successfully remove a donator.";
    }
}