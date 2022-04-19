using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LabFootball
{
    class Player
    {
        int ID { get; set; }
        string Name { get; set; }
        private DateTime dateOfBirth;
        public DateTime DateOfBirth {
            get { return dateOfBirth; }
            set { dateOfBirth = value; }
        }
        private int goals;
        public int Goals
        {
            get { return goals; }
            set { goals = value; }
        }

        int TotalGoals { get; set; }
        public Player(int id, string name, int goals, int totalGoals, DateTime dateOfBirth)
        {
            ID = id;
            Name = name;
            Goals = goals;
            TotalGoals = totalGoals;
            DateOfBirth = dateOfBirth;
        }
        public override string ToString()
        {
            return $"Name: {Name}, ID: {ID}, Goals: {Goals}, Total Goals: {TotalGoals}, Birth Date: {DateOfBirth.ToString("dd.MM.yyyy")}{(this.GetType().Name== "PlayerTransfer" ? " (Transfer)":"")}";
        }
    }
}
