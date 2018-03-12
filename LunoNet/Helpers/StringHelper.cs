using System;
using System.Text;

namespace LunoNet.Helpers
{
    public static class StringHelper
    {
        /// <summary>
        /// Converts string to base64.
        /// </summary>
        /// <returns>The to base64.</returns>
        /// <param name="value">Value.</param>
        public static string ConvertToBase64(string value)
        {
            return Convert.ToBase64String(Encoding.Default.GetBytes(value));    
        } 
    }
}
