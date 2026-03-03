using System.Text;

namespace Lab02;


public static class StringExtension
{
    public static string Repeat(this string str, int count)
    {
        StringBuilder sb = new StringBuilder();
        for (int i = 0; i < count; i++)
        {
            sb.Append(str);
        }
        return sb.ToString();
    }
    public static string StarEncode(this string str, char changeC)
    {
        StringBuilder sb = new StringBuilder();
        for (int i = 0; i < str.Length; i++)
        {
            sb.Append(changeC);
        }
        return sb.ToString();
    }
}