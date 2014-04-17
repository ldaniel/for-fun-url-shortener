namespace URLShortener.Models
{
    public static class AlphabetTest
    {
        public static readonly string Alphabet = "0a1Ab2c3d4Ce5Df6gE7hFG9jHkmnJopKqrLstMuvNwxOyzPQRSTUVWXYZ";
        public static readonly int Base = Alphabet.Length;

        public static string Encode(int i)
        {
            if (i == 0)
                return Alphabet[0].ToString();

            var s = string.Empty;

            while (i > 0)
            {
                s += Alphabet[i % Base];
                i = i / Base;
            }

            return string.Join(string.Empty, s.Reverse());
        }

        public static int Decode(string s)
        {
            var i = 0;
            foreach (var c in s)
                i = (i * Base) + Alphabet.IndexOf(c);

            return i;
        }

        private static string Reverse(this string s)
        {
            var charArray = s.ToCharArray();
            var len = s.Length - 1;

            for (var i = 0; i < len; i++, len--)
            {
                charArray[i] ^= charArray[len];
                charArray[len] ^= charArray[i];
                charArray[i] ^= charArray[len];
            }

            return new string(charArray);
        }
    }
}