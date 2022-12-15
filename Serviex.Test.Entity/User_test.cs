using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace Serviex.Test.Entity
{
    [DataContract]
    public class User_test
    {
        [DataMember]
        public int Id { get; set; }
        [DataMember]
        public string Name { get; set; }
        [DataMember]
        public DateTime Date_of_birth { get; set; }
        [DataMember]
        public string Gender { get; set; }
    }
}
