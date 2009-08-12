using System.Diagnostics.Contracts;

namespace C5.Contracts
{
    internal sealed class Logical
    {
        [Pure]
        public delegate bool Consequent();

        [Pure]
        public static bool Implication(bool p, Consequent q)
        {
            Contract.Ensures(Equivalence(Contract.Result<bool>(), () => !p || q()));

            return !p || q();
        }

        [Pure]
        public static bool Equivalence(bool p, Consequent q)
        {
            Contract.Ensures(Contract.Result<bool>() && p && q() ||
                             !Contract.Result<bool>() && !p && !q());
            //Contract.Ensures(Equivalence(proposition, equivalent));

            return p && q() || !p && !q();
        }
    }
}
