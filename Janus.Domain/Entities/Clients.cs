using System;
using System.Collections.Generic;
using System.Text;

namespace Janus.Domain.Entities
{
    public class Clients
    {
        public Guid ID { get; set; }

        public string CompanyName { get; set; }
        public string Address { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public string PhoneNumber { get; set; }
        public string MainContact { get; set; }
        public DateTime DateTimeLogged { get; set; }

        public Guid TenantID { get; set; }
    }
}
