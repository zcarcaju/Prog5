using System;
using System.Collections.Generic;

namespace FP3
{
    /*
    Map: (F<T>, (T -> R)) -> F<R>
    Map pega um functor F<T> e uma função f: T -> R e retorna um F<R> cujo valor interno é o resultado de aplicar a função f para o valor interno de F<T>.
    */

    class Program
    {
        static void Main(string[] args)
        {
            Option<int> number = 2;
            Func<int, int> plusThree = x => x + 3;

            Option<int> result = number.Map(plusThree);

            Console.WriteLine(result);

            Console.ReadKey();
        }
    }

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
        public Option<TResult> Map<TResult>(Func<T, TResult> function)
        {
            Option<TResult> result = function(Value);
            return result;
        }

        public override string ToString() => IsSome ? $"{Value}" : "Option.None";
    }
}
