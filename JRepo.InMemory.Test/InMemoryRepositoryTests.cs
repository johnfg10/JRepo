using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestPlatform.ObjectModel.Client;
using Moq;
using Xunit;

namespace JRepo.InMemory.Test
{
    public class InMemoryRepositoryTests
    {
        [Fact]
        public void CreateAsyncTest()
        {
            var mock = new Mock<InMemoryRepository<string, TestObject>>();
            var testObject = new TestObject() {Id = "TestId", test = "foeoffe"};
            mock.Object.CreateAsync(testObject);

            Assert.Contains(mock.Object.InMemStore, it => it == testObject);
        }        
        
        [Fact]
        public void ReplaceOneAsyncTest()
        {
            var mock = new Mock<InMemoryRepository<string, TestObject>>();
            var testObject = new TestObject() {Id = "TestId", test = "foeoffe"};
            var testObjectTwo = new TestObject() {Id = "TestId", test = "Tefieonwdnow"};
            mock.Object.InMemStore.Add(testObject);

            mock.Object.ReplaceOneAsync(it => it.Id == "TestId", testObjectTwo);  
 
            Assert.Contains(mock.Object.InMemStore, it => it == testObjectTwo);
        }

        [Fact]
        public void GetQueryableTest()
        {
            var mock = new Mock<InMemoryRepository<string, TestObject>>();
            var testObject = new TestObject() {Id = "TestId", test = "foeoffe"};
            mock.Object.InMemStore.Add(testObject);

            //mock.SetupGet(x => x.InMemStore).Returns(new List<TestObject>() {testObject});
            //mock.Verify(it => it.Queryable().First(a => a.Id == "TestId"));
            Assert.Equal(testObject, mock.Object.Queryable().First());
            //Assert.Equal(testObject, mock.Verify<TestObject>(it => it.Queryable().First()));
        }

        [Fact]
        public void UpdateAsyncTest()
        {
            var mock = new Mock<InMemoryRepository<string, TestObject>>();
            var testObject = new TestObject() {Id = "TestId", test = "foeoffe"};
            var testObjectTwo = new TestObject() {Id = "TestId", test = "wdiundwopnwod"};
            mock.Object.InMemStore.Add(testObject);

            mock.Object.UpdateAsync(it => it.Id == "TestId", new {test = "wdiundwopnwod"});
            
            Assert.Equal(testObject, mock.Object.Queryable().First());
        }
        
        [Fact]
        public void UpdateStringAsyncTest()
        {
            var mock = new Mock<InMemoryRepository<string, TestObject>>();
            var testObject = new TestObject() {Id = "TestId", test = "foeoffe"};
            var testObjectTwo = new TestObject() {Id = "TestId", test = "wdiundwopnwod"};
            mock.Object.InMemStore.Add(testObject);

            mock.Object.UpdateAsync(it => it.Id == "TestId", "{\"test\": \"wdiundwopnwod\"}");
            
            Assert.Equal(testObject, mock.Object.Queryable().First());
        }
    }
}