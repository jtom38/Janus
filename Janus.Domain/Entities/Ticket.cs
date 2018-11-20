using System;
using System.Collections.Generic;
using System.Text;

namespace Janus.Domain.Entities
{
    public class Ticket
    {
        public Guid ID { get; set; }

        public DateTime DateTimeCreated { get; set; }
        public DateTime DateTimeEdited { get; set; }
        public string CreatedBy { get; set; }
        public string Message { get; set; }
        public DateTime DateTimeStarted { get; set; }
        public DateTime DateTimeFinished { get; set; }
        public string TicketOwner { get; set; }
        public int TicketNumber { get; set; }
        public string SubmittedBy { get; set; }
        public string Title { get; set; }

        public Status Status { get; set; }
        public Categories Category { get; set; }
        public SubCategories SubCategory { get; set; }
        public ICollection<TicketComments> TicketComments { get; set; }

        public ComputerID Computer { get; set; }

        public Guid TenantID { get; set; }
    }
}
