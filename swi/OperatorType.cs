using System.Text.Json.Serialization;

enum OperatorType : ushort
{
  [JsonPropertyName("add")] add, 
  [JsonPropertyName("sub")] sub,
  [JsonPropertyName("mul")] mul, 
  [JsonPropertyName("sqrt")] sqrt
}