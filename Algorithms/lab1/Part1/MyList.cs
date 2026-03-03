using System.Text;

namespace Algorithms.lab1;

class MyList<T> {
	private T[] _data;

	public int Count { get; private set; }
	public T this[int index] {
		get {
			if (index < 0 || index >= this.Count) throw new IndexOutOfRangeException();
			return this._data[index];
		}
		set {
			if (index < 0 || index >= this.Count) throw new IndexOutOfRangeException();
			this._data[index] = value;
		}
	}

	public void Add(T value) {
		if (this.IsFull()) this._resize();

		this._data[this.Count] = value;
		this.Count++;
	}
	public void Insert(T value,int index) {
		if (index < 0 || index > this.Count) throw new IndexOutOfRangeException();
		if (this.IsFull()) this._resize();

		for (int i = this.Count; i > index; i--) {
			this._data[i] = this._data[i - 1];
		}
		this._data[index] = value;
		this.Count++;
	}
	public T Remove(int index) {
		if (index < 0 || index >= this.Count) throw new IndexOutOfRangeException();
		T val = this._data[index];
		for (int i = index; i < this.Count - 1; i++) {
			this._data[i] = this._data[i + 1];
		}
		this.Count--;
		this._data[this.Count] = default!;
		return val;
	}
	public bool Contains(T value) {
		for (int i = 0; i < this.Count; i++) {
			if (Equals(this._data[i],value)) return true;
		}
		return false;
	}
	public bool IsFull() => this.Count >= this._data.Length;
	public bool IsEmpty() => this.Count == 0;
	public IEnumerator<T> GetEnumerator() {
		for (int i = 0; i < this.Count; i++) {
			yield return this._data[i];
		}
	}
	public void Clear() {
		this._data = [];
		this.Count = 0;
	}
	public T[] ToArray() => this._data.ToArray();
	public override string ToString() {
		var result = new StringBuilder("[ ");
		foreach (var i in this) result.Append($"{i} ");
		result.Append(']');
		return result.ToString();
	}
	private void _resize() {
		T[] newArray = new T[this._data.Length < 1 ? 1 : this._data.Length * 2];

		for (int i = 0; i < this._data.Length; i++) {
			newArray[i] = this._data[i];
		}
		this._data = newArray;
	}

	public MyList(int capacity = 2) {
		if (capacity < 0) throw new ArgumentOutOfRangeException(nameof(capacity));
		this._data = new T[capacity];
		this.Count = 0;
	}
	public MyList(T[] elements) {
		this._data = new T[elements.Length];
		this.Count = elements.Length;
		for (int i = 0; i < elements.Length; i++) {
			this._data[i] = elements[i];
		}
	}
	public MyList(MyList<T> other) {
		this._data = new T[other.Count];
		this.Count = other.Count;
		for (int i = 0; i < other.Count; i++) {
			this._data[i] = other[i];
		}
	}
}