using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Extensions.Http;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using System.IO;
using System.Threading.Tasks;

namespace PalindromString
{
    public static class CheckPalindromStringAzFun
    {
        [FunctionName("CheckPalindromString")]
        public static async Task<IActionResult> Run(
            [HttpTrigger(AuthorizationLevel.Function, "get", "post", Route = null)] HttpRequest req,
            ILogger log)
        {
            log.LogInformation("C# HTTP trigger function processed a request.");

            string word = req.Query["word"];
            bool result = false;

            string requestBody = await new StreamReader(req.Body).ReadToEndAsync();
            dynamic data = JsonConvert.DeserializeObject(requestBody);
            word = word ?? data?.word;
            result = CheckPalindromString.CheckPalindrom(word);

            string responseMessage = string.IsNullOrEmpty(word)
                ? "This HTTP triggered function executed successfully. Pass a string word in the query string or in the request body for a personalized response."
                : $"{word} is {resultWord(result)}Palindrom string.";

            return new OkObjectResult(responseMessage);
        }
        static string resultWord(bool r) => r ? "" : "not a ";
    }
}
