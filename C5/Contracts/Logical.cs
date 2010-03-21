using System.Diagnostics.Contracts;

namespace C5.Contracts
{
    internal static class Logical
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
        public static bool Implication(bool p, bool q)
        {
            Contract.Ensures(Equivalence(Contract.Result<bool>(), !p || q));

            return !p || q;
        }

        [Pure]
        public static bool Equivalence(bool p, Consequent q)
        {
            Contract.Ensures(Contract.Result<bool>() && p && q() ||
                             !Contract.Result<bool>() && !p && !q());

            return Equivalence(p, q());
        }

        [Pure]
        public static bool Equivalence(bool p, bool q)
        {
            Contract.Ensures(Contract.Result<bool>() && p && q ||
                             !Contract.Result<bool>() && !p && !q);

            return p && q || !p && !q;
        }
    }
}
