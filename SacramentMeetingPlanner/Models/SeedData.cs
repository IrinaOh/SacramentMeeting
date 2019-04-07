/*using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SacramentMeetingPlanner.Models
{
    public class SeedData
    {
    }
} */
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using SacramentMeetingPlanner.Models;
using System;
using System.Linq;

namespace SacramentMeeting.Models
{
    public static class SeedData
    {
        public static void Initialize(IServiceProvider serviceProvider)
        {
            using (var context = new SacramentMeetingPlannerContext(
                serviceProvider.GetRequiredService<
                    DbContextOptions<SacramentMeetingPlannerContext>>()))
            {
                // Look for any meetings.
                if (context.Meeting.Any())
                {
                    return;   // DB has been seeded
                }

                context.Meeting.AddRange(
                    new Meeting
                    {
                        MeetingDate = DateTime.Parse("2019-3-17"),
                        Conducting = "Bruce Willies",
                        Presiding = "Bruce Willies",
                        Invocation = "Mary Jo",
                        Benediction = "Bruce Lee",
                        OpeningHymn = 344,
                        SacramentHymn = 134,
                        ClosingHymn = 235
                    },

                    new Meeting
                    {
                        MeetingDate = DateTime.Parse("2019-2-12"),
                        Conducting = "Bruce Willies",
                        Presiding = "Bruce Willies",
                        Invocation = "Mary Jo",
                        Benediction = "Bruce Lee",
                        OpeningHymn = 344,
                        SacramentHymn = 134,
                        ClosingHymn = 235
                    }
                );
                context.SaveChanges();
            }
        }
    }
}


