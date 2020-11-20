using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DungeonLibrary;
using System.Speech.Synthesis;

namespace Dungeon
{
    class Program
    {
        static void Main(string[] args)
        {
            //This is the program that will control the flow of the overall program (the experience of the user). All classes will be build in separate files and referred to in this program to allow us to use instances of the objects.
            Console.Title = "Forest Walker";
            SpeechSynthesizer speech = new SpeechSynthesizer();
            speech.SetOutputToDefaultAudioDevice();
            Console.WriteLine("\n-=-=-= Welcome to ForestWalker =-=-=-\n" +
                @"                              __
                            .d$$b
                          .' TO$;\
                         /  : TP._;
                        / _.;  :Tb|
                       /   /   ;j$j
                   _.-'       d$$$$
                 .' ..       d$$$$;
                /  / P'      d$$$$P. |\
               / '      .d$$$P' |\^'l
             .'           `T$P^'''''  :
         ._.'      _.'                ;
      `-.- '.-'-' ._.       _.-'.-''
    `.-' _____  ._              .-'
   - (.g$$$$$$$b.              .'
     '' ^^ T$$$P ^)            .(:
          _ / -'  /.'         /:/;
       ._.'-'`-'  ')/         /;/;
 `-.- '..--''   ' /         /  ;
.-' ..--''        -'          :
..--''--.- '         (\      .-(\
  ..--''              `-\(\/;`
    _.                      :
                            ;`-
                           :\
                           ; AWWWWOOOOOO");
            var wolfHowl = new System.Media.SoundPlayer();
            wolfHowl.SoundLocation = @"C:\Users\Student\Documents\Visual Studio 2017\Projects\03_CSF2\CSF2\DungeonApp\Dungeon\Resources\wolfHowl01.wav";
            wolfHowl.PlaySync();
            speech.Speak("Welcome to Forest Walker.");
            Console.WriteLine("\tWhat is your name, Traveler?");
            string playerName = Console.ReadLine();
            Console.Clear();
            //Keep a running total variable for the user's score
            int score = 0;
            int monstersKilled = 0;
            Console.WriteLine("\tWelcome, {0}. You are about to embark on a spiritual journey through the North American forest.\nAn animal can be chosen to aid you on your journey.", playerName);
            
            Console.WriteLine();

            //TODO 1. Create a Weapon and a Player
            Weapon dagger = new Weapon(1, 8, "Rusty Dagger", 8, false, "Sword", false, 10, false);
            Weapon bow = new Weapon(1, 8, "Short Bow", 2, false, "Bow", true, 15, true);
            Weapon club = new Weapon(5, 8, "Crude Club", 9, false, "Club", false, 0, false);

            Player player = new Player(playerName, 70, 2, 60, 60, Race.Human, bow);
            //Console.WriteLine(sword); - Commented out after testing ToString() return

            //TODO create a loop for finding animal spirit guides (one land one air?)

            //TODO create companions to choose from
            Companion wolf = new Companion("Lobo", 12, 7, 65, 20, 40, 40, Animal.Wolf, null);
            Companion bear = new Companion("Ben", 7, 4, 60, 40, 85, 85, Animal.Bear, null);
            Companion deer = new Companion("Elliot", 5, 1, 50, 30, 30, 30, Animal.Deer, null);
            Companion bison = new Companion("Strongheart", 6, 2, 60, 60, 100, 100, Animal.Bison, null);
            Companion horse = new Companion("Beau", 4, 1, 30, 90, 50, 50, Animal.Horse, null);
            Companion mouse = new Companion("Ralph", 0, 0, 0, 100, 5, 5, Animal.Mouse, null);
            Companion raccoon = new Companion("Eddie", 3, 2, 90, 10, 20, 20, Animal.Raccoon, null);
            Companion skunk = new Companion("Pepe", 4, 2, 55, 40 ,20, 20, Animal.Skunk, null);
            repeat: Console.Write("Nine animals now appear before you. In the stillness, you sense a purposeful patience in their demeanor. Some of these animals you may have caught glimpses or signs of in your journey earlier. Others you have not seen or heard until now. They all can aid you in some way, but not all of them will necessarily follow you. That is why you must choose your companions wisely.\n\nDo you understand? Y/N:");
            tryAgain: string response = Console.ReadLine().ToUpper();

            if (response == "Y" || response == "YES")
            {
             
            }
            else if (response == "N" || response == "NO")
            {
                Console.WriteLine("Then I will repeat the instructions. Please read carefully.");
                System.Threading.Thread.Sleep(3000);
                Console.Clear();
                goto repeat;
            }
            else
            {
                Console.Write("Invalid input. Did you understand the instructions? Y/N: ");
                goto tryAgain;
            }
            chooseAnimal: string userNum = Console.ReadLine();
            if (userNum == "1" || userNum == "2" || userNum == "3" || userNum == "4" || userNum == "5" || userNum == "6" || userNum == "7" || userNum == "8")
            {
                int companionChoice = int.Parse(userNum);
                Companion[] companions = { wolf, bear, deer, bison, horse, mouse, raccoon, skunk, };
                Character companion = companions[companionChoice];

            }
            else
            {
                Console.WriteLine("Improper input. Please enter a value 1-8 to choose your companion.");
                goto chooseAnimal;
            }
            
            //TODONE 2. Create a loop for the room and monster
            bool exit = false;
            do
            {
                //TODO 3. Call a new room
                Console.WriteLine(GetRoom());
                //TODONE 4. Create a monster
                Dragon d1 = new Dragon();
                Dragon d2 = new Dragon("Toothless", 25, 25, 40, 10, 1, 12, "This is one bad dragon!", true);
                Orc o1 = new Orc();
                Orc o2 = new Orc("gruk", 30, 30, 45, 20, 5, 7, "This brutish Orc is uglier than your average Orc. Which is saying something!", true);
                Specter s1 = new Specter();
                Specter s2 = new Specter("Bloody Bob", 20, 20, 50, 30, 2, 9, "A bloodthirsty specter darts toward you in a blind rage.", true);

                //Since Rabbit and other child classes are children of monster, all can be placed into an array of Monster objects
                Monster[] monsters = { d1, d1, d2, o1, o1, o1, o1, o1, o2, o2, s1, s1, s2 };

                //Randomly select a monster from the array
                Random rand = new Random();
                int randomNumber = rand.Next(monsters.Length);
                Monster monster = monsters[randomNumber];
                Console.WriteLine("A monster appears! " + monster.Name);
                
                //TODO 5. Create a loop for the menu
                bool reload = false;
                do
                {
                    //TODONE 6. Create the menu
                    #region MENU
                    Console.WriteLine("\n\nPlease choose an Action:\n" +
                        "A) Attack\n" +
                        "R) Run Away\n" +
                        "P) Player Info\n" +
                        "M) Monster Info\n" +
                        "C) Companion Info" +
                        "X) Exit\n\n" +
                        $"Score: {score}\n\n");
                    #endregion
                    //TODONE 7. Get User Choice
                    #region UserChoice
                    ConsoleKey userChoice = Console.ReadKey(true).Key;
                    #endregion

                    //TODONE 8. Clear the console after we get input from the user
                    Console.Clear();

                    //TODO need to make program work without statement below
                    Companion companion = wolf;
                    //TODO 9. Build out the switch for userChoice
                    #region Game Experience - Switch
                    switch (userChoice)
                    {
                        case ConsoleKey.A:
                            Console.WriteLine("Attack\n");
                            //TODO 10. Build attack logic and place here
                            Combat.DoBattle(player, companion, monster);
                            if (monster.Life <= 0)
                            {
                                //it's dead - you could put some logic here to have player get items, get life back , or something similar due to defeating the monster.
                                Console.ForegroundColor = ConsoleColor.Green;
                                Console.WriteLine("\nYou killed {0}! The spirit you freed from the monster restores some of your health.\n", monster.Name);
                                Console.ResetColor();
                                player.Life += monster.MaxLife / 4;
                                
                                //get a new room and monster
                                if (monstersKilled < 10 )
                                reload = true;
                                score += monster.MaxLife - (player.MaxLife - player.Life);
                                monstersKilled++;

                            }
                            break;
                        case ConsoleKey.R:
                            Console.WriteLine("Run for your life!");
                            //TODO 11. Build run away logic
                            Console.WriteLine($"{monster.Name} attacks you as you run!\n");
                            Combat.DoAttack(monster, player);
                            //load a new room and monster
                            reload = true;
                            break;
                        case ConsoleKey.P:
                            Console.WriteLine("Player Info");
                            //TODONE 12. Add Player Info
                            Console.WriteLine(player);
                            break;
                        case ConsoleKey.M:
                            Console.WriteLine("Monster Info");
                            //TODONE 13. Add Monster Info
                            Console.WriteLine(monster);
                            break;
                        case ConsoleKey.C:
                            Console.WriteLine("Companion Info");
                            Console.WriteLine(companion);
                            break;
                        case ConsoleKey.X:
                        case ConsoleKey.E:
                            Console.WriteLine("The forest can break even the most battle-hardened. Strengthen your resolve before entering these woods again.");
                            exit = true;
                            break;
                        default:
                            Console.WriteLine("That input was not recognized. Please choose a valid option.\n");
                            break;
                    }
                    #endregion
                    if (player.Life <= 0)
                    {
                        Console.WriteLine("As the light\n");
                        exit = true;
                    }

                    //TODO 14. Handle Player Life

                } while (!reload && !exit);

            } while (!exit);//while exit is NOT TRUE keep in the loop
        }//end Main()
        //TODO 15. Create GetRoom() and plug it in to TODO 3.
        //The signature below says that (private) it will only be available in this file, that it is a static method (only referring to itself), and that it returns a string.
        private static string GetRoom()
        {
            string[] rooms =
            {
                //list string descriptions of rooms comma-separated
                "The room is dark and musty with the smell of lost souls.",
                "You enter a pretty pink powder room and instantly get glitter on you.",
                "You peer through the open doorway into a broad, pillared hall. The columns of stone are carved as tree trunks and seem placed at random like trees in a forest. Stone root systems crawl out into the floor and marble branches expand across the ceiling.",
                "A stone throne stands on a foot-high circular dais in the center of this cold chamber. The throne and dais bear the simple adornments of patterns of crossed lines -- a pattern also employed around each door to the room.",
                 "You inhale a briny smell like the sea as you crack open the door to this chamber. Within you spy the source of the scent: a dark and still pool of brackish water within a low circular wall.Above it stands a strange statue of a lobster - headed and clawed woman.The statue is nearly 15 feet tall and holds the lobster claws crossed over its naked breasts.",
                 "This hallway leads to a dead end, causing you to turn around. When you reach the last room you left, it has changed to an enormous septagonal room, where ivy covers the crumbling metallic walls. The floor is covered with rat droppings. An unlit chandalier hangs overhead.",
                 "Gentle drips of water are heard as you enter a frigid triangular room with damp walls. Bat droppings cover the old floor. Sunlight trickles into the room.",
                 "All sound seems to fade away as you enter an ancient room with worn walls. An inch of water covers the polishedfloor. Moss that lines the wall seems to be glowing, giving off a mysterious light. It seems like this room is a barracks.",
                 "You are able to hear movement in front of you as you enter an outlandish hexagonal room, where moss covers the fortified stone walls. Vines and plants grow from the cracks in the floor. An unlit chandalier hangs overhead."
            };

            Random rand = new Random();
            //since the maxValue is exclusive, we can just use the length to include all indeces from the above.
            int indexNbr = rand.Next(rooms.Length);
            string room = "***** NEW ROOM *****\n" + rooms[indexNbr] + "\n";

            return room;
        }
    }
}
