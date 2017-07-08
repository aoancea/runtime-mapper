using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;

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

            ScenarioHelper.Assert_Cow(source, destination);
        }

        [TestMethod]
        public void Map_SourceAndDestinationAreDifferentTypeButContainTheSameProperties_DestinationCopied()
        {
            Cow source = ScenarioHelper.Create_Cow();

            Mule destination = new Mule();

            Mapper.Map(source, destination);

            Assert.AreNotEqual(source, destination);

            ScenarioHelper.Assert_Mule(source, destination);
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

            B_ClassWithDictionary destination = new B_ClassWithDictionary();

            Mapper.Map(source, destination);

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


        #region Aggregate types

        [TestMethod]
        public void Map_WhenSourceAndDestinationHaveTheSameAggregatedType_ThenDestinationIsCopied()
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

            A_BigClass destination = new A_BigClass();

            Mapper.Map(source, destination);

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
        public void Map_WhenSourceAndDestinationHaveDifferentAggregatedTypes_ThenDestinationIsCopied()
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

            B_BigClass destination = new B_BigClass();

            Mapper.Map(source, destination);

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
        public void Map_WhenSourceAndDestinationHaveSameTypeWithCircularReference_ThenDestinationIsCopied()
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

            A_CircularReference destination = new A_CircularReference();

            Mapper.Map(source, destination);

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
        public void Map_WhenSourceAndDestinationHaveDifferentTypeWithCircularReference_ThenDestinationIsCopied()
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

            B_CircularReference destination = new B_CircularReference();

            Mapper.Map(source, destination);

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
    }
}