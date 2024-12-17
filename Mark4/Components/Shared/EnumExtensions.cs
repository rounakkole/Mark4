using Microsoft.CodeAnalysis.Elfie.Diagnostics;
using Microsoft.DotNet.Scaffolding.Shared.Project;

namespace Mark4.Components.Shared
{
    /// <summary>
    /// Enum extensions
    /// Pattern matching: https://learn.microsoft.com/en-us/dotnet/csharp/fundamentals/functional/pattern-matching
    /// Discard pattern: https://learn.microsoft.com/en-us/dotnet/csharp/language-reference/operators/patterns#discard-pattern
    /// </summary>
    public static class EnumExtensions
    {
        #region Methods

        public static string? ToChartDatasetDataLabelAlignmentString(this Alignment alignment) =>
            alignment switch
            {
                Alignment.Start => "start",
                Alignment.Center or Alignment.None => "center", // default
                Alignment.End => "end",
                _ => null
            };

        public static string? ToChartDatasetDataLabelAnchorString(this Anchor anchor) =>
            anchor switch
            {
                Anchor.Start => "start",
                Anchor.Center or Anchor.None => "center", // default
                Anchor.End => "end",
                _ => null
            };

        public static string ToCssString(this Unit unit) =>
            unit switch
            {
                Unit.Em => "em",
                Unit.Percentage => "%",
                Unit.Pt => "pt",
                Unit.Px => "px",
                Unit.Rem => "rem",
                Unit.Vh => "vh",
                Unit.VMax => "vmax",
                Unit.VMin => "vmin",
                Unit.Vw => "vw",
                _ => string.Empty
            };

        public static string ToPaginationAlignmentClass(this Alignment alignment) =>
            alignment switch
            {
                Alignment.Start => "justify-content-start",
                Alignment.Center => "justify-content-center",
                Alignment.End => "justify-content-end",
                _ => ""
            };

        #endregion
    }
}
