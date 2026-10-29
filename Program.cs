using System;
using System.Numerics;

public class Program
{

    static void Main()
    {
        var rand = new Random();
        const string MenuTitle = "===== MAIN MENU - CODEQUEST =====";
        const string MenuOption1 = "1. Train your wizard";
        const string MenuOption2 = "2. Check the dungeon";
        const string MenuOption3 = "3. Loot the mine";
        const string MenuOptionExit = "0. Exit game";
        const string MenuPrompt = "Choose an option (1-3) - (0) to exit: ";

        const string ErrorNotNumber = "Error: you must type a number, not text.";
        const string ErrorTooBig = "Error: that number is too big.";
        const string ErrorRange = "Error: the option must be between 0 and 3.";
        const string ErrorNoInput = "Error: no input received.";

        const string InputWizardName = "🧙‍ Input the name of your wizard:";
        const string Greeting = "⏳ Good morning, ";
        const string DayCount = "Today is day: ";
        const string TrainingResult1 = " you have trained ";
        const string TrainingResult2 = " hours, your power is now: ";
        const string LevelUp = " you are now level: ";
        const string FailedTraining = "You failed your training, come back next year";
        const string PassTraining = "You still mix your wand and your spoon";
        const string DecentTraining = "You are a gust of wind summoner";
        const string GoodTraining = "Wow! You can summon drakes without burning the lab!";
        const string ExcellentTraining = "You have achieved the rank of Arcane Master";
        const string RankF = "You obtain the rank --> Raoden the Elantri";
        const string RankD = "You obtain the rank --> Zyn the bugged";
        const string RankC = "You obtain the rank --> Arka Nullpointer";
        const string RankB = "You obtain the rank --> Elarion of the cinders";
        const string RankA = "You obtain the rank --> ITB-Wizard the Grey";
        const string DoorMsg = "You find a door in front of you. You have 3 tries to correctly input the magical code to unlock it (int 1-5): ";
        const string CurrentDoor = "You are on door number: ";
        const string DoorCurrentTry = "You are on try: ";
        const string DoorUnlocked = "You have correctly guessed the magical code, the dragon let's you through!";
        const string DoorTryAgain = "That's not the correct code, try again.";
        const string DoorFailed = "🐲 You failed to open the door, the dragon kicks you from the server!";
        const string DoorWin = "🐲 You have succesfully advanced through the dragon's dungeon. You can now loot its treasure!";
        const string MineGreeting = "🪙 You have conquered the dragon's dungeon and earned the right to loot its treasure.";
        const string MineCongrats = "Congratulations on making it this far";
        const string BitcoinsFound = "You digged through the treasure and found: ";
        const string BitcoinsNotFound = "You digged through the treasure but didn't found anything";
        const string GoldenGPU = "You have unlocked the golden GPU! Your spells now run at 120 FPS!";
        const string TrashGPU = "Your still using integrated graphics, return to the mine to try your luck again!";
        const string TotalBitcoins = "You now have: ";
        const string MineNotUnlocked = "You have yet to earn the right to the dragon's treasure. Conquer it's dungeon and you shall pass.";
        const string MineKick = "The dragon kicks you from his mine for not proving yourself worthy of its treasure";

        // Valor centinella: -1 NO és una opció vàlida.
        // El necessitem perquè el compilador no garanteix que 'option' s'assigni
        // dins del try (pot saltar una excepció abans d'arribar a l'assignació).
        int option = -1, power = 0, level = 1, trainingHours, lastLevel, password, correctPassword, bitcoins = 0;
        bool isValid, hasName = false, unlockMine = false;
        string wizardName = "";


        do
        {
            isValid = false; // A cada volta suposem que l'entrada NO és vàlida



            Console.WriteLine(MenuTitle);
            Console.WriteLine(MenuOption1);
            Console.WriteLine(MenuOption2);
            Console.WriteLine(MenuOption3);
            Console.WriteLine(MenuOptionExit);
            Console.Write(MenuPrompt);

            try
            {
                // int.Parse pot llançar: FormatException, OverflowException
                // o ArgumentNullException (si ReadLine retorna null amb Ctrl+Z / Ctrl+D)
                option = int.Parse(Console.ReadLine());

                // Validació de rang: si no es compleix, LLANÇEM nosaltres l'excepció
                if (option < 0 || option > 3)
                {
                    throw new ArgumentOutOfRangeException(nameof(option), ErrorRange);
                }

                // Si arribem aquí no ha saltat cap excepció: entrada vàlida
                isValid = true;
                Console.WriteLine($"You chose: {option}");
            }
            catch (FormatException)              // Text que no és un número: "abc", "3.5", ""
            {
                Console.WriteLine(ErrorNotNumber);
            }
            catch (OverflowException)            // Número que no cap en un int: "99999999999"
            {
                Console.WriteLine(ErrorTooBig);
            }
            catch (ArgumentNullException)        // ReadLine ha retornat null
            {
                Console.WriteLine(ErrorNoInput);
            }
            catch (ArgumentOutOfRangeException)  // La que hem llançat nosaltres pel rang
            {
                Console.WriteLine(ErrorRange);
            }
            finally
            {
                // S'executa SEMPRE: hi hagi error o no
                Console.WriteLine("----------------------------");
            }

            //Train the wizard

            if (option == 1)
            {

                if (!hasName)
                {
                    Console.WriteLine(InputWizardName);
                    wizardName = Console.ReadLine();
                    hasName = true;
                    Console.WriteLine("-------------------");
                }

                for (int i = 1; i < 6; i++)
                {
                    Console.WriteLine(Greeting + wizardName + "!");
                    Console.WriteLine(DayCount + i);


                    trainingHours = rand.Next(1, 24);
                    power += rand.Next(1, 10);
                    lastLevel = level;
                    level = 1 + (power / 10);

                    Console.WriteLine(wizardName + TrainingResult1 + trainingHours + TrainingResult2 + power + "!");
                    if (level > lastLevel)
                    {
                        Console.WriteLine(wizardName + LevelUp + level + "!");
                    }
                    Console.WriteLine("===================");
                    Console.WriteLine("");
                }
                if (power < 20)
                {
                    Console.WriteLine(FailedTraining);
                    Console.WriteLine(RankF);
                }
                else if (power >= 20 && power < 30)
                {
                    Console.WriteLine(PassTraining);
                    Console.WriteLine(RankD);
                }
                else if (power >= 30 && power < 35)
                {
                    Console.WriteLine(DecentTraining);
                    Console.WriteLine(RankC);
                }
                else if (power >= 35 && power < 40)
                {
                    Console.WriteLine(GoodTraining);
                    Console.WriteLine(RankB);
                }
                else if (power >= 40)
                {
                    Console.WriteLine(ExcellentTraining);
                    Console.WriteLine(RankA);
                }
                Console.WriteLine("=================");
                Console.WriteLine("");
                //Dungeon minigame
            else if (option == 2)
                {
                    for (int i = 1; i < 4; i++)
                    {
                        correctPassword = rand.Next(1, 5);
                        for (int j = 1; j < 4; j++)
                        {

                            Console.WriteLine(CurrentDoor + i);
                            Console.WriteLine(DoorCurrentTry + j);

                            Console.WriteLine(DoorMsg);
                            password = Convert.ToInt32(Console.ReadLine());
                            Console.WriteLine("===================");

                            if (password == correctPassword)
                            {
                                Console.WriteLine(DoorUnlocked);
                                j = 4;
                                if (i == 3)
                                {
                                    Console.WriteLine(DoorWin);
                                    unlockMine = true;
                                }
                            }
                            else if (j == 3)
                            {
                                Console.WriteLine(DoorFailed);
                                i = 4;
                            }
                            else
                            {
                                Console.WriteLine(DoorTryAgain);
                            }
                        }

                    }
                }
                
            }
            


            // Repetim si l'entrada ha estat invàlida O si no han demanat sortir.
            // Comprovem primer !isValid perquè, amb un error, 'option' pot
            // valer 0 d'una volta anterior.

        } while (!isValid || option != 0);

    }
}