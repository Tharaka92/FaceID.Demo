using FaceID.Demo.Windows.Azure;
using FaceID.Demo.Windows.Azure.AzureFaceOps;
using FaceID.Demo.Windows.Azure.AzureFaceOps.RestModels;
using Microsoft.Azure.CognitiveServices.Vision.Face;
using Microsoft.Azure.CognitiveServices.Vision.Face.Models;
using Microsoft.Rest;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using System.Web;

namespace FaceID.Demo.Windows.Azure
{
    public static class FaceService
    {
        private static readonly string SUBSCRIPTION_KEY = "b00d00addaed44de943b1c39f0d1fb07";
        //private static readonly string ENDPOINT = "https://focofaceid.cognitiveservices.azure.com/";
        //private static readonly string ENDPOINT = "https://westus2.api.cognitive.microsoft.com";
        private static readonly string ENDPOINT = "https://eastus.api.cognitive.microsoft.com";

        //private static readonly IFaceServiceClient faceServiceClient;

        //private static string groupId = "demo";
        private static string groupId = "focogroup";

        //private static IFaceServiceClient InitAzureOxfordFace()
        //{
        //    return new FaceServiceClient(SUBSCRIPTION_KEY, ENDPOINT);
        //}

        private static IFaceClient InitAzureOfficialFace()
        {
            return new FaceClient(new ApiKeyServiceClientCredentials(SUBSCRIPTION_KEY)) { Endpoint = ENDPOINT };
        }

        public static async Task CreatePersonAsync(string name, string description, byte[] imgdata)
        {
            try
            {
                //var response = InitAzureOxfordFace().CreatePersonAsync(groupId, name, description);
                //await InitAzureOfficialFace().PersonGroup.CreateAsync(groupId, recognitionModel: RecognitionModel.Recognition02);
                var response = await InitAzureOfficialFace().PersonGroupPerson.CreateAsync(groupId, name, description);
                await AddFaceAsync(response.PersonId, imgdata);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public static async Task AddFaceAsync(Guid personId, byte[] imgdata)
        {
            try
            {
                //await InitAzureOxfordFace().AddPersonFaceAsync(groupId, personId, new MemoryStream(imgdata));
                //await InitAzureOxfordFace().TrainPersonGroupAsync(groupId);

                await InitAzureOfficialFace().PersonGroupPerson.AddFaceFromStreamAsync(groupId, personId, new MemoryStream(imgdata));
                await InitAzureOfficialFace().PersonGroup.TrainAsync(groupId); //Should wait until the traning is completed.
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public static async Task<List<UserViewModel>> RecognizeAsync(byte[] imgdata)
        {
            try
            {
                //var imageCandidates = (await InitAzureOxfordFace().DetectAsync(new MemoryStream(imgdata))).Select(c => new UserViewModel(c.FaceId)).ToList();

                var imageCandidates = (await InitAzureOfficialFace().Face.DetectWithStreamAsync(new MemoryStream(imgdata), recognitionModel: RecognitionModel.Recognition02)).ToList();

                List<UserViewModel> users = new List<UserViewModel>();

                if (imageCandidates.Any())
                {
                    //var response = await InitAzureOxfordFace().IdentifyAsync(groupId, imageCandidates.Select(c => c.Id).ToArray(), (float)0.65, 1);

                    List<string> faceIds = imageCandidates.Select(c => c.FaceId.Value.ToString()).ToList();

                    //var response = await InitAzureOfficialFace().Face.IdentifyAsync(faceIds, groupId, null, 1, 0.5);

                    var requestModel = new IdentifyRequestModel
                    {
                        PersonGroupId = groupId,
                        FaceIds = faceIds.ToArray(),
                        MaxNumOfCandidatesReturned = 1,
                        ConfidenceThreshold = 0.5
                    };

                    var response = await AzureFaceRestClient.IdentifyAsync(SUBSCRIPTION_KEY, ENDPOINT, requestModel);

                    //var persons = await GetAllAsync();

                    foreach (var item in response)
                    {
                        var current = item.Candidates.FirstOrDefault();
                        if (current != null)
                        {
                            var candidate = await GetAllAsync(Guid.Parse(current.PersonId));
                            candidate.Confidence = current.Confidence;

                            users.Add(candidate);
                        }
                    }
                }
                return users.Where(c => c.Confidence.HasValue).ToList();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public static async Task<UserViewModel> GetAllAsync(Guid personId)
        {
            try
            {
                //return (await InitAzureOxfordFace().GetPersonsAsync(groupId)).Select(p => new UserViewModel(p.Name, p.UserData, p.PersonId)).ToList();

                var person = (await InitAzureOfficialFace().PersonGroupPerson.GetAsync(groupId, personId));
                return new UserViewModel { Name = person.Name, Id = person.PersonId, Description = person.UserData };
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}