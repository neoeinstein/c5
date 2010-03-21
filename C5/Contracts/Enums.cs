using System;
using System.Diagnostics.Contracts;

namespace C5.Contracts
{
    internal static class Enums
    {
        [Pure]
        public static bool IsValidFlag<T>(T value, T allFlag) where T : IConvertible
        {
            return (value.ToUInt64(null) & ~allFlag.ToUInt64(null)) == 0;
        }

        [Pure]
        public static bool IsOneOf<T>(T value, params T[] validValues) where T : struct
        {
            Contract.Ensures(
                Logical.Equivalence(
                    Contract.Result<bool>() == true,
                    Contract.Exists(validValues, (item) => value.Equals(item))));

            foreach (T item in validValues)
                if (value.Equals(item))
                    return true;

            return false;
        }

        [Pure]
        public static bool IsValidEnumerationDirection(EnumerationDirection direction)
        {
            Contract.Ensures(
                Logical.Equivalence(
                    Contract.Result<bool>(),
                    direction == EnumerationDirection.Backwards
                 || direction == EnumerationDirection.Forwards));

            switch (direction)
            {
                case EnumerationDirection.Backwards:
                case EnumerationDirection.Forwards:
                    return true;
                default:
                    return false;
            }
        }

        [Pure]
        public static bool IsValidEventType(EventTypeEnum eventType)
        {
            Contract.Ensures(Logical.Equivalence(Contract.Result<bool>(),(eventType & ~EventTypeEnum.All) == 0));

            return (eventType & ~EventTypeEnum.All) == 0;
        }

        [Pure]
        public static bool IsValidBasicEventType(EventTypeEnum eventType)
        {
            Contract.Ensures(Logical.Equivalence(Contract.Result<bool>(),(eventType & ~EventTypeEnum.Basic) == 0));

            return (eventType & ~EventTypeEnum.Basic) == 0;
        }

        [Pure]
        public static bool IsValidSpeed(Speed speed)
        {
            Contract.Ensures(
                Logical.Equivalence(
                    Contract.Result<bool>(),
                    speed == Speed.Constant
                  || speed == Speed.Log
                  || speed == Speed.Linear
                  || speed == Speed.PotentiallyInfinite));

            switch(speed)
            {
                case Speed.Constant:
                case Speed.Log:
                case Speed.Linear:
                case Speed.PotentiallyInfinite:
                    return true;
                default:
                    return false;
            }
        }
    }
}
