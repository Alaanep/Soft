using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Reflection;
using System.Reflection.Metadata;
using ABC.Aids;

namespace ABC.Tests {
    public  abstract class AssemblyTests: TestAsserts
    {   
        private static string testsStr =>"Tests";
        private string notTestedMsg => $"Class \"{fullNameOfFirstNotTested()}\" is not tested";
        private static string testProjectStr => $"{testsStr}.";
        private Assembly? testingAssembly;
        private Assembly? assemblyToBeTested;
        private List<Type>? testingTypes;
        private List<Type>? typesToBeTested;
        private string? namespaceOfTest;
        private string? namespaceOfType;

        [TestMethod] public void IsAllTested() => isAllTested();

        protected virtual  void isAllTested() {
            testingAssembly = getAssembly(this);
            testingTypes = getTypes(testingAssembly);
            namespaceOfTest = getNameSpace(this);
            removeNotInNamespace(testingTypes, namespaceOfTest);
            removeNotClassTests();
            removeNotCorrectTests();
            namespaceOfType = removeTestsTagForm(namespaceOfTest);
            assemblyToBeTested = getAssembly(namespaceOfType);
            typesToBeTested = getTypes(assemblyToBeTested);
            removeNotInNamespace(typesToBeTested, namespaceOfType);
            removeInterfaces();
            removeNotNeedTesting();
            removeDublications();
            removeTested();
            if (allAreTested()) return;
            reportNotAllIsTested();
        }

        private void removeDublications() =>typesToBeTested?.Find(x => isItDublicated(x));

        private bool isItDublicated(Type x) {
            var t = typesToBeTested?.Find(y => isDublicated(y, x));
            if (t is null) return false;
            _ = typesToBeTested?.Remove(t);
            return t is not null;
        }

        private bool isDublicated(Type x, Type y)
        {
            if (x == y) return false;
            var nameX = x.Name;
            var nameY = y.Name;
            var lengthX = nameX.IndexOf('`');
            var lengthY = nameY.IndexOf('`');
            if (lengthX >= 0) nameX = nameX[..lengthX];
            if (lengthY >= 0) nameY = nameY[..lengthY];
            return nameX == nameY;
        }

        private void removeInterfaces() => typesToBeTested?.RemoveAll(t => t.IsInterface);
        private void removeNotCorrectTests() => testingTypes.Remove(x => !isCorrectTest(x));
        private void removeNotClassTests() => testingTypes.Remove(x => !Types.NameEnds(x, testsStr));
        private void removeNotInNamespace(List<Type>?t, string? nameSpace) => t?.Remove(x => !Types.NameStarts(x, nameSpace));
        private static string? removeTestsTagForm(string? s) => s?.Remove(testProjectStr);
        private static string? getNameSpace(object obj) => GetNameSpace.OfType(obj);
        private static Assembly? getAssembly(object o) => GetAssembly.OfType(o);
        private static Assembly? getAssembly(string? name) => GetAssembly.ByName(name);
        private static List<Type>? getTypes(Assembly? a) => GetAssembly.Types(a);
        private void reportNotAllIsTested() => isInconclusive(notTestedMsg);
        private string fullNameOfFirstNotTested() => firstNotTestedType(typesToBeTested)?.FullName ?? string.Empty;
        private static Type? firstNotTestedType(List<Type>? l) => l.GetFirst();
        private bool allAreTested() => typesToBeTested.IsEmpty();
        private void removeTested() => typesToBeTested?.Remove(x=>isItTested(x));
        private  bool isItTested(Type x){
           var t = testingTypes?.Find(y => isTestFor(y, x));
           if(t is null)return false;
           _= testingTypes?.Remove(t);
           return t is not null;
        }
        private static bool isCorrectTest(Type x) => isCorrectlyInherited(x) && isTestClass(x);
        private static bool isTestClass(Type x) => x?.HasAttribute<TestClassAttribute>() ?? false;
        private static bool isCorrectlyInherited(Type x) => x.IsInherited(typeof(TypeTests));

        private static bool isTestFor(Type testingType, Type typeToBeTested) {
            var testName = typeToBeTested.FullName??String.Empty;
            testName = testName.RemoveHead();
            var length = testName.IndexOf('`');
            if (length > 0)testName=testName[..length];
            testName += "Tests";
            return testingType.NameEnds($".{testName}");
        }
            
        private void removeNotNeedTesting() => typesToBeTested?.Remove(x => !isTypeToBeTested(x));
        private bool isTypeToBeTested(Type x) => x?.BelongsTo(namespaceOfType) ?? false;
    }
}
