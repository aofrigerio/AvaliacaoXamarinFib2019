using System;
using System.Runtime.Serialization;

namespace MultPlatProject
{
    [DataContract]
    public class ErrorResponse
    {
        [DataMember(Name="message")]
        public string Message { get; set; }

        [DataMember(Name="code")]
        public int Code { get; set; }
    }
}
