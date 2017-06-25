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
                Bool = Constants.Bool.value1,
                DateTime = Constants.DateTime.value1,
                Decimal = Constants.Decimal.value1,
                Guid = Constants.Guid.value1,
                Int = Constants.Int.value1,
                String = Constants.String.value1,
                //Dictionary = new Dictionary<Guid, string>() { { Constants.Guid.value3, "value1" } },

                // Nullable primitives
                //BoolNullable = Constants.Bool.value1,
                //DateTimeNullable = Constants.DateTime.value1,
                //DecimalNullable = Constants.Decimal.value1,
                //GuidNullable = Constants.Guid.value1,
                //IntNullable = Constants.Int.value1,

                // Array of primitives
                //BoolArray = new bool[] { Constants.Bool.value1, Constants.Bool.value2 },
                //DateTimeArray = new DateTime[] { Constants.DateTime.value1, Constants.DateTime.value2 },
                //DecimalArray = new decimal[] { Constants.Decimal.value1, Constants.Decimal.value2 },
                //GuidArray = new Guid[] { Constants.Guid.value1, Constants.Guid.value2 },
                //IntArray = new int[] { Constants.Int.value1, Constants.Int.value2 },
                //StringArray = new string[] { Constants.String.value1, Constants.String.value2 },

                // List of primitives
                //BoolList = new List<bool>() { Constants.Bool.value1, Constants.Bool.value2 },
                //DateTimeList = new List<DateTime>() { Constants.DateTime.value1, Constants.DateTime.value2 },
                //DecimalList = new List<decimal>() { Constants.Decimal.value1, Constants.Decimal.value2 },
                //GuidList = new List<Guid>() { Constants.Guid.value1, Constants.Guid.value2 },
                //IntList = new List<int>() { Constants.Int.value1, Constants.Int.value2 },
                //StringList = new List<string>() { Constants.String.value1, Constants.String.value2 }
            };
        }

        public static void Assert_Cow(Cow cow)
        {
            Assert_BaseClass(cow);
        }

        public static void Assert_Mule(Mule mule)
        {
            Assert_BaseClass(mule);
        }


        private static void Assert_BaseClass(BaseClass baseClass)
        {
            Assert.AreEqual(Constants.Bool.value1, baseClass.Bool);
            Assert.AreEqual(Constants.DateTime.value1, baseClass.DateTime);
            Assert.AreEqual(Constants.Decimal.value1, baseClass.Decimal);
            Assert.AreEqual(Constants.Guid.value1, baseClass.Guid);
            Assert.AreEqual(Constants.Int.value1, baseClass.Int);
            Assert.AreEqual(Constants.String.value1, baseClass.String);
            //Assert.AreEqual("value1", baseClass.Dictionary[Constants.Guid.value3]);

            // Nullable primitives
            //Assert.AreEqual(Constants.Bool.value1, baseClass.BoolNullable);
            //Assert.AreEqual(Constants.DateTime.value1, baseClass.DateTimeNullable);
            //Assert.AreEqual(Constants.Decimal.value1, baseClass.DecimalNullable);
            //Assert.AreEqual(Constants.Guid.value1, baseClass.GuidNullable);
            //Assert.AreEqual(Constants.Int.value1, baseClass.IntNullable);

            // Array of primitives
            //Assert.AreEqual(Constants.Bool.value1, baseClass.BoolArray[0]);
            //Assert.AreEqual(Constants.Bool.value2, baseClass.BoolArray[1]);
            //Assert.AreEqual(Constants.DateTime.value1, baseClass.DateTimeArray[0]);
            //Assert.AreEqual(Constants.DateTime.value2, baseClass.DateTimeArray[1]);
            //Assert.AreEqual(Constants.Decimal.value1, baseClass.DecimalArray[0]);
            //Assert.AreEqual(Constants.Decimal.value2, baseClass.DecimalArray[1]);
            //Assert.AreEqual(Constants.Guid.value1, baseClass.GuidArray[0]);
            //Assert.AreEqual(Constants.Guid.value2, baseClass.GuidArray[1]);
            //Assert.AreEqual(Constants.Int.value1, baseClass.IntArray[0]);
            //Assert.AreEqual(Constants.Int.value2, baseClass.IntArray[1]);
            //Assert.AreEqual(Constants.String.value1, baseClass.StringArray[0]);
            //Assert.AreEqual(Constants.String.value2, baseClass.StringArray[1]);

            // List of primitives
            //Assert.AreEqual(Constants.Bool.value1, baseClass.BoolList[0]);
            //Assert.AreEqual(Constants.Bool.value2, baseClass.BoolList[1]);
            //Assert.AreEqual(Constants.DateTime.value1, baseClass.DateTimeList[0]);
            //Assert.AreEqual(Constants.DateTime.value2, baseClass.DateTimeList[1]);
            //Assert.AreEqual(Constants.Decimal.value1, baseClass.DecimalList[0]);
            //Assert.AreEqual(Constants.Decimal.value2, baseClass.DecimalList[1]);
            //Assert.AreEqual(Constants.Guid.value1, baseClass.GuidList[0]);
            //Assert.AreEqual(Constants.Guid.value2, baseClass.GuidList[1]);
            //Assert.AreEqual(Constants.Int.value1, baseClass.IntList[0]);
            //Assert.AreEqual(Constants.Int.value2, baseClass.IntList[1]);
            //Assert.AreEqual(Constants.String.value1, baseClass.StringList[0]);
            //Assert.AreEqual(Constants.String.value2, baseClass.StringList[1]);
        }
    }
}
