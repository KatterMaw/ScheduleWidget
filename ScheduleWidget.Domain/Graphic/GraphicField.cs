using System.Collections.Immutable;

namespace ScheduleWidget.Domain.Graphic;

public sealed class GraphicField
{
	public static GraphicField Empty { get; } = new(ImmutableList<Layer>.Empty);
	
	public ImmutableSortedSet<Element> Elements { get; }
	public ImmutableList<Layer> Layers { get; }
	public DateTime Start { get; }
	public DateTime End { get; }

	public GraphicField(IEnumerable<Layer> layers)
	{
		Layers = layers.ToImmutableList();
		
		// ISSUE Must be EXTREMELY expensive with many elements
		// TODO add Layer property, so it won't distinct elements with equal dates
		Elements = Layers.SelectMany(layer => layer.Elements).ToImmutableSortedSet(new ElementStartDateComparer());
		
		// could be used with Elements.First() and Elements.Last() instead of accessing by index,
		// but Last() shall iterate over all elements (which of can be like 1000 and much more elements),
		// which is way more expensive than accessing by index.
		// But although First() is cheap enough (especially in this place, this code should not be called often),
		// still use indexes for uniformity.
		Start = Layers.Min(layer => layer.Elements[0].Start);
		End = Layers.Max(layer => layer.Elements[^1].End);
	}
}