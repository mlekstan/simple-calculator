namespace swi.Tests;

public class SubtractionTests
{
  [Theory]
  [InlineData(3, 8, -5)]
  public void Execute_RealNumbers_ReturnsDifferenceOfNumbers(double rawValue1, double value2, double expected)
  {
    const OperatorType OPERATOR = OperatorType.sub;
    var operationDto = new OperationDto(OPERATOR, rawValue1, value2);
    var subtraction = new Subtraction(operationDto);

    subtraction.Execute();

    Assert.Equal(expected, subtraction.Result);
  }

  [Theory]
  [InlineData(double.NaN, 4)]
  [InlineData(double.NaN, double.NaN)]
  [InlineData(double.NaN, -4)]
  [InlineData(double.PositiveInfinity, 4)]
  [InlineData(double.PositiveInfinity, double.NegativeInfinity)]
  [InlineData(double.PositiveInfinity, -4)]
  public void Execute_InfinityAndNaN_ThrowsIvalidOperationException(double rawValue1, double value2)
  {
    const OperatorType OPERATOR = OperatorType.sub;
    var operationDto = new OperationDto(OPERATOR, rawValue1, value2);
    var subtraction = new Subtraction(operationDto);

    Action action = () => subtraction.Execute();

    Assert.Throws<InvalidOperationException>(action);
  }

  [Theory]
  [InlineData(3, null)]
  [InlineData(double.NaN, null)]
  public void Execute_Value2IsNull_ThrowsInvalidOperationException(double rawValue1, double? value2)
  {
    const OperatorType OPERATOR = OperatorType.sub;
    var operationDto = new OperationDto(OPERATOR, rawValue1, value2);
    var addition = new Addition(operationDto);

    Action action = () => addition.Execute();

    Assert.Throws<InvalidOperationException>(action);
  }
}