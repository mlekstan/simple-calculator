abstract class Operation : OperationDto, IComparable
{
  protected double Result;
  public Operation(OperationDto operationDto) : base()
  {
    Operator = operationDto.Operator;
    Value1 = operationDto.Value1;
    Value2 = operationDto.Value2;
    Name = operationDto.Name;
  }
  public abstract void Execute();
  public int CompareTo(object? obj)
  {
    if (obj == null) return 1;

    var operation = obj as Operation;
    if (operation != null)
      return Result.CompareTo(operation.Result);
    else
      throw new Exception("Object is not a Operation");
  }
  protected static void CheckValue(double value, string message)
  {
    if (double.IsNaN(value) || double.IsInfinity(value))
    {
      throw new Exception(message);
    }   
  }
}

class Addition : Operation
{
  public Addition(OperationDto operationDto) : base(operationDto) {}
  
  public override void Execute()
  {
    if (Value2 == null)
    {
      throw new Exception("Wymagane są dwa operandy.");
    }

    var result = Value1.Value + Value2.Value;
    CheckValue(result, "Wartości operndów muszą być liczbami.");
    Result = result;
  }
}

class Subtraction : Operation
{
  public Subtraction(OperationDto operationDto) : base(operationDto) {}
  public override void Execute()
  {
    if (Value2 == null)
    {
      throw new Exception("Wymagane są dwa operandy.");
    }

    var result = Value1.Value - Value2.Value;
    CheckValue(result, "Wartości operndów muszą być liczbami.");
    Result = result;
  }
}

class Multiplication : Operation
{
  public Multiplication(OperationDto operationDto) : base(operationDto) {}
  public override void Execute()
  {
    if (Value2 == null)
    {
      throw new Exception("Wymagane są dwa operandy.");
    }

    var result = Value1.Value * Value2.Value;
    CheckValue(result, "Wartości operndów muszą być liczbami.");
    Result = result;
  }
}

class SquareRoot : Operation
{
  public SquareRoot(OperationDto operationDto) : base(operationDto) {}
  public override void Execute()
  {
    var result = Math.Sqrt(Value1.Value);
    CheckValue(result, "Wartość operandu musi być liczbą większą od 0.");
    Result = result;
  }
}