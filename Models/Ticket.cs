using Microsoft.EntityFrameworkCore;
using System;
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
        [Key]
        public int ID { get; set; } // Unique Identifier

        [Required]
        [Display(Name ="Datum ingediend")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime DateSubmitted { get; set; } // Timestamp of date ticket is submitted

        [Required]
        [Display(Name = "Deadline")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime Deadline { get; set; } // Self imposed deadline

        [Required]
        [Display(Name = "Applicatie")]
        [StringLength(50)]
        public string ApplicationName { get; set; } // Name of the application described in the ticket

        [Required]
        [Display(Name = "Klant")]
        [StringLength(50)]
        public string ClientName { get; set; } // Name of the client

        [Required]
        [Display(Name = "Email")]
        [StringLength(50)]
        public string Email { get; set; } // Email of the client

        [Required]
        [Display(Name = "Titel")]
        [StringLength(50, MinimumLength = 4)]
        public string Title { get; set; } // Title of the ticket

        [Required]
        [Display(Name = "Omschrijving")]
        [StringLength(2147483647)]
        public string Description { get; set; } // Discription of the ticket

        [Required]
        [Display(Name = "Type")]
        public TypeEnum EnumType { get; set; } // Type of the ticket

        public enum TypeEnum
        {
            [Display(Name = "Bug")]
            Bug,
            [Display(Name = "Eis")]
            Demand,
            [Display(Name = "Wens")]
            Wish
        }

        [Required]
        [Display(Name = "Prioriteit(klant)")]
        public ClientPrioEnum ClientPriority { get; set; } // Priority given by client

        public enum ClientPrioEnum
        {
            [Display(Name = "1")]
            One,
            [Display(Name = "2")]
            Two,
            [Display(Name = "3")]
            Three,
            [Display(Name = "4")]
            Four,
            [Display(Name = "5")]
            Five
        }

        [Required]
        [Display(Name = "Prioriteit(intern)")]
        public int OurPriority { get; set; } // Priority within the company

        public enum OurPrioEnum
        {
            [Display(Name = "1")]
            One,
            [Display(Name = "2")]
            Two,
            [Display(Name = "3")]
            Three,
            [Display(Name = "4")]
            Four,
            [Display(Name = "5")]
            Five
        }

        [Required]
        [Display(Name = "Status")]
        [Range(0, 5)]
        public int Status { get; set; } // Displays current status -- Opties: Open, Gesloten

        [Required]
        [Display(Name = "Toegewezen aan")]
        [StringLength(50)]
        public string AppointedTo { get; set; } // Name of appointee

        [Required]
        [Display(Name = "Bijlages")]
        public byte[] Attachments { get; set; } // Placeholder for adding attachments
    }
}
