namespace ScheduleWidget.Domain.Graphic;

public sealed class ElementStartDateComparer : IComparer<Element>
{
	public int Compare(Element? first, Element? second)
	{
		if (ReferenceEquals(first, second))
			return 0;
		if (ReferenceEquals(null, second))
			return 1;
		if (ReferenceEquals(null, first))
			return -1;
		return first.Start.CompareTo(second.Start);
	}
}