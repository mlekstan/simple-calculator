using System.Text.Json;
using System.Text.Json.Serialization;

namespace swi;

public class OperationDto
{
  [JsonConverter(typeof(JsonStringEnumConverter))]
  [JsonPropertyName("operator")]
  public OperatorType? RawOperator { get; set; }
  [JsonPropertyName("value1")]
  public double? RawValue1 { get; set; }
  [JsonPropertyName("value2")]
  public double? Value2 { get; set; }
  [JsonIgnore]
  public OperatorType Operator { get; set; }
  [JsonIgnore]
  public double Value1 { get; set; }
  [JsonIgnore]
  public string? Name { get; set; }

  [JsonConstructor]
  public OperationDto(OperatorType? rawOperator, double? rawValue1, double? value2)
  {
    RawOperator = rawOperator ?? throw new JsonException("Field 'operator' is required.");
    RawValue1 = rawValue1 ?? throw new JsonException("Field 'value1' is required.");

    Operator = rawOperator.Value;
    Value1 = rawValue1.Value;
    Value2 = value2;
  }
  public OperationDto() {}
}