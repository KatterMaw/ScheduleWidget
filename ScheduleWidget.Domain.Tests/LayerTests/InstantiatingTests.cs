using ScheduleWidget.Domain.Graphic;

namespace ScheduleWidget.Domain.Tests.LayerTests;

public sealed class InstantiatingTests
{
	[Theory]
	[InlineData(0, 1, 1, 2)]
	[InlineData(0, 1)]
	[InlineData(0, 1, 3, 10, 10, 11)]
	public void ShouldNotThrowElementOverlappingException(params int[] elementsTimeData)
	{
		var elements = CreateElements(elementsTimeData);
		_ = new Layer(elements);
	}

	[Theory]
	[InlineData(0, 1, 0, 2, 1, 2)]
	public void ShouldThrowElementOverlappingException(int expectedFirstElementIndex, int expectedSecondElementIndex, params int[] elementsTimeData)
	{
		var elements = CreateElements(elementsTimeData);
		var exception = Assert.Throws<ElementOverlappingException>(() => new Layer(elements));
		exception.FirstElementIndex.Should().Be(expectedFirstElementIndex);
		exception.SecondElementIndex.Should().Be(expectedSecondElementIndex);
	}
	
	private IEnumerable<Element> CreateElements(IEnumerable<int> timeData)
	{
		return timeData.Chunk(2).Select(CreateElement);
	}

	private Element CreateElement(int[] timeData)
	{
		return CreateElement(timeData[0], timeData[1]);
	}

	private Element CreateElement(int startMinutes, int endMinutes)
	{
		return CreateElement(_baseTime.AddMinutes(startMinutes), _baseTime.AddMinutes(endMinutes));
	}
	
	private Element CreateElement(DateTime start, DateTime end)
	{
		return new Element(start, end, "Test element", ElementType.Completed);
	}

	private readonly DateTime _baseTime = DateTime.MinValue;
}