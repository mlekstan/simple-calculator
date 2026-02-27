namespace swi.Tests;

public class AdditionTests
{
  [Theory]
  [InlineData(2, 3, 5)]
  public void Execute_RealNumbers_ReturnsSumOfNumbers(double rawValue1, double value2, double expected)
  {
    const OperatorType OPERATOR = OperatorType.add;
    var operationDto = new OperationDto(OPERATOR, rawValue1, value2);
    var addition = new Addition(operationDto);

    addition.Execute();

    Assert.Equal(expected, addition.Result);
  }

  [Theory]
  [InlineData(double.NaN, 3)]
  [InlineData(double.NaN, double.NaN)]
  [InlineData(double.NaN, -3)]
  [InlineData(double.PositiveInfinity, 3)]
  [InlineData(double.PositiveInfinity, double.NegativeInfinity)]
  [InlineData(double.PositiveInfinity, -3)]
  public void Execute_InfinityAndNaN_ThrowsInvalidOperationException(double rawValue1, double value2)
  {
    const OperatorType OPERATOR = OperatorType.add;
    var operationDto = new OperationDto(OPERATOR, rawValue1, value2);
    var addition = new Addition(operationDto);

    Action action = () => addition.Execute();

    Assert.Throws<InvalidOperationException>(action);
  }

  [Theory]
  [InlineData(3, null)]
  [InlineData(double.NaN, null)]
  public void Execute_Value2IsNull_ThrowsInvalidOperationException(double rawValue1, double? value2)
  {
    const OperatorType OPERATOR = OperatorType.add;
    var operationDto = new OperationDto(OPERATOR, rawValue1, value2);
    var addition = new Addition(operationDto);

    Action action = () => addition.Execute();

    Assert.Throws<InvalidOperationException>(action);
  }
}