
using System.IO;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Extensions.Http;
using Microsoft.AspNetCore.Http;
using Microsoft.Azure.WebJobs.Host;
using Newtonsoft.Json;
using TrashTalk.Models;
using TrashTalk.Utility;
using System.Threading.Tasks;

namespace TrashTalk
{
    [StorageAccount("AzureWebJobsStorage")]
    public static class IFTTTTrigger
    {
        [FunctionName("IFTTTTrigger")]
        [return: Queue("game-results")]
        public static GameResult Run(
            [HttpTrigger(AuthorizationLevel.Function, "post", Route = null)]IFTTTGameResult result,
            TraceWriter log)
        {
            // Break the incoming text apart to get the scores
            var gameResult = Helpers.BreakIFTTTApart(result);

            return gameResult;
        }
    }
}
