namespace Bitlush
{
	public sealed class AvlNode<TKey, TValue>
	{
		public AvlNode<TKey, TValue> Parent;
		public AvlNode<TKey, TValue> Left;
		public AvlNode<TKey, TValue> Right;
		public TKey Key;
		public TValue Value;
		public int Balance;
	}
}
