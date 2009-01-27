using MbUnit.Framework;
using MbUnit.Framework.ContractVerifiers;

namespace C5.Tests.Exceptions
{
    [Category("Exceptions")]
    public class InternalExceptionFixture
    {
        [VerifyContract] public readonly IContract ExceptionTests = new ExceptionContract<InternalException>
            {ImplementsStandardConstructors = false};
    }
}