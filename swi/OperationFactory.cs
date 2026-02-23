class OperationFactory
{
  private readonly Dictionary<OperatorType, Func<OperationDto, Operation>> _decisionDict = new()
  {
    { OperatorType.add, operationDto => new Addition(operationDto) }, 
    { OperatorType.sub, operationDto => new Subtraction(operationDto) },
    { OperatorType.mul, operationDto => new Multiplication(operationDto) },
    { OperatorType.sqrt, operationDto => new SquareRoot(operationDto) }
  };

  public Operation CreateOperation(OperationDto operationDto)
  {
    if (this._decisionDict.TryGetValue(operationDto.Operator, out Func<OperationDto, Operation> create))
    {
      return create(operationDto);
    }

    throw new Exception($"Operacja {operationDto.Operator} nie istnieje.");
  }
}