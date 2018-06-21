
using System.IO;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Extensions.Http;
using Microsoft.AspNetCore.Http;
using Microsoft.Azure.WebJobs.Host;
using Newtonsoft.Json;
using System.Threading.Tasks;
using System.Collections.Generic;
using TrashTalk.Models;
using Twilio.Rest.Api.V2010.Account;
using Twilio.Types;
using System;

namespace TrashTalk
{
    public static class TalkTrashFunction
    {
        const string dbName = "trashtalk-db";
        const string collName = "trashtalk-coll";
        const string conxString = "CosmosDBConnection";

        [FunctionName("TalkTrashFunction")]
        [return: TwilioSms(AccountSidSetting ="TwilioAccountSID", AuthTokenSetting="TwilioAuthKey")] 
        public async static Task<CreateMessageOptions> Run(
            [QueueTrigger(queueName:"game-results", Connection ="AzureWebJobsStorage")]
                GameResult gameResultFromQueue,
            [CosmosDB(databaseName:dbName, collectionName:collName, ConnectionStringSetting =conxString,
                SqlQuery ="SELECT * FROM c WHERE c.FavoriteTeam = {Opponent}")] IEnumerable<FriendInfo> friends,
            [CosmosDB(databaseName:dbName, collectionName:collName, ConnectionStringSetting =conxString)]
                IAsyncCollector<GameResult> writeResultsToCosmos,
            //[TwilioSms(AccountSidSetting ="TwilioAccountSID",AuthTokenSetting ="TwilioAuthKey")]
            //    IAsyncCollector<CreateMessageOptions>smsMessages,
            TraceWriter log)
        {
            // First write the game result to cosmos
            await writeResultsToCosmos.AddAsync(gameResultFromQueue);

            // Make sure the Brewers won - if so, text all our friends!
            if (!gameResultFromQueue.BrewersWin)
                return null;

            foreach (var friend in friends)
            {
                var msgOptions = new CreateMessageOptions(new PhoneNumber(friend.TelNumber))
                {
                    From = new PhoneNumber(GetEnvironmentVariable("TwilioFromPhone")),
                    Body = $"Yeah - the Brewers beat the {gameResultFromQueue.Opponent} again {friend.Name}!! HA HA HA HA HA!!!"
                };

                return msgOptions;

                //await smsMessages.AddAsync(msgOptions);
            }

            return null;
        }

        public static string GetEnvironmentVariable(string name)
        {
            return Environment.GetEnvironmentVariable(name, EnvironmentVariableTarget.Process);
        }
    }

}
