using UnityEngine;

public class Hacker : MonoBehaviour    
{
    // Game configuration data
    const string menuHint = "You may type menu at any time.";
    string[] level1Passwords = { "books", "aisle", "shelf", "password", "font", "borrow"};
    string[] level2Passwords = { "prisoner", "handcuffs", "holster", "uniform", "arrest"};
    string[] level3Passwords = { "starfield", "telescope", "environment", "exploration", "astronauts" };

    // Game State
    int level;
    enum Screen { MainMenu, Password, Win };
    Screen currentScreen;
    string password;

    // Start is called before the first frame update
    void Start()
    {
        ShowMainMenu();
    }

    void ShowMainMenu()
    {
        level = 0;
        currentScreen = Screen.MainMenu;
        Terminal.ClearScreen();
        Terminal.WriteLine("Hello samurai");
        Terminal.WriteLine("What would you like to hack into?");
        Terminal.WriteLine("Press 1: Library (pff easy peasy)");
        Terminal.WriteLine("Press 2: Police Station (intersting)");
        Terminal.WriteLine("Press 3: NASA (chalange)");
        Terminal.WriteLine("Select the victim:");
    }    

    void OnUserInput(string input)
    {
        if(input == "menu") // we can always go back to menu
        {
            ShowMainMenu();            
        }
        else if(currentScreen == Screen.MainMenu)
        {
            RunMainMenu(input);
        }
        else if(currentScreen == Screen.Password)
        {
            CheckPassword(input);
        }
    }

    void RunMainMenu(string input)
    {
        bool isValidLevelNumber = (input == "1" || input == "2" || input == "3");
        if(isValidLevelNumber)
        {
            level = int.Parse(input);
            AskForPassword();
        }
        else if (input == "007")
        {
            Terminal.WriteLine("Plaease select the level Mr Bond!");
        }
        else
        {
            Terminal.WriteLine("Please chose a valid level");
            Terminal.WriteLine(menuHint);
        }
    }

    void AskForPassword()
    {
        currentScreen = Screen.Password;
        Terminal.ClearScreen();
        SetRandomPassword();
        Terminal.WriteLine("Enter your password, hint: " + password.Anagram());
        Terminal.WriteLine(menuHint);
    }

    private void SetRandomPassword()
    {
        switch (level)
        {
            case 1:
                password = level1Passwords[Random.Range(0, level1Passwords.Length)];
                break;
            case 2:
                password = level2Passwords[Random.Range(0, level2Passwords.Length)];
                break;
            case 3:
                password = level3Passwords[Random.Range(0, level3Passwords.Length)];
                break;
            default:
                Debug.LogError("Invalid level number");
                break;
        }
    }

    void CheckPassword(string input)
    {
        if(input == password)
        {
            DisplayWinScreen();
        }
        else
        {
            AskForPassword();
        }
    }

    void DisplayWinScreen()
    {
        currentScreen = Screen.Win;
        Terminal.ClearScreen();
        ShowLevelReward();
        Terminal.WriteLine(menuHint);
    }

    void ShowLevelReward()
    {
        switch(level)
        {
            case 1:
                Terminal.WriteLine("Have a book...");
                Terminal.WriteLine(@"
    _______
   /      //
  /      //
 /______//
(______(/
"
                );
                break;
            case 2:
                Terminal.WriteLine("Have a gun...");
                Terminal.WriteLine(@"
      __,_____
     / __.==--'
    /#(-'
    `-'
"
                );
                break;
            case 3:
                Terminal.WriteLine("Have a rocket...");
                Terminal.WriteLine(@"
      /\
     |o |
     |  |
    /|/\|\
   /_||||_\ 
"
                );
                break;
            default:
                Debug.LogError("Invalid level reached");
                break;
        }       
    }
}
