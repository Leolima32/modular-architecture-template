namespace Module.Categories.Core.Entities
{
    public class Category
    {
        public Category()
        {
            Id = Guid.NewGuid();
        }

        public Category(string name)
        {
            Id = Guid.NewGuid();
            Name = name;
        }

        public Guid Id { get; set; }
        public string Name { get; set; }
    }
}
