using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace SacramentMeetingPlanner.Models
{
    public class SpeakerAssignment
    {
        public int ID { get; set; }
        public int MeetingID { get; set; }

        [Display(Name = "Speaker's Name")]
        [Required]
        public string SpeakerName { get; set; }

        public Meeting Meeting { get; set; }
    }
}
