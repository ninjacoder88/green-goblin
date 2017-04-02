using System.Collections.Generic;

namespace GreenGoblin.Repository
{
    public class GreenGoblinDatabaseRepository : IGreenGoblinRepository
    {
        public IEnumerable<TimeEntry> Load()
        {
            yield break;
        }

        public void Save(IEnumerable<TimeEntry> models)
        {
        }
    }
}