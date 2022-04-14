using System;

namespace Jego.Utility
{
    public static class NumberFormatter
    {
        /// <summary>
        /// Returns the number formatted to have a comma between every 3 numbers
        /// </summary>
        /// <param name="value">The int to format</param>
        /// <returns>The formatted number, example: 1000420 becomes 1,000,420</returns>
        public static string Format(int value)
        {
            return string.Format("{0:n0}", value);
        }
        
        /// <summary>
        /// Returns the number formatted to have a comma between every 3 numbers
        /// </summary>
        /// <param name="value">The float to format</param>
        /// <returns>The formatted number, example: 1000419.69 becomes 1,000,420</returns>
        public static string Format(float value)
        {
            return string.Format("{0:n0}", value);
        }
    }
}