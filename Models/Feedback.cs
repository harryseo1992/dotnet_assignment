using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace Assignment1_v3.Models
{
    public class Feedback
    {
        [Display(Name = "Feedback ID")]
        public Guid FeedbackId { get; set; } = Guid.NewGuid();
        public string? Link { get; set; }

        [EnumDataType(typeof(FeedbackMessage))]
        public FeedbackMessage? Message { get; set; }

        public string? UserId { get; set; }

        [ForeignKey("UserId")]

        [Display(Name = "Board Member")]
        public ApplicationUser? ApplicationUser { get; set; }

        public Guid? ResolutionId { get; set; }

        [ForeignKey("ResolutionId")]

        public Resolution? Resolution { get; set; }
    }
}