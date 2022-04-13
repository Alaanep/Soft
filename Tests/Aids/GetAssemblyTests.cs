using System;
using System.Linq;
using System.Reflection;
using ABC.Aids;
using ABC.Data.Party;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace ABC.Tests.Aids;

[TestClass] public class GetAssemblyTests : IsTypeTested
{
    private string? assemblyName;
    private Assembly? assembly;
    private static string[] typeNames= Array.Empty<string>();

    [TestInitialize]
    public void Init() {
        assemblyName = $"{nameof(ABC)}.{nameof(ABC.Aids)}";
        assembly = GetAssembly.ByName(assemblyName);
        typeNames = new string[] { nameof(Chars), nameof(Enums), nameof(Lists), nameof(Strings), nameof(Safe), nameof(Types) };
    }

    [TestCleanup] public void Clean() {
        isNotNull(assembly);
        areEqual(assemblyName, assembly.GetName().Name);
    }

    [TestMethod] public void ByNameTest() { }
    [TestMethod] public void OfTypeTest() {
        assemblyName = $"{nameof(ABC)}.{nameof(ABC.Data)}";
        var obj = new CountryData();
        assembly = GetAssembly.OfType(obj);
    }
    [TestMethod] public void TypesTest() {
        var l = GetAssembly.Types(assembly);
        isTrue(typeNames.Length<=(l?.Count??-1));
        foreach (var n in typeNames) {
            areEqual(l?.FirstOrDefault(x=>x.Name==n)?.Name, n);
        }

        isNull(l?.FirstOrDefault(x => x.Name == GetRandom.String()));
    }
    [TestMethod] public void TypeTest() {
        var n = randomTypeName;
        var obj = GetAssembly.Type(assembly, n);
        isNotNull(obj);
        areEqual(n, obj.Name);
    }

    private string randomTypeName = typeNames[GetRandom.Int32(0, typeNames.Length)];
}