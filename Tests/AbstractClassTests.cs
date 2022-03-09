using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace ABC.Tests;

public abstract class AbstractClassTests: BaseTests
{
    [TestMethod] public void IsAbstractTest() => isTrue(obj?.GetType().BaseType?.IsAbstract ?? false);
}