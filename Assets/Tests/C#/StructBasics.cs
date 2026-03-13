using NUnit.Framework;
using UnityEngine;
// using UnityEngine.TestTools;



namespace LearnByTesting
{
public class StructBasics
{
    struct BasicStruct
    {
        public int Id;
        public string Name;
    };
    
    [Test]
    public void Struct_BasicDeclaration()
    {
        BasicStruct s;
        s.Id = 5;
        Assert.That(s.Id, Is.EqualTo(5));
    }

    struct BasicStructConstructor
    {
        public int Id;
        public string Name;

        public BasicStructConstructor(int id, string name)
        {
            Id = id;
            Name = name;
        }
    };

    [Test]
    public void Struct_ValueType_DoesntChange()
    {
        BasicStructConstructor s1 = new BasicStructConstructor(5, "bob");
        BasicStructConstructor s2 = s1;
        s1.Id = 6;
        Assert.That(s1.Id, Is.Not.EqualTo(s2.Id));
        Assert.That(s1.Name, Is.EqualTo(s2.Name));
    }
    
    [Test]
    public void Struct_ToString()
    {
        BasicStructConstructor s = new(3, "jane");
        Assert.That(s.Name, Is.EqualTo("jane"));
        string namespaceStr = "LearnByTesting";
        string classStr = "StructBasics";
        string structStr = "BasicStructConstructor";
        Assert.That(s.ToString(), Is.EqualTo($"{namespaceStr}.{classStr}+{structStr}"));
    }
}
}
