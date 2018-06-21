using System;
using System.Collections.Generic;
using System.Text;
using TrashTalk.Models;

namespace TrashTalk.Utility
{
    public static class Helpers
    {
        public static GameResult BreakIFTTTApart(IFTTTGameResult iftttGameResult)
        {
            try
            {
                var startingCharPosition = iftttGameResult.Text.IndexOf(" ") + 1;
                var endingCharPosition = iftttGameResult.Text.IndexOf(".");

                var teamAndScores = iftttGameResult.Text.Substring(startingCharPosition, endingCharPosition - startingCharPosition)
                                         .Split(new char[] { ' ' });

                var team1Name = teamAndScores[0];
                var team1Score = teamAndScores[1];
                var team2Name = teamAndScores[2];
                var team2Score = teamAndScores[3];

                var result = new GameResult
                {
                    Date = DateTime.Now
                };

                if (team1Name.Equals("Brewers", StringComparison.OrdinalIgnoreCase))
                {
                    result.BrewersScore = int.Parse(team1Score);
                    result.Opponent = team2Name;
                    result.OpponnentScore = int.Parse(team2Score);
                }
                else
                {
                    result.Opponent = team1Name;
                    result.OpponnentScore = int.Parse(team1Score);
                    result.BrewersScore = int.Parse(team2Score);
                }

                result.BrewersWin = result.BrewersScore > result.OpponnentScore;
                result.OpponentWin = !result.BrewersWin;

                return result;
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine(ex.Message);

                return null;
            }
        }
    }
}
