using Microsoft.Extensions.Localization;
using System.Text.RegularExpressions;

namespace ProConsulta.Extensions
{
    public static class StringExtensions
    {
        public static string CharactersOnly(this string value)
        {
            if(string.IsNullOrEmpty(value))
                return value;

            string pattern = @"[-\.\(\)\s ]";

            string result = Regex.Replace(value, pattern, string.Empty);

            return result;
        }
    }
}
