using System.Diagnostics.CodeAnalysis;
using System.Runtime.CompilerServices;

namespace ScheduleWidget.Domain.Graphic;

public sealed class ElementOverlappingException : Exception
{
	/// <summary>
	/// Throw exception with message "Element at index {firstIndex} ends later than element at index {secondIndex} starts".
	/// </summary>
	/// <param name="firstElementIndex">index of element which ends later</param>
	/// <param name="firstElementLabel">label of element which ends later</param>
	/// <param name="secondElementIndex">index of element which starts earlier</param>
	/// <param name="secondElementLabel">label of element which starts earlier</param>
	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	[DoesNotReturn]
	public static void Throw(int firstElementIndex, string firstElementLabel, int secondElementIndex, string secondElementLabel)
	{
		throw new ElementOverlappingException(firstElementIndex, firstElementLabel, secondElementIndex, secondElementLabel);
	}
	
	public int FirstElementIndex { get; }
	public string FirstElementLabel { get; }
	public int SecondElementIndex { get; }
	public string SecondElementLabel { get; }

	/// <param name="firstElementIndex">index of element which ends later</param>
	/// <param name="firstElementLabel">label of element which ends later</param>
	/// <param name="secondElementIndex">index of element which starts earlier</param>
	/// <param name="secondElementLabel">label of element which starts earlier</param>
	public ElementOverlappingException(int firstElementIndex, string firstElementLabel, int secondElementIndex, string secondElementLabel)
		: base(FormatMessage(firstElementIndex, firstElementLabel, secondElementIndex, secondElementLabel))
	{
		FirstElementIndex = firstElementIndex;
		FirstElementLabel = firstElementLabel;
		SecondElementIndex = secondElementIndex;
		SecondElementLabel = secondElementLabel;
	}

		private static string FormatMessage(int firstElementIndex, string firstElementLabel, int secondElementIndex, string secondElementLabel)
	{
		return $"Element #{firstElementIndex} \"{firstElementLabel}\" ends later than element #{secondElementIndex} \"{secondElementLabel}\" starts";
	}
}