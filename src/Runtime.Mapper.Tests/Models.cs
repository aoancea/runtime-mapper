using System;
using System.Collections.Generic;

namespace Runtime.Mapper.Tests
{
    internal class BaseClass
    {
        public int Int { get; set; }

        public decimal Decimal { get; set; }

        public string String { get; set; }

        public DateTime DateTime { get; set; }

        public Guid Guid { get; set; }

        public bool Bool { get; set; }

        //public Dictionary<Guid, string> Dictionary { get; set; }

        #region Nullable primitives

        //public int? IntNullable { get; set; }

        //public decimal? DecimalNullable { get; set; }

        //public DateTime DateTimeNullable { get; set; }

        //public Guid? GuidNullable { get; set; }

        //public bool? BoolNullable { get; set; }

        #endregion

        #region Array of primitives
        //public int[] IntArray { get; set; }

        //public decimal[] DecimalArray { get; set; }

        //public string[] StringArray { get; set; }

        //public DateTime[] DateTimeArray { get; set; }

        //public Guid[] GuidArray { get; set; }

        //public bool[] BoolArray { get; set; }
        #endregion

        #region List of primitives
        //public List<int> IntList { get; set; }

        //public List<decimal> DecimalList { get; set; }

        //public List<string> StringList { get; set; }

        //public List<DateTime> DateTimeList { get; set; }

        //public List<Guid> GuidList { get; set; }

        //public List<bool> BoolList { get; set; }
        #endregion
    }

    internal class Cow : BaseClass
    {

    }

    internal class Mule : BaseClass
    {

    }
}