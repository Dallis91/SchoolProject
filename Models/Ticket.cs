using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ticketApp.Models
{
    public class TicketSystemContext : DbContext
    {
        public TicketSystemContext(DbContextOptions<TicketSystemContext> options)
            : base(options)
        { }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            builder.Ignore<SelectListItem>();
            builder.Ignore<SelectListGroup>();
        }

        public DbSet<Ticket> Tickets { get; set; }
    }

    [Table("Tickets")]
    public partial class Ticket
    {
        [Key]
        public int ID { get; set; } // Unique Identifier

        [Required]
        [Display(Name = "Datum ingediend")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:d}", ApplyFormatInEditMode = true, HtmlEncode = false)]
        public DateTime DateSubmitted { get; set; } // Timestamp of date ticket is submitted

        [Required]
        [Display(Name = "Deadline")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:d}", ApplyFormatInEditMode = true, HtmlEncode = false)]
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
        [DataType(DataType.MultilineText)]
        [StringLength(2147483647)]
        public string Description { get; set; } // Discription of the ticket

        [Required]
        [Display(Name = "Type")]
        public string Type { get; set; } // Type of the ticket -- Opties: Bug, Eis, Wens

        public List<SelectListItem> TypeList { get; } = new List<SelectListItem>
        {
            new SelectListItem { Value = "Bug", Text = "Bug" },
            new SelectListItem { Value = "Eis", Text = "Eis" },
            new SelectListItem { Value = "Wens", Text = "Wens" }
        };

        [Required]
        [Display(Name = "Sprint")]
        public string OurSprintList { get; set; } // Priority within the company -- Opties: Laag, Middelmatig, Hoog

        public List<SelectListItem> Sprints { get; } = new List<SelectListItem>
        {
            new SelectListItem { Value = "1", Text = "Sprint 1" },
            new SelectListItem { Value = "2", Text = "Sprint 2" },
            new SelectListItem { Value = "3", Text = "Sprint 3" },
        };

        [Required]
        [Display(Name = "Status")]
        public string Status { get; set; } // Displays current status -- Opties: Ontvangen, Open, Gesloten

        public List<SelectListItem> StatusList { get; } = new List<SelectListItem>
        {
            new SelectListItem { Value = "1", Text = "Open" },
            new SelectListItem { Value = "2", Text = "Ontvangen" },
            new SelectListItem { Value = "3", Text = "Gesloten" },
        };

        [Required]
        [Display(Name = "Toegewezen aan")]
        [StringLength(50)]
        public string AppointedTo { get; set; } // Name of appointee

        [Display(Name = "Bijlages")]
        public string Attachments { get; set; } // Placeholder for adding attachments
    }
}
