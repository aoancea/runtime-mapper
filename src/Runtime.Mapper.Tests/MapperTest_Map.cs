using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Runtime.Mapper.Tests
{
    [TestClass]
    public class MapperTest_Map
    {
        [TestMethod]
        public void Map_SourceAndDestinationTypeAreTheSame_DestinationCopied()
        {
            Cow source = ScenarioHelper.Create_Cow();

            Cow destination = new Cow();

            Mapper.Map(source, destination);

            Assert.AreNotEqual(source, destination);

            ScenarioHelper.Assert_Cow(destination);
        }

        [TestMethod]
        public void Map_SourceAndDestinationAreDifferentTypeButContainTheSameProperties_DestinationCopied()
        {
            Cow source = ScenarioHelper.Create_Cow();

            Mule destination = new Mule();

            Mapper.Map(source, destination);

            Assert.AreNotEqual(source, destination);

            ScenarioHelper.Assert_Mule(destination);
        }
    }
}