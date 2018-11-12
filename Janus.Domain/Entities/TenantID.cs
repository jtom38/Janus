using System;
using System.Collections.Generic;
using System.Text;

namespace Janus.Domain.Entities
{
    public class TenantID
    {
        public Guid ID { get; set; }
        public string CompanyName { get; set; }
        public DateTime DateLogged { get; set; }
    }
}
