using System;

namespace IdGenerator.Core
{
    public class FactoryParts
    {
        public string CategoryId { get; protected set; }
        public string FactoryId { get; protected set; }
        public int CategoryFactoryId { get; protected set; }
        public DateTime CreatedAt { get; protected set; }
    
        public FactoryParts(string categoryId, string factoryId, int categoryFactoryId, DateTime createdAt)
        {
            CategoryId = categoryId;
            FactoryId = factoryId;
            CategoryFactoryId = categoryFactoryId;
            CreatedAt = createdAt;
        }
        protected FactoryParts() { }

        public string GenerateUniqueId()
            => $"{CategoryId}-{FactoryId}-{CategoryFactoryId}";        
    }
}
