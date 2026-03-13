namespace Algorithms.lab2;

public class KVPair<TKey,TValue>(TKey key,TValue value) where TKey : notnull {
	public TKey Key { get; } = key;
	public TValue Value { get; } = value;
	public override string ToString() => $"[Key: {this.Key}, Value: {this.Value}]";
}
