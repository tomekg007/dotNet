namespace IdGenerator.Core
{
    public class Category
    {
        public string Id { get; protected set; }
        public string Name { get; protected set; }

        public Category(string id, string name)
        {
            Id = id;
            Name = name;
        }

        protected Category() { }
    }
}
