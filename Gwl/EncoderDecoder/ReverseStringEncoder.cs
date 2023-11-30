using System;

namespace Gwl.EncoderDecoder
{
    public class ReverseStringEncoder : IEncoder
    {
        public string Encode(string content)
        {
            // Реализация кодирования
            // Например, просто возвращаем обратную строку
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
