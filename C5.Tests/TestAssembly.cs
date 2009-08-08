using System.Diagnostics.Contracts;
using MbUnit.Framework;
namespace C5.Tests
{
    [AssemblyFixture]
    public class TestAssembly
    {
        [SetUp]
        public static void AssemblyInitialize()
        {
            Contract.ContractFailed += (sender, e) =>
                {
                    e.SetHandled();
                    e.SetUnwind(); // Forces abort after contract failure
                    Assert.Fail("{0}:{1}", e.FailureKind, e.Message);
                };
        }
    }
}
