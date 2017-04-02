using System;
using System.Collections.Generic;
using System.Threading;

namespace GreenGoblin.Repository
{
    public class TestingRepository : IGreenGoblinRepository
    {
        public IEnumerable<TimeEntry> Load()
        {
            Thread.Sleep(5000);

            var entries =
                new List<TimeEntry>
                    {
                        new TimeEntry(new DateTime(2017, 04, 01, 6, 30, 12), new DateTime(2017, 04, 01, 6, 45, 12),
                                      "Support Ticket", string.Empty)
                    };

            return entries;
        }

        public void Save(IEnumerable<TimeEntry> models)
        {
        }
    }
}