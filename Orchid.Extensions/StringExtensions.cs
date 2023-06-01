using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Orchid.Extensions
{
    /// <summary>
    /// An extension class which provides useful extension methods for String class.
    /// </summary>
    public static class StringExtensions
    {
        #region Public Methods

        /// <summary>
        /// Filters a list of strings, removing any strings that are null or empty.
        /// </summary>
        /// <param name="stringsList">The list of strings to filter.</param>
        /// <returns>A new list of strings containing only the non-null and non-empty strings.</returns>
        public static List<string> FilterNotNullOrEmpty(this List<string> stringsList)
        {
            return stringsList.Where(s => !string.IsNullOrEmpty(s)).ToList();
        }

        /// <summary>
        /// Determines whether a string is null or empty.
        /// </summary>
        /// <param name="str">The string to check.</param>
        /// <returns>
        ///   <c>true</c> if the string is null or empty; otherwise, <c>false</c>.
        /// </returns>
        public static bool IsNullOrEmpty(this string str)
        {
            return string.IsNullOrEmpty(str);
        }

        /// <summary>
        /// Joins the elements of an enumerable collection into a single string, using the specified delimiter.
        /// </summary>
        ///
        /// <typeparam name="T">The type of elements in the enumerable collection.</typeparam>
        /// <param name="values">The enumerable collection of values to join.</param>
        /// <param name="delimiter">The string to use as a delimiter between the joined elements.</param>
        /// <returns>A string that represents the joined elements of the enumerable collection.</returns>
        public static string JoinToString<T>(this IEnumerable<T> values, string delimiter)
        {
            return string.Join(delimiter, values.Select(v => v.ToString()));
        }

        #endregion Public Methods
    }
}
