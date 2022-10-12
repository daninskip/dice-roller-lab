bool playAgain;

do
{
    Console.WriteLine("Welcome to the Casino");
    Console.WriteLine("How many sides should each die have?");

    int diceSides;
    bool isValid = int.TryParse(Console.ReadLine(), out diceSides);
    while (!isValid)
    {
        Console.WriteLine("Please enter a number");
        isValid = int.TryParse(Console.ReadLine(), out diceSides);
    }

    Console.WriteLine("Press <Enter> to roll the dice");
    Console.ReadKey();

    int dice1Value = GetDieValue(diceSides);
    int dice2Value = GetDieValue(diceSides);
    int diceTotal = dice1Value + dice2Value;
    string message;
    Console.WriteLine($"The {diceSides} sided dice roll and stop. Dice 1 rolled {dice1Value}, dice 2 rolled {dice2Value}, totalling {diceTotal}");
    switch (diceSides){
        case 6:
            message = WinningCombinations6Side(dice1Value, dice2Value);
            Console.WriteLine(message);
            break;
        case 12:
            message = WinningCombinations12Side(dice1Value, dice2Value);
            Console.WriteLine(message);
            break;
    }

    Console.WriteLine("Would you like to play again? (y/n)");
    string input = Console.ReadLine();
    playAgain = input.ToLower() == "y";

    int GetDieValue(int diceSides)
    {
        Random random = new Random();
        int dieValue = random.Next(1, diceSides); ;
        return dieValue;
    }

    string WinningCombinations6Side(int dice1Value, int dice2Value)
    {
        string message = "";
        if (dice1Value == 1 && dice2Value == 1)
        {
            message = "Snake Eyes!";
        }
        else if (diceTotal == 3)
        {
            message = "Ace Deuce!";
        }
        else if (dice1Value == 6 && dice2Value == 6)
        {
            message = "Box Cars!";
        }
        else if (diceTotal == 7 || diceTotal == 11)
        {
            message = "Win!";
        }
        else
        {
            message = "";
        }
        if (diceTotal == 2 || diceTotal == 3 || diceTotal == 12)
        {
            message = message + " and Craps!";

        }
        return message;
        Console.WriteLine(message);
    }

    string WinningCombinations12Side(int dice1Value, int dice2Value)
    {
        string message = "";
        if (dice1Value == 10 && dice2Value == 10)
        {
            message = "Tens!";
        }
        else if (diceTotal == 7)
        {
            message = "Lucky Seven!";
        }
        else if (dice1Value == 12 && dice2Value == 12)
        {
            message = "High Roller!";
        }
        else if (diceTotal == 9 || diceTotal == 17)
        {
            message = "Winner!";
        }
        else
        {
            message = "";
        }
        if (diceTotal == 4 || diceTotal == 6 || diceTotal == 24)
        {
            message = message + " and Craps!";

        }
        return message;
        Console.WriteLine(message);
    }
} while (playAgain == true);

Console.WriteLine("Thanks for playing!");
Console.WriteLine("Come again soon!");