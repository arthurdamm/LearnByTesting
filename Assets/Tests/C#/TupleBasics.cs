using System; // "Type" type
using NUnit.Framework;
using UnityEngine;
using Random = System.Random;

namespace LearnByTesting
{
    public class TupleBasics
    {
        [Test]
        public void Tuple_DefaultFields_Usage()
        {
            (int, string) tuple = (42, "foo");
            Assert.That(tuple.Item1, Is.EqualTo(42));
            Assert.That(tuple.Item2, Is.EqualTo("foo"));
        }
        
        [Test]
        public void Tuple_NamedFields_Usage()
        {
            (int id, string name) tuple = (42, "foo");
            Assert.That(tuple.Item1, Is.EqualTo(42));
            Assert.That(tuple.Item2, Is.EqualTo("foo"));
            Assert.That(tuple.id, Is.EqualTo(42));
            Assert.That(tuple.name, Is.EqualTo("foo"));
        }

        [Test]
        public void Tuple_ToString()
        {
            (int, string) tuple = (42, "foo");
            Assert.That(tuple.ToString(), Is.EqualTo("(42, foo)"));
            Assert.That(tuple.ToString(), Is.EqualTo($"({tuple.Item1}, {tuple.Item2})"));
        }

        [Test]
        public void Tuple_GetType()
        {
            (int, string) tuple = (42, "foo");
            var equalTuple = (13, "bar");
            Type tupleType = typeof(ValueTuple<int, string>);
            Assert.That(tuple.GetType(), Is.EqualTo(equalTuple.GetType()));
            Assert.That(tuple.GetType(), Is.EqualTo(tupleType));
        }

        [Test]
        public void Tuple_Equality()
        {
            (int, string) tuple = (42, "foo");
            (int, string) equalTuple = (42, "foo");
            (int, string) unequalTuple = (42, "bar");
            Assert.That(tuple == equalTuple, Is.True);
            Assert.That(tuple != unequalTuple, Is.True);
            Assert.That(tuple, Is.EqualTo(equalTuple));
            Assert.That(tuple, Is.Not.EqualTo(unequalTuple));
        }

        [Test]
        public void Tuple_Destructuring()
        {
            (int id, string name) tuple = (13, "foo");
            (int id, string name) = tuple;
            Assert.That(id, Is.EqualTo(tuple.id));
            Assert.That(name, Is.EqualTo(tuple.name));

        }

        [Test]
        public void Tuple_ArbitrarilyLarge()
        {
            var t = (1, 2, 3, 4, 5, 6, 7, 8, 9, 10,
                    11, 12, 13, 14, 15, 16, 17, 18,
                    19, 20, 21, 22, 23, 24, 25, 26);
            Assert.That(t.Item26, Is.EqualTo(26));
        }

        [Test]
        public void Tuple_ReturnType()
        {
            (float, string) innerFunc()
            {
                return (3.14f, "pi");
            }

            var t = innerFunc();
            Assert.That(t.Item1, Is.EqualTo(3.14f).Within(1e-6));
            Assert.That(t.Item2, Is.EqualTo("pi"));
        }
    }
}
