using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Runtime.Mapper.Tests
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void Map_SourceAndDestinationTypeAreTheSame_DestinationCopied()
        {
            Cow source = new Cow()
            {
                Id = new Guid("80415b86-1cd0-4a11-83e5-d228d3a60354"),
                Name = "Cow 1"
            };

            Cow destination = new Cow();

            Mapper.Map(source, destination);

            Assert.AreEqual(source, source);
            Assert.AreEqual(destination, destination);
            Assert.AreNotEqual(source, destination);

            Assert.AreEqual(new Guid("80415b86-1cd0-4a11-83e5-d228d3a60354"), destination.Id);
            Assert.AreEqual("Cow 1", destination.Name);
        }
    }
}
