using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Reflection;
using System.Reflection.Metadata;
using ABC.Aids;

namespace ABC.Tests {
    public  abstract class IsAssemblyTested: TestAsserts
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
            removeNotInNamespace();
            removeNotClassTests();
            removeNotCorrectTests();
            namespaceOfType = removeTestsTagForm(namespaceOfTest);
            assemblyToBeTested = getAssembly(namespaceOfType);
            typesToBeTested = getTypes(assemblyToBeTested);
            removeNotNeedTesting();
            removeTested();
            if (allAreTested()) return;
            reportNotAllIsTested();
        }

        private void removeNotCorrectTests() => testingTypes.Remove(x => !isCorrectTest(x));
        private void removeNotClassTests() => testingTypes.Remove(x => !Types.NameEnds(x, testsStr));
        private void removeNotInNamespace() => testingTypes.Remove(x => !Types.NameStarts(x, namespaceOfTest));
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
        private static bool isCorrectlyInherited(Type x) => x.IsInherited(typeof(IsTypeTested));

        private static bool isTestFor(Type testingType, Type typeToBeTested)
        {
            var testName = typeToBeTested.Name;
            var length = testName.IndexOf('`');
            if (length > 0)testName=testName[..length];
            testName += "Tests";
            return testingType.NameEnds($".{testName}");
        }
            
        private void removeNotNeedTesting() => typesToBeTested?.Remove(x => !isTypeToBeTested(x));
        private bool isTypeToBeTested(Type x) => x?.BelongsTo(namespaceOfType) ?? false;
    }
}
