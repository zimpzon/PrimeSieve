namespace PrimeSieveLib
{
    public static class PrimeSieve
    {
        public const int MAX_PRIME = 1_000_000;

        // One bit per odd number.
        // 3 -> bit 0, 5 -> bit 1, 7 -> bit 2, ...
        private static readonly byte[] _sieve;

        static PrimeSieve()
        {
            _sieve = new byte[MAX_PRIME / 16 + 1];

            int limit = (int)Math.Sqrt(MAX_PRIME);

            for (int i = 3; i <= limit; i += 2)
            {
                if (IsComposite(i))
                    continue;

                for (int j = i * i; j <= MAX_PRIME; j += i * 2)
                    SetComposite(j);
            }
        }

        public static bool IsPrime(int n, out bool outOfBounds)
        {
            outOfBounds = n > MAX_PRIME;
            if (outOfBounds)
                return false;

            if (n < 2 )
                return false;

            if (n == 2)
                return true;

            bool isUnevenNumber = (n & 1) == 0;
            if (isUnevenNumber)
                return false;

            return !IsComposite(n);
        }

        private static bool IsComposite(int n)
        {
            int index = n >> 1;
            return (_sieve[index >> 3] & (1 << (index & 7))) != 0;
        }

        private static void SetComposite(int n)
        {
            int index = n >> 1;
            _sieve[index >> 3] |= (byte)(1 << (index & 7));
        }
    }
}
