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

                // Primitives - Default
                BoolDefault = default(bool),
                DateTimeDefault = default(DateTime),
                DecimalDefault = default(decimal),
                GuidDefault = default(Guid),
                IntDefault = default(int),
                StringDefault = default(string),

                //Dictionary = new Dictionary<Guid, string>() { { Constants.Guid.value3, "value1" } },

                // Nullable primitives - Value
                BoolNullable = Constants.Bool.value1,
                DateTimeNullable = Constants.DateTime.value1,
                DecimalNullable = Constants.Decimal.value1,
                GuidNullable = Constants.Guid.value1,
                IntNullable = Constants.Int.value1,

                // Nullable primitives - Null
                BoolNullableDefault = default(bool?),
                DateTimeNullableDefault = default(DateTime?),
                DecimalNullableDefault = default(decimal?),
                GuidNullableDefault = default(Guid?),
                IntNullableDefault = default(int?),

                // Array of primitives
                BoolArray = new bool[] { Constants.Bool.value1, Constants.Bool.value2 },
                DateTimeArray = new DateTime[] { Constants.DateTime.value1, Constants.DateTime.value2 },
                DecimalArray = new decimal[] { Constants.Decimal.value1, Constants.Decimal.value2 },
                GuidArray = new Guid[] { Constants.Guid.value1, Constants.Guid.value2 },
                IntArray = new int[] { Constants.Int.value1, Constants.Int.value2 },
                StringArray = new string[] { Constants.String.value1, Constants.String.value2 },

                // List of primitives
                BoolList = new List<bool>() { Constants.Bool.value1, Constants.Bool.value2 },
                DateTimeList = new List<DateTime>() { Constants.DateTime.value1, Constants.DateTime.value2 },
                DecimalList = new List<decimal>() { Constants.Decimal.value1, Constants.Decimal.value2 },
                GuidList = new List<Guid>() { Constants.Guid.value1, Constants.Guid.value2 },
                IntList = new List<int>() { Constants.Int.value1, Constants.Int.value2 },
                StringList = new List<string>() { Constants.String.value1, Constants.String.value2 }
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

            // Primitives - Default
            Assert.AreEqual(false, destination.BoolDefault);
            Assert.AreEqual(DateTime.MinValue, destination.DateTimeDefault);
            Assert.AreEqual(decimal.Zero, destination.DecimalDefault);
            Assert.AreEqual(Guid.Empty, destination.GuidDefault);
            Assert.AreEqual(0, destination.IntDefault);
            Assert.AreEqual(null, destination.StringDefault);

            //Assert.AreEqual("value1", baseClass.Dictionary[Constants.Guid.value3]);

            // Nullable primitives - Value
            Assert.AreEqual(Constants.Bool.value1, destination.BoolNullable);
            Assert.AreEqual(Constants.DateTime.value1, destination.DateTimeNullable);
            Assert.AreEqual(Constants.Decimal.value1, destination.DecimalNullable);
            Assert.AreEqual(Constants.Guid.value1, destination.GuidNullable);
            Assert.AreEqual(Constants.Int.value1, destination.IntNullable);

            // Nullable primitives - Null
            Assert.AreEqual(null, destination.BoolNullableDefault);
            Assert.AreEqual(null, destination.DateTimeNullableDefault);
            Assert.AreEqual(null, destination.DecimalNullableDefault);
            Assert.AreEqual(null, destination.GuidNullableDefault);
            Assert.AreEqual(null, destination.IntNullableDefault);

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
        }
    }
}
