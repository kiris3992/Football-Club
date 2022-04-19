using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LabFootball
{
    class Program
    {
        static void Main(string[] args)
        {
            App.Start();
        }

        static class App
        {
            static List<Team> teams;
            static InputValidator validator;
            
            public static void Start()
            {
                teams = new List<Team>();
                ManageUserInput("/?");
            }
            public static void AddTeams()
            {
                validator = new InputValidator();
                validator.Add(new InputValidator.IntNumber("Total teams", "How many teams you want ?", 1, 100));
                validator.Add(new InputValidator.IntNumber("Permanent players", "How many Permanent players per Team ?", 1, 100));
                validator.Add(new InputValidator.IntNumber("Transfer players", "How many Transfer players per Team ?", 1, 100));

                for(int i = 0; i < validator.Items.Count; i++)
                {
                    Console.WriteLine(validator.Items[i].Query);
                    string userInput = Console.ReadLine(); 
                    if (userInput == "cancel") 
                    {
                        Console.WriteLine("Action is canceled by user."); break; 
                    }
                    if (!validator.Items[i].Validate(userInput))
                    {
                        Console.WriteLine(validator.Items[i].Message);i--;
                    }
                }

                if (validator.IsValid())
                {
                    object[] vals = validator.GetParamValuesToArray();
                    teams = new List<Team>(Team.GetRandomTeamsToList(Convert.ToInt32(vals[0]), Convert.ToInt32(vals[1]), Convert.ToInt32(vals[2])));
                }
            }
            public static void ManageUserInput(string userInput)
            {
                switch (userInput)
                {
                    case "/?":
                        Console.WriteLine(" a)\tAdd :\n\t\t- Teams, type '1'");
                        Console.WriteLine(" b)\tPrint :\n\t\t- All Teams with players : type '2'\n\t\t- Younger Player of each Team : type '3'\n\t\t- 1st Scorer of each Team : type '4'\n\t\t- Team with best Attack : type '5'");
                        Console.WriteLine(" c.\tInfo :\n\t\t- Exit App, type 'exit'\n\t\t- Clear screen, type '0'\n\t\t- View Help, type '/?'");
                        ManageUserInput(Console.ReadLine());
                        break;

                    case "1":
                        Console.WriteLine("Adding Teams -->");
                        AddTeams();
                        Console.WriteLine($"\nTotal teams added: {teams.Count}\n");
                        ManageUserInput(Console.ReadLine());
                        break;

                    case "2":
                        Console.WriteLine("\nPrinting Teams with Players -->");
                        foreach(Team team in teams)
                        {
                            Console.WriteLine(team.PrintTeamWithPlayers());
                        }
                        Console.WriteLine($"\nEnd of printing {teams.Count} teams.\n");
                        ManageUserInput(Console.ReadLine());
                        break;

                    case "3":
                        Console.WriteLine("\nPrinting Younger Player of each team -->");
                        foreach (Team team in teams)
                        {
                            Console.WriteLine(team.GetTeamInfo());
                            Console.WriteLine($"\t{team.GetYoungerPlayer()}");
                        }
                        Console.WriteLine($"\nEnd of printing Younger players.\n");
                        ManageUserInput(Console.ReadLine());
                        break;

                    case "4":
                        Console.WriteLine("\nPrinting First Scorrer of each team -->");
                        foreach (Team team in teams)
                        {
                            Console.WriteLine(team.GetTeamInfo());
                            Console.WriteLine($"\t{team.GetFirstScorrer()}");
                        }
                        Console.WriteLine($"\nEnd of printing First Scorrer.\n");
                        ManageUserInput(Console.ReadLine());
                        break;

                    case "5":
                        Console.WriteLine("\nTeam with best Attack :");
                        Console.WriteLine(Team.GetBestAttackTeamInfo(teams));
                        ManageUserInput(Console.ReadLine());
                        break;

                    case "0":
                        Console.Clear();
                        Console.WriteLine("Type /? to show help screen.");
                        ManageUserInput(Console.ReadLine());
                        break;

                    case "exit":
                        return;

                    default:
                        Console.Beep();
                        Console.WriteLine("\nWrong input ... To view Help type '/?'");
                        ManageUserInput(Console.ReadLine());
                        break;
                }
            }
        }
    }
}
