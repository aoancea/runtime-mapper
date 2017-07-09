using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;

namespace Runtime.Mapper.Tests
{
    [TestClass]
    public class MapperTest_DeepCopyTo
    {
        [TestMethod]
        public void DeepCopyTo_SourceAndDestinationTypeAreTheSame_DestinationCopied()
        {
            Cow source = ScenarioHelper.Create_Cow();

            Cow destination = source.DeepCopyTo<Cow>();

            Assert.AreNotEqual(source, destination);

            ScenarioHelper.Assert_Cow(source, destination);
        }

        [TestMethod]
        public void DeepCopyTo_SourceAndDestinationAreDifferentTypeButContainTheSameProperties_DestinationCopied()
        {
            Cow source = ScenarioHelper.Create_Cow();

            Mule destination = source.DeepCopyTo<Mule>();

            Assert.AreNotEqual(source, destination);

            ScenarioHelper.Assert_Mule(source, destination);
        }


        #region Primitives

        [TestMethod]
        public void DeepCopyTo_Int_To_Int_DestinationCopied()
        {
            int source = 5;

            int destination = source.DeepCopyTo<int>();

            Assert.AreEqual(5, destination);
        }

        [TestMethod]
        public void DeepCopyTo_Decimal_To_Decimal_DestinationCopied()
        {
            decimal source = 5M;

            decimal destination = source.DeepCopyTo<decimal>();

            Assert.AreEqual(5M, destination);
        }

        [TestMethod]
        public void DeepCopyTo_String_To_String_DestinationCopied()
        {
            string source = "123";

            string destination = source.DeepCopyTo<string>();

            Assert.AreEqual("123", destination);
        }

        [TestMethod]
        public void DeepCopyTo_Guid_To_Guid_DestinationCopied()
        {
            Guid source = Constants.Guid.value3;

            Guid destination = source.DeepCopyTo<Guid>();

            Assert.AreEqual(Constants.Guid.value3, destination);
        }

        [TestMethod]
        public void DeepCopyTo_DateTime_To_DateTime_DestinationCopied()
        {
            DateTime source = new DateTime(2016, 01, 01);

            DateTime destination = source.DeepCopyTo<DateTime>();

            Assert.AreEqual(new DateTime(2016, 01, 01), destination);
        }

        [TestMethod]
        public void DeepCopyTo_Bool_To_Bool_DestinationCopied()
        {
            bool source = true;

            bool destination = source.DeepCopyTo<bool>();

            Assert.AreEqual(true, destination);
        }

        [TestMethod]
        public void DeepCopyTo_Char_To_Char_DestinationCopied()
        {
            char source = 'x';

            char destination = source.DeepCopyTo<char>();

            Assert.AreEqual('x', destination);
        }

        [TestMethod]
        public void DeepCopyTo_Enum_To_Enum_DestinationCopied()
        {
            Enumeration source = Enumeration.Three;

            Enumeration destination = source.DeepCopyTo<Enumeration>();

            Assert.AreEqual(Enumeration.Three, destination);
        }

        [TestMethod]
        public void DeepCopyTo_Float_To_Float_DestinationCopied()
        {
            float source = 323.412f;

            float destination = source.DeepCopyTo<float>();

            Assert.AreEqual(323.412f, destination);
        }

        [TestMethod]
        public void DeepCopyTo_Double_To_Double_DestinationCopied()
        {
            double source = 2.7E+3D;

            double destination = source.DeepCopyTo<double>();

            Assert.AreEqual(2.7E+3D, destination);
        }

        #endregion


        #region Collections

        #region Array -> Array - Primitive types

        [TestMethod]
        public void DeepCopyTo_SourceOfGuidArrayToDestinationOfGuidArray_DestinationCopied()
        {
            Guid[] source = new Guid[] { Constants.Guid.value1, Constants.Guid.value2, Constants.Guid.value3 };

            Guid[] destination = source.DeepCopyTo<Guid[]>();

            Assert.AreNotEqual(source, destination);

            Assert.AreEqual(Constants.Guid.value1, destination[0]);
            Assert.AreEqual(Constants.Guid.value2, destination[1]);
            Assert.AreEqual(Constants.Guid.value3, destination[2]);
        }

        [TestMethod]
        public void DeepCopyTo_SourceOfIntArrayToDestinationOfIntArray_DestinationCopied()
        {
            int[] source = new int[] { Constants.Int.value1, Constants.Int.value2 };

            int[] destination = source.DeepCopyTo<int[]>();

            Assert.AreNotEqual(source, destination);

            Assert.AreEqual(Constants.Int.value1, destination[0]);
            Assert.AreEqual(Constants.Int.value2, destination[1]);
        }

        #endregion

        #region List -> List - Primitive types

        [TestMethod]
        public void DeepCopyTo_SourceOfGuidListToDestinationOfGuidList_DestinationCopied()
        {
            List<Guid> source = new List<Guid> { Constants.Guid.value1, Constants.Guid.value2, Constants.Guid.value3 };

            List<Guid> destination = source.DeepCopyTo<List<Guid>>();

            Assert.AreNotEqual(source, destination);

            Assert.AreEqual(Constants.Guid.value1, destination[0]);
            Assert.AreEqual(Constants.Guid.value2, destination[1]);
            Assert.AreEqual(Constants.Guid.value3, destination[2]);
        }

        [TestMethod]
        public void DeepCopyTo_SourceOfIntListToDestinationOfIntList_DestinationCopied()
        {
            List<int> source = new List<int> { Constants.Int.value1, Constants.Int.value2 };

            List<int> destination = source.DeepCopyTo<List<int>>();

            Assert.AreNotEqual(source, destination);

            Assert.AreEqual(Constants.Int.value1, destination[0]);
            Assert.AreEqual(Constants.Int.value2, destination[1]);
        }

        #endregion

        #region Array -> List - Primitive types

        [TestMethod]
        public void DeepCopyTo_SourceOfGuidArrayToDestinationOfGuidList_DestinationCopied()
        {
            Guid[] source = new Guid[] { Constants.Guid.value1, Constants.Guid.value2, Constants.Guid.value3 };

            List<Guid> destination = source.DeepCopyTo<List<Guid>>();

            Assert.AreNotEqual(source, destination);

            Assert.AreEqual(Constants.Guid.value1, destination[0]);
            Assert.AreEqual(Constants.Guid.value2, destination[1]);
            Assert.AreEqual(Constants.Guid.value3, destination[2]);
        }

        [TestMethod]
        public void DeepCopyTo_SourceOfIntArrayToDestinationOfIntList_DestinationCopied()
        {
            int[] source = new int[] { Constants.Int.value1, Constants.Int.value2 };

            List<int> destination = source.DeepCopyTo<List<int>>();

            Assert.AreNotEqual(source, destination);

            Assert.AreEqual(Constants.Int.value1, destination[0]);
            Assert.AreEqual(Constants.Int.value2, destination[1]);
        }

        #endregion

        #region List -> Array - Primitive types

        [TestMethod]
        public void DeepCopyTo_SourceOfGuidListToDestinationOfGuidArray_DestinationCopied()
        {
            List<Guid> source = new List<Guid> { Constants.Guid.value1, Constants.Guid.value2, Constants.Guid.value3 };

            Guid[] destination = source.DeepCopyTo<Guid[]>();

            Assert.AreNotEqual(source, destination);

            Assert.AreEqual(Constants.Guid.value1, destination[0]);
            Assert.AreEqual(Constants.Guid.value2, destination[1]);
            Assert.AreEqual(Constants.Guid.value3, destination[2]);
        }

        [TestMethod]
        public void DeepCopyTo_SourceOfIntListToDestinationOfIntArray_DestinationCopied()
        {
            List<int> source = new List<int> { Constants.Int.value1, Constants.Int.value2 };

            int[] destination = source.DeepCopyTo<int[]>();

            Assert.AreNotEqual(source, destination);

            Assert.AreEqual(Constants.Int.value1, destination[0]);
            Assert.AreEqual(Constants.Int.value2, destination[1]);
        }

        #endregion


        #region Array -> Array - Custom Types

        [TestMethod]
        public void DeepCopyTo_ArrayToArrayOfSameType_DestinationCopied()
        {
            Cow[] source = new Cow[1]
            {
                 ScenarioHelper.Create_Cow()
            };

            Cow[] destination = source.DeepCopyTo<Cow[]>();

            Assert.AreNotEqual(source, destination);
            Assert.AreEqual(1, destination.Length);
            Assert.AreNotEqual(source[0], destination[0]);

            ScenarioHelper.Assert_Cow(source[0], destination[0]);
        }

        [TestMethod]
        public void DeepCopyTo_ArrayToArrayOfDifferentType_DestinationCopied()
        {
            Cow[] source = new Cow[1]
            {
                 ScenarioHelper.Create_Cow()
            };

            Mule[] destination = source.DeepCopyTo<Mule[]>();

            Assert.AreNotEqual(source, destination);
            Assert.AreEqual(1, destination.Length);
            Assert.AreNotEqual(source[0], destination[0]);

            ScenarioHelper.Assert_Mule(source[0], destination[0]);
        }

        #endregion

        #region List -> List - Custom Types

        [TestMethod]
        public void DeepCopyTo_ListToListOfSameType_DestinationCopied()
        {
            List<Cow> source = new List<Cow>
            {
                 ScenarioHelper.Create_Cow()
            };

            List<Cow> destination = source.DeepCopyTo<List<Cow>>();

            Assert.AreNotEqual(source, destination);
            Assert.AreEqual(1, destination.Count);
            Assert.AreNotEqual(source[0], destination[0]);

            ScenarioHelper.Assert_Cow(source[0], destination[0]);
        }

        [TestMethod]
        public void DeepCopyTo_ListToListOfDifferentType_DestinationCopied()
        {
            List<Cow> source = new List<Cow>
            {
                 ScenarioHelper.Create_Cow()
            };

            List<Mule> destination = source.DeepCopyTo<List<Mule>>();

            Assert.AreNotEqual(source, destination);
            Assert.AreEqual(1, destination.Count);
            Assert.AreNotEqual(source[0], destination[0]);

            ScenarioHelper.Assert_Mule(source[0], destination[0]);
        }

        #endregion

        #region Array - List - Custom Types

        [TestMethod]
        public void DeepCopyTo_ArrayToListOfSameType_DestinationCopied()
        {
            Cow[] source = new Cow[1]
            {
                 ScenarioHelper.Create_Cow()
            };

            List<Cow> destination = source.DeepCopyTo<List<Cow>>();

            Assert.AreNotEqual(source, destination);
            Assert.AreEqual(1, destination.Count);
            Assert.AreNotEqual(source[0], destination[0]);

            ScenarioHelper.Assert_Cow(source[0], destination[0]);
        }

        [TestMethod]
        public void DeepCopyTo_ArrayToListOfDifferentTypesButWithSameProperties_DestinationCopied()
        {
            Cow[] source = new Cow[1]
            {
                 ScenarioHelper.Create_Cow()
            };

            List<Mule> destination = source.DeepCopyTo<List<Mule>>();

            Assert.AreNotEqual(source, destination);
            Assert.AreEqual(1, destination.Count);
            Assert.AreNotEqual(source[0], destination[0]);

            ScenarioHelper.Assert_Mule(source[0], destination[0]);
        }

        #endregion

        #region List - Array - Custom Types

        [TestMethod]
        public void DeepCopyTo_ListToArrayOfSameType_DestinationCopied()
        {
            List<Cow> source = new List<Cow>
            {
                 ScenarioHelper.Create_Cow()
            };

            Cow[] destination = source.DeepCopyTo<Cow[]>();

            Assert.AreNotEqual(source, destination);
            Assert.AreEqual(1, destination.Length);
            Assert.AreNotEqual(source[0], destination[0]);

            ScenarioHelper.Assert_Cow(source[0], destination[0]);
        }

        [TestMethod]
        public void DeepCopyTo_ListToArrayOfDifferentTypesButWithSameProperties_DestinationCopied()
        {
            List<Cow> source = new List<Cow>
            {
                 ScenarioHelper.Create_Cow()
            };

            Mule[] destination = source.DeepCopyTo<Mule[]>();

            Assert.AreNotEqual(source, destination);
            Assert.AreEqual(1, destination.Length);
            Assert.AreNotEqual(source[0], destination[0]);

            ScenarioHelper.Assert_Mule(source[0], destination[0]);
        }

        #endregion


        #region Array -> Array - Enum types

        [TestMethod]
        public void DeepCopyTo_SourceOfEnumArrayToDestinationOfEnumArray_DestinationCopied()
        {
            Enumeration[] source = new Enumeration[] { Enumeration.One, Enumeration.Two, Enumeration.Three };

            Enumeration[] destination = source.DeepCopyTo<Enumeration[]>();

            Assert.AreNotEqual(source, destination);

            Assert.AreEqual(Enumeration.One, destination[0]);
            Assert.AreEqual(Enumeration.Two, destination[1]);
            Assert.AreEqual(Enumeration.Three, destination[2]);
        }

        [TestMethod]
        public void DeepCopyTo_SourceOfEnumArrayToDestinationOfEnumArray_DifferentDestinationType_DestinationCopied()
        {
            A_Enumeration[] source = new A_Enumeration[] { A_Enumeration.One, A_Enumeration.Two, A_Enumeration.Three };

            B_Enumeration[] destination = source.DeepCopyTo<B_Enumeration[]>();

            Assert.AreNotEqual(source, destination);

            Assert.AreEqual(B_Enumeration.One, destination[0]);
            Assert.AreEqual(B_Enumeration.Two, destination[1]);
            Assert.AreEqual(B_Enumeration.Three, destination[2]);
        }

        #endregion

        #region List -> List - Enum types

        [TestMethod]
        public void DeepCopyTo_SourceOfEnumListToDestinationOfEnumList_DestinationCopied()
        {
            List<Enumeration> source = new List<Enumeration> { Enumeration.One, Enumeration.Two, Enumeration.Three };

            List<Enumeration> destination = source.DeepCopyTo<List<Enumeration>>();

            Assert.AreNotEqual(source, destination);

            Assert.AreEqual(Enumeration.One, destination[0]);
            Assert.AreEqual(Enumeration.Two, destination[1]);
            Assert.AreEqual(Enumeration.Three, destination[2]);
        }

        [TestMethod]
        public void DeepCopyTo_SourceOfEnumListToDestinationOfEnumList_DifferentDestinationType_DestinationCopied()
        {
            List<A_Enumeration> source = new List<A_Enumeration> { A_Enumeration.One, A_Enumeration.Two, A_Enumeration.Three };

            List<B_Enumeration> destination = source.DeepCopyTo<List<B_Enumeration>>();

            Assert.AreNotEqual(source, destination);

            Assert.AreEqual(B_Enumeration.One, destination[0]);
            Assert.AreEqual(B_Enumeration.Two, destination[1]);
            Assert.AreEqual(B_Enumeration.Three, destination[2]);
        }

        #endregion

        #region Array -> List - Enum types

        [TestMethod]
        public void DeepCopyTo_SourceOfEnumArrayToDestinationOfEnumList_DestinationCopied()
        {
            Enumeration[] source = new Enumeration[] { Enumeration.One, Enumeration.Two, Enumeration.Three };

            List<Enumeration> destination = source.DeepCopyTo<List<Enumeration>>();

            Assert.AreNotEqual(source, destination);

            Assert.AreEqual(Enumeration.One, destination[0]);
            Assert.AreEqual(Enumeration.Two, destination[1]);
            Assert.AreEqual(Enumeration.Three, destination[2]);
        }

        [TestMethod]
        public void DeepCopyTo_SourceOfEnumArrayToDestinationOfEnumList_DifferentDestinationType_DestinationCopied()
        {
            A_Enumeration[] source = new A_Enumeration[] { A_Enumeration.One, A_Enumeration.Two, A_Enumeration.Three };

            List<B_Enumeration> destination = source.DeepCopyTo<List<B_Enumeration>>();

            Assert.AreNotEqual(source, destination);

            Assert.AreEqual(B_Enumeration.One, destination[0]);
            Assert.AreEqual(B_Enumeration.Two, destination[1]);
            Assert.AreEqual(B_Enumeration.Three, destination[2]);
        }

        #endregion

        #region List -> Array - Enum types

        [TestMethod]
        public void DeepCopyTo_SourceOfEnumListToDestinationOfEnumArray_DestinationCopied()
        {
            List<Enumeration> source = new List<Enumeration> { Enumeration.One, Enumeration.Two, Enumeration.Three };

            Enumeration[] destination = source.DeepCopyTo<Enumeration[]>();

            Assert.AreNotEqual(source, destination);

            Assert.AreEqual(Enumeration.One, destination[0]);
            Assert.AreEqual(Enumeration.Two, destination[1]);
            Assert.AreEqual(Enumeration.Three, destination[2]);
        }

        [TestMethod]
        public void DeepCopyTo_SourceOfEnumListToDestinationOfEnumArray_DifferentDestinationType_DestinationCopied()
        {
            List<A_Enumeration> source = new List<A_Enumeration> { A_Enumeration.One, A_Enumeration.Two, A_Enumeration.Three };

            B_Enumeration[] destination = source.DeepCopyTo<B_Enumeration[]>();

            Assert.AreNotEqual(source, destination);

            Assert.AreEqual(B_Enumeration.One, destination[0]);
            Assert.AreEqual(B_Enumeration.Two, destination[1]);
            Assert.AreEqual(B_Enumeration.Three, destination[2]);
        }

        #endregion


        #region Array -> Array - Objects

        [TestMethod]
        public void DeepCopyTo_SourceOfObjectArrayToDestinationOfObjectArray_DestinationCopied()
        {
            object[] source = new object[] { Constants.String.value1, Constants.DateTime.value2, Constants.Bool.value2, ScenarioHelper.CreateA_BigClass(), Enumeration.Two };

            object[] destination = source.DeepCopyTo<object[]>();

            Assert.AreNotEqual(source, destination);

            Assert.AreEqual(Constants.String.value1, destination[0]);
            Assert.AreEqual(Constants.DateTime.value2, destination[1]);
            Assert.AreEqual(Constants.Bool.value2, destination[2]);
            ScenarioHelper.Assert_A_BigClass((A_BigClass)source[3], (A_BigClass)destination[3]);
            Assert.AreEqual(Enumeration.Two, destination[4]);
        }

        #endregion

        #region List -> List - Objects

        [TestMethod]
        public void DeepCopyTo_SourceOfObjectListToDestinationOfObjectList_DestinationCopied()
        {
            List<object> source = new List<object> { Constants.String.value1, Constants.DateTime.value2, Constants.Bool.value2, ScenarioHelper.CreateA_BigClass(), Enumeration.Two };

            List<object> destination = source.DeepCopyTo<List<object>>();

            Assert.AreNotEqual(source, destination);

            Assert.AreEqual(Constants.String.value1, destination[0]);
            Assert.AreEqual(Constants.DateTime.value2, destination[1]);
            Assert.AreEqual(Constants.Bool.value2, destination[2]);
            ScenarioHelper.Assert_A_BigClass((A_BigClass)source[3], (A_BigClass)destination[3]);
            Assert.AreEqual(Enumeration.Two, destination[4]);
        }

        #endregion

        #region Array -> List - Objects

        [TestMethod]
        public void DeepCopyTo_SourceOfObjectArrayToDestinationOfObjectList_DestinationCopied()
        {
            object[] source = new object[] { Constants.String.value1, Constants.DateTime.value2, Constants.Bool.value2, ScenarioHelper.CreateA_BigClass(), Enumeration.Two };

            List<object> destination = source.DeepCopyTo<List<object>>();

            Assert.AreNotEqual(source, destination);

            Assert.AreEqual(Constants.String.value1, destination[0]);
            Assert.AreEqual(Constants.DateTime.value2, destination[1]);
            Assert.AreEqual(Constants.Bool.value2, destination[2]);
            ScenarioHelper.Assert_A_BigClass((A_BigClass)source[3], (A_BigClass)destination[3]);
            Assert.AreEqual(Enumeration.Two, destination[4]);
        }

        #endregion

        #region List -> Array - Objects

        [TestMethod]
        public void DeepCopyTo_SourceOfObjectListToDestinationOfObjectArray_DestinationCopied()
        {
            List<object> source = new List<object> { Constants.String.value1, Constants.DateTime.value2, Constants.Bool.value2, ScenarioHelper.CreateA_BigClass(), Enumeration.Two };

            object[] destination = source.DeepCopyTo<object[]>();

            Assert.AreNotEqual(source, destination);

            Assert.AreEqual(Constants.String.value1, destination[0]);
            Assert.AreEqual(Constants.DateTime.value2, destination[1]);
            Assert.AreEqual(Constants.Bool.value2, destination[2]);
            ScenarioHelper.Assert_A_BigClass((A_BigClass)source[3], (A_BigClass)destination[3]);
            Assert.AreEqual(Enumeration.Two, destination[4]);
        }

        #endregion

        #region Dictionary

        [TestMethod]
        public void DeepCopyTo_DictionaryToDictionaryOfSameType_DestinationCopied()
        {
            Dictionary<Guid, string> source = new Dictionary<Guid, string>()
            {
                { new Guid("35B5042A-24B9-4308-91CA-806FDEFFCE20"), "value1" },
                { new Guid("59236B13-AFBC-4C87-94DD-F0010A2319C1"), "value2" },
                { new Guid("ADF639AB-4AB4-48BC-BAC0-E25DC9915F08"), "value3" },
            };

            Dictionary<Guid, string> destination = source.DeepCopyTo<Dictionary<Guid, string>>();

            source[new Guid("35B5042A-24B9-4308-91CA-806FDEFFCE20")] = "value11";
            source[new Guid("59236B13-AFBC-4C87-94DD-F0010A2319C1")] = "value21";
            source[new Guid("ADF639AB-4AB4-48BC-BAC0-E25DC9915F08")] = "value31";

            Assert.AreEqual("value1", destination[new Guid("35B5042A-24B9-4308-91CA-806FDEFFCE20")]);
            Assert.AreEqual("value2", destination[new Guid("59236B13-AFBC-4C87-94DD-F0010A2319C1")]);
            Assert.AreEqual("value3", destination[new Guid("ADF639AB-4AB4-48BC-BAC0-E25DC9915F08")]);
        }

        [TestMethod]
        public void DeepCopyTo_DictionaryToDictionaryOfSameTypeWithCustomValue_DestinationCopied()
        {
            Dictionary<Guid, Cow> source = new Dictionary<Guid, Cow>()
            {
                { new Guid("35B5042A-24B9-4308-91CA-806FDEFFCE20"), ScenarioHelper.Create_Cow() },
                { new Guid("59236B13-AFBC-4C87-94DD-F0010A2319C1"), ScenarioHelper.Create_Cow() },
                { new Guid("ADF639AB-4AB4-48BC-BAC0-E25DC9915F08"), ScenarioHelper.Create_Cow() },
            };

            Dictionary<Guid, Cow> destination = source.DeepCopyTo<Dictionary<Guid, Cow>>();

            Cow destinationItem1 = destination[new Guid("35B5042A-24B9-4308-91CA-806FDEFFCE20")];
            Cow destinationItem2 = destination[new Guid("59236B13-AFBC-4C87-94DD-F0010A2319C1")];
            Cow destinationItem3 = destination[new Guid("ADF639AB-4AB4-48BC-BAC0-E25DC9915F08")];

            Assert.AreNotEqual(source[new Guid("35B5042A-24B9-4308-91CA-806FDEFFCE20")], destinationItem1);
            Assert.AreNotEqual(source[new Guid("59236B13-AFBC-4C87-94DD-F0010A2319C1")], destinationItem2);
            Assert.AreNotEqual(source[new Guid("ADF639AB-4AB4-48BC-BAC0-E25DC9915F08")], destinationItem3);

            ScenarioHelper.Assert_Cow(source[new Guid("35B5042A-24B9-4308-91CA-806FDEFFCE20")], destinationItem1);
            ScenarioHelper.Assert_Cow(source[new Guid("59236B13-AFBC-4C87-94DD-F0010A2319C1")], destinationItem2);
            ScenarioHelper.Assert_Cow(source[new Guid("ADF639AB-4AB4-48BC-BAC0-E25DC9915F08")], destinationItem3);
        }

        [TestMethod]
        public void DeepCopyTo_ClassWithDictionaryMapsToClassWithDictionaryOfDifferentCustomType_DestinationCopied()
        {
            A_ClassWithDictionary source = new A_ClassWithDictionary()
            {
                Prop1 = new Dictionary<string, string>() { { "key1", "value1" }, { "key2", "value2" } },
                Prop2 = new Dictionary<Guid, string>() { { Constants.Guid.value1, "value3" }, { Constants.Guid.value3, "value4" } },
                Prop3 = new Dictionary<Guid, Cow>() { { Constants.Guid.value2, ScenarioHelper.Create_Cow() } }
            };

            B_ClassWithDictionary destination = source.DeepCopyTo<B_ClassWithDictionary>();

            Assert.AreNotEqual(source, destination);

            Assert.AreEqual(2, destination.Prop1.Keys.Count);
            Assert.AreEqual("value1", destination.Prop1["key1"]);
            Assert.AreEqual("value2", destination.Prop1["key2"]);

            Assert.AreEqual(2, destination.Prop2.Keys.Count);
            Assert.AreEqual("value3", destination.Prop2[Constants.Guid.value1]);
            Assert.AreEqual("value4", destination.Prop2[Constants.Guid.value3]);

            Assert.AreEqual(1, destination.Prop3.Keys.Count);
            Assert.AreNotEqual(source.Prop3[Constants.Guid.value2], destination.Prop3[Constants.Guid.value2]);
            ScenarioHelper.Assert_Mule(source.Prop3[Constants.Guid.value2], destination.Prop3[Constants.Guid.value2]);
        }

        #endregion
        
        #region Array -> Array - Derived types

        [TestMethod]
        public void DeepCopyTo_SourceOfInterfaceArrayToDestinationOfInterfaceArray_DestinationCopied()
        {
            IInterface[] source = new IInterface[]
            {
                new Parent() { Prop1 = Constants.Int.value1, Prop2 = new Dictionary<Guid, string>() { { Constants.Guid.value1, Constants.String.value1 } } },
                new Child1() { Prop1 = Constants.Int.value2, Prop2 = new Dictionary<Guid, string>() { { Constants.Guid.value2, Constants.String.value2 } }, Prop3 = Constants.Decimal.value2 },
                new Parent() { Prop1 = Constants.Int.value1, Prop2 = new Dictionary<Guid, string>() { { Constants.Guid.value3, Constants.String.value1 } } },
            };

            IInterface[] destination = source.DeepCopyTo<IInterface[]>();

            Assert.AreNotEqual(source, destination);

            Assert.AreEqual(Constants.Int.value1, ((Parent)destination[0]).Prop1);
            Assert.AreNotEqual(((Parent)source[0]).Prop2, ((Parent)destination[0]).Prop2);
            Assert.AreEqual(Constants.String.value1, ((Parent)destination[0]).Prop2[Constants.Guid.value1]);

            Assert.AreEqual(Constants.Int.value2, ((Child1)destination[1]).Prop1);
            Assert.AreNotEqual(((Child1)source[1]).Prop2, ((Child1)destination[1]).Prop2);
            Assert.AreEqual(Constants.String.value2, ((Child1)destination[1]).Prop2[Constants.Guid.value2]);
            Assert.AreEqual(Constants.Decimal.value2, ((Child1)destination[1]).Prop3);

            Assert.AreEqual(Constants.Int.value1, ((Parent)destination[2]).Prop1);
            Assert.AreNotEqual(((Parent)source[2]).Prop2, ((Parent)destination[2]).Prop2);
            Assert.AreEqual(Constants.String.value1, ((Parent)destination[2]).Prop2[Constants.Guid.value3]);
        }

        [TestMethod]
        public void DeepCopyTo_SourceOfAbstractArrayToDestinationOfAbstractArray_DestinationCopied()
        {
            AbstractClass[] source = new AbstractClass[]
            {
                new Parent() { Prop1 = Constants.Int.value1, Prop2 = new Dictionary<Guid, string>() { { Constants.Guid.value1, Constants.String.value1 } } },
                new Child1() { Prop1 = Constants.Int.value2, Prop2 = new Dictionary<Guid, string>() { { Constants.Guid.value2, Constants.String.value2 } }, Prop3 = Constants.Decimal.value2 },
                new Parent() { Prop1 = Constants.Int.value1, Prop2 = new Dictionary<Guid, string>() { { Constants.Guid.value3, Constants.String.value1 } } },
            };

            AbstractClass[] destination = source.DeepCopyTo<AbstractClass[]>();

            Assert.AreNotEqual(source, destination);

            Assert.AreEqual(Constants.Int.value1, ((Parent)destination[0]).Prop1);
            Assert.AreNotEqual(((Parent)source[0]).Prop2, ((Parent)destination[0]).Prop2);
            Assert.AreEqual(Constants.String.value1, ((Parent)destination[0]).Prop2[Constants.Guid.value1]);

            Assert.AreEqual(Constants.Int.value2, ((Child1)destination[1]).Prop1);
            Assert.AreNotEqual(((Child1)source[1]).Prop2, ((Child1)destination[1]).Prop2);
            Assert.AreEqual(Constants.String.value2, ((Child1)destination[1]).Prop2[Constants.Guid.value2]);
            Assert.AreEqual(Constants.Decimal.value2, ((Child1)destination[1]).Prop3);

            Assert.AreEqual(Constants.Int.value1, ((Parent)destination[2]).Prop1);
            Assert.AreNotEqual(((Parent)source[2]).Prop2, ((Parent)destination[2]).Prop2);
            Assert.AreEqual(Constants.String.value1, ((Parent)destination[2]).Prop2[Constants.Guid.value3]);
        }

        [TestMethod]
        public void DeepCopyTo_SourceOfBaseArrayToDestinationOfDerivedArray_DestinationCopied()
        {
            Parent[] source = new Parent[]
            {
                new Parent() { Prop1 = Constants.Int.value1, Prop2 = new Dictionary<Guid, string>() { { Constants.Guid.value1, Constants.String.value1 } } },
                new Child1() { Prop1 = Constants.Int.value2, Prop2 = new Dictionary<Guid, string>() { { Constants.Guid.value2, Constants.String.value2 } }, Prop3 = Constants.Decimal.value2 },
                new Parent() { Prop1 = Constants.Int.value1, Prop2 = new Dictionary<Guid, string>() { { Constants.Guid.value3, Constants.String.value1 } } },
            };

            Child1[] destination = source.DeepCopyTo<Child1[]>();

            Assert.AreNotEqual(source, destination);

            Assert.AreEqual(typeof(Child1), destination[0].GetType());
            Assert.AreEqual(Constants.Int.value1, destination[0].Prop1);
            Assert.AreNotEqual(source[0].Prop2, destination[0].Prop2);
            Assert.AreEqual(Constants.String.value1, destination[0].Prop2[Constants.Guid.value1]);
            Assert.AreEqual(decimal.Zero, destination[0].Prop3);

            Assert.AreEqual(typeof(Child1), destination[1].GetType());
            Assert.AreEqual(Constants.Int.value2, destination[1].Prop1);
            Assert.AreNotEqual(((Child1)source[1]).Prop2, destination[1].Prop2);
            Assert.AreEqual(Constants.String.value2, destination[1].Prop2[Constants.Guid.value2]);
            Assert.AreEqual(Constants.Decimal.value2, destination[1].Prop3);

            Assert.AreEqual(typeof(Child1), destination[2].GetType());
            Assert.AreEqual(Constants.Int.value1, destination[2].Prop1);
            Assert.AreNotEqual(source[2].Prop2, destination[2].Prop2);
            Assert.AreEqual(Constants.String.value1, destination[2].Prop2[Constants.Guid.value3]);
            Assert.AreEqual(decimal.Zero, destination[2].Prop3);
        }

        [TestMethod]
        public void DeepCopyTo_SourceOfDerivedArrayToDestinationOfBaseArray_DestinationCopied()
        {
            Child1[] source = new Child1[]
            {
                new Child1() { Prop1 = Constants.Int.value2, Prop2 = new Dictionary<Guid, string>() { { Constants.Guid.value2, Constants.String.value2 } }, Prop3 = Constants.Decimal.value2 },
            };

            Parent[] destination = source.DeepCopyTo<Parent[]>();

            Assert.AreNotEqual(source, destination);

            Assert.AreEqual(typeof(Parent), destination[0].GetType());
            Assert.AreEqual(Constants.Int.value2, destination[0].Prop1);
            Assert.AreNotEqual(source[0].Prop2, destination[0].Prop2);
            Assert.AreEqual(Constants.String.value2, destination[0].Prop2[Constants.Guid.value2]);
        }

        #endregion

        #region List -> List - Derived types

        [TestMethod]
        public void DeepCopyTo_SourceOfInterfaceListToDestinationOfInterfaceList_DestinationCopied()
        {
            List<IInterface> source = new List<IInterface>
            {
                new Parent() { Prop1 = Constants.Int.value1, Prop2 = new Dictionary<Guid, string>() { { Constants.Guid.value1, Constants.String.value1 } } },
                new Child1() { Prop1 = Constants.Int.value2, Prop2 = new Dictionary<Guid, string>() { { Constants.Guid.value2, Constants.String.value2 } }, Prop3 = Constants.Decimal.value2 },
                new Parent() { Prop1 = Constants.Int.value1, Prop2 = new Dictionary<Guid, string>() { { Constants.Guid.value3, Constants.String.value1 } } },
            };

            List<IInterface> destination = source.DeepCopyTo<List<IInterface>>();

            Assert.AreNotEqual(source, destination);

            Assert.AreEqual(Constants.Int.value1, ((Parent)destination[0]).Prop1);
            Assert.AreNotEqual(((Parent)source[0]).Prop2, ((Parent)destination[0]).Prop2);
            Assert.AreEqual(Constants.String.value1, ((Parent)destination[0]).Prop2[Constants.Guid.value1]);

            Assert.AreEqual(Constants.Int.value2, ((Child1)destination[1]).Prop1);
            Assert.AreNotEqual(((Child1)source[1]).Prop2, ((Child1)destination[1]).Prop2);
            Assert.AreEqual(Constants.String.value2, ((Child1)destination[1]).Prop2[Constants.Guid.value2]);
            Assert.AreEqual(Constants.Decimal.value2, ((Child1)destination[1]).Prop3);

            Assert.AreEqual(Constants.Int.value1, ((Parent)destination[2]).Prop1);
            Assert.AreNotEqual(((Parent)source[2]).Prop2, ((Parent)destination[2]).Prop2);
            Assert.AreEqual(Constants.String.value1, ((Parent)destination[2]).Prop2[Constants.Guid.value3]);
        }

        [TestMethod]
        public void DeepCopyTo_SourceOfAbstractListToDestinationOfAbstractList_DestinationCopied()
        {
            List<AbstractClass> source = new List<AbstractClass>
            {
                new Parent() { Prop1 = Constants.Int.value1, Prop2 = new Dictionary<Guid, string>() { { Constants.Guid.value1, Constants.String.value1 } } },
                new Child1() { Prop1 = Constants.Int.value2, Prop2 = new Dictionary<Guid, string>() { { Constants.Guid.value2, Constants.String.value2 } }, Prop3 = Constants.Decimal.value2 },
                new Parent() { Prop1 = Constants.Int.value1, Prop2 = new Dictionary<Guid, string>() { { Constants.Guid.value3, Constants.String.value1 } } },
            };

            List<AbstractClass> destination = source.DeepCopyTo<List<AbstractClass>>();

            Assert.AreNotEqual(source, destination);

            Assert.AreEqual(Constants.Int.value1, ((Parent)destination[0]).Prop1);
            Assert.AreNotEqual(((Parent)source[0]).Prop2, ((Parent)destination[0]).Prop2);
            Assert.AreEqual(Constants.String.value1, ((Parent)destination[0]).Prop2[Constants.Guid.value1]);

            Assert.AreEqual(Constants.Int.value2, ((Child1)destination[1]).Prop1);
            Assert.AreNotEqual(((Child1)source[1]).Prop2, ((Child1)destination[1]).Prop2);
            Assert.AreEqual(Constants.String.value2, ((Child1)destination[1]).Prop2[Constants.Guid.value2]);
            Assert.AreEqual(Constants.Decimal.value2, ((Child1)destination[1]).Prop3);

            Assert.AreEqual(Constants.Int.value1, ((Parent)destination[2]).Prop1);
            Assert.AreNotEqual(((Parent)source[2]).Prop2, ((Parent)destination[2]).Prop2);
            Assert.AreEqual(Constants.String.value1, ((Parent)destination[2]).Prop2[Constants.Guid.value3]);
        }

        [TestMethod]
        public void DeepCopyTo_SourceOfBaseListToDestinationOfDerivedList_DestinationCopied()
        {
            List<Parent> source = new List<Parent>
            {
                new Parent() { Prop1 = Constants.Int.value1, Prop2 = new Dictionary<Guid, string>() { { Constants.Guid.value1, Constants.String.value1 } } },
                new Child1() { Prop1 = Constants.Int.value2, Prop2 = new Dictionary<Guid, string>() { { Constants.Guid.value2, Constants.String.value2 } }, Prop3 = Constants.Decimal.value2 },
                new Parent() { Prop1 = Constants.Int.value1, Prop2 = new Dictionary<Guid, string>() { { Constants.Guid.value3, Constants.String.value1 } } },
            };

            List<Child1> destination = source.DeepCopyTo<List<Child1>>();

            Assert.AreNotEqual(source, destination);

            Assert.AreEqual(typeof(Child1), destination[0].GetType());
            Assert.AreEqual(Constants.Int.value1, destination[0].Prop1);
            Assert.AreNotEqual(source[0].Prop2, destination[0].Prop2);
            Assert.AreEqual(Constants.String.value1, destination[0].Prop2[Constants.Guid.value1]);
            Assert.AreEqual(decimal.Zero, destination[0].Prop3);

            Assert.AreEqual(typeof(Child1), destination[1].GetType());
            Assert.AreEqual(Constants.Int.value2, destination[1].Prop1);
            Assert.AreNotEqual(((Child1)source[1]).Prop2, destination[1].Prop2);
            Assert.AreEqual(Constants.String.value2, destination[1].Prop2[Constants.Guid.value2]);
            Assert.AreEqual(Constants.Decimal.value2, destination[1].Prop3);

            Assert.AreEqual(typeof(Child1), destination[2].GetType());
            Assert.AreEqual(Constants.Int.value1, destination[2].Prop1);
            Assert.AreNotEqual(source[2].Prop2, destination[2].Prop2);
            Assert.AreEqual(Constants.String.value1, destination[2].Prop2[Constants.Guid.value3]);
            Assert.AreEqual(decimal.Zero, destination[2].Prop3);
        }

        [TestMethod]
        public void DeepCopyTo_SourceOfDerivedListToDestinationOfBaseList_DestinationCopied()
        {
            List<Child1> source = new List<Child1>
            {
                new Child1() { Prop1 = Constants.Int.value2, Prop2 = new Dictionary<Guid, string>() { { Constants.Guid.value2, Constants.String.value2 } }, Prop3 = Constants.Decimal.value2 },
            };

            List<Parent> destination = source.DeepCopyTo<List<Parent>>();

            Assert.AreNotEqual(source, destination);

            Assert.AreEqual(typeof(Parent), destination[0].GetType());
            Assert.AreEqual(Constants.Int.value2, destination[0].Prop1);
            Assert.AreNotEqual(source[0].Prop2, destination[0].Prop2);
            Assert.AreEqual(Constants.String.value2, destination[0].Prop2[Constants.Guid.value2]);
        }

        #endregion

        #region Array -> List - Derived types

        [TestMethod]
        public void DeepCopyTo_SourceOfInterfaceArrayToDestinationOfInterfaceList_DestinationCopied()
        {
            IInterface[] source = new IInterface[]
            {
                new Parent() { Prop1 = Constants.Int.value1, Prop2 = new Dictionary<Guid, string>() { { Constants.Guid.value1, Constants.String.value1 } } },
                new Child1() { Prop1 = Constants.Int.value2, Prop2 = new Dictionary<Guid, string>() { { Constants.Guid.value2, Constants.String.value2 } }, Prop3 = Constants.Decimal.value2 },
                new Parent() { Prop1 = Constants.Int.value1, Prop2 = new Dictionary<Guid, string>() { { Constants.Guid.value3, Constants.String.value1 } } },
            };

            List<IInterface> destination = source.DeepCopyTo<List<IInterface>>();

            Assert.AreNotEqual(source, destination);

            Assert.AreEqual(Constants.Int.value1, ((Parent)destination[0]).Prop1);
            Assert.AreNotEqual(((Parent)source[0]).Prop2, ((Parent)destination[0]).Prop2);
            Assert.AreEqual(Constants.String.value1, ((Parent)destination[0]).Prop2[Constants.Guid.value1]);

            Assert.AreEqual(Constants.Int.value2, ((Child1)destination[1]).Prop1);
            Assert.AreNotEqual(((Child1)source[1]).Prop2, ((Child1)destination[1]).Prop2);
            Assert.AreEqual(Constants.String.value2, ((Child1)destination[1]).Prop2[Constants.Guid.value2]);
            Assert.AreEqual(Constants.Decimal.value2, ((Child1)destination[1]).Prop3);

            Assert.AreEqual(Constants.Int.value1, ((Parent)destination[2]).Prop1);
            Assert.AreNotEqual(((Parent)source[2]).Prop2, ((Parent)destination[2]).Prop2);
            Assert.AreEqual(Constants.String.value1, ((Parent)destination[2]).Prop2[Constants.Guid.value3]);
        }

        [TestMethod]
        public void DeepCopyTo_SourceOfAbstractArrayToDestinationOfAbstractList_DestinationCopied()
        {
            AbstractClass[] source = new AbstractClass[]
            {
                new Parent() { Prop1 = Constants.Int.value1, Prop2 = new Dictionary<Guid, string>() { { Constants.Guid.value1, Constants.String.value1 } } },
                new Child1() { Prop1 = Constants.Int.value2, Prop2 = new Dictionary<Guid, string>() { { Constants.Guid.value2, Constants.String.value2 } }, Prop3 = Constants.Decimal.value2 },
                new Parent() { Prop1 = Constants.Int.value1, Prop2 = new Dictionary<Guid, string>() { { Constants.Guid.value3, Constants.String.value1 } } },
            };

            List<AbstractClass> destination = source.DeepCopyTo<List<AbstractClass>>();

            Assert.AreNotEqual(source, destination);

            Assert.AreEqual(Constants.Int.value1, ((Parent)destination[0]).Prop1);
            Assert.AreNotEqual(((Parent)source[0]).Prop2, ((Parent)destination[0]).Prop2);
            Assert.AreEqual(Constants.String.value1, ((Parent)destination[0]).Prop2[Constants.Guid.value1]);

            Assert.AreEqual(Constants.Int.value2, ((Child1)destination[1]).Prop1);
            Assert.AreNotEqual(((Child1)source[1]).Prop2, ((Child1)destination[1]).Prop2);
            Assert.AreEqual(Constants.String.value2, ((Child1)destination[1]).Prop2[Constants.Guid.value2]);
            Assert.AreEqual(Constants.Decimal.value2, ((Child1)destination[1]).Prop3);

            Assert.AreEqual(Constants.Int.value1, ((Parent)destination[2]).Prop1);
            Assert.AreNotEqual(((Parent)source[2]).Prop2, ((Parent)destination[2]).Prop2);
            Assert.AreEqual(Constants.String.value1, ((Parent)destination[2]).Prop2[Constants.Guid.value3]);
        }

        [TestMethod]
        public void DeepCopyTo_SourceOfBaseArrayToDestinationOfDerivedList_DestinationCopied()
        {
            Parent[] source = new Parent[]
            {
                new Parent() { Prop1 = Constants.Int.value1, Prop2 = new Dictionary<Guid, string>() { { Constants.Guid.value1, Constants.String.value1 } } },
                new Child1() { Prop1 = Constants.Int.value2, Prop2 = new Dictionary<Guid, string>() { { Constants.Guid.value2, Constants.String.value2 } }, Prop3 = Constants.Decimal.value2 },
                new Parent() { Prop1 = Constants.Int.value1, Prop2 = new Dictionary<Guid, string>() { { Constants.Guid.value3, Constants.String.value1 } } },
            };

            List<Child1> destination = source.DeepCopyTo<List<Child1>>();

            Assert.AreNotEqual(source, destination);

            Assert.AreEqual(typeof(Child1), destination[0].GetType());
            Assert.AreEqual(Constants.Int.value1, destination[0].Prop1);
            Assert.AreNotEqual(source[0].Prop2, destination[0].Prop2);
            Assert.AreEqual(Constants.String.value1, destination[0].Prop2[Constants.Guid.value1]);
            Assert.AreEqual(decimal.Zero, destination[0].Prop3);

            Assert.AreEqual(typeof(Child1), destination[1].GetType());
            Assert.AreEqual(Constants.Int.value2, destination[1].Prop1);
            Assert.AreNotEqual(((Child1)source[1]).Prop2, destination[1].Prop2);
            Assert.AreEqual(Constants.String.value2, destination[1].Prop2[Constants.Guid.value2]);
            Assert.AreEqual(Constants.Decimal.value2, destination[1].Prop3);

            Assert.AreEqual(typeof(Child1), destination[2].GetType());
            Assert.AreEqual(Constants.Int.value1, destination[2].Prop1);
            Assert.AreNotEqual(source[2].Prop2, destination[2].Prop2);
            Assert.AreEqual(Constants.String.value1, destination[2].Prop2[Constants.Guid.value3]);
            Assert.AreEqual(decimal.Zero, destination[2].Prop3);
        }

        [TestMethod]
        public void DeepCopyTo_SourceOfDerivedArrayToDestinationOfBaseList_DestinationCopied()
        {
            Child1[] source = new Child1[]
            {
                new Child1() { Prop1 = Constants.Int.value2, Prop2 = new Dictionary<Guid, string>() { { Constants.Guid.value2, Constants.String.value2 } }, Prop3 = Constants.Decimal.value2 },
            };

            List<Parent> destination = source.DeepCopyTo<List<Parent>>();

            Assert.AreNotEqual(source, destination);

            Assert.AreEqual(typeof(Parent), destination[0].GetType());
            Assert.AreEqual(Constants.Int.value2, destination[0].Prop1);
            Assert.AreNotEqual(source[0].Prop2, destination[0].Prop2);
            Assert.AreEqual(Constants.String.value2, destination[0].Prop2[Constants.Guid.value2]);
        }

        #endregion

        #region List -> List - Derived types

        [TestMethod]
        public void DeepCopyTo_SourceOfInterfaceListToDestinationOfInterfaceArray_DestinationCopied()
        {
            List<IInterface> source = new List<IInterface>
            {
                new Parent() { Prop1 = Constants.Int.value1, Prop2 = new Dictionary<Guid, string>() { { Constants.Guid.value1, Constants.String.value1 } } },
                new Child1() { Prop1 = Constants.Int.value2, Prop2 = new Dictionary<Guid, string>() { { Constants.Guid.value2, Constants.String.value2 } }, Prop3 = Constants.Decimal.value2 },
                new Parent() { Prop1 = Constants.Int.value1, Prop2 = new Dictionary<Guid, string>() { { Constants.Guid.value3, Constants.String.value1 } } },
            };

            IInterface[] destination = source.DeepCopyTo<IInterface[]>();

            Assert.AreNotEqual(source, destination);

            Assert.AreEqual(Constants.Int.value1, ((Parent)destination[0]).Prop1);
            Assert.AreNotEqual(((Parent)source[0]).Prop2, ((Parent)destination[0]).Prop2);
            Assert.AreEqual(Constants.String.value1, ((Parent)destination[0]).Prop2[Constants.Guid.value1]);

            Assert.AreEqual(Constants.Int.value2, ((Child1)destination[1]).Prop1);
            Assert.AreNotEqual(((Child1)source[1]).Prop2, ((Child1)destination[1]).Prop2);
            Assert.AreEqual(Constants.String.value2, ((Child1)destination[1]).Prop2[Constants.Guid.value2]);
            Assert.AreEqual(Constants.Decimal.value2, ((Child1)destination[1]).Prop3);

            Assert.AreEqual(Constants.Int.value1, ((Parent)destination[2]).Prop1);
            Assert.AreNotEqual(((Parent)source[2]).Prop2, ((Parent)destination[2]).Prop2);
            Assert.AreEqual(Constants.String.value1, ((Parent)destination[2]).Prop2[Constants.Guid.value3]);
        }

        [TestMethod]
        public void DeepCopyTo_SourceOfAbstractListToDestinationOfAbstractArray_DestinationCopied()
        {
            List<AbstractClass> source = new List<AbstractClass>
            {
                new Parent() { Prop1 = Constants.Int.value1, Prop2 = new Dictionary<Guid, string>() { { Constants.Guid.value1, Constants.String.value1 } } },
                new Child1() { Prop1 = Constants.Int.value2, Prop2 = new Dictionary<Guid, string>() { { Constants.Guid.value2, Constants.String.value2 } }, Prop3 = Constants.Decimal.value2 },
                new Parent() { Prop1 = Constants.Int.value1, Prop2 = new Dictionary<Guid, string>() { { Constants.Guid.value3, Constants.String.value1 } } },
            };

            AbstractClass[] destination = source.DeepCopyTo<AbstractClass[]>();

            Assert.AreNotEqual(source, destination);

            Assert.AreEqual(Constants.Int.value1, ((Parent)destination[0]).Prop1);
            Assert.AreNotEqual(((Parent)source[0]).Prop2, ((Parent)destination[0]).Prop2);
            Assert.AreEqual(Constants.String.value1, ((Parent)destination[0]).Prop2[Constants.Guid.value1]);

            Assert.AreEqual(Constants.Int.value2, ((Child1)destination[1]).Prop1);
            Assert.AreNotEqual(((Child1)source[1]).Prop2, ((Child1)destination[1]).Prop2);
            Assert.AreEqual(Constants.String.value2, ((Child1)destination[1]).Prop2[Constants.Guid.value2]);
            Assert.AreEqual(Constants.Decimal.value2, ((Child1)destination[1]).Prop3);

            Assert.AreEqual(Constants.Int.value1, ((Parent)destination[2]).Prop1);
            Assert.AreNotEqual(((Parent)source[2]).Prop2, ((Parent)destination[2]).Prop2);
            Assert.AreEqual(Constants.String.value1, ((Parent)destination[2]).Prop2[Constants.Guid.value3]);
        }

        [TestMethod]
        public void DeepCopyTo_SourceOfBaseListToDestinationOfDerivedArray_DestinationCopied()
        {
            List<Parent> source = new List<Parent>
            {
                new Parent() { Prop1 = Constants.Int.value1, Prop2 = new Dictionary<Guid, string>() { { Constants.Guid.value1, Constants.String.value1 } } },
                new Child1() { Prop1 = Constants.Int.value2, Prop2 = new Dictionary<Guid, string>() { { Constants.Guid.value2, Constants.String.value2 } }, Prop3 = Constants.Decimal.value2 },
                new Parent() { Prop1 = Constants.Int.value1, Prop2 = new Dictionary<Guid, string>() { { Constants.Guid.value3, Constants.String.value1 } } },
            };

            Child1[] destination = source.DeepCopyTo<Child1[]>();

            Assert.AreNotEqual(source, destination);

            Assert.AreEqual(typeof(Child1), destination[0].GetType());
            Assert.AreEqual(Constants.Int.value1, destination[0].Prop1);
            Assert.AreNotEqual(source[0].Prop2, destination[0].Prop2);
            Assert.AreEqual(Constants.String.value1, destination[0].Prop2[Constants.Guid.value1]);
            Assert.AreEqual(decimal.Zero, destination[0].Prop3);

            Assert.AreEqual(typeof(Child1), destination[1].GetType());
            Assert.AreEqual(Constants.Int.value2, destination[1].Prop1);
            Assert.AreNotEqual(((Child1)source[1]).Prop2, destination[1].Prop2);
            Assert.AreEqual(Constants.String.value2, destination[1].Prop2[Constants.Guid.value2]);
            Assert.AreEqual(Constants.Decimal.value2, destination[1].Prop3);

            Assert.AreEqual(typeof(Child1), destination[2].GetType());
            Assert.AreEqual(Constants.Int.value1, destination[2].Prop1);
            Assert.AreNotEqual(source[2].Prop2, destination[2].Prop2);
            Assert.AreEqual(Constants.String.value1, destination[2].Prop2[Constants.Guid.value3]);
            Assert.AreEqual(decimal.Zero, destination[2].Prop3);
        }

        [TestMethod]
        public void DeepCopyTo_SourceOfDerivedListToDestinationOfBaseArray_DestinationCopied()
        {
            List<Child1> source = new List<Child1>
            {
                new Child1() { Prop1 = Constants.Int.value2, Prop2 = new Dictionary<Guid, string>() { { Constants.Guid.value2, Constants.String.value2 } }, Prop3 = Constants.Decimal.value2 },
            };

            Parent[] destination = source.DeepCopyTo<Parent[]>();

            Assert.AreNotEqual(source, destination);

            Assert.AreEqual(typeof(Parent), destination[0].GetType());
            Assert.AreEqual(Constants.Int.value2, destination[0].Prop1);
            Assert.AreNotEqual(source[0].Prop2, destination[0].Prop2);
            Assert.AreEqual(Constants.String.value2, destination[0].Prop2[Constants.Guid.value2]);
        }

        #endregion

        #endregion


        #region Aggregate types

        [TestMethod]
        public void DeepCopyTo_WhenSourceAndDestinationHaveTheSameAggregatedType_ThenDestinationIsCopied()
        {
            A_BigClass source = new A_BigClass()
            {
                Bool = true,
                DateTime = new DateTime(2011, 01, 02),
                Decimal = 14.10M,
                Guid = new Guid("8DA4C611-A758-4EB7-A352-8D12FE84DBD9"),
                Int = 4141,
                String = "1142",

                FirstClass = new A_FirstClass()
                {
                    Bool = true,
                    DateTime = new DateTime(2012, 01, 02),
                    Decimal = 66.10M,
                    Guid = new Guid("8D24C611-A758-4EB7-A352-8D82FE84DBD9"),
                    Int = 54,
                    String = "8567",

                    FirstClassFirstSubClass = new A_FirstClassFirstSubClass()
                    {
                        Bool = true,
                        DateTime = new DateTime(2013, 01, 02),
                        Decimal = 324.10M,
                        Guid = new Guid("8DA43611-A758-4EB7-A352-8D82FE84DBD9"),
                        Int = 7345,
                        String = "834"
                    },
                    FirstClassSecondSubClass = new A_FirstClassSecondSubClass()
                    {
                        Bool = true,
                        DateTime = new DateTime(2014, 01, 02),
                        Decimal = 523.10M,
                        Guid = new Guid("8DA4C611-A758-4EB7-A352-8482FE84DBD9"),
                        Int = 235,
                        String = "978"
                    }
                },

                SecondClass = new A_SecondClass()
                {
                    Bool = true,
                    DateTime = new DateTime(2015, 01, 02),
                    Decimal = 78.10M,
                    Guid = new Guid("8DA4C611-3758-4EB7-A352-8D82FE84DBD9"),
                    Int = 2346,
                    String = "5",

                    SecondClassFirstSubClass = new A_SecondClassFirstSubClass()
                    {
                        Bool = true,
                        DateTime = new DateTime(2016, 01, 02),
                        Decimal = 32.10M,
                        Guid = new Guid("8DA41611-A758-4EB7-A352-8D82FE84DBD9"),
                        Int = 8,
                        String = "7089"
                    },
                    SecondClassSecondSubClass = new A_SecondClassSecondSubClass()
                    {
                        Bool = true,
                        DateTime = new DateTime(2017, 01, 02),
                        Decimal = 56.10M,
                        Guid = new Guid("8DA44611-A758-4EB7-A352-8D82FE844BD9"),
                        Int = 5,
                        String = "887"
                    }
                }
            };

            A_BigClass destination = source.DeepCopyTo<A_BigClass>();

            Assert.AreNotEqual(source, destination);
            Assert.AreEqual(true, destination.Bool);
            Assert.AreEqual(new DateTime(2011, 01, 02), destination.DateTime);
            Assert.AreEqual(14.10M, destination.Decimal);
            Assert.AreEqual(new Guid("8DA4C611-A758-4EB7-A352-8D12FE84DBD9"), destination.Guid);
            Assert.AreEqual(4141, destination.Int);
            Assert.AreEqual("1142", destination.String);

            Assert.AreNotEqual(source.FirstClass, destination.FirstClass);
            Assert.AreEqual(true, destination.FirstClass.Bool);
            Assert.AreEqual(new DateTime(2012, 01, 02), destination.FirstClass.DateTime);
            Assert.AreEqual(66.10M, destination.FirstClass.Decimal);
            Assert.AreEqual(new Guid("8D24C611-A758-4EB7-A352-8D82FE84DBD9"), destination.FirstClass.Guid);
            Assert.AreEqual(54, destination.FirstClass.Int);
            Assert.AreEqual("8567", destination.FirstClass.String);

            Assert.AreNotEqual(source.FirstClass.FirstClassFirstSubClass, destination.FirstClass.FirstClassFirstSubClass);
            Assert.AreEqual(true, destination.FirstClass.FirstClassFirstSubClass.Bool);
            Assert.AreEqual(new DateTime(2013, 01, 02), destination.FirstClass.FirstClassFirstSubClass.DateTime);
            Assert.AreEqual(324.10M, destination.FirstClass.FirstClassFirstSubClass.Decimal);
            Assert.AreEqual(new Guid("8DA43611-A758-4EB7-A352-8D82FE84DBD9"), destination.FirstClass.FirstClassFirstSubClass.Guid);
            Assert.AreEqual(7345, destination.FirstClass.FirstClassFirstSubClass.Int);
            Assert.AreEqual("834", destination.FirstClass.FirstClassFirstSubClass.String);

            Assert.AreNotEqual(source.FirstClass.FirstClassSecondSubClass, destination.FirstClass.FirstClassSecondSubClass);
            Assert.AreEqual(true, destination.FirstClass.FirstClassSecondSubClass.Bool);
            Assert.AreEqual(new DateTime(2014, 01, 02), destination.FirstClass.FirstClassSecondSubClass.DateTime);
            Assert.AreEqual(523.10M, destination.FirstClass.FirstClassSecondSubClass.Decimal);
            Assert.AreEqual(new Guid("8DA4C611-A758-4EB7-A352-8482FE84DBD9"), destination.FirstClass.FirstClassSecondSubClass.Guid);
            Assert.AreEqual(235, destination.FirstClass.FirstClassSecondSubClass.Int);
            Assert.AreEqual("978", destination.FirstClass.FirstClassSecondSubClass.String);

            Assert.AreNotEqual(source.SecondClass, destination.SecondClass);
            Assert.AreEqual(true, destination.SecondClass.Bool);
            Assert.AreEqual(new DateTime(2015, 01, 02), destination.SecondClass.DateTime);
            Assert.AreEqual(78.10M, destination.SecondClass.Decimal);
            Assert.AreEqual(new Guid("8DA4C611-3758-4EB7-A352-8D82FE84DBD9"), destination.SecondClass.Guid);
            Assert.AreEqual(2346, destination.SecondClass.Int);
            Assert.AreEqual("5", destination.SecondClass.String);

            Assert.AreNotEqual(source.SecondClass.SecondClassFirstSubClass, destination.SecondClass.SecondClassFirstSubClass);
            Assert.AreEqual(true, destination.SecondClass.SecondClassFirstSubClass.Bool);
            Assert.AreEqual(new DateTime(2016, 01, 02), destination.SecondClass.SecondClassFirstSubClass.DateTime);
            Assert.AreEqual(32.10M, destination.SecondClass.SecondClassFirstSubClass.Decimal);
            Assert.AreEqual(new Guid("8DA41611-A758-4EB7-A352-8D82FE84DBD9"), destination.SecondClass.SecondClassFirstSubClass.Guid);
            Assert.AreEqual(8, destination.SecondClass.SecondClassFirstSubClass.Int);
            Assert.AreEqual("7089", destination.SecondClass.SecondClassFirstSubClass.String);

            Assert.AreNotEqual(source.SecondClass.SecondClassSecondSubClass, destination.SecondClass.SecondClassSecondSubClass);
            Assert.AreEqual(true, destination.SecondClass.SecondClassSecondSubClass.Bool);
            Assert.AreEqual(new DateTime(2017, 01, 02), destination.SecondClass.SecondClassSecondSubClass.DateTime);
            Assert.AreEqual(56.10M, destination.SecondClass.SecondClassSecondSubClass.Decimal);
            Assert.AreEqual(new Guid("8DA44611-A758-4EB7-A352-8D82FE844BD9"), destination.SecondClass.SecondClassSecondSubClass.Guid);
            Assert.AreEqual(5, destination.SecondClass.SecondClassSecondSubClass.Int);
            Assert.AreEqual("887", destination.SecondClass.SecondClassSecondSubClass.String);
        }

        [TestMethod]
        public void DeepCopyTo_WhenSourceAndDestinationHaveDifferentAggregatedTypes_ThenDestinationIsCopied()
        {
            A_BigClass source = new A_BigClass()
            {
                Bool = true,
                DateTime = new DateTime(2011, 01, 02),
                Decimal = 14.10M,
                Guid = new Guid("8DA4C611-A758-4EB7-A352-8D12FE84DBD9"),
                Int = 4141,
                String = "1142",

                FirstClass = new A_FirstClass()
                {
                    Bool = true,
                    DateTime = new DateTime(2012, 01, 02),
                    Decimal = 66.10M,
                    Guid = new Guid("8D24C611-A758-4EB7-A352-8D82FE84DBD9"),
                    Int = 54,
                    String = "8567",

                    FirstClassFirstSubClass = new A_FirstClassFirstSubClass()
                    {
                        Bool = true,
                        DateTime = new DateTime(2013, 01, 02),
                        Decimal = 324.10M,
                        Guid = new Guid("8DA43611-A758-4EB7-A352-8D82FE84DBD9"),
                        Int = 7345,
                        String = "834"
                    },
                    FirstClassSecondSubClass = new A_FirstClassSecondSubClass()
                    {
                        Bool = true,
                        DateTime = new DateTime(2014, 01, 02),
                        Decimal = 523.10M,
                        Guid = new Guid("8DA4C611-A758-4EB7-A352-8482FE84DBD9"),
                        Int = 235,
                        String = "978"
                    }
                },

                SecondClass = new A_SecondClass()
                {
                    Bool = true,
                    DateTime = new DateTime(2015, 01, 02),
                    Decimal = 78.10M,
                    Guid = new Guid("8DA4C611-3758-4EB7-A352-8D82FE84DBD9"),
                    Int = 2346,
                    String = "5",

                    SecondClassFirstSubClass = new A_SecondClassFirstSubClass()
                    {
                        Bool = true,
                        DateTime = new DateTime(2016, 01, 02),
                        Decimal = 32.10M,
                        Guid = new Guid("8DA41611-A758-4EB7-A352-8D82FE84DBD9"),
                        Int = 8,
                        String = "7089"
                    },
                    SecondClassSecondSubClass = new A_SecondClassSecondSubClass()
                    {
                        Bool = true,
                        DateTime = new DateTime(2017, 01, 02),
                        Decimal = 56.10M,
                        Guid = new Guid("8DA44611-A758-4EB7-A352-8D82FE844BD9"),
                        Int = 5,
                        String = "887"
                    }
                }
            };

            B_BigClass destination = source.DeepCopyTo<B_BigClass>();

            Assert.AreNotEqual(source, destination);
            Assert.AreEqual(true, destination.Bool);
            Assert.AreEqual(new DateTime(2011, 01, 02), destination.DateTime);
            Assert.AreEqual(14.10M, destination.Decimal);
            Assert.AreEqual(new Guid("8DA4C611-A758-4EB7-A352-8D12FE84DBD9"), destination.Guid);
            Assert.AreEqual(4141, destination.Int);
            Assert.AreEqual("1142", destination.String);

            Assert.AreNotEqual(source.FirstClass, destination.FirstClass);
            Assert.AreEqual(true, destination.FirstClass.Bool);
            Assert.AreEqual(new DateTime(2012, 01, 02), destination.FirstClass.DateTime);
            Assert.AreEqual(66.10M, destination.FirstClass.Decimal);
            Assert.AreEqual(new Guid("8D24C611-A758-4EB7-A352-8D82FE84DBD9"), destination.FirstClass.Guid);
            Assert.AreEqual(54, destination.FirstClass.Int);
            Assert.AreEqual("8567", destination.FirstClass.String);

            Assert.AreNotEqual(source.FirstClass.FirstClassFirstSubClass, destination.FirstClass.FirstClassFirstSubClass);
            Assert.AreEqual(true, destination.FirstClass.FirstClassFirstSubClass.Bool);
            Assert.AreEqual(new DateTime(2013, 01, 02), destination.FirstClass.FirstClassFirstSubClass.DateTime);
            Assert.AreEqual(324.10M, destination.FirstClass.FirstClassFirstSubClass.Decimal);
            Assert.AreEqual(new Guid("8DA43611-A758-4EB7-A352-8D82FE84DBD9"), destination.FirstClass.FirstClassFirstSubClass.Guid);
            Assert.AreEqual(7345, destination.FirstClass.FirstClassFirstSubClass.Int);
            Assert.AreEqual("834", destination.FirstClass.FirstClassFirstSubClass.String);

            Assert.AreNotEqual(source.FirstClass.FirstClassSecondSubClass, destination.FirstClass.FirstClassSecondSubClass);
            Assert.AreEqual(true, destination.FirstClass.FirstClassSecondSubClass.Bool);
            Assert.AreEqual(new DateTime(2014, 01, 02), destination.FirstClass.FirstClassSecondSubClass.DateTime);
            Assert.AreEqual(523.10M, destination.FirstClass.FirstClassSecondSubClass.Decimal);
            Assert.AreEqual(new Guid("8DA4C611-A758-4EB7-A352-8482FE84DBD9"), destination.FirstClass.FirstClassSecondSubClass.Guid);
            Assert.AreEqual(235, destination.FirstClass.FirstClassSecondSubClass.Int);
            Assert.AreEqual("978", destination.FirstClass.FirstClassSecondSubClass.String);

            Assert.AreNotEqual(source.SecondClass, destination.SecondClass);
            Assert.AreEqual(true, destination.SecondClass.Bool);
            Assert.AreEqual(new DateTime(2015, 01, 02), destination.SecondClass.DateTime);
            Assert.AreEqual(78.10M, destination.SecondClass.Decimal);
            Assert.AreEqual(new Guid("8DA4C611-3758-4EB7-A352-8D82FE84DBD9"), destination.SecondClass.Guid);
            Assert.AreEqual(2346, destination.SecondClass.Int);
            Assert.AreEqual("5", destination.SecondClass.String);

            Assert.AreNotEqual(source.SecondClass.SecondClassFirstSubClass, destination.SecondClass.SecondClassFirstSubClass);
            Assert.AreEqual(true, destination.SecondClass.SecondClassFirstSubClass.Bool);
            Assert.AreEqual(new DateTime(2016, 01, 02), destination.SecondClass.SecondClassFirstSubClass.DateTime);
            Assert.AreEqual(32.10M, destination.SecondClass.SecondClassFirstSubClass.Decimal);
            Assert.AreEqual(new Guid("8DA41611-A758-4EB7-A352-8D82FE84DBD9"), destination.SecondClass.SecondClassFirstSubClass.Guid);
            Assert.AreEqual(8, destination.SecondClass.SecondClassFirstSubClass.Int);
            Assert.AreEqual("7089", destination.SecondClass.SecondClassFirstSubClass.String);

            Assert.AreNotEqual(source.SecondClass.SecondClassSecondSubClass, destination.SecondClass.SecondClassSecondSubClass);
            Assert.AreEqual(true, destination.SecondClass.SecondClassSecondSubClass.Bool);
            Assert.AreEqual(new DateTime(2017, 01, 02), destination.SecondClass.SecondClassSecondSubClass.DateTime);
            Assert.AreEqual(56.10M, destination.SecondClass.SecondClassSecondSubClass.Decimal);
            Assert.AreEqual(new Guid("8DA44611-A758-4EB7-A352-8D82FE844BD9"), destination.SecondClass.SecondClassSecondSubClass.Guid);
            Assert.AreEqual(5, destination.SecondClass.SecondClassSecondSubClass.Int);
            Assert.AreEqual("887", destination.SecondClass.SecondClassSecondSubClass.String);
        }

        [TestMethod]
        public void DeepCopyTo_WhenSourceAndDestinationHaveSameTypeWithCircularReference_ThenDestinationIsCopied()
        {
            A_CircularReference source = new A_CircularReference()
            {
                Bool = true,
                DateTime = new DateTime(2011, 01, 02),
                Decimal = 14.10M,
                Guid = new Guid("8DA4C611-A758-4EB7-A352-8D12FE84DBD9"),
                Int = 4141,
                String = "1142",

                CircularReferenceProperty = new A_CircularReference()
                {
                    Bool = true,
                    DateTime = new DateTime(2012, 01, 02),
                    Decimal = 66.10M,
                    Guid = new Guid("8D24C611-A758-4EB7-A352-8D82FE84DBD9"),
                    Int = 54,
                    String = "8567",
                }
            };

            A_CircularReference destination = source.DeepCopyTo<A_CircularReference>();

            Assert.AreNotEqual(source, destination);
            Assert.AreEqual(true, destination.Bool);
            Assert.AreEqual(new DateTime(2011, 01, 02), destination.DateTime);
            Assert.AreEqual(14.10M, destination.Decimal);
            Assert.AreEqual(new Guid("8DA4C611-A758-4EB7-A352-8D12FE84DBD9"), destination.Guid);
            Assert.AreEqual(4141, destination.Int);
            Assert.AreEqual("1142", destination.String);

            Assert.AreNotEqual(source.CircularReferenceProperty, destination.CircularReferenceProperty);
            Assert.AreEqual(true, destination.CircularReferenceProperty.Bool);
            Assert.AreEqual(new DateTime(2012, 01, 02), destination.CircularReferenceProperty.DateTime);
            Assert.AreEqual(66.10M, destination.CircularReferenceProperty.Decimal);
            Assert.AreEqual(new Guid("8D24C611-A758-4EB7-A352-8D82FE84DBD9"), destination.CircularReferenceProperty.Guid);
            Assert.AreEqual(54, destination.CircularReferenceProperty.Int);
            Assert.AreEqual("8567", destination.CircularReferenceProperty.String);

            Assert.IsNull(destination.CircularReferenceProperty.CircularReferenceProperty);
        }

        [TestMethod]
        public void DeepCopyTo_WhenSourceAndDestinationHaveDifferentTypeWithCircularReference_ThenDestinationIsCopied()
        {
            A_CircularReference source = new A_CircularReference()
            {
                Bool = true,
                DateTime = new DateTime(2011, 01, 02),
                Decimal = 14.10M,
                Guid = new Guid("8DA4C611-A758-4EB7-A352-8D12FE84DBD9"),
                Int = 4141,
                String = "1142",

                CircularReferenceProperty = new A_CircularReference()
                {
                    Bool = true,
                    DateTime = new DateTime(2012, 01, 02),
                    Decimal = 66.10M,
                    Guid = new Guid("8D24C611-A758-4EB7-A352-8D82FE84DBD9"),
                    Int = 54,
                    String = "8567",
                }
            };

            B_CircularReference destination = source.DeepCopyTo<B_CircularReference>();

            Assert.AreNotEqual(source, destination);
            Assert.AreEqual(true, destination.Bool);
            Assert.AreEqual(new DateTime(2011, 01, 02), destination.DateTime);
            Assert.AreEqual(14.10M, destination.Decimal);
            Assert.AreEqual(new Guid("8DA4C611-A758-4EB7-A352-8D12FE84DBD9"), destination.Guid);
            Assert.AreEqual(4141, destination.Int);
            Assert.AreEqual("1142", destination.String);

            Assert.AreNotEqual(source.CircularReferenceProperty, destination.CircularReferenceProperty);
            Assert.AreEqual(true, destination.CircularReferenceProperty.Bool);
            Assert.AreEqual(new DateTime(2012, 01, 02), destination.CircularReferenceProperty.DateTime);
            Assert.AreEqual(66.10M, destination.CircularReferenceProperty.Decimal);
            Assert.AreEqual(new Guid("8D24C611-A758-4EB7-A352-8D82FE84DBD9"), destination.CircularReferenceProperty.Guid);
            Assert.AreEqual(54, destination.CircularReferenceProperty.Int);
            Assert.AreEqual("8567", destination.CircularReferenceProperty.String);

            Assert.IsNull(destination.CircularReferenceProperty.CircularReferenceProperty);
        }

        #endregion



        #region Derived types

        [TestMethod]
        public void DeepCopyTo_Interface_To_Interface_DestinationCopied()
        {
            IInterface source = new Parent() { Prop1 = Constants.Int.value1, Prop2 = new Dictionary<Guid, string>() { { Constants.Guid.value3, Constants.String.value1 } } };

            IInterface destination = source.DeepCopyTo<IInterface>();

            Assert.AreNotEqual(source, destination);

            Assert.AreEqual(Constants.Int.value1, ((Parent)destination).Prop1);

            Assert.AreNotEqual(((Parent)source).Prop2, ((Parent)destination).Prop2);
            Assert.AreEqual(Constants.String.value1, ((Parent)destination).Prop2[Constants.Guid.value3]);
        }

        [TestMethod]
        public void DeepCopyTo_Interface_To_Abstract_DestinationCopied()
        {
            IInterface source = new Parent() { Prop1 = Constants.Int.value1, Prop2 = new Dictionary<Guid, string>() { { Constants.Guid.value3, Constants.String.value1 } } };

            AbstractClass destination = source.DeepCopyTo<AbstractClass>();

            Assert.AreNotEqual(source, destination);

            Assert.AreEqual(Constants.Int.value1, ((Parent)destination).Prop1);

            Assert.AreNotEqual(((Parent)source).Prop2, ((Parent)destination).Prop2);
            Assert.AreEqual(Constants.String.value1, ((Parent)destination).Prop2[Constants.Guid.value3]);
        }

        [TestMethod]
        public void DeepCopyTo_Abstrat_To_Abstract_DestinationCopied()
        {
            AbstractClass source = new Parent() { Prop1 = Constants.Int.value1, Prop2 = new Dictionary<Guid, string>() { { Constants.Guid.value3, Constants.String.value1 } } };

            AbstractClass destination = source.DeepCopyTo<AbstractClass>();

            Assert.AreNotEqual(source, destination);

            Assert.AreEqual(Constants.Int.value1, ((Parent)destination).Prop1);

            Assert.AreNotEqual(((Parent)source).Prop2, ((Parent)destination).Prop2);
            Assert.AreEqual(Constants.String.value1, ((Parent)destination).Prop2[Constants.Guid.value3]);
        }

        [TestMethod]
        public void DeepCopyTo_Abstract_To_Interface_DestinationCopied()
        {
            AbstractClass source = new Parent() { Prop1 = Constants.Int.value1, Prop2 = new Dictionary<Guid, string>() { { Constants.Guid.value3, Constants.String.value1 } } };

            IInterface destination = source.DeepCopyTo<IInterface>();

            Assert.AreNotEqual(source, destination);

            Assert.AreEqual(Constants.Int.value1, ((Parent)destination).Prop1);

            Assert.AreNotEqual(((Parent)source).Prop2, ((Parent)destination).Prop2);
            Assert.AreEqual(Constants.String.value1, ((Parent)destination).Prop2[Constants.Guid.value3]);
        }


        [TestMethod]
        public void DeepCopyTo_Derived_To_Base_DestinationCopied()
        {
            Child1 source = new Child1() { Prop1 = Constants.Int.value1, Prop2 = new Dictionary<Guid, string>() { { Constants.Guid.value3, Constants.String.value1 } }, Prop3 = Constants.Decimal.value1 };

            Parent destination = source.DeepCopyTo<Parent>();

            Assert.AreNotEqual(source, destination);

            Assert.AreEqual(typeof(Parent), destination.GetType());

            Assert.AreEqual(Constants.Int.value1, destination.Prop1);

            Assert.AreNotEqual(source.Prop2, destination.Prop2);
            Assert.AreEqual(Constants.String.value1, destination.Prop2[Constants.Guid.value3]);
        }

        [TestMethod]
        public void DeepCopyTo_Base_To_Derived_DestinationCopied()
        {
            Parent source = new Parent() { Prop1 = Constants.Int.value1, Prop2 = new Dictionary<Guid, string>() { { Constants.Guid.value3, Constants.String.value1 } } };

            Child1 destination = source.DeepCopyTo<Child1>();

            Assert.AreNotEqual(source, destination);

            Assert.AreEqual(typeof(Child1), destination.GetType());

            Assert.AreEqual(Constants.Int.value1, destination.Prop1);

            Assert.AreNotEqual(source.Prop2, destination.Prop2);
            Assert.AreEqual(Constants.String.value1, destination.Prop2[Constants.Guid.value3]);

            Assert.AreEqual(decimal.Zero, destination.Prop3);
        }


        #endregion
    }
}