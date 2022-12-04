using System.Diagnostics;
using ConsoleTables; // Including both libraries needed in this code

Console.WriteLine("Welcome to the zoo!");
Console.WriteLine("You have 2 animals here, a lion and a tiger");
Console.WriteLine("Your job is to feed them when they are hungry before they starve!");
Console.WriteLine("You can check if they are hungry by typing 'lion' or 'tiger' respectively");
Console.WriteLine("They might be asleep when you check on them!, this can work to your disadvantage if they are hungry because you can't feed them while they are asleep! So be quick when they wake up");
Console.WriteLine("To feed them, type in the animal you want to feed and what you want to feed them with, so for example, the lion only eats antelopes so you would write 'lion antelope'");
Console.WriteLine("The tiger eats deer so you need to apply the above and feed it on time");
Console.WriteLine("When one of the animals is hungry, a new timer appears when you check on them, this is counting how long they have been hungry for so be quick !");
Console.WriteLine("When they are fed, they return back to normal but it won't be long until they are hungry again so stay vigilant!");
Console.WriteLine();
Console.WriteLine("Essentially, the aim of the game is to consistently check on both animals and feed them when they are hungry and awake so they can go back to normal before they die of starvation");
Console.WriteLine("When that all makes sense, press enter to start!");

Console.ReadLine(); // Only allows progression once the description has been read

Lion lion = new Lion();
Tiger tiger = new Tiger(); // New instances for both lion and tiger

Console.WriteLine("Please enter the difficulty you would like to play at: easy or hard");

bool chosen = false; // Boolean for whether difficulty has been successfully chosen

while (chosen == false) // While it hasn't been chosen, it loops taking in an input and checking if it is a valid difficulty until it receives a valid input
{

    string difficulty = Console.ReadLine();

    switch (difficulty)
    {
      case "easy": // Easy gives 20 seconds of awake time to feed the animals
        lion.Energy = 10;
        lion.Hunger = 30;
        lion.Hungerlimit = 70;
        tiger.Energy = 15;
        tiger.Hunger = 30;
        tiger.Hungerlimit = 65;
        chosen = true;
        break;
      case "hard": // Hard gives 10 seconds of awake time to feed the animals
        lion.Energy = 10;
        lion.Hunger = 20;
        lion.Hungerlimit = 30;
        tiger.Energy = 15;
        tiger.Hunger = 20;
        tiger.Hungerlimit = 30;
        chosen = true;
        break;
      default:
        Console.WriteLine("Please enter the difficulty you would like to play at as just the word 'easy' or 'hard'");
        break;
    }
    
}



Stopwatch stopwatch = new Stopwatch();
Stopwatch Lhunger = new Stopwatch();
Stopwatch Thunger = new Stopwatch(); // 3 separate stopwatches, one for the general flow of time and the other two for the duration each animal is hungry
stopwatch.Start();

int Ltimediff = 0; // These 2 time integers are used to calculate the time duration that has passed since one of the animals is fed
int Ttimediff = 0;
int timeL = 0; // These 2 time integers is the time each animal has been hungry for
int timeT = 0; // Given these four times the global scope (by initiating them outside of any methods) so they can be access in all the places they need to be accessed

while (true) // Main loop of the program
{
    string input = Console.ReadLine(); // Waits for input

    int time = (int)stopwatch.ElapsedMilliseconds/1000; // Records the total elapsed time
    int Lsleep = time / lion.Energy; // Calculates the quotient of the total time divided by the energy capacity of an animal, used to find where in it's cycle each animal is
    int Tsleep = time / tiger.Energy;
    int Lfood = (time-Ltimediff) / lion.Hunger; // Calculates the quotient of the time since the animal has last been hungry and the hunger capacity of the animal, when the quotient reaches 1;
    int Tfood = (time-Ttimediff) / tiger.Hunger; // it means the hunger capacity is bigger than or equal to the time since last hungry

    if (Lfood > 0 & lion.Hungry == false) // If the hunger quotient is bigger than 0, the hungry status is set to true if it hasnt been set already, and the hunger time is started
    {
        lion.Hungry = true;
        Lhunger.Start();
    }
    if (Tfood > 0 & tiger.Hungry == false)
    {
        tiger.Hungry = true;
        Thunger.Start();
    }

    if (lion.Hungry == true) // If the animal is true, the time hungry so far is recorded, if this time is bigger than the limited time that the animal can be hungry, the animal is dead and the game ends.
    {
        timeL = (int)Lhunger.ElapsedMilliseconds/1000;
        if (timeL > lion.Hungerlimit)
        {
            Console.WriteLine("GAME OVER, LION DIED OF HUNGER!");
            Environment.Exit(0);
        }
    }
    if (tiger.Hungry == true)
    {
        timeT = (int)Thunger.ElapsedMilliseconds/1000;
        if (timeT > tiger.Hungerlimit)
        {
            Console.WriteLine("GAME OVER, TIGER DIED OF HUNGER!");
            Environment.Exit(0);
        }
    }

    if (Lsleep % 2 == 0 ) // If the quotient of the time and energy capacity is even, then the animal is awake, if it is odd, the animal sleeps, this maintains a consistent sleep cycle for both animals
    {
        lion.Sleep = false;
    }
    if (Tsleep % 2 == 0)
    {
        tiger.Sleep = false;
    }
    if (Lsleep % 2 == 1)
    {
        lion.Sleep = true;
    }
    if (Tsleep % 2 == 1)
    {
        tiger.Sleep = true;
    }

    Console.WriteLine("Elapsed Time is {0}s", time);

    switch (input) // Cases for different potential user inputs
    {
        case "lion": // If lion is the input, it gives a general idea of the status of the lion, asleep, hungry or neither
            if (lion.Sleep == true && lion.Hungry == true)
            {
                var table = new ConsoleTable("Animal","Status","Response","Time hungry");
                table.AddRow("Lion","Asleep",lion.snore(),timeL);
                table.Write();
                Console.WriteLine();
            }
            else if (lion.Sleep == false && lion.Hungry == true)
            {
                var table = new ConsoleTable("Animal","Status","Response","Time hungry");
                table.AddRow("Lion","Hungry, feed him!",lion.growl(),timeL);
                table.Write();
                Console.WriteLine();
            }
            else if (lion.Sleep == true && lion.Hungry == false)
            {
                var table = new ConsoleTable("Animal","Status","Response");
                table.AddRow("Lion","Asleep",lion.snore());
                table.Write();
                Console.WriteLine();
            }
            else
            {
                var table = new ConsoleTable("Animal","Status","Response");
                table.AddRow("Lion","Chilling out!","mmmmmm");
                table.Write();
                Console.WriteLine();
            }
            break;

        case "tiger": // Same as above but with tiger
            if (tiger.Sleep == true && tiger.Hungry == true)
            {
                var table = new ConsoleTable("Animal","Status","Response","Time hungry");
                table.AddRow("Tiger","Asleep",tiger.snore(),timeT);
                table.Write();
                Console.WriteLine();
            }
            else if (tiger.Sleep == false && tiger.Hungry == true)
            {
                var table = new ConsoleTable("Animal","Status","Response","Time hungry");
                table.AddRow("Tiger","Hungry, feed him!",tiger.growl(),timeT);
                table.Write();
                Console.WriteLine();
            }
            else if (tiger.Sleep == true && tiger.Hungry == false)
            {
                var table = new ConsoleTable("Animal","Status","Response");
                table.AddRow("Tiger","Asleep",tiger.snore());
                table.Write();
                Console.WriteLine();
            }
            else
            {
                var table = new ConsoleTable("Animal","Status","Response");
                table.AddRow("Tiger","Chilling out!","mmmmmm");
                table.Write();
                Console.WriteLine();
            }
            break;
        case "lion antelope": // If the correct food is given to the animal, it is fed and satisfied, if the animal is asleep, it wont be able to recieve the food, if it isnt even hungry, it wont accept the food!
            if (lion.Sleep == false && lion.Hungry == true)
            {
                Lhunger.Reset();
                lion.Hungry = false;
                var table = new ConsoleTable("Animal","Status","Response");
                table.AddRow("Lion","Fed and satisfied!","mmmmm");
                table.Write();
                Console.WriteLine();
                Ltimediff = time;
            }
            else if (lion.Sleep == true && lion.Hungry == true)
            {
                var table = new ConsoleTable("Animal","Status","Response","Time hungry");
                table.AddRow("Lion","Asleep",lion.snore(),timeL);
                table.Write();
                Console.WriteLine();
            }
            else if (lion.Sleep == true && lion.Hungry == false)
            {
                var table = new ConsoleTable("Animal","Status","Response");
                table.AddRow("Lion","Asleep",lion.snore());
                table.Write();
                Console.WriteLine();
            }
            else
            {
                var table = new ConsoleTable("Animal","Status","Response");
                table.AddRow("Lion","He isn't hungry!","mmmmmm");
                table.Write();
                Console.WriteLine();
            }
            break;
        case "tiger antelope": // If the wrong food is given to the animal, it won't be accepted, the other scenarios are the same as above
            if (tiger.Sleep == false && tiger.Hungry == true)
            {
                var table = new ConsoleTable("Animal","Status","Response","Time hungry");
                table.AddRow("Tiger","Hungry, feed him, but not antelope!",tiger.growl(),timeT);
                table.Write();
                Console.WriteLine();
            }
            else if (tiger.Sleep == true && lion.Hungry == true)
            {
                var table = new ConsoleTable("Animal","Status","Response","Time hungry");
                table.AddRow("Tiger","Asleep",tiger.snore(),timeT);
                table.Write();
                Console.WriteLine();
            }
            else if (tiger.Sleep == true && tiger.Hungry == false)
            {
                var table = new ConsoleTable("Animal","Status","Response");
                table.AddRow("Tiger","Asleep",tiger.snore());
                table.Write();
                Console.WriteLine();
            }
            else 
            {
                var table = new ConsoleTable("Animal","Status","Response");
                table.AddRow("Tiger","He isn't hungry!","mmmmmm");
                table.Write();
                Console.WriteLine();
            }
            break;
        case "tiger deer": 
            if (tiger.Sleep == false && tiger.Hungry == true)
            {
                Thunger.Reset();
                tiger.Hungry = false;
                var table = new ConsoleTable("Animal","Status","Response");
                table.AddRow("Tiger","Fed and satisfied!","mmmmm");
                table.Write();
                Console.WriteLine();
                Ttimediff = time;
            }
            else if (tiger.Sleep == true && tiger.Hungry == true)
            {
                var table = new ConsoleTable("Animal","Status","Response","Time hungry");
                table.AddRow("Tiger","Asleep",tiger.snore(),timeT);
                table.Write();
                Console.WriteLine();
            }
            else if (tiger.Sleep == true && tiger.Hungry == false)
            {
                var table = new ConsoleTable("Animal","Status","Response");
                table.AddRow("Tiger","Asleep",tiger.snore());
                table.Write();
                Console.WriteLine();
            }
            else
            {
                var table = new ConsoleTable("Animal","Status","Response");
                table.AddRow("Tiger","He isn't hungry!","mmmmmm");
                table.Write();
                Console.WriteLine();
            }
            break;
        case "lion deer":
            if (lion.Sleep == false && lion.Hungry == true)
            {
                var table = new ConsoleTable("Animal","Status","Response","Time hungry");
                table.AddRow("Lion","Hungry, feed him, but not deer!",lion.growl(),timeL);
                table.Write();
                Console.WriteLine();
            }
            else if (lion.Sleep == true && lion.Hungry == true)
            {
                var table = new ConsoleTable("Animal","Status","Response","Time hungry");
                table.AddRow("Lion","Asleep",lion.snore(),timeL);
                table.Write();
                Console.WriteLine();
            }
            else if (lion.Sleep == true && lion.Hungry == false)
            {
                var table = new ConsoleTable("Animal","Status","Response");
                table.AddRow("Lion","Asleep",lion.snore());
                table.Write();
                Console.WriteLine();
            }
            else
            {
                var table = new ConsoleTable("Animal","Status","Response");
                table.AddRow("Lion","He isn't hungry!","mmmmmm");
                table.Write();
                Console.WriteLine();
            }
            break;
    }

    Console.WriteLine();
}