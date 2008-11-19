using MbUnit.Framework;
using MbUnit.Framework.ContractVerifiers;

namespace C5.Tests.Exceptions
{
    [Category("Exceptions")]
    [VerifyExceptionContract(typeof(CollectionModifiedException))]
    public class CollectionModifiedExceptionFixture
    {
    }
}