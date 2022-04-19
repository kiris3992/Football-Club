using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LabFootball
{
    class PlayerPermanent : Player
    {
        public PlayerPermanent(int id, string name, int goals, int totalGoals, DateTime dateOfBirth) : base(id, name, goals, totalGoals, dateOfBirth)
        {

        }
    }
}
