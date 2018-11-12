using System;
using System.Collections.Generic;
using System.Text;

namespace Janus.Domain.Entities
{
    public class Techs
    {
        public Guid ID { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string EmailAddress { get; set; }
        public DateTime DateLogged { get; set; }

        public Guid TenantID { get; set; }
    }
}
