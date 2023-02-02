namespace Module.Brands.Core.Entities
{
    public class Brand
    {
        public Brand()
        {
            Id = Guid.NewGuid();
        }

        public Brand(string name)
        {
            Id = Guid.NewGuid();
            Name = name;
        }

        public Guid Id { get; set; }
        public string Name { get; set; }
    }
}
