using System;
using System.Collections.Generic;
using System.Text;

namespace Janus.Domain.Entities
{
    public class Network
    {
        public Guid ID { get; set; }

        public string IpAddressV4 { get; set; }
        public string IpAddressV6 { get; set; }
        public string MacAddress { get; set; }
        public string SubNet { get; set; }
        public string Gateway { get; set; }
        public string DNS01 { get; set; }
        public string DNS02 { get; set; }
        public bool DhcpEnabled { get; set; }
        public string DhcpServer { get; set; }
        public DateTime? DateTimeAdded { get; set; }
        public string ComputerID { get; set; }
        public string Description { get; set; }
        public string DnsDomain { get; set; }

        public Guid TenantID { get; set; }
    }
}
