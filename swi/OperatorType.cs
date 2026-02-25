using System.Text.Json.Serialization;

namespace swi;

public enum OperatorType : ushort
{
  [JsonPropertyName("add")] add, 
  [JsonPropertyName("sub")] sub,
  [JsonPropertyName("mul")] mul, 
  [JsonPropertyName("sqrt")] sqrt
}