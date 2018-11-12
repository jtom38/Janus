using System;
using System.Collections.Generic;
using System.Text;

namespace Janus.Domain.Entities
{
    public class HardDrives
    {
        public Guid ID { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string FileSystem { get; set; }
        public string SerialNumber { get; set; }
        public string FreeSpace { get; set; }
        public string TotalSpace { get; set; }        
        public string DateTimeAdded { get; set; }
        public string DateTimeEdited { get; set; }
        
        public ICollection<ComputerID> ComputerID { get; set; }

        public Guid TenantID { get; set; }
    }
}
