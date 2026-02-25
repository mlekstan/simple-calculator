namespace swi.Tests;

public class SquareRootTests
{
  [Theory]
  [InlineData(16, null, 4)]
  [InlineData(16, -5, 4)]
  public void Execute_RealNumber_ReturnsRootOfNumber(double rawValue1, double? value2, double expected)
  {
    const OperatorType OPERATOR = OperatorType.sqrt;
    var operationDto = new OperationDto(OPERATOR, rawValue1, value2);
    var squareRoot = new SquareRoot(operationDto);

    squareRoot.Execute();

    Assert.Equal(expected, squareRoot.Result);
  }

  [Theory]
  [InlineData(double.PositiveInfinity, null)]
  [InlineData(double.NaN, null)]
  [InlineData(-5, null)]
  public void Execute_NotNumberHigherOrEqualToZero_ThrowsInvalid(double rawValue1, double? value2)
  {
    const OperatorType OPERATOR = OperatorType.sqrt;
    var operationDto = new OperationDto(OPERATOR, rawValue1, value2);
    var squareRoot = new SquareRoot(operationDto);

    Action action = () => squareRoot.Execute();

    Assert.Throws<InvalidOperationException>(action);    
  }
}