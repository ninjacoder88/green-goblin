using System.Collections.Generic;

namespace GreenGoblin.WindowsForm
{
    public interface IGreenGoblinRepository
    {
        IEnumerable<TimeEntryModel> LoadModels();

        void Save(IEnumerable<TimeEntryModel> models);
    }
}