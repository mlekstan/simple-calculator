namespace swi.Tests;

public class MultiplicationTests
{
  [Fact]
  public void Execute_RealNumbers_ReturnsProductOfNumbers()
  {
    const OperatorType OPERATOR = OperatorType.mul;
    var operationDto = new OperationDto(OPERATOR, 4, 5);
    var multiplication = new Multiplication(operationDto);

    multiplication.Execute();

    Assert.Equal(20, multiplication.Result);
  }

  [Theory]
  [InlineData(double.NaN, 6)]
  [InlineData(double.NaN, double.NaN)]
  [InlineData(double.NaN, -5)]
  [InlineData(double.PositiveInfinity, 4)]
  [InlineData(double.PositiveInfinity, double.NegativeInfinity)]
  [InlineData(double.PositiveInfinity, -3)]
  public void Execute_InfinityAndNaN_ThrowsIvalidOperationException(double rawValue1, double value2)
  {
    const OperatorType OPERATOR = OperatorType.mul;
    var operationDto = new OperationDto(OPERATOR, rawValue1, value2);
    var subtraction = new Subtraction(operationDto);

    Action action = () => subtraction.Execute();

    Assert.Throws<InvalidOperationException>(action);
  }

  [Theory]
  [InlineData(6, null)]
  [InlineData(double.NaN, null)]
  public void Execute_Value2IsNull_ThrowsInvalidOperationException(double rawValue1, double? value2)
  {
    const OperatorType OPERATOR = OperatorType.mul;
    var operationDto = new OperationDto(OPERATOR, rawValue1, value2);
    var addition = new Addition(operationDto);

    Action action = () => addition.Execute();

    Assert.Throws<InvalidOperationException>(action);
  }
}