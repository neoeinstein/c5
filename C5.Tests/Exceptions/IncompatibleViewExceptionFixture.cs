using MbUnit.Framework;
using MbUnit.Framework.ContractVerifiers;

namespace C5.Tests.Exceptions
{
    [Category("Exceptions")]
    public class IncompatibleViewExceptionFixture
    {
        [VerifyContract]
        public readonly IContract ExceptionTests = new ExceptionContract<IncompatibleViewException>();
    }
}