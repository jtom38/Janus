using System;
using System.Collections.Generic;
using System.Text;

namespace Janus.Domain.Entities
{
    public class WindowsUpdates
    {
        public WindowsUpdates()
        {
            ComputerID = new HashSet<ComputerID>();
        }

        public Guid ID { get; set; }                

        public string HotFixID { get; set; }
        public string InstalledOn { get; set; }
        public string Description { get; set; }
        public string Caption { get; set; }
        public string HostName { get; set; }
        public DateTime DateTimeAdded { get; set; }

        public ICollection<ComputerID> ComputerID { get; set; }

        public Guid TenantID { get; set; }
    }
}
