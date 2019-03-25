using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;

namespace ticketApp.Models
{
    public class TicketSystemContext : DbContext
    {
        public TicketSystemContext(DbContextOptions<TicketSystemContext> options)
            : base(options)
        { }

        public DbSet<Ticket> Tickets { get; set; }
    }

    public class Ticket
    {
        public int ID { get; set; } // Unique Identifier
        public string DateSubmitted { get; set; } // Timestamp of date ticket is submitted
        public string Deadline { get; set; } // Self imposed deadline
        public string Title { get; set; } // Title of the ticket
        public string Email { get; set; } // Email of the client
        public string ApplicationName { get; set; } // Name of the application described in the ticket
        public string Description { get; set; } // Discription of the ticket
        public string Type { get; set; } // Type of the ticket
        public string ClientName { get; set; } // Name of the client
        public int ClientPriority { get; set; } // Priority given by client
        public int OurPriority { get; set; } // Priority within the company
        public string AppointedTo { get; set; } // Name of appointee
        public int Status { get; set; } // Displays current status
        public int Attachments { get; set; } // Placeholder for adding attachments
    }
}
