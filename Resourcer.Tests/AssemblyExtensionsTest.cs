using System;
using System.Collections;
using System.Drawing;
using System.IO;
using System.Reflection;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Resourcer.Tests
{
    [TestClass]
    public class AssemblyExtensionsTest
    {
        private Assembly _assembly;

        [TestInitialize]
        public void Init()
        {
            _assembly = Assembly.GetExecutingAssembly();
        }

        [TestMethod]
        public void ExtractResource_WithInvalidName_FailsGracefully()
        {
            var result = _assembly.ExtractResource("I Don't Exist");

            Assert.AreEqual(result.Success, false);
            StringAssert.StartsWith(result.Error, "Resource not found:");
        }
    }
}
