using System;
using System.Collections.Generic;
using System.Text;

namespace TrashTalk.Models
{
    public class TextMessage
    {
        public DateTime DateSent { get; set; }
        public string FriendName { get; set; }
        public string TelNumber { get; set; }
        public int BrewersScore { get; set; }
        public int OpponentScore { get; set; }
        public string Opponent { get; set; }
    }
}
