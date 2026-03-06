using System.Text;

namespace Algorithms.lab2;

class MyHashTable {
	private LinkedList<Square>[] _list;
	private int _size;
	public int Count { get; private set; }

	public bool Insert(Square element) {
		float perimeter = element.GetPerimeter();
		int index = this._hash(perimeter);
		foreach (var square in this._list[index]) {
			if (comparePerimeters(square.GetPerimeter(),perimeter)) return false;
		}
		this._list[index].AddLast(element);
		this.Count++;
		return true;
	}
	public Square? GetSquare(float perimeter) {
		foreach (var square in this._list[this._hash(perimeter)]) {
			if (comparePerimeters(square.GetPerimeter(),perimeter)) return square;
		}
		return null;
	}
	public void Clear() {
		foreach (var list in this._list) {
			list.Clear();
		}
	}
	public string GetFullContent() {
		var result = new StringBuilder("{\n");
		for (int i = 0; i < this._size; i++) {
			var list = this._list[i];
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
	public IEnumerator<KVPair<float,Square>> GetEnumerator() {
		foreach (var list in this._list) {
			foreach (var square in list) {
				yield return new KVPair<float, Square>(square.GetPerimeter(),square);
			}
		}
	}
	#region Part 3 code
	public void RemoveWhere(Predicate<Square> predicate) {
		foreach (var list in this._list) {
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
	private int _hash(float key) => (int)key % this._size;

	public MyHashTable(int buckets = 4) {
		this._list = new LinkedList<Square>[buckets];
		this._size = buckets;
		this.Count = 0;
		for (int i = 0; i < buckets; i++) this._list[i] = new LinkedList<Square>();
	}

	static bool comparePerimeters(float perimeter1,float perimeter2) {
		float margin = 0.001f;
		return MathF.Abs(perimeter1 - perimeter2) < margin;
	}
}