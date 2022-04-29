using Json.Models;
using NUnit.Framework;
using System;
using Micro = System.Text.Json;
using Newton = Newtonsoft.Json;

namespace Json.Tests;

public class NewtonsoftVsSystemTests
{
    private static Monster monster => new()
    {
        Name = "Harry",
        Type = "Wyvern",
        Legs = 2,
        Code = "123",
        Birthday = new DateTime(2003, 01, 22)
    };

    private readonly string _microSerializedMonster;
    private readonly string _newtonSerializedMonster;

    public NewtonsoftVsSystemTests()
    {
        _microSerializedMonster = Micro.JsonSerializer.Serialize(monster);
        _newtonSerializedMonster = Newton.JsonConvert.SerializeObject(monster);
    }

    [Test]
    public void WhenSerializing_ItShouldBeEqual()
    {
        Console.WriteLine(_microSerializedMonster);
        Console.WriteLine(_newtonSerializedMonster);

        Assert.AreEqual(_microSerializedMonster, _newtonSerializedMonster);
    }

    [Test]
    public void WhenDeserializing_ItShouldBeDifferent() // WIP !!!
    {
        var microDeserializedMonster = (Monster?)Micro.JsonSerializer.Deserialize(_microSerializedMonster, typeof(Monster));
        var newtonDeserializedMonster = Newton.JsonConvert.DeserializeObject<Monster>(_newtonSerializedMonster);

        Console.WriteLine(microDeserializedMonster);
        Console.WriteLine(newtonDeserializedMonster);

        Assert.AreNotEqual(microDeserializedMonster, newtonDeserializedMonster);
    }
}
