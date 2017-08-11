using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SQLLibrary
{
    public class HighScore
    {
        public int ID { get; set; }
        public string PlayerName { get; set; }
        public string Score { get; set; }
        public string Difficulty { get; set; }

        public HighScore(int id, string playerName, string score, string difficulty)
        {
            ID = id;
            PlayerName = playerName;
            Score = score;
            Difficulty = difficulty;
        }

    }

}
