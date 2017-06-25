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
                Guid = new Guid("80415b86-1cd0-4a11-83e5-d228d3a60354"),
                String = "Cow 1"
            };

            Cow destination = new Cow();

            Mapper.Map(source, destination);

            Assert.AreEqual(source, source);
            Assert.AreEqual(destination, destination);
            Assert.AreNotEqual(source, destination);

            Assert.AreEqual(new Guid("80415b86-1cd0-4a11-83e5-d228d3a60354"), destination.Guid);
            Assert.AreEqual("Cow 1", destination.String);
        }
    }
}
