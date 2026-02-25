abstract class Operation : OperationDto, IComparable
{
  public double Result = double.MinValue;
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

    if (obj is Operation operation)
      return Result.CompareTo(operation.Result);
    else
      throw new Exception("Object is not a Operation");
  }
  protected static void CheckValue(double value, string message)
  {
    if (double.IsNaN(value) || double.IsInfinity(value))
    {
      throw new InvalidOperationException(message);
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
      throw new InvalidOperationException("Two operands are required: 'value1', 'value2'.");
    }

    var result = Value1 + Value2.Value;
    CheckValue(result, "Values of operands must be numbers.");
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
      throw new InvalidOperationException("Two operands are required: 'value1', 'value2'.");
    }

    var result = Value1 - Value2.Value;
    CheckValue(result, "Values of operands must be numbers.");
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
      throw new InvalidOperationException("Two operands are required: 'value1', 'value2'.");
    }

    var result = Value1 * Value2.Value;
    CheckValue(result, "Values of operands must be numbers.");
    Result = result;
  }
}

class SquareRoot : Operation
{
  public SquareRoot(OperationDto operationDto) : base(operationDto) {}
  public override void Execute()
  {
    var result = Math.Sqrt(Value1);
    CheckValue(result, "Value of operand 'value1' must be at least 0.");
    Result = result;
  }
}