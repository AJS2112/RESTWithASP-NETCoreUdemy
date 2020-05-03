using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Threading.Tasks;

namespace RESTWithASPNETCoreUdemy.Data.VO
{
    [DataContract]
    public class BookVO 
    { 
        [DataMember (Order = 1, Name = "codigo")]
        public long? Id { get; set; }
        [DataMember(Order = 2, Name = "Titulo")]
        public string Title { get; set; }
        [DataMember(Order = 3, Name = "Autor")]
        public string Author { get; set; }
        [DataMember(Order = 5, Name = "Preço")]
        public decimal Price { get; set; }
        [DataMember(Order = 4, Name = "Lançamento")]
        public DateTime LaunchDate { get; set; }
    }
}
 