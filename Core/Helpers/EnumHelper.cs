using System.ComponentModel;

namespace CountEZ.Core.Helpers
{
    internal static class EnumHelper
    {
        /// <summary>
        /// Display friendly names for enumeration elements using the Description annotation
        /// </summary>
        public static string GetDisplayName(this Enum value)
        {
            var fieldInfo = value.GetType().GetField(value.ToString());

            if (fieldInfo == null )
                return value.ToString();

            var att = (DescriptionAttribute[])fieldInfo.GetCustomAttributes(typeof(DescriptionAttribute), false);

            if (att == null || att.Length == 0)
                return value.ToString();

            return att[0].Description;
        }
    }
}
