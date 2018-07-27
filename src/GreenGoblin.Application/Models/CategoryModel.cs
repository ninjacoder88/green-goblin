namespace GreenGoblin.WindowsFormApplication.Models
{
    public class CategoryModel
    {
        public CategoryModel(string name)
        {
            Name = name;
        }

        public string Name { get; }

        public override string ToString()
        {
            return Name;
        }
    }
}