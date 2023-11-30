using System;

namespace Gwl.EncoderDecoder
{
    public class ReverseStringEncoder : IEncoder
    {
        public string Encode(string content)
        {
            // нужно немного дописать и тут
            return ReverseString(content);
        }

        private string ReverseString(string input)
        {
            char[] charArray = input.ToCharArray();
            Array.Reverse(charArray);
            return new string(charArray);
        }
    }
}
