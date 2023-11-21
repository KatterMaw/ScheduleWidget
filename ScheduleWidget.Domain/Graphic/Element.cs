namespace ScheduleWidget.Domain.Graphic;

public sealed class Element
{
	public DateTime Start { get; }
	public DateTime End { get; }
	public string Label { get; }
	public ElementType Type { get; }

	public Element(DateTime start, DateTime end, string label, ElementType type)
	{
		Start = start;
		End = end;
		Label = label;
		Type = type;
	}
}