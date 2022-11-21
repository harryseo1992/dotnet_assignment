using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;
using Assignment1_v3.Data;
using Assignment1_v3.Models;
using static Assignment1_v3.Data.ApplicationDbContext;

namespace Assignment1_v3.Models

{
    public class Resolution
    {
        public Guid ResolutionId { get; set; } = Guid.NewGuid();
       [DatabaseGenerated(DatabaseGeneratedOption.Computed)]
       [Display(Name = "Creation Date")]
       [DisplayFormat(DataFormatString = "{0:MM/dd/yyyy}")]
       public DateTime? CreationDate { get; set; }

       [Display(Name = "Abstract")]
       public string? ResolutionAbstract { get; set; }

       [EnumDataType(typeof(Status))]
       [Display(Name = "Status")]
       public Status? Status { get; set; }

       public List<Feedback>? Feedbacks { get; set; }

        [Display(Name = "Board Member")]
        public string? UserId { get; set; }
        [ForeignKey("UserId")]
        public ApplicationUser? ApplicationUser { get; set; }
    
    }
}