namespace swi.Tests;

public class OperationFactoryTests
{
  [Theory]
  [InlineData(typeof(Addition), OperatorType.add)]
  [InlineData(typeof(Subtraction), OperatorType.sub)]
  [InlineData(typeof(Multiplication), OperatorType.mul)]
  [InlineData(typeof(SquareRoot), OperatorType.sqrt)]
  public void CreateOperation(Type type, OperatorType @operator)
  {
    // Arrange
    var operationDto = new OperationDto(@operator, 1, null);
    var operationFactory = new OperationFactory();
    
    // Act
    var operation = operationFactory.CreateOperation(operationDto);

    // Assert
    Assert.IsType(type, operation);
  }
}