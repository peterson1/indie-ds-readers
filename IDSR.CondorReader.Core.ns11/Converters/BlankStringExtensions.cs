using Repo2.Core.ns11.Extensions.StringExtensions;

namespace IDSR.CondorReader.Core.ns11.Converters
{
    public static class BlankStringExtensions
    {
        public static string NullIfBlank(this string text)
            => text.IsBlank() ? null : text;
    }
}
