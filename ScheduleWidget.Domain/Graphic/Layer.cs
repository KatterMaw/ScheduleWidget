using System.Collections.Immutable;

namespace ScheduleWidget.Domain.Graphic;

public sealed class Layer
{
	public ImmutableSortedSet<Element> Elements { get; }

	public Layer(IEnumerable<Element> elements)
	{
		Elements = elements.ToImmutableSortedSet(new ElementStartDateComparer());
		EnsureNoOverlappingElements();
	}

	private void EnsureNoOverlappingElements()
	{
		for (var currentIndex = 0; currentIndex < Elements.Count - 1; currentIndex++)
		{
			var nextIndex = currentIndex + 1;
			EnsureNoOverlapping(currentIndex, nextIndex);
			// Also it can be done in a while loop and single line in it (but it looks less obvious and straightforward):
			// int currentIndex = 0;
			// while (currentIndex < Elements.Count - 1)
			// 	EnsureNoOverlapping(currentIndex, ++currentIndex);
		}
	}

	private void EnsureNoOverlapping(int firstIndex, int secondIndex)
	{
		var firstElement = Elements[firstIndex];
		var secondElement = Elements[secondIndex];
		if (firstElement.End > secondElement.Start)
			ElementOverlappingException.Throw(firstIndex, firstElement.Label, secondIndex, secondElement.Label);
	}
}