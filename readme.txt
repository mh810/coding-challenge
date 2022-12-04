ZOO

---------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------

Run using dotnet 7.0 in Visual Studio Code with the C# extenstion installed, utilises the ConsoleTable library.

Includes 2 files, program.cs, which is the main part, and animal.cs, which includes the class definitions used in the program.

---------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------

Welcome to the zoo!
You have 2 animals here, a lion and a tiger
Your job is to feed them when they are hungry before they starve!
You can check if they are hungry by typing 'lion' or 'tiger' respectively
They might be asleep when you check on them, this can work to your disadvantage if they are hungry because you can't feed them while they are asleep! So be quick when they wake up
To feed them, type in the animal you want to feed and what you want to feed them with, so for example, the lion only eats antelopes so you would write 'lion antelope'
The tiger eats only deer so you need to apply the above and feed it on time (by typing 'tiger deer')
When one of the animals is hungry, a new timer appears when you check on them, this is counting how long they have been hungry for so be quick !
When they are fed, they return back to normal but it won't be long until they are hungry again so stay vigilant!

Essentially, the aim of the game is to consistently check on both animals and feed them when they are hungry and awake so they can go back to normal before they die of starvation

---------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------

Program.cs starts with an explanation of the game and then creates an instance of tiger lion and an instance of the tiger classes.

After which the user is prompted to choose a difficulty to play, this determines the hunger and sleep variables set in the lion and tiger instances, which make the game easier or harder, its easier if there is more time
with which to feed the animals.

The stopwatches used in the game are then started and the main loop of the game starts.

Loop:

When an input is given, the total elapsed time is recorded. The animals are checked for if they should be hungry at this point in time, if this is affirmative, they will become hungry and a hunger time is also started.

When an animal is hungry, this hunger time is always monitored and if it is above the limit of hunger time, the game is over.

During all this, if the time is at the point in the animal's sleep cycle where it should be asleep, it will be made to sleep.

If the input was just 'lion' or 'tiger', the user gets a general status update.

If it is one of the animals and then a food, the program acts according to the status of the animal and which combination of animal and food is given, this being either feeding the animal or failing to whether that is
because the animal is asleep or it is not hungry or it is just the wrong combination to give.

---------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------

In animal.cs, there is the base Animal class that has several properties that can be accessed via subsequent methods, this ensures encapsulation of the class.

There are properties for whether the animal is asleep or not, hungry or not, and values for how much time it takes for the animal to get hungry, how long it takes them to feel tired and thus how long they sleep for,
as well as how long they can be hungry for before they die.

There are two virtual methods for the noise made for the snore and growl of the animal. These are overridden in the derived classes of animal, of which there are 2: a lion and a tiger class which inherit all the properties as well.

---------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------

