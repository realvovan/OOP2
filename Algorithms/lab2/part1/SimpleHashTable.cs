using System.Text;

namespace Algorithms.lab2;

class KVPair<TKey,TValue>(TKey key,TValue value) {
	public TKey Key { get; } = key;
	public TValue Value { get; } = value;
}

class SimpleSquareHashTable {
	private Square[] _array;
	private int _size;

	public bool Insert(Square element) {
		int index = this._hash(element.GetPerimeter());
		int startIndex = index;
		while (this._array[index] is not null) {
			index = (index + 1) % this._size;
			if (index == startIndex) return false;
		}
		this._array[index] = element;
		return true;
	}
	public Square? GetSquare(float perimeter) {
		const float MARGIN = 0.001f;
		int index = this._hash(perimeter);
		int startIndex = index;
		do {
			var square = this._array[index];
			if (square is not null && MathF.Abs(square.GetPerimeter() - perimeter) < MARGIN) return square;
			index = (index + 1) % this._size;
		} while (index != startIndex);
		return null;
	}
	public void Clear() => this._array = new Square[this._size];
	public string GetFullContent() {
		var result = new StringBuilder("{\n");
		for (int i = 0; i < this._size; i++) result.Append($"\t[{i}] = {this._array[i]}\n");
		result.Append('}');
		return result.ToString();
	}
	public IEnumerator<KVPair<float,Square>> GetEnumerator() {
		foreach (var square in this._array) {
			yield return new KVPair<float, Square>(square.GetPerimeter(),square);
		}
	}
	private int _hash(float key) => (int)key % this._size;

	public SimpleSquareHashTable(int size = 4) {
		this._array = new Square[size];
		this._size = size;
	}
}
