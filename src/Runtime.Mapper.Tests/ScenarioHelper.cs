using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Runtime.Mapper.Tests
{
    internal class ScenarioHelper
    {
        public static Cow Create_Cow()
        {
            return new Cow()
            {
                // Primitives - Value
                Bool = Constants.Bool.value1,
                DateTime = Constants.DateTime.value1,
                Decimal = Constants.Decimal.value1,
                Guid = Constants.Guid.value1,
                Int = Constants.Int.value1,
                String = Constants.String.value1,
                Float = Constants.Float.value1,
                Double = Constants.Double.value1,

                // Primitives - Default
                BoolDefault = default(bool),
                DateTimeDefault = default(DateTime),
                DecimalDefault = default(decimal),
                GuidDefault = default(Guid),
                IntDefault = default(int),
                StringDefault = default(string),
                FloatDefault = default(float),
                DoubleDefault = default(double),

                //Enums - Value
                Enum = Enumeration.Three,
                EnumDefault = default(Enumeration),
                EnumNullable = Enumeration.Two,
                //EnumNullableDefault = default(Enumeration),

                // Dictionary
                DictionaryGuidInt = new Dictionary<Guid, int>() { { Constants.Guid.value3, Constants.Int.value1 } },
                DictionaryGuidDecimal = new Dictionary<Guid, decimal>() { { Constants.Guid.value3, Constants.Decimal.value1 } },
                DictionaryGuidString = new Dictionary<Guid, string>() { { Constants.Guid.value3, Constants.String.value1 } },
                DictionaryGuidDateTime = new Dictionary<Guid, DateTime>() { { Constants.Guid.value3, Constants.DateTime.value1 } },
                DictionaryGuidGuid = new Dictionary<Guid, Guid>() { { Constants.Guid.value3, Constants.Guid.value1 } },
                DictionaryGuidBool = new Dictionary<Guid, bool>() { { Constants.Guid.value3, Constants.Bool.value1 } },
                // TODO: add dictionary scenario for Float and Double

                // Nullable primitives - Value
                BoolNullable = Constants.Bool.value1,
                DateTimeNullable = Constants.DateTime.value1,
                DecimalNullable = Constants.Decimal.value1,
                GuidNullable = Constants.Guid.value1,
                IntNullable = Constants.Int.value1,
                FloatNullable = Constants.Float.value1,
                DoubleNullable = Constants.Double.value1,

                // Nullable primitives - Null
                BoolNullableDefault = default(bool?),
                DateTimeNullableDefault = default(DateTime?),
                DecimalNullableDefault = default(decimal?),
                GuidNullableDefault = default(Guid?),
                IntNullableDefault = default(int?),
                FloatNullableDefault = default(float?),
                DoubleNullableDefault = default(double?),

                // Array of primitives
                BoolArray = new bool[] { Constants.Bool.value1, Constants.Bool.value2 },
                DateTimeArray = new DateTime[] { Constants.DateTime.value1, Constants.DateTime.value2 },
                DecimalArray = new decimal[] { Constants.Decimal.value1, Constants.Decimal.value2 },
                GuidArray = new Guid[] { Constants.Guid.value1, Constants.Guid.value2 },
                IntArray = new int[] { Constants.Int.value1, Constants.Int.value2 },
                StringArray = new string[] { Constants.String.value1, Constants.String.value2 },
                FloatArray = new float[] { Constants.Float.value1, Constants.Float.value2 },
                DoubleArray = new double[] { Constants.Double.value1, Constants.Double.value2 },

                // List of primitives
                BoolList = new List<bool>() { Constants.Bool.value1, Constants.Bool.value2 },
                DateTimeList = new List<DateTime>() { Constants.DateTime.value1, Constants.DateTime.value2 },
                DecimalList = new List<decimal>() { Constants.Decimal.value1, Constants.Decimal.value2 },
                GuidList = new List<Guid>() { Constants.Guid.value1, Constants.Guid.value2 },
                IntList = new List<int>() { Constants.Int.value1, Constants.Int.value2 },
                StringList = new List<string>() { Constants.String.value1, Constants.String.value2 },
                FloatList = new List<float>() { Constants.Float.value1, Constants.Float.value2 },
                DoubleList = new List<double>() { Constants.Double.value1, Constants.Double.value2 },

                // Objects
                Object1 = Constants.String.value1,
                Object2 = Enumeration.Two,
                Object3 = CreateA_BigClass(),
                ObjectArray = new object[5] { Constants.String.value1, Constants.DateTime.value2, Constants.Bool.value2, CreateA_BigClass(), Enumeration.Two },
                ObjectList = new List<object>() { Enumeration.Two, Constants.DateTime.value2, Constants.Bool.value2, Constants.String.value1, CreateA_BigClass() }
            };
        }

        public static void Assert_Cow(BaseClass source, Cow destination)
        {
            Assert_BaseClass(source, destination);
        }

        public static void Assert_Mule(BaseClass source, Mule destination)
        {
            Assert_BaseClass(source, destination);
        }


        private static void Assert_BaseClass(BaseClass source, BaseClass destination)
        {
            // Primitives - Value
            Assert.AreEqual(Constants.Bool.value1, destination.Bool);
            Assert.AreEqual(Constants.DateTime.value1, destination.DateTime);
            Assert.AreEqual(Constants.Decimal.value1, destination.Decimal);
            Assert.AreEqual(Constants.Guid.value1, destination.Guid);
            Assert.AreEqual(Constants.Int.value1, destination.Int);
            Assert.AreEqual(Constants.String.value1, destination.String);
            Assert.AreEqual(Constants.Float.value1, destination.Float);
            Assert.AreEqual(Constants.Double.value1, destination.Double);

            // Primitives - Default
            Assert.AreEqual(false, destination.BoolDefault);
            Assert.AreEqual(DateTime.MinValue, destination.DateTimeDefault);
            Assert.AreEqual(decimal.Zero, destination.DecimalDefault);
            Assert.AreEqual(Guid.Empty, destination.GuidDefault);
            Assert.AreEqual(0, destination.IntDefault);
            Assert.AreEqual(null, destination.StringDefault);
            Assert.AreEqual(0f, destination.FloatDefault);
            Assert.AreEqual(0d, destination.DoubleDefault);

            //Enums - Value
            Assert.AreEqual(Enumeration.Three, destination.Enum);
            Assert.AreEqual(Enumeration.One, destination.EnumDefault);

            Assert.AreEqual(Enumeration.Two, destination.EnumNullable);
            Assert.AreEqual(null, destination.EnumNullableDefault);

            // Dictionary
            Assert.AreNotEqual(source.DictionaryGuidInt, destination.DictionaryGuidInt);
            Assert.AreEqual(Constants.Int.value1, destination.DictionaryGuidInt[Constants.Guid.value3]);

            Assert.AreNotEqual(source.DictionaryGuidDecimal, destination.DictionaryGuidDecimal);
            Assert.AreEqual(Constants.Decimal.value1, destination.DictionaryGuidDecimal[Constants.Guid.value3]);

            Assert.AreNotEqual(source.DictionaryGuidString, destination.DictionaryGuidString);
            Assert.AreEqual(Constants.String.value1, destination.DictionaryGuidString[Constants.Guid.value3]);

            Assert.AreNotEqual(source.DictionaryGuidDateTime, destination.DictionaryGuidDateTime);
            Assert.AreEqual(Constants.DateTime.value1, destination.DictionaryGuidDateTime[Constants.Guid.value3]);

            Assert.AreNotEqual(source.DictionaryGuidGuid, destination.DictionaryGuidGuid);
            Assert.AreEqual(Constants.Guid.value1, destination.DictionaryGuidGuid[Constants.Guid.value3]);

            Assert.AreNotEqual(source.DictionaryGuidBool, destination.DictionaryGuidBool);
            Assert.AreEqual(Constants.Bool.value1, destination.DictionaryGuidBool[Constants.Guid.value3]);

            // Nullable primitives - Value
            Assert.AreEqual(Constants.Bool.value1, destination.BoolNullable);
            Assert.AreEqual(Constants.DateTime.value1, destination.DateTimeNullable);
            Assert.AreEqual(Constants.Decimal.value1, destination.DecimalNullable);
            Assert.AreEqual(Constants.Guid.value1, destination.GuidNullable);
            Assert.AreEqual(Constants.Int.value1, destination.IntNullable);
            Assert.AreEqual(Constants.Float.value1, destination.FloatNullable);
            Assert.AreEqual(Constants.Double.value1, destination.DoubleNullable);

            // Nullable primitives - Null
            Assert.AreEqual(null, destination.BoolNullableDefault);
            Assert.AreEqual(null, destination.DateTimeNullableDefault);
            Assert.AreEqual(null, destination.DecimalNullableDefault);
            Assert.AreEqual(null, destination.GuidNullableDefault);
            Assert.AreEqual(null, destination.IntNullableDefault);
            Assert.AreEqual(null, destination.FloatNullableDefault);
            Assert.AreEqual(null, destination.DoubleNullableDefault);

            // Array of primitives
            Assert.AreNotEqual(source.BoolArray, destination.BoolArray);
            Assert.AreEqual(Constants.Bool.value1, destination.BoolArray[0]);
            Assert.AreEqual(Constants.Bool.value2, destination.BoolArray[1]);

            Assert.AreNotEqual(source.DateTimeArray, destination.DateTimeArray);
            Assert.AreEqual(Constants.DateTime.value1, destination.DateTimeArray[0]);
            Assert.AreEqual(Constants.DateTime.value2, destination.DateTimeArray[1]);

            Assert.AreNotEqual(source.DecimalArray, destination.DecimalArray);
            Assert.AreEqual(Constants.Decimal.value1, destination.DecimalArray[0]);
            Assert.AreEqual(Constants.Decimal.value2, destination.DecimalArray[1]);

            Assert.AreNotEqual(source.GuidArray, destination.GuidArray);
            Assert.AreEqual(Constants.Guid.value1, destination.GuidArray[0]);
            Assert.AreEqual(Constants.Guid.value2, destination.GuidArray[1]);

            Assert.AreNotEqual(source.IntArray, destination.IntArray);
            Assert.AreEqual(Constants.Int.value1, destination.IntArray[0]);
            Assert.AreEqual(Constants.Int.value2, destination.IntArray[1]);

            Assert.AreNotEqual(source.StringArray, destination.StringArray);
            Assert.AreEqual(Constants.String.value1, destination.StringArray[0]);
            Assert.AreEqual(Constants.String.value2, destination.StringArray[1]);

            Assert.AreNotEqual(source.FloatArray, destination.FloatArray);
            Assert.AreEqual(Constants.Float.value1, destination.FloatArray[0]);
            Assert.AreEqual(Constants.Float.value2, destination.FloatArray[1]);

            Assert.AreNotEqual(source.DoubleArray, destination.DoubleArray);
            Assert.AreEqual(Constants.Double.value1, destination.DoubleArray[0]);
            Assert.AreEqual(Constants.Double.value2, destination.DoubleArray[1]);

            // List of primitives
            Assert.AreNotEqual(source.BoolList, destination.BoolList);
            Assert.AreEqual(Constants.Bool.value1, destination.BoolList[0]);
            Assert.AreEqual(Constants.Bool.value2, destination.BoolList[1]);

            Assert.AreNotEqual(source.DateTimeList, destination.DateTimeList);
            Assert.AreEqual(Constants.DateTime.value1, destination.DateTimeList[0]);
            Assert.AreEqual(Constants.DateTime.value2, destination.DateTimeList[1]);

            Assert.AreNotEqual(source.DecimalList, destination.DecimalList);
            Assert.AreEqual(Constants.Decimal.value1, destination.DecimalList[0]);
            Assert.AreEqual(Constants.Decimal.value2, destination.DecimalList[1]);

            Assert.AreNotEqual(source.GuidList, destination.GuidList);
            Assert.AreEqual(Constants.Guid.value1, destination.GuidList[0]);
            Assert.AreEqual(Constants.Guid.value2, destination.GuidList[1]);

            Assert.AreNotEqual(source.IntList, destination.IntList);
            Assert.AreEqual(Constants.Int.value1, destination.IntList[0]);
            Assert.AreEqual(Constants.Int.value2, destination.IntList[1]);

            Assert.AreNotEqual(source.StringList, destination.StringList);
            Assert.AreEqual(Constants.String.value1, destination.StringList[0]);
            Assert.AreEqual(Constants.String.value2, destination.StringList[1]);

            Assert.AreNotEqual(source.FloatList, destination.FloatList);
            Assert.AreEqual(Constants.Float.value1, destination.FloatList[0]);
            Assert.AreEqual(Constants.Float.value2, destination.FloatList[1]);

            Assert.AreNotEqual(source.DoubleList, destination.DoubleList);
            Assert.AreEqual(Constants.Double.value1, destination.DoubleList[0]);
            Assert.AreEqual(Constants.Double.value2, destination.DoubleList[1]);

            // Objects


            Assert.AreEqual(Constants.String.value1, destination.Object1);
            Assert.AreEqual(Enumeration.Two, destination.Object2);

            Assert_A_BigClass((A_BigClass)source.Object3, (A_BigClass)destination.Object3);

            Assert.AreNotEqual(source.ObjectArray, destination.ObjectArray);
            Assert.AreEqual(Constants.String.value1, destination.ObjectArray[0]);
            Assert.AreEqual(Constants.DateTime.value2, destination.ObjectArray[1]);
            Assert.AreEqual(Constants.Bool.value2, destination.ObjectArray[2]);
            Assert_A_BigClass((A_BigClass)source.ObjectArray[3], (A_BigClass)destination.ObjectArray[3]);
            Assert.AreEqual(Enumeration.Two, destination.ObjectArray[4]);

            Assert.AreNotEqual(source.ObjectList, destination.ObjectList);
            Assert.AreEqual(Enumeration.Two, destination.ObjectList[0]);
            Assert.AreEqual(Constants.DateTime.value2, destination.ObjectList[1]);
            Assert.AreEqual(Constants.Bool.value2, destination.ObjectList[2]);
            Assert.AreEqual(Constants.String.value1, destination.ObjectList[3]);
            Assert_A_BigClass((A_BigClass)source.ObjectList[4], (A_BigClass)destination.ObjectList[4]);
        }

        public static A_BigClass CreateA_BigClass()
        {
            return new A_BigClass()
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
        }

        public static void Assert_A_BigClass(A_BigClass source, A_BigClass destination)
        {
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
    }
}