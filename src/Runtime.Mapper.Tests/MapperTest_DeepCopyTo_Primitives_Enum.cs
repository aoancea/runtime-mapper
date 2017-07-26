using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Runtime.Mapper.Tests
{
    [TestClass]
    public class MapperTest_DeepCopyTo_Primitives_Enum
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
        public void DeepCopyTo_Enum_To_Enum_DestinationCopied()
        {
            Enumeration source = Enumeration.Three;

            Enumeration destination = source.DeepCopyTo<Enumeration>();

            Assert.AreEqual(Enumeration.Three, destination);
        }

        [TestMethod]
        public void DeepCopyTo_Enum_To_NullableEnum_DestinationCopied()
        {
            A_Enumeration source = A_Enumeration.Two;

            B_Enumeration? destination = source.DeepCopyTo<B_Enumeration?>();

            Assert.AreEqual(B_Enumeration.Two, destination);
        }

        [TestMethod]
        public void DeepCopyTo_Enum_To_Object_DestinationCopied()
        {
            Enumeration source = Enumeration.Three;

            object destination = source.DeepCopyTo<object>();

            Assert.AreEqual(Enumeration.Three, destination);
        }


        [TestMethod]
        public void DeepCopyTo_NullableEnum_To_Enum_DestinationCopied()
        {
            A_Enumeration? source = A_Enumeration.Two;

            B_Enumeration destination = source.DeepCopyTo<B_Enumeration>();

            Assert.AreEqual(B_Enumeration.Two, destination);
        }

        [TestMethod]
        public void DeepCopyTo_NullableEnum_To_NullableEnum_DestinationCopied()
        {
            A_Enumeration? source = A_Enumeration.Two;

            B_Enumeration? destination = source.DeepCopyTo<B_Enumeration?>();

            Assert.AreEqual(B_Enumeration.Two, destination);
        }

        [TestMethod]
        public void DeepCopyTo_NullableEnum_To_Object_DestinationCopied()
        {
            Enumeration? source = Enumeration.Two;

            object destination = source.DeepCopyTo<object>();

            Assert.AreEqual(Enumeration.Two, destination);
        }


        [TestMethod]
        public void DeepCopyTo_Null_NullableEnum_To_Enum_DestinationCopied()
        {
            A_Enumeration? source = null;

            B_Enumeration destination = source.DeepCopyTo<B_Enumeration>();

            Assert.AreEqual(B_Enumeration.One, destination);
        }

        [TestMethod]
        public void DeepCopyTo_Null_NullableEnum_To_NullableEnum_DestinationCopied()
        {
            A_Enumeration? source = null;

            B_Enumeration? destination = source.DeepCopyTo<B_Enumeration?>();

            Assert.AreEqual(null, destination);
        }

        [TestMethod]
        public void DeepCopyTo_Null_NullableEnum_To_Object_DestinationCopied()
        {
            A_Enumeration? source = null;

            object destination = source.DeepCopyTo<object>();

            Assert.AreEqual(null, destination);
        }


        [TestMethod]
        public void DeepCopyTo_Object_To_Enum_DestinationCopied()
        {
            object source = Enumeration.Three;

            Enumeration destination = source.DeepCopyTo<Enumeration>();

            Assert.AreEqual(Enumeration.Three, destination);
        }

        [TestMethod]
        public void DeepCopyTo_Object_To_NullableEnum_DestinationCopied()
        {
            object source = Enumeration.Three;

            Enumeration? destination = source.DeepCopyTo<Enumeration?>();

            Assert.AreEqual(Enumeration.Three, destination);
        }


        [TestMethod]
        public void DeepCopyTo_Null_Object_To_Enum_DestinationCopied()
        {
            object source = null;

            Enumeration destination = source.DeepCopyTo<Enumeration>();

            Assert.AreEqual(Enumeration.One, destination);
        }

        [TestMethod]
        public void DeepCopyTo_Null_Object_To_NullableEnum_DestinationCopied()
        {
            object source = null;

            Enumeration? destination = source.DeepCopyTo<Enumeration?>();

            Assert.AreEqual(null, destination);
        }
    }
}