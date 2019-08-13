using JRepo.Core;

namespace JRepo.InMemory.Test
{
    public class TestObject : IId<string>
    {
        public string test { get; set; }
        
        public string Id { get; set; }
    }
}