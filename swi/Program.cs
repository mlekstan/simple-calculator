using System.Globalization;
using System.Text.Json;
using swi;


var INPUT_FILE_PATH = @"./input.json";
var OUTPUT_FILE_PATH = @"./output.txt";

CultureInfo.DefaultThreadCurrentCulture = CultureInfo.InvariantCulture;
CultureInfo.DefaultThreadCurrentUICulture = CultureInfo.InvariantCulture;

Dictionary<string, OperationDto> inputDict;

try
{
  string jsonText = File.ReadAllText((args.Length == 1) ? args[0] : INPUT_FILE_PATH);
  inputDict = JsonSerializer.Deserialize<Dictionary<string, OperationDto>>(jsonText)
    ?? throw new JsonException("JSON deserialization result is null.");
}
catch (FileNotFoundException e)
{
  Console.WriteLine("File not found. {0}", e.Message);
  return;
}
catch (JsonException e)
{
  Console.WriteLine("Incorrect JSON format. {0}", e.Message);
  return;
}
catch (Exception e)
{
  Console.WriteLine("Unexpected error occured. {0}", e.Message);
  return;
}

var operationFactory = new OperationFactory();
List<Operation> executedOperationsList = new(); 

foreach(var entry in inputDict)
{
  var operationDto = entry.Value;
  operationDto.Name = entry.Key;

  try
  {
    var operation = operationFactory.CreateOperation(operationDto);
    operation.Execute();
    executedOperationsList.Add(operation);      
  }
  catch (Exception e)
  {
    Console.WriteLine($"Name of JSON object in which error occured: '{operationDto.Name}'. Content: {e.Message}");
    return;
  }
}

executedOperationsList.Sort();

using (StreamWriter sw = File.CreateText(OUTPUT_FILE_PATH))
{
  foreach (var operation in executedOperationsList)
  {
    sw.WriteLine($"{operation.Name}: {operation.Result}");
  }
}

using (StreamWriter sw = File.CreateText(OUTPUT_FILE_PATH))
{
  for (int i = 0; i < executedOperationsList.Count; i++)
  {
    var operation = executedOperationsList[i];
    
    if (i > 0) 
      sw.WriteLine(); 
    
    sw.Write($"{operation.Name}: {operation.Result}");
  }
}