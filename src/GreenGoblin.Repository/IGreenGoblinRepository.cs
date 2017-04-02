using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace GreenGoblin.Repository
{
    public interface IGreenGoblinRepository
    {
        IEnumerable<TimeEntry> Load();

        void Save(IEnumerable<TimeEntry> models);
    }
}
