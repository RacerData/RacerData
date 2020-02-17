using System.Text;

namespace RacerData.iRacing.Extensions
{
    public static class StringExtensions
    {
        public static string SplitWords(this string value)
        {
            var sb = new StringBuilder();

            for (int i = 0; i < value.Length; i++)
            {
                sb.Append(value[i]);

                if ((i < value.Length - 1) && char.IsLower(value[i]) && char.IsUpper(value[i + 1]))
                {
                    sb.Append(" ");
                }
            }

            return sb.ToString();
        }
    }
}
