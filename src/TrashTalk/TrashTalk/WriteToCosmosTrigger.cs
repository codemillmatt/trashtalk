using System;
using System.Threading.Tasks;
using System.Collections.Generic;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Host;
using TrashTalk.Models;
using Microsoft.Azure.Documents.Client;
using Microsoft.Azure.Documents.Linq;
using System.Linq;

namespace TrashTalk
{
    public static class WriteToCosmosTrigger
    {
        //[FunctionName("WriteToCosmosTrigger")]
        //public static async Task Run(
        //    [QueueTrigger("game-results", Connection = "AzureWebJobsStorage")]GameResult gameResult,
        //    [CosmosDB(databaseName: "trashtalk-db", collectionName: "trashtalk-coll", ConnectionStringSetting = "CosmosDBConnection")]
        //DocumentClient client,
        //    TraceWriter log)
        //{
        //    try
        //    {
        //        Uri collectionUri = UriFactory.CreateDocumentCollectionUri("trashtalk-db", "trashtalk-coll");

        //        // load up all the friends
        //        IDocumentQuery<FriendInfo> friendQuery = client.CreateDocumentQuery<FriendInfo>(collectionUri)
        //            .Where(fi => fi.FavoriteTeam == gameResult.Opponent)
        //            .AsDocumentQuery();

        //        while (friendQuery.HasMoreResults)
        //        {
        //            foreach (var friend in await friendQuery.ExecuteNextAsync<FriendInfo>())
        //            {
        //                var sms = new TextMessage
        //                {
        //                    BrewersScore = gameResult.BrewersScore,
        //                    FriendName = friend.Name,
        //                    Opponent = gameResult.Opponent,
        //                    OpponentScore = gameResult.OpponnentScore,
        //                    TelNumber = friend.TelNumber,
        //                    DateSent = DateTime.Today
        //                };

        //                await client.CreateDocumentAsync(collectionUri, sms);
        //            }
        //        }

        //    }
        //    catch (Exception ex)
        //    {
        //        log.Error(ex.StackTrace);
        //    }
        //}
    }
}
