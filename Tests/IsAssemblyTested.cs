﻿using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Reflection;
using System.Reflection.Metadata;
using ABC.Aids;

namespace ABC.Tests {
    public  abstract class IsAssemblyTested: TestAsserts
    {
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
            namespaceOfType = removeTestsTagForm(namespaceOfTest);
            assemblyToBeTested = getAssembly(namespaceOfType);
            typesToBeTested = getTypes(assemblyToBeTested);
            removeNotNeedTesting();
            removeTested();
            if (allAreTested()) return;
            reportNotAllIsTested();
        }

        private static string? removeTestsTagForm(string? s) => s?.Remove("Tests.");
        private static string? getNameSpace(object obj) => GetNameSpace.OfType(obj);
        private static Assembly? getAssembly(object o) => GetAssembly.OfType(o);
        private static Assembly? getAssembly(string? name) => GetAssembly.ByName(name);
        private static List<Type>? getTypes(Assembly? a) => GetAssembly.Types(a);
        private void reportNotAllIsTested() => isInconclusive($"Class \"{fullNameOfFirstNotTested()}\" is not tested");
        private string fullNameOfFirstNotTested() => firstNotTestedType(typesToBeTested)?.FullName ?? string.Empty;
        private static Type firstNotTestedType(List<Type>? l) => l.GetFirst();
        private bool allAreTested() => typesToBeTested.IsEmpty();
        private void removeTested() => typesToBeTested?.Remove(x=>isItTested(x));
        private  bool isItTested(Type x) =>
            testingTypes?.ContainsItem(y => isTestFor(y, x) && isCorrectTest(y)) ?? false;
        private static bool isCorrectTest(Type x) => isCorrectlyInherited(x) && isTestClass(x);
        private static bool isTestClass(Type x) => x?.HasAttribute<TestClassAttribute>() ?? false;
        private static bool isCorrectlyInherited(Type x) => x.IsInherited(typeof(IsTypeTested));
        private static bool isTestFor(Type testingType, Type typeToBeTested) =>
            testingType.NameEnds(typeToBeTested.Name + "Tests");
        private void removeNotNeedTesting() => typesToBeTested?.Remove(x => !isTypeToBeTested(x));
        private bool isTypeToBeTested(Type x) => x?.BelongsTo(namespaceOfType) ?? false;
    }
}