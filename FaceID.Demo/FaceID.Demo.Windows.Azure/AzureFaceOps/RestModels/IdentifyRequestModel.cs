using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FaceID.Demo.Windows.Azure.AzureFaceOps.RestModels
{
    public class IdentifyRequestModel
    {
        public string PersonGroupId { get; set; }

        public string[] FaceIds { get; set; }

        public int MaxNumOfCandidatesReturned { get; set; }

        public double ConfidenceThreshold { get; set; }
    }

    public class IdentifyResponseModel
    {
        public string FaceId { get; set; }

        public List<Candidate> Candidates { get; set; }

        public ErrorModel Error { get; set; }
    }

    public class Candidate
    {
        public string PersonId { get; set; }

        public double Confidence { get; set; }
    }

    public class ErrorModel
    {
        public string Code { get; set; }

        public string Message { get; set; }
    }
}
