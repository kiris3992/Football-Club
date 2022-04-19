using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LabFootball
{
    class Team
    {
        int ID { get; set; }
        string Name { get; set; }
        public int Attack {
            get
            {
                return Players.Sum(o => o.Goals);
            }
        }
        List<Player> Players { get; set; }
        public Team(int id, string name,List<Player> players)
        {
            ID = id;
            Name = name;
            Players = new List<Player>(players);
        }

        public string GetTeamInfo()
        {
            return $"\nTeam ID: {ID} Name: {Name} Attack: {Attack}";
        }
        public string PrintTeamWithPlayers()
        {
            string str = GetTeamInfo();
            str += "\n\tPlayers:";
            foreach(Player player in Players)
            {
                str += $"\n\t{player}";
            }
            return str;
        }
        public string GetYoungerPlayer() // Edo logika prepei na mpei kai elenxos gia thn periptosh pou yparxoun ides Birth Dates...
        {
            var p = Players[0];
            foreach (Player player in Players)
            {
                if (player.DateOfBirth > p.DateOfBirth) p = player;
            }
            return p.ToString();
        }
        public string GetFirstScorrer() // Edo logika prepei na mpei kai elenxos gia thn periptosh pou yparxoun idia Goal h' na metrane meta ta Total Goals...
        {
            var p = Players[0];
            foreach (Player player in Players)
            {
                if (player.Goals > p.Goals) p = player;
            }
            return p.ToString();
        }
        
        public static string GetBestAttackTeamInfo(List<Team> teams)
        {
            var t = teams[0];
            foreach(Team team in teams)
            {
                if (team.Attack > t.Attack) t = team;
            }
            return t.GetTeamInfo();
        }
        public static List<Team> GetRandomTeamsToList(int totalTeams, int totalPermanentPlayers, int totalTransferPlayers)
        {
            Random rnd = new Random();
            List<Team> teams = new List<Team>();
            List<string> randTeamNames = new List<string>();
            List<string> teamNames = new List<string>() { "Liverpool FC", "Manchester City", "Bayern München", "Real Madrid", "Chelsea FC", "Barcelona", "Inter Milan", "Ajax Amsterdam", "RB Leipzig", "Paris Saint-Germain", "Atlético Madrid", "SSC Napoli", "Villarreal", "FC Porto", "AC Milan", "Atlético Mineiro", "Benfica", "Juventus", "Borussia Dortmund", "Flamengo", "Tottenham Hotspur", "Sevilla", "Sporting", "Roma", "River Plate", "Manchester United", "Palmeiras", "Red Bull Salzburg", "Arsenal", "FK Red Star Belgrade", "Bayer Leverkusen", "Atalanta", "Lazio", "Real Betis", "Slavia Prague", "Al Ahly", "PSV Eindhoven", "West Ham United", "Real Sociedad", "Rangers", "Freiburg", "Flora Tallinn", "Shakhtar Donetsk", "Leicester City", "Feyenoord", "Olympiakos", "Monaco", "Fiorentina", "Marseille", "Celtic", "Defensa y Justicia", "FC Union Berlin", "Rennes", "Celta Vigo", "Lyon", "Zenit St. Petersburg", "Crystal Palace", "Dinamo Zagreb", "Lille", "FC Sheriff", "Eintracht Frankfurt", "Sassuolo", "Kawasaki Frontale", "Al Hilal", "Athletic Bilbao", "FC Köln", "Partizan Beograd", "Dynamo Kyiv", "Wolverhampton Wanderers", "Red Bull Bragantino SP", "FCI Levadia Tallinn", "Braga", "AZ Alkmaar", "Sparta Prague", "Osasuna", "Newcastle United", "Ceará SC", "Tigres UANL", "Boca Juniors", "The New Saints", "Viktoria Plzeň", "Hellas Verona", "Valencia", "Hoffenheim", "São Paulo", "Fluminense FC", "Ulsan Hyundai", "Club Brugge", "Udinese", "RC Strasbourg", "Aston Villa", "Young Boys", "Corinthians", "PFC Ludogorets 1945 Razgrad", "Atlético Goianiense", "BATE Borisov", "Mamelodi Sundowns FC", "Mainz", "Nice", "PAOK FC" };
            while (randTeamNames.Count < totalTeams)
            {
                string rName = teamNames[rnd.Next(0, teamNames.Count)];
                if (!randTeamNames.Contains(rName) || randTeamNames.Count >= teamNames.Count) randTeamNames.Add(rName);
            }

            List<string> playerNames = new List<string>() { "Lionel Messi", "Cristiano Ronaldo", "Xavi", "Andres Iniesta", "Zlatan Ibrahimovic", "Radamel Falcao", "Robin van Persie", "Andrea Pirlo", "Yaya Toure", "Edinson Cavani", "Sergio Aguero", "Iker Casillas", "Neymar", "Sergio Busquets", "Xabi Alonso", "Thiago Silva", "Mesut Ozil", "David Silva", "Bastian Schweinsteiger", "Gianluigi Buffon", "Luis Suarez", "Sergio Ramos", "Vincent Kompany", "Gerard Pique", "Philipp Lahm", "Willian", "Marco Reus", "Franck Ribery", "Manuel Neuer", "Ashley Cole", "Wayne Rooney", "Juan Mata", "Thomas Muller", "Mario Götze", "Karim Benzema", "Cesc Fabregas", "Oscar", "Fernandinho", "Javier Mascherano", "Gareth Bale", "Javier Zanetti", "Daniele De Rossi", "Dani Alves", "Petr Cech", "Mats Hummels", "Carles Puyol", "Angel Di Maria", "Carlos Tevez", "Didier Drogba", "Giorgio Chiellini", "Marcelo", "Stephan El Shaarawy", "Toni Kroos", "Samuel Eto’o", "Jordi Alba", "Mario Gomez", "Arturo Vidal", "Eden Hazard", "James Rodriguez", "Marouane Fellaini", "Ramires", "David Villa", "Klaas Jan Huntelaar", "Nemanja Vidic", "Joe Hart", "Arjen Robben", "Mario Balotelli", "Mathieu Valbuena", "Pierre-Emerick Aubameyang", "Robert Lewandowski", "Hernanes", "Pedro", "Santi Cazorla", "Christian Eriksen", "Ezequiel Lavezzi", "Joao Moutinho", "Mario Mandžukić", "Patrice Evra", "David Luiz", "Luka Modric", "Victor Wanyama", "Mapou Yanga-M'Biwa", "Hulk", "Darijo Srna", "Emmanuel Mayuka", "John Terry", "Kwadwo Asamoah", "Leonardo Bonucci", "Javier Pastore", "Henrikh Mkhitaryan", "Moussa Dembele", "Hatem Ben Arfa", "Samir Nasri", "Shinji Kagawa", "Wesley Sneijder", "Pepe", "Marek Hamsik", "Javi Martinez", "Diego Forlan", "Paulinho" };
            for (int i = 0; i < randTeamNames.Count; i++)
            {
                List<string> randNames = new List<string>();
                while (randNames.Count < (totalPermanentPlayers + totalTransferPlayers) + 1)
                {
                    string rName = playerNames[rnd.Next(0, playerNames.Count)];
                    if (!randNames.Contains(rName) || randNames.Count >= playerNames.Count) randNames.Add(rName);
                }
                List<Player> players = new List<Player>();
                for (int j = 0; j < randNames.Count - 1; j++)
                {
                    int goals = rnd.Next(0, 21);
                    DateTime dt = new DateTime(DateTime.Now.Year, 1, 1).AddYears(-40).AddDays(rnd.Next(0, 365 * 20));
                    if (j < totalPermanentPlayers)
                    {
                        players.Add(new PlayerPermanent(j + 1, randNames[j], goals, rnd.Next(goals, goals + 80), dt));
                    }
                    else
                    {
                        players.Add(new PlayerTransfer(j + 1, randNames[j], goals, rnd.Next(goals, goals + 80), dt));
                    }
                }

                teams.Add(new Team(i + 1, randTeamNames[i], players));
            }

            return teams;
        }
    }
}
