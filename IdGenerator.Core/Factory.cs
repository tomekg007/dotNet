namespace IdGenerator.Core
{
    public class Factory
    {
        public string Id { get; protected set; }
        public string Name { get; protected set; }

        public Factory(string id, string name )
        {
            Id = id;
            Name = name;
        }
        protected Factory() { }
    }
}
