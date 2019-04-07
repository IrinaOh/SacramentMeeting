using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace SacramentMeetingPlanner.Models
{
    public class Meeting
    {
        public int Id { get; set; }
        [Display(Name = "Meeting Date")]
        [DataType(DataType.Date)]
        public DateTime MeetingDate { get; set; }

        [StringLength(60, MinimumLength = 3)]
        public string Conducting { get; set; }
        [StringLength(60, MinimumLength = 3)]
        public string Presiding { get; set; }
        //prayers
        [StringLength(60, MinimumLength = 3)]
        public string Invocation { get; set; }
        [StringLength(60, MinimumLength = 3)]
        public string Benediction { get; set; }
        
        //songs
        [Range(1, 341)]
        [Display(Name = "Opening Hymn")]
        public int OpeningHymn { get; set; }
        [Range(1, 341)]
        [Display(Name = "Sacrament Hymn")]
        public int SacramentHymn { get; set; }
        [Range(1, 341)]
        [Display(Name = "Closing Hymn")]
        public int ClosingHymn { get; set; }
    }
}
