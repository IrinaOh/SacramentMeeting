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
        public string Conducting { get; set; }
        public string Presiding { get; set; }
        //prayers
        public string Invocation { get; set; }
        public string Benediction { get; set; }
        //songs
        [Display(Name = "Opening Hymn")]
        public int OpeningHymn { get; set; }
        [Display(Name = "Sacrament Hymn")]
        public int SacramentHymn { get; set; }
        [Display(Name = "Closing Hymn")]
        public int ClosingHymn { get; set; }
    }
}
