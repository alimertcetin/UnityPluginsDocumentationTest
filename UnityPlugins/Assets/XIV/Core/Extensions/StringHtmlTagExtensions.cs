using System.Text;
using UnityEngine;

namespace XIV.Core.Extensions
{
    public static class StringHtmlTagExtensions
    {
		static StringBuilder stringBuilder = new StringBuilder();

		const string TAG_BOLD = "b";
		const string TAG_COLOR = "color";

		static string Format(string tag, string value)
        {
            stringBuilder.Clear();
            stringBuilder.Append("<" + tag + ">");
            stringBuilder.Append(value);
            stringBuilder.Append("</" + tag + ">");

			return stringBuilder.ToString();
        }

		static string Format(string tag, string tagValue, string value)
        {
			if (string.IsNullOrEmpty(tagValue)) return Format(tag, value);

			stringBuilder.Clear();
			stringBuilder.Append("<" + tag + "=" + tagValue + ">");
			stringBuilder.Append(value);
			stringBuilder.Append("</" + tag + ">");

			return stringBuilder.ToString();
        }

        public static string ToBold(this string value)
		{
			return Format(TAG_BOLD, value);
        }

        public static string ToColorRed(this string value)
		{
			return Format(TAG_COLOR, "red", value);
        }

        public static string ToColorGreen(this string value)
        {
            return Format(TAG_COLOR, "green", value);
        }

        public static string ToColorBlue(this string value)
        {
            return Format(TAG_COLOR, "blue", value);
        }

        public static string ToColorYellow(this string value)
		{
			return Format(TAG_COLOR, "yellow", value);
        }

        public static string ToColor(this string value, string colorHex)
		{
			return Format(TAG_COLOR, colorHex, value);
        }

        public static string ToColor(this string value, Color color)
        {
	        return ToColor(value, "#" + ColorUtility.ToHtmlStringRGBA(color));
        }
	}
}