using System;
using System.Linq;
using System.Collections.Generic;
using System.Collections;

namespace Isaque_FP2
{
    public static class FP
    {
        public static None None => None.Value;

        public static Option<T> Some<T>(T value) => new Some<T>(value);


    }
    public struct None
    {
        public static readonly None Value = new None();
    }

    public struct Some<T>
    {
        public T Value { get; }
        public Some(T value)
        {
            if (value == null) throw new ArgumentException();
            Value = value;
        }
    }

    public struct Option<T>
    {
        readonly T Value;
        readonly bool IsSome;

        private Option(T value)
        {
            Value = value;
            IsSome = true;
        }
        public static implicit operator Option<T>(None _) => new Option<T>();
        public static implicit operator Option<T>(Some<T> some) => new Option<T>(some.Value);
        public static implicit operator Option<T>(T value) => value == null ? FP.None : FP.Some(value);

        public TResult Match<TResult>(Func<TResult> None, Func<T, TResult> Some) => IsSome ? Some(Value) : None();

        public override string ToString() => IsSome ? $"{Value}" : "Option.None";
    }

    class Program
    {

        enum Words { Paralelepípedo, Parar, Google};

        public static string StringName(Option<string> name)
        {
            string matchString = name.Match
            (
                None: () => "Hello, World!",
                Some: (value) => "Hello, " + value + "!"
            );

            return matchString;
        }

        public static void Main(string[] Args)
        {
            string test1Method1 = "Chá", test2Method1 = "Espingarda", test3Method1 = "Google";
            Option<Words> resultTest1Method1 = test1Method1.OpEnum<Words>(), resultTest2Method1 = test2Method1.OpEnum<Words>(), resultTest3Method1 = test3Method1.OpEnum<Words>();
            Console.WriteLine(resultTest1Method1);
            Console.WriteLine(resultTest2Method1);
            Console.WriteLine(resultTest3Method1);

            string test1Method2 = "Bolsominion", test2Method2 = "17";
            Option<int> resultTest1Method2 = test1Method2.ConvertStringToInt(), resultTest2Method2 = test2Method2.ConvertStringToInt();
            Console.WriteLine(resultTest1Method2);
            Console.WriteLine(resultTest2Method2);

            Option<string> test1Method3 = FP.None, test2Method3 = "Roberto";
            string resultTest1Method3 = StringName(test1Method3), resultTest2Method3 = StringName(test2Method3);
            Console.WriteLine(resultTest1Method3);
            Console.WriteLine(resultTest2Method3);

            Console.ReadKey();
        }
    }

    public static class Extensions
    {
        public static Option<T> OpEnum<T>(this String s) where T : struct
        {
            T tryEnum;
            bool tryParse = Enum.TryParse(s, out tryEnum);

            Option<T> myEnum = tryParse ? tryEnum : (Option<T>)FP.None;

            return myEnum;
        }

        public static Option<int> ConvertStringToInt (this String s)
        {
            int tryResult;
            bool tryParse = int.TryParse(s, out tryResult);

            Option<int> myInt = tryParse ? tryResult : (Option<int>)FP.None;

            return myInt;
        }
    }
}