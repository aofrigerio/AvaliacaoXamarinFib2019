using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Text;

namespace MultPlatProject
{
    [DataContract]
    public class Book : BaseDTO
    {
        [DataMember(Name = "title")]
        public string Title { get; set; }

        [DataMember(Name = "cover")]
        public string Cover { get; set; }

        [DataMember(Name = "quantity")]
        public int Quantity { get; set; }

        [DataMember(Name = "author")]
        public Author Author { get; set; }
        
    }
}
