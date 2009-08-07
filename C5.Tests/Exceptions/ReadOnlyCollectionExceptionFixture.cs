using MbUnit.Framework;
using MbUnit.Framework.ContractVerifiers;

namespace C5.Tests.Exceptions
{
    [Category("Exceptions")]
    [Parallelizable(TestScope.All)]
    public class ReadOnlyCollectionExceptionFixture
    {
        [VerifyContract]
        public readonly IContract ExceptionTests = new ExceptionContract<ReadOnlyCollectionException>();
    }
}