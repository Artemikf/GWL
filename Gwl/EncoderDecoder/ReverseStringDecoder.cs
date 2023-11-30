using System;

namespace Gwl.EncoderDecoder
{
    public class ReverseStringDecoder : IDecoder
    {
        public string Decode(string content)
        {
            // нужно немного дописать
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
