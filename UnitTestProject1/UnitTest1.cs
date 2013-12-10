#region Usings

using AwfulVideoStore;
using Microsoft.VisualStudio.TestTools.UnitTesting;

#endregion

namespace UnitTestProject1 {
    [TestClass]
    public class UnitTest1 {
        [TestMethod]
        public void TestMethod1() {
            Login.Authorize("admin", "admin", );
        }
    }
}