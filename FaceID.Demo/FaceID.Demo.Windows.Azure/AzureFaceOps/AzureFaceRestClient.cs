using FaceID.Demo.Windows.Azure.AzureFaceOps.RestModels;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace FaceID.Demo.Windows.Azure.AzureFaceOps
{
    public static class AzureFaceRestClient
    {
        public static async Task<List<IdentifyResponseModel>> IdentifyAsync(string subscriptionKey, string endpoint, IdentifyRequestModel model)
        {
            try
            {
                string uriBase = $"{endpoint}/face/v1.0/identify";

                HttpClient client = new HttpClient();

                client.DefaultRequestHeaders.Add("Ocp-Apim-Subscription-Key", subscriptionKey);

                var json = JsonConvert.SerializeObject(model);

                HttpResponseMessage response;

                var data = new StringContent(json, Encoding.UTF8, "application/json");

                response = await client.PostAsync(uriBase, data);

                string result = response.Content.ReadAsStringAsync().Result;

                return JsonConvert.DeserializeObject<List<IdentifyResponseModel>>(result);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
