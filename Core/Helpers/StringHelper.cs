namespace CountEZ.Core.Helpers
{
    internal static class StringHelper
    {

        public static T ToEnum<T>(this string value) where T : struct
            => string.IsNullOrWhiteSpace(value) ?
               default : (T)Enum.Parse(typeof(Task), value, true);
    }
}
