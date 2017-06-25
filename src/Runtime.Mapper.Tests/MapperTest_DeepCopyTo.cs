using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Runtime.Mapper.Tests
{
    [TestClass]
    public class MapperTest_DeepCopyTo
    {
        [TestMethod]
        public void DeepCopyTo_SourceAndDestinationTypeAreTheSame_DestinationCopied()
        {
            Cow source = new Cow()
            {
                Guid = new Guid("80415b86-1cd0-4a11-83e5-d228d3a60354"),
                String = "Cow 1"
            };


            Cow destination = source.DeepCopyTo<Cow>();

            Assert.AreNotEqual(source, destination);

            Assert.AreEqual(new Guid("80415b86-1cd0-4a11-83e5-d228d3a60354"), destination.Guid);
            Assert.AreEqual("Cow 1", destination.String);
        }
    }
}
