

using UnityEngine;

public class Hacker : MonoBehaviour {
	// game  config data
	string[] level1passwords = { "rose", "gold", "fire", "cole", "tasty" };
	string[] level2passwords = { "rosegoldination", "goldified", "firebums", "coleworld", "tastylize" };
	string[] level3passwords = { "cole", "slim shady", "khalid", "snarky puppy", "jay z" };
	//game state
	int level;
	string password;
	const string help = "type menu any time";
	enum Screen { MainMenu, WaitingForPassword, Win};
	Screen currentScreen;
	// Use this for initialization
	void Start () {
		
		ShowMainMenu();
	}
	void ShowMainMenu(){
		currentScreen = Screen.MainMenu;
		Terminal.ClearScreen();
		Terminal.WriteLine("Hackerz");
		Terminal.WriteLine("where would you like to hack into?");
		Terminal.WriteLine("Press 1 for Local Bank");
		Terminal.WriteLine("Press 2 for World Bank");
		Terminal.WriteLine("Press 3 for peeps i jam");
		Terminal.WriteLine("What is it gonna be?");
		Terminal.WriteLine("1, 2 or 3: ");

		

	}
	
	void OnUserInput(string input)
	{

		if (input == "menu")
		{
			ShowMainMenu();
		}
		else if (currentScreen == Screen.MainMenu)
		{
			RunMainMenu(input);
		}
		else if (currentScreen == Screen.WaitingForPassword) {
			InputPassword(input);
		}



	}

	 void RunMainMenu(string input)
	{
		bool isValidLevelNumber = (input == "1" || input == "2" || input == "3");
		if (isValidLevelNumber)
		{
			level = int.Parse(input);
			StartGame();
		}
		else if (input == "rose gold")
		{
			Terminal.WriteLine("you have achieved rosegoldation");
		}

		else
		{
			Terminal.WriteLine("invalid selection");
			Terminal.WriteLine(help);
		}
		
	}

	void StartGame()
	{
		currentScreen = Screen.WaitingForPassword;
		Terminal.ClearScreen();
		AskForPassword();
		Terminal.WriteLine("Enter your password, Hint: " + password.Anagram());
		Terminal.WriteLine(help);




	}

	void AskForPassword()
	{
		switch (level)
		{
			case 1:
				password = level1passwords[Random.Range(0, level1passwords.Length)];
				break;
			case 2:
				password = level2passwords[Random.Range(0, level2passwords.Length)];
				break;
			case 3:
				password = level3passwords[Random.Range(0, level3passwords.Length)];
				break;


			default:
				Debug.LogError("Invalid Selection");
				break;
		}
	}

	void InputPassword(string input)
	{
		
		if ( input == password) {
			DisplayWinScreen();
		}
		else
		{
			StartGame();
			Terminal.WriteLine("try again");
		}
	}

	 void DisplayWinScreen()
	{
		currentScreen = Screen.Win;
		Terminal.ClearScreen();
		ShowLevelReward();
		Terminal.WriteLine(help);


	}

	void ShowLevelReward()
	{
		switch (level)
		{
			case 1:
			Terminal.WriteLine("weh done");
				Terminal.WriteLine(@"

11111111111111
111111111111
1111111111
111111
1111
111
11
1


");
		break;
			case 2:
				Terminal.WriteLine("keep it up");
				Terminal.WriteLine(@"
2222222222222
2222222222
2222222
22222
222
22
2
");
				break;
			case 3:
				Terminal.WriteLine("litt");
				Terminal.WriteLine(@"
33333333333
333333333
3333333
33333
333
33
3
");
				break;

		}
		
	}

	
	// Update is called once per frame
	void Update () {
		

	}
}
