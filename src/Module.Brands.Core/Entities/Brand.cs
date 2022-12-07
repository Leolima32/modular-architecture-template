namespace Module.Brands.Core.Entities
{
    public class Brand
    {
        public Brand()
        {
            Id = Guid.NewGuid();
        }

        public Guid Id { get; set; }
        public string Name { get; set; }
    }
}
