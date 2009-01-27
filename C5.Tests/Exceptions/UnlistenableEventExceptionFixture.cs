using MbUnit.Framework;
using MbUnit.Framework.ContractVerifiers;

namespace C5.Tests.Exceptions
{
    [Category("Exceptions")]
    public class UnlistenableEventExceptionFixture
    {
        [VerifyContract]
        public readonly IContract ExceptionTests = new ExceptionContract<UnlistenableEventException>();
    }
}