using System;
using System.Collections.Generic;
using System.Text;

namespace Janus.Domain.Entities
{
    public class TicketComments
    {

        public Guid ID { get; set; }
        
        public string Message { get; set; }
        public string PostedBy { get; set; }
        public string DateTimeCreated { get; set; }

        public Guid TicketID { get; set; }

        public Ticket Tickets { get; private set; }
    }
}
