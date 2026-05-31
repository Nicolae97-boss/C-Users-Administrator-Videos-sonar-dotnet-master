namespace Tests.Diagnostics
{
    using System.Threading.Tasks;
    using Microsoft.VisualStudio.TestTools.UnitTesting;

    [TestClass]
    public class MsTestTest
    {
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestMethod]
        private void PrivateTestMethod() // Noncompliant {{Make this test method 'public'.}}
//                   ^^^^^^^^^^^^^^^^^
        {
        }

        [TestMethod]
        protected void ProtectedTestMethod() // Noncompliant
        {
        }

        [TestMethod]
        internal void InternalTestMethod() // Noncompliant
        {
        }

        [TestMethod]
        public async void AsyncTestMethod()  // Noncompliant {{Make this test method non-'async' or return 'Task'.}}
        {
        }

        [TestMethod]
        public void GenericTestMethod<T>()  // Noncompliant {{Make this test method non-generic.}} FP  https://sonarsource.atlassian.net/browse/NET-3623
        {
        }

        [TestMethod]
        private void MultiErrorsMethod1<T>() // Noncompliant {{Make this test method 'public' and non-generic.}} FP
        {
        }

        [TestMethod]
        private async void MultiErrorsMethod2<T>() // Noncompliant {{Make this test method 'public', non-generic and non-'async' or return 'Task'.}} FP
        {
        }

        [TestMethod]
        public async Task DoSomethingAsync() // Compliant
        {
            return;
        }
    }
}

namespace Tests.Diagnostics
{
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using System.Threading.Tasks;

    [TestClass]
    public class MsTestTest_DataTestMethods
    {
        [Microsoft.VisualStudio.TestTools.UnitTesting.DataTestMethod]
        private void PrivateTestMethod() // Noncompliant {{Make this test method 'public'.}}
//                   ^^^^^^^^^^^^^^^^^
        {
        }

        [DataTestMethod]
        protected void ProtectedTestMethod() // Noncompliant
        {
        }

        [DataTestMethod]
        internal void InternalTestMethod() // Noncompliant
        {
        }

        [DataTestMethod]
        public async void AsyncTestMethod()  // Noncompliant {{Make this test method non-'async' or return 'Task'.}}
        {
        }

        [DataTestMethod]
        public void GenericTestMethod<T>()  // Noncompliant {{Make this test method non-generic.}} FP
        {
        }

        [DataTestMethod]
        private void MultiErrorsMethod1<T>() // Noncompliant {{Make this test method 'public' and non-generic.}} FP
        {
        }

        [DataTestMethod]
        private async void MultiErrorsMethod2<T>() // Noncompliant {{Make this test method 'public', non-generic and non-'async' or return 'Task'.}} FP
        {
        }

        [DataTestMethod]
        public async Task DoSomethingAsync() // Compliant
        {
            return;
        }
    }
}

namespace DerivedAttributeTestCases
{
    using Microsoft.VisualStudio.TestTools.UnitTesting;

    [DerivedTestClassAttribute]
    class TestSuite
    {
        [DerivedTestMethodAttribute]
        void NestedTest() { } // Noncompliant

        [DerivedDataTestMethodAttribute]
        void NestedDataTest() { } // Noncompliant
    }

    public class DerivedTestClassAttribute : TestClassAttribute { }

    public class DerivedTestMethodAttribute : TestMethodAttribute { }

    public class DerivedDataTestMethodAttribute : DataTestMethodAttribute { }
}
