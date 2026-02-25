using System.Text.Json;

namespace swi.Tests;

public class OperationDtoTests
{
  [Theory]
  [InlineData(null, 3, 4)]
  [InlineData(OperatorType.mul, null, 5)]
  [InlineData(null, null, null)]
  public void OperatonDto_RequiredFields_ThrowsJsonException(OperatorType? rawOperator, double? rawValue1, double? value2)
  {
    Action action = () => new OperationDto(rawOperator, rawValue1, value2);

    Assert.Throws<JsonException>(action);
  }
}