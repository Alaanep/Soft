﻿using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace ABC.Tests.Soft {
    [TestClass]public class IsSoftTested: IsAssemblyTested
    {
        protected override void isAllTested() => isInconclusive("Namespace has to be changed to \"ABC.Soft\"");
    }
}
