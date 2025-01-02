using System.Text.Json.Serialization;

namespace Mark4.Components.Charts
{
    public class ChartData
    {
        #region Properties, Indexers

        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public List<IChartDataset>? Datasets { get; set; }

        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public List<string>? Labels { get; set; }

        #endregion
    }
}
