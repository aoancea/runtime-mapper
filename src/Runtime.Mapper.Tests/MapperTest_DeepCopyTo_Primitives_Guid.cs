using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace Runtime.Mapper.Tests
{
    [TestClass]
    public class MapperTest_DeepCopyTo_Primitives_Guid
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
        public void DeepCopyTo_Guid_To_Guid_DestinationCopied()
        {
            Guid source = Constants.Guid.value3;

            Guid destination = source.DeepCopyTo<Guid>();

            Assert.AreEqual(Constants.Guid.value3, destination);
        }

        [TestMethod]
        public void DeepCopyTo_Guid_To_NullableGuid_DestinationCopied()
        {
            Guid source = Constants.Guid.value3;

            Guid? destination = source.DeepCopyTo<Guid?>();

            Assert.AreEqual(Constants.Guid.value3, destination);
        }

        [TestMethod]
        public void DeepCopyTo_Guid_To_Object_DestinationCopied()
        {
            Guid source = Constants.Guid.value3;

            object destination = source.DeepCopyTo<object>();

            Assert.AreEqual(Constants.Guid.value3, destination);
        }


        [TestMethod]
        public void DeepCopyTo_NullableGuid_To_Guid_DestinationCopied()
        {
            Guid? source = Constants.Guid.value3;

            Guid destination = source.DeepCopyTo<Guid>();

            Assert.AreEqual(Constants.Guid.value3, destination);
        }

        [TestMethod]
        public void DeepCopyTo_NullableGuid_To_NullableGuid_DestinationCopied()
        {
            Guid? source = Constants.Guid.value3;

            Guid? destination = source.DeepCopyTo<Guid?>();

            Assert.AreEqual(Constants.Guid.value3, destination);
        }

        [TestMethod]
        public void DeepCopyTo_NullableGuid_To_Object_DestinationCopied()
        {
            Guid? source = Constants.Guid.value3;

            object destination = source.DeepCopyTo<object>();

            Assert.AreEqual(Constants.Guid.value3, destination);
        }


        [TestMethod]
        public void DeepCopyTo_Null_NullableGuid_To_Guid_DestinationCopied()
        {
            Guid? source = null;

            Guid destination = source.DeepCopyTo<Guid>();

            Assert.AreEqual(Guid.Empty, destination);
        }

        [TestMethod]
        public void DeepCopyTo_Null_NullableGuid_To_NullableGuid_DestinationCopied()
        {
            Guid? source = null;

            Guid? destination = source.DeepCopyTo<Guid?>();

            Assert.AreEqual(null, destination);
        }

        [TestMethod]
        public void DeepCopyTo_Null_NullableGuid_To_Object_DestinationCopied()
        {
            Guid? source = null;

            object destination = source.DeepCopyTo<object>();

            Assert.AreEqual(null, destination);
        }


        [TestMethod]
        public void DeepCopyTo_Object_To_Guid_DestinationCopied()
        {
            object source = Constants.Guid.value3;

            Guid destination = source.DeepCopyTo<Guid>();

            Assert.AreEqual(Constants.Guid.value3, destination);
        }

        [TestMethod]
        public void DeepCopyTo_Object_To_NullableGuid_DestinationCopied()
        {
            object source = Constants.Guid.value3;

            Guid? destination = source.DeepCopyTo<Guid?>();

            Assert.AreEqual(Constants.Guid.value3, destination);
        }


        [TestMethod]
        public void DeepCopyTo_Null_Object_To_Guid_DestinationCopied()
        {
            object source = null;

            Guid destination = source.DeepCopyTo<Guid>();

            Assert.AreEqual(Guid.Empty, destination);
        }

        [TestMethod]
        public void DeepCopyTo_Null_Object_To_NullableGuid_DestinationCopied()
        {
            object source = null;

            Guid? destination = source.DeepCopyTo<Guid?>();

            Assert.AreEqual(null, destination);
        }
    }
}