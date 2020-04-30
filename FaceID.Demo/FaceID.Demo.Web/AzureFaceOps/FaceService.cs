using FaceID.Demo.Web.Models;
using Microsoft.Azure.CognitiveServices.Vision.Face;
using Microsoft.Azure.CognitiveServices.Vision.Face.Models;
using Microsoft.ProjectOxford.Face;
using Microsoft.Rest;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using System.Web;

namespace FaceID.Demo.Web.AzureFaceOps
{
    public static class FaceService
    {
        private static readonly string SUBSCRIPTION_KEY = "a08d3e408c514d7390e3e2fde7720013";
        //private static readonly string ENDPOINT = "https://focofaceid.cognitiveservices.azure.com/";
        private static readonly string ENDPOINT = "https://westus2.api.cognitive.microsoft.com/";

        //private static readonly IFaceServiceClient faceServiceClient;
        private static string groupId = "demo";

        private static IFaceServiceClient InitAzureOxfordFace()
        {
            return new FaceServiceClient(SUBSCRIPTION_KEY, ENDPOINT);
        }

        private static IFaceClient InitAzureOfficialFace()
        {
            return new FaceClient(new ApiKeyServiceClientCredentials(SUBSCRIPTION_KEY)) { Endpoint = ENDPOINT };
        }

        public static async Task CreatePersonAsync(string name, string description, byte[] imgdata)
        {
            //var response = InitAzureOxfordFace().CreatePersonAsync(groupId, name, description);

            var response = await InitAzureOfficialFace().PersonGroupPerson.CreateAsync(groupId, name, description);
            await AddFaceAsync(response.PersonId, imgdata);
        }

        public static async Task AddFaceAsync(Guid personId, byte[] imgdata)
        {
            //await InitAzureOxfordFace().AddPersonFaceAsync(groupId, personId, new MemoryStream(imgdata));
            //await InitAzureOxfordFace().TrainPersonGroupAsync(groupId);

            await InitAzureOfficialFace().PersonGroupPerson.AddFaceFromStreamAsync(groupId, personId, new MemoryStream(imgdata));
            await InitAzureOfficialFace().PersonGroup.TrainAsync(groupId); //Should wait until the traning is completed.
        }

        public static async Task<List<UserViewModel>> RecognizeAsync(byte[] imgdata)
        {
            //var imageCandidates = (await InitAzureOxfordFace().DetectAsync(new MemoryStream(imgdata))).Select(c => new UserViewModel(c.FaceId)).ToList();

            var imageCandidates = (await InitAzureOfficialFace().Face.DetectWithStreamAsync(new MemoryStream(imgdata), recognitionModel: RecognitionModel.Recognition01)).ToList();

            List<UserViewModel> users = new List<UserViewModel>();

            if (imageCandidates.Any())
            {
                //var response = await InitAzureOxfordFace().IdentifyAsync(groupId, imageCandidates.Select(c => c.Id).ToArray(), (float)0.65, 1);

                List<Guid> faceIds = imageCandidates.Select(c => c.FaceId.Value).ToList();

                var response = await InitAzureOfficialFace().Face.IdentifyAsync(faceIds, groupId, null, 1, 0.5);
                //var persons = await GetAllAsync();

                for (var i = 0; i < response.Count; i++)
                {
                    var current = response[i].Candidates.FirstOrDefault();
                    if (current != null)
                    {
                        var candidate = await GetAllAsync(current.PersonId);
                        users[i].Name = candidate.Name;
                        users[i].Description = candidate.Description;
                        users[i].Confidence = current.Confidence;
                    }
                }
            }
            return users.Where(c => c.Confidence.HasValue).ToList();
        }

        public static async Task<UserViewModel> GetAllAsync(Guid personId)
        {
            //return (await InitAzureOxfordFace().GetPersonsAsync(groupId)).Select(p => new UserViewModel(p.Name, p.UserData, p.PersonId)).ToList();

            var person = (await InitAzureOfficialFace().PersonGroupPerson.GetAsync(groupId, personId));
            return new UserViewModel { Name = person.Name, Id = person.PersonId, Description = person.UserData };
        }
    }
}