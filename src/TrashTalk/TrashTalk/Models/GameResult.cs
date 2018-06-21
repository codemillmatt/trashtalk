using System;
using System.Collections.Generic;
using System.Text;

namespace TrashTalk.Models
{
    public class GameResult
    {
        public DateTime Date { get; set; }
        public string Opponent { get; set; }
        public int OpponnentScore { get; set; }
        public int BrewersScore { get; set; }
        public bool OpponentWin { get; set; }
        public bool BrewersWin { get; set; }
    }
}
