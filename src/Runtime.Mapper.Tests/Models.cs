using System;
using System.Collections.Generic;

namespace Runtime.Mapper.Tests
{
    internal class BaseClass
    {
        #region Primitives - Value

        public int Int { get; set; }

        public decimal Decimal { get; set; }

        public string String { get; set; }

        public DateTime DateTime { get; set; }

        public Guid Guid { get; set; }

        public bool Bool { get; set; }

        public float Float { get; set; }

        public double Double { get; set; }

        #endregion

        #region Primitives - Default

        public int IntDefault { get; set; }

        public decimal DecimalDefault { get; set; }

        public string StringDefault { get; set; }

        public DateTime DateTimeDefault { get; set; }

        public Guid GuidDefault { get; set; }

        public bool BoolDefault { get; set; }

        public float FloatDefault { get; set; }

        public double DoubleDefault { get; set; }

        #endregion

        #region Enums - Value

        public Enumeration Enum { get; set; }

        public Enumeration EnumDefault { get; set; }

        public Enumeration? EnumNullable { get; set; }

        public Enumeration? EnumNullableDefault { get; set; }

        #endregion

        #region Dictionary

        public Dictionary<Guid, int> DictionaryGuidInt { get; set; }

        public Dictionary<Guid, decimal> DictionaryGuidDecimal { get; set; }

        public Dictionary<Guid, string> DictionaryGuidString { get; set; }

        public Dictionary<Guid, DateTime> DictionaryGuidDateTime { get; set; }

        public Dictionary<Guid, Guid> DictionaryGuidGuid { get; set; }

        public Dictionary<Guid, bool> DictionaryGuidBool { get; set; }

        public Dictionary<Guid, float> DictionaryGuidFloat { get; set; }

        public Dictionary<Guid, double> DictionaryGuidDouble { get; set; }

        #endregion

        #region Nullable primitives - Value

        public int? IntNullable { get; set; }

        public decimal? DecimalNullable { get; set; }

        public DateTime? DateTimeNullable { get; set; }

        public Guid? GuidNullable { get; set; }

        public bool? BoolNullable { get; set; }

        public float? FloatNullable { get; set; }

        public double? DoubleNullable { get; set; }

        #endregion

        #region Nullable primitives - Default

        public int? IntNullableDefault { get; set; }

        public decimal? DecimalNullableDefault { get; set; }

        public DateTime? DateTimeNullableDefault { get; set; }

        public Guid? GuidNullableDefault { get; set; }

        public bool? BoolNullableDefault { get; set; }

        public float? FloatNullableDefault { get; set; }

        public double? DoubleNullableDefault { get; set; }

        #endregion

        #region Array of primitives
        public int[] IntArray { get; set; }

        public decimal[] DecimalArray { get; set; }

        public string[] StringArray { get; set; }

        public DateTime[] DateTimeArray { get; set; }

        public Guid[] GuidArray { get; set; }

        public bool[] BoolArray { get; set; }

        public float[] FloatArray { get; set; }

        public double[] DoubleArray { get; set; }
        #endregion

        #region List of primitives
        public List<int> IntList { get; set; }

        public List<decimal> DecimalList { get; set; }

        public List<string> StringList { get; set; }

        public List<DateTime> DateTimeList { get; set; }

        public List<Guid> GuidList { get; set; }

        public List<bool> BoolList { get; set; }

        public List<float> FloatList { get; set; }

        public List<double> DoubleList { get; set; }
        #endregion

        #region Objects
        public object Object1 { get; set; }

        public object Object2 { get; set; }

        public object Object3 { get; set; }

        public object[] ObjectArray { get; set; }

        public List<object> ObjectList { get; set; }
        #endregion
    }

    internal class Cow : BaseClass
    {

    }

    internal class Mule : BaseClass
    {

    }

    public enum Enumeration
    {
        One = 0,
        Two = 1,
        Three = 2
    }

    internal interface IInterface
    {

    }

    internal abstract class AbstractClass : IInterface
    {

    }

    internal class Parent : AbstractClass, IInterface
    {
        public int Prop1 { get; set; }

        public Dictionary<Guid, string> Prop2 { get; set; }
    }

    internal class Child1 : Parent
    {
        public decimal Prop3 { get; set; }
    }

    #region A
    internal class A_BigClass : BaseClass
    {
        public A_FirstClass FirstClass { get; set; }

        public A_SecondClass SecondClass { get; set; }
    }

    internal class A_FirstClass : BaseClass
    {
        public A_FirstClassFirstSubClass FirstClassFirstSubClass { get; set; }

        public A_FirstClassSecondSubClass FirstClassSecondSubClass { get; set; }
    }

    internal class A_FirstClassFirstSubClass : BaseClass
    {

    }

    internal class A_FirstClassSecondSubClass : BaseClass
    {

    }

    internal class A_SecondClass : BaseClass
    {
        public A_SecondClassFirstSubClass SecondClassFirstSubClass { get; set; }

        public A_SecondClassSecondSubClass SecondClassSecondSubClass { get; set; }
    }

    internal class A_SecondClassFirstSubClass : BaseClass
    {

    }

    internal class A_SecondClassSecondSubClass : BaseClass
    {

    }

    internal class A_CircularReference : BaseClass
    {
        public A_CircularReference CircularReferenceProperty { get; set; }
    }

    internal enum A_Enumeration
    {
        One = 0,
        Two = 1,
        Three = 2
    }

    internal class A_ClassWithDictionary
    {
        public Dictionary<string, string> Prop1 { get; set; }

        public Dictionary<Guid, string> Prop2 { get; set; }

        public Dictionary<Guid, Cow> Prop3 { get; set; }
    }
    #endregion

    #region B
    internal class B_BigClass : BaseClass
    {
        public B_FirstClass FirstClass { get; set; }

        public B_SecondClass SecondClass { get; set; }
    }

    internal class B_FirstClass : BaseClass
    {
        public B_FirstClassFirstSubClass FirstClassFirstSubClass { get; set; }

        public B_FirstClassSecondSubClass FirstClassSecondSubClass { get; set; }
    }

    internal class B_FirstClassFirstSubClass : BaseClass
    {

    }

    internal class B_FirstClassSecondSubClass : BaseClass
    {

    }

    internal class B_SecondClass : BaseClass
    {
        public B_SecondClassFirstSubClass SecondClassFirstSubClass { get; set; }

        public B_SecondClassSecondSubClass SecondClassSecondSubClass { get; set; }
    }

    internal class B_SecondClassFirstSubClass : BaseClass
    {

    }

    internal class B_SecondClassSecondSubClass : BaseClass
    {

    }

    internal class B_CircularReference : BaseClass
    {
        public B_CircularReference CircularReferenceProperty { get; set; }
    }

    internal enum B_Enumeration
    {
        One = 0,
        Two = 1,
        Three = 2
    }

    internal class B_ClassWithDictionary
    {
        public Dictionary<string, string> Prop1 { get; set; }

        public Dictionary<Guid, string> Prop2 { get; set; }

        public Dictionary<Guid, Mule> Prop3 { get; set; }
    }

    #endregion
}