using System.Text;

namespace Algorithms.lab2;


class MyHashtable<TKey,TValue> where TKey : notnull {
	private LinkedList<KVPair<TKey,TValue>>[] _buckets;
	private int _size;
	public int Count { get; private set; }

	public bool Insert(TKey key,TValue value) {
		var bucket = this._buckets[this._hash(key)];
		foreach (var kv in bucket) {
			if (kv.Key.Equals(key)) return false;
		}
		bucket.AddLast(new KVPair<TKey,TValue>(key,value));
		this.Count++;
		return true;
	}
	public TValue? ElementAt(TKey key) {
		var bucket = this._buckets[this._hash(key)];
		foreach (var kv in bucket) {
			if (kv.Key.Equals(key)) return kv.Value;
		}
		return default;
	}
	public bool RemoveAt(TKey key) {
		var bucket = this._buckets[this._hash(key)];
		var node = bucket.First;
		while (node is not null) {
			if (node.Value.Key.Equals(key)) {
				bucket.Remove(node);
				return true;
			}
			node = node.Next;
		}
		return false;
	}
	#region Part 3 code
	public void RemoveWhere(Predicate<KVPair<TKey,TValue>> predicate) {
		foreach (var list in this._buckets) {
			var node = list.First;
			while (node is not null) {
				var next = node.Next;
				if (predicate(node.Value)) {
					list.Remove(node);
					this.Count--;
				}
				node = next;
			}
		}
	}
	#endregion
	public void Clear() {
		this._buckets = new LinkedList<KVPair<TKey,TValue>>[this._size];
		for (int i = 0; i < this._size; i++) {
			this._buckets[i] = new();
		}
		this.Count = 0;
	}
	public string GetFullContent() {
		var result = new StringBuilder("{\n");
		for (int i = 0; i < this._size; i++) {
			var list = this._buckets[i];
			if (list.Count == 0) result.Append($"\t[{i}] = null\n");
			else {
				result.Append($"\t[{i}] = [\n");
				foreach (var square in list) {
					result.Append($"\t\t{square}\n");
				}
				result.Append($"\t]\n");
			}
		}
		result.Append('}');
		return result.ToString();
	}
	public IEnumerator<KVPair<TKey,TValue>> GetEnumerator() {
		foreach (var bucket in this._buckets) {
			foreach (var kv in bucket) {
				yield return kv;
			}
		}
	}
	private int _hash(TKey key) => Math.Abs(key.GetHashCode()) % this._size;

	public MyHashtable(int buckets = 4) {
		ArgumentOutOfRangeException.ThrowIfNegativeOrZero(buckets);
		this.Count = 0;
		this._size = buckets;
		this._buckets = new LinkedList<KVPair<TKey,TValue>>[buckets];
		for (int i = 0; i < buckets; i++) {
			this._buckets[i] = new();
		}
	}
}