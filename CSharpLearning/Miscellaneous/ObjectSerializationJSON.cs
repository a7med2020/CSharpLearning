using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Text.Json;
 

public class Person
{
    public string Name { get; set; }
    public int Age { get; set; }
}

class Foo
{
    public string Language { get; set; }
    public string Sample { get; set; }
}

public class ObjectSerializationJSON
{
    public static void Execute()
    {

    //With System.Text.Json

        // Serialization
        var person = new Person { Name = "Charlie", Age = 35 };

        // Serialization
        var jsonString = System.Text.Json.JsonSerializer.Serialize(person);
        File.WriteAllText("Files/person.json", jsonString);

        // Deserialization
        var deserializedJsonString = File.ReadAllText("Files/person.json");
        var deserializedPerson = System.Text.Json.JsonSerializer.Deserialize<Person>(deserializedJsonString);
        Console.WriteLine($"{deserializedPerson.Name}, {deserializedPerson.Age}");



       // With Newtonsoft.Json
        List<Foo> foos = new List<Foo>
        {
            new Foo { Language = "Hebrew", Sample = "אספירין" },
            new Foo { Language = "Hindi", Sample = "एस्पिरि" },
            new Foo { Language = "Chinese", Sample = "阿司匹林" },
            new Foo { Language = "Japanese", Sample = "アセチルサリチル酸" },
            new Foo { Language = "Arabic", Sample = "أحمد" },
        };

        var json = JsonConvert.SerializeObject(foos, Formatting.Indented);

        File.WriteAllText("Files/utf8.json", json, Encoding.UTF8);
        File.WriteAllText("Files/default.json", json, Encoding.Default);
    }
}