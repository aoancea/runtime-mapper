using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Runtime.Mapper.Tests
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void Map_SourceAndDestinationTypeAreTheSame_DestinationCopied()
        {
            Cow source = ScenarioHelper.Create_Cow();

            Cow destination = new Cow();

            Mapper.Map(source, destination);

            Assert.AreEqual(source, source);
            Assert.AreEqual(destination, destination);
            Assert.AreNotEqual(source, destination);

            ScenarioHelper.Assert_Cow(destination);
        }
    }
}