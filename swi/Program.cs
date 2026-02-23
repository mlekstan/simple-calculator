using System.Text.Json;
using System.Text.Json.Serialization;


try
{
  string jsonText = File.ReadAllText(args[0]);
  var inputDict = JsonSerializer.Deserialize<Dictionary<string, OperationDto>>(jsonText);
  var operationFactory = new OperationFactory();
  List<Operation> executedOperationsList = new(); 
  

  foreach(var entry in inputDict)
  {
    OperationDto operationDto = entry.Value;
    operationDto.Name = entry.Key;

    try
    {
      var operation = operationFactory.CreateOperation(operationDto);
      operation.Execute();
      executedOperationsList.Add(operation);      
    }
    catch (Exception e)
    {
      Console.WriteLine($"Błąd. Lokalizacja: {operationDto.Name}. Treść: {e.Message}");
    }
  }

  executedOperationsList.Sort();

} 
catch (Exception e)
{
  Console.Write("Nieprawidłowy format danych wejściowych {0}", e);
}


enum OperatorType : ushort
{
  [JsonPropertyName("add")] add, 
  [JsonPropertyName("sub")] sub,
  [JsonPropertyName("mul")] mul, 
  [JsonPropertyName("sqrt")] sqrt
}