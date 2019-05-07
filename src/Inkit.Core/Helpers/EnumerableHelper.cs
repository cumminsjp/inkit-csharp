using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Inkit.Core.Helpers
{
	/// <summary>
	/// Helper class for IEnumerable
	/// </summary>
	public static class EnumerableHelper
	{
		/// <summary>
		///     Converts items to a numbered list
		/// </summary>
		/// <param name="items">The items.</param>
		/// <returns>string</returns>
		public static string ToNumberedListString(this IEnumerable<string> items)
		{
			var sb = new StringBuilder();

			var i = 0;

			foreach (var item in items)
			{
				i++;

				sb.Append(i);
				sb.Append(". ");
				sb.AppendLine(item);
				sb.AppendLine(string.Empty);
			}

			return sb.ToString();
		}

		/// <summary>
		/// Converts a list of items to a comma separated string value.
		/// </summary>
		/// <typeparam name="T"></typeparam>
		/// <param name="items">The items.</param>
		/// <returns></returns>
		public static string ToCSV<T>(this IEnumerable<T> items)
		{
			var delimiter = ",";

			return ToCharacterSeparatedValueString(items, delimiter);
		}

		/// <summary>
		/// Converts a list of items to a character separated string value.
		/// </summary>
		/// <typeparam name="T"></typeparam>
		/// <param name="items">The items.</param>
		/// <param name="delimiter">The delimiter.</param>
		/// <returns></returns>
		public static string ToCharacterSeparatedValueString<T>(this IEnumerable<T> items, string delimiter)
		{
			var q = items.Select(x => x.ToString());
				
			return string.Join(delimiter, q.ToArray());
		}

	}
}