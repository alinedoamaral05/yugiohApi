using System.Globalization;
using System.Text;

namespace YuGiOhApi.Providers;

public static class NormalizeString
{
    public static string NormalizedSearch(this string text)
    {
        StringBuilder sbReturn = new StringBuilder();
        var arrayText = text.Normalize(NormalizationForm.FormD).ToCharArray();
        foreach (char letter in arrayText)
        {
            if (CharUnicodeInfo.GetUnicodeCategory(letter) != UnicodeCategory.NonSpacingMark)
                sbReturn.Append(letter);
        }

        var lowerString = sbReturn.ToString().ToLower();
        return lowerString;
    }
}