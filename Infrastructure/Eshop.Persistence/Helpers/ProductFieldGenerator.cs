using System;
using System.Linq;
using System.Collections.Generic;
using System.Text;

namespace Eshop.Persistence.Helpers
{
    public static class ProductFieldGenerator
    {
        private static readonly char[] _letters = "abcdefghijklmnopqrstuvwxyz".ToCharArray();
        private static readonly char[] _lettersAndDigits = "abcdefghijklmnopqrstuvwxyz1234567890".ToCharArray();

        #region "Private Methods"

        private static string RandomString(int length, bool lettersOnly)
        {
            var charSet = lettersOnly ? _letters : _lettersAndDigits;
            const int byteSize = 0x100;
            using (var rng = System.Security.Cryptography.RandomNumberGenerator.Create())
            {
                var result = new StringBuilder();
                var buf = new byte[128];
                while (result.Length < length)
                {
                    rng.GetBytes(buf);
                    for (var i = 0; i < buf.Length && result.Length < length; ++i)
                    {
                        var outOfRangeStart = byteSize - (byteSize % charSet.Length);
                        if (outOfRangeStart <= buf[i]) continue;
                        result.Append(charSet[buf[i] % charSet.Length]);
                    }
                }
                return result.ToString();
            }
        }

        private static int RoundOff(this int i)
        {
            return ((int)Math.Round(i / 10.0)) * 10;
        }

        #endregion "Private Methods"

        #region "Public Methods"

        public static string[] GenerateRandomProductNames(int lengthFrom, int lengthTo, int count)
        {
            HashSet<string> list = new();
            Random random = new();
            while (list.Count < count)
            {
                var length = random.Next(lengthFrom, lengthTo);
                list.Add(RandomString(length, true));
            }

            return list.ToArray();
        }

        public static List<decimal> GenerateRandomProductPrices(int minVal, int maxVal, int count)
        {
            List<decimal> list = new();
            Random random = new();
            for (int i = 0; i < count; i++)
            {
                list.Add(random.Next(minVal, maxVal).RoundOff());
            }

            return list;
        }

        public static string[] GenerateUniqueProductBarcodes(int length, int count)
        {
            HashSet<string> list = new();
            while (list.Count < count)
            {
                list.Add(RandomString(length, false));
            }

            var arr = list.ToArray();
            for (int i = 1; i < arr.Length; i++)
            {
                if ((i + 1) % 10 == 0)
                    arr[i] = string.Empty;
            }

            return arr;
        }

        public static int[] GenerateUniqueProductPLUs(int lengthFrom, int lengthTo, int count)
        {
            HashSet<int> list = new();
            Random random = new(lengthFrom);
            while (list.Count < count)
            {
                list.Add(random.Next(lengthTo));
            }

            return list.ToArray();
        }

        #endregion "Public Methods"
    }
}