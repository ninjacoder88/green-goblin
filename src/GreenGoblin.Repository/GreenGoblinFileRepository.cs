using System.Collections.Generic;

namespace GreenGoblin.Repository
{
    public class GreenGoblinFileRepository : IGreenGoblinRepository
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