namespace Runtime.Mapper.Tests
{
    internal class Constants
    {
        public class Bool
        {
            public const bool value1 = true;
            public const bool value2 = false;
        }

        public class DateTime
        {
            public static System.DateTime value1 = new System.DateTime(2010, 01, 02);
            public static System.DateTime value2 = new System.DateTime(2011, 01, 02);
        }

        public class Decimal
        {
            public const decimal value1 = 10.10M;
            public const decimal value2 = 20.20M;
        }

        public class Guid
        {
            public static System.Guid value1 = new System.Guid("8da4c611-a758-4eb7-a352-8d82fe84dbd9");
            public static System.Guid value2 = new System.Guid("46a93cc8-64a0-4d77-9600-4b694e40debf");
            public static System.Guid value3 = new System.Guid("46A93CC8-64A0-4D77-9600-4B694E40DEBF");
        }

        public class Int
        {
            public const int value1 = 123;
            public const int value2 = 234;
        }

        public class String
        {
            public const string value1 = "123";
            public const string value2 = "234";
        }
    }
}