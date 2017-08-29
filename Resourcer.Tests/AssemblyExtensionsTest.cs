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

        [TestMethod]
        public void ExtractResource_WithValidName_Succeeds()
        {
            var result = _assembly.ExtractResource("Resourcer.Tests.fractal-1121017_640.jpg");

            Assert.IsTrue(result.Success);
            Assert.IsTrue(File.Exists(result.Location));
            Assert.IsNull(result.Error);
        }

        [TestMethod]
        public void GetResource_WithInvalidName_ReturnsNull()
        {
            var result = _assembly.GetResource<object>("I Don't Exist");

            Assert.IsNull(result);
        }

        [TestMethod]
        [ExpectedException(typeof(NotSupportedException))]
        public void GetResource_WithUnsupportedType_Throws()
        {
            _assembly.GetResource<Hashtable>("Resourcer.Tests.README.md");            
        }

        [TestMethod]
        public void GetResource_WithValidStringResource_ReturnsString()
        {
            var result = _assembly.GetResource<string>("Resourcer.Tests.README.md");

            Assert.IsNotNull(result);
        }

        [TestMethod]
        public void GetResource_WithValidImageResource_ReturnsImage()
        {
            var result = _assembly.GetResource<Bitmap>("Resourcer.Tests.fractal-1121017_640.jpg");

            Assert.IsNotNull(result);
        }
    }
}
