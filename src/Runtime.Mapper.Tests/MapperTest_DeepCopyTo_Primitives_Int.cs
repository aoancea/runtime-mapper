using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Runtime.Mapper.Tests
{
    [TestClass]
    public class MapperTest_DeepCopyTo_Primitives_Int
    {
        #region Test name pattern
        /*
            value -> value
            value -> nullable value
            value -> reference

            value nullable value -> value
            value nullable value -> nullable value
            value nullable value -> reference

            null nullable value -> value
            null nullable value -> nullable value
            null nullable value -> reference

            reference -> value
            reference -> nullable value

            null reference -> value
            null reference -> nullable value
        */
        #endregion


        [TestMethod]
        public void DeepCopyTo_Int_To_Int_DestinationCopied()
        {
            int source = 5;

            int destination = source.DeepCopyTo<int>();

            Assert.AreEqual(5, destination);
        }

        [TestMethod]
        public void DeepCopyTo_Int_To_NullableInt_DestinationCopied()
        {
            int source = Constants.Int.value1;

            int? destination = source.DeepCopyTo<int?>();

            Assert.AreEqual(Constants.Int.value1, destination);
        }

        [TestMethod]
        public void DeepCopyTo_Int_To_Object_DestinationCopied()
        {
            int source = 5;

            object destination = source.DeepCopyTo<object>();

            Assert.AreEqual(5, destination);
        }


        [TestMethod]
        public void DeepCopyTo_NullableInt_To_Int_DestinationCopied()
        {
            int? source = Constants.Int.value1;

            int destination = source.DeepCopyTo<int>();

            Assert.AreEqual(Constants.Int.value1, destination);
        }

        [TestMethod]
        public void DeepCopyTo_NullableInt_To_NullableInt_DestinationCopied()
        {
            int? source = Constants.Int.value1;

            int? destination = source.DeepCopyTo<int?>();

            Assert.AreEqual(Constants.Int.value1, destination);
        }

        [TestMethod]
        public void DeepCopyTo_NullableInt_To_Object_DestinationCopied()
        {
            int? source = 5;

            object destination = source.DeepCopyTo<object>();

            Assert.AreEqual(5, destination);
        }


        [TestMethod]
        public void DeepCopyTo_Null_NullableInt_To_Int_DestinationCopied()
        {
            int? source = null;

            int destination = source.DeepCopyTo<int>();

            Assert.AreEqual(0, destination);
        }

        [TestMethod]
        public void DeepCopyTo_Null_NullableInt_To_NullableInt_DestinationCopied()
        {
            int? source = null;

            int? destination = source.DeepCopyTo<int?>();

            Assert.AreEqual(null, destination);
        }

        [TestMethod]
        public void DeepCopyTo_Null_NullableInt_To_Object_DestinationCopied()
        {
            int? source = null;

            object destination = source.DeepCopyTo<object>();

            Assert.AreEqual(null, destination);
        }


        [TestMethod]
        public void DeepCopyTo_Object_To_Int_DestinationCopied()
        {
            object source = 5;

            int destination = source.DeepCopyTo<int>();

            Assert.AreEqual(5, destination);
        }

        [TestMethod]
        public void DeepCopyTo_Object_To_NullableInt_DestinationCopied()
        {
            object source = 5;

            int? destination = source.DeepCopyTo<int?>();

            Assert.AreEqual(5, destination);
        }


        [TestMethod]
        public void DeepCopyTo_Null_Object_To_Int_DestinationCopied()
        {
            object source = null;

            int destination = source.DeepCopyTo<int>();

            Assert.AreEqual(0, destination);
        }

        [TestMethod]
        public void DeepCopyTo_Null_Object_To_NullableInt_DestinationCopied()
        {
            object source = null;

            int? destination = source.DeepCopyTo<int?>();

            Assert.AreEqual(null, destination);
        }
    }
}