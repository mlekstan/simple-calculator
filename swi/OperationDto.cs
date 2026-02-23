using System.Text.Json.Serialization;
class OperationDto
{
  [JsonConverter(typeof(JsonStringEnumConverter))]
  [JsonPropertyName("operator")]
  public OperatorType? Operator { get; set; }
  [JsonPropertyName("value1")]
  public double? Value1 { get; set; }
  [JsonPropertyName("value2")]
  public double? Value2 { get; set; }
  public string? Name { get; set; }
}