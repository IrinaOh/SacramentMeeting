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
                        ClosingHymn = 235,
                        Topic = "Prayer"
                    },

                    new Meeting
                    {
                        MeetingDate = DateTime.Parse("2019-2-12"),
                        Conducting = "Brandon Flowers",
                        Presiding = "Bruce Willies",
                        Invocation = "Mary Jo",
                        Benediction = "Bruce Lee",
                        OpeningHymn = 344,
                        SacramentHymn = 134,
                        ClosingHymn = 235,
                        Topic = "Repentance"
                    },

                    new Meeting
                    {
                        MeetingDate = DateTime.Parse("2019-2-19"),
                        Conducting = "Tony Rodgers",
                        Presiding = "Bruce Willies",
                        Invocation = "Mary Jo",
                        Benediction = "Bruce Lee",
                        OpeningHymn = 344,
                        SacramentHymn = 134,
                        ClosingHymn = 235,
                        Topic = "Baptism"
                    },

                    new Meeting
                    {
                        MeetingDate = DateTime.Parse("2019-2-26"),
                        Conducting = "Parker Kent",
                        Presiding = "Bruce Willies",
                        Invocation = "Mary Jo",
                        Benediction = "Bruce Lee",
                        OpeningHymn = 344,
                        SacramentHymn = 134,
                        ClosingHymn = 235,
                        Topic = "Millenium"
                    }
                );
                context.SaveChanges();
            }
        }
    }
}


