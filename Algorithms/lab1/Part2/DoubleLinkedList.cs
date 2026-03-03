using System.Reflection.Metadata.Ecma335;
using System.Text;

namespace Algorithms.lab1;

class Node<T> {
	public T Data;
	public Node<T>? Next;
	public Node<T>? Prev;
	public Node(T value) {
		this.Data = value;
	}
}

class DoubleLinkedList<T> {
	private Node<T>? _head;
	private Node<T>? _tail;

	public int Count { get; private set; }
	public T this[int index] {
		get => this._getNodeAtIndex(index).Data;
		set => this._getNodeAtIndex(index).Data = value;
	}

	public void AddFirst(T value) {
		var newNode = new Node<T>(value);
		if (this._head == null) {
			this._head = newNode;
			this._tail = newNode;
		} else {
			newNode.Next = this._head;
			this._head.Prev = newNode;
			this._head = newNode;
		}
		this.Count++;
	}
	public void AddLast(T value) {
		var newNode = new Node<T>(value);
		if (this._tail == null) {
			this._head = newNode;
			this._tail = newNode;
		} else {
			newNode.Prev = this._tail;
			this._tail.Next = newNode;
			this._tail = newNode;
		}
		this.Count++;
	}
	public T Remove(int index) {
		if (index == 0) return this.RemoveFirst();
		if (index == this.Count - 1) return this.RemoveLast();
		var node = this._getNodeAtIndex(index);
		node.Prev!.Next = node.Next;
		node.Next!.Prev = node.Prev;
		this.Count--;
		return node.Data;
	}
	public void Insert(T value,int index) {
		if (index == 0) {
			this.AddFirst(value);
			return;
		}
		if (index == this.Count) {
			this.AddLast(value);
			return;
		}
		var node = this._getNodeAtIndex(index);
		var newNode = new Node<T>(value) {
			Prev = node.Prev,
			Next = node
		};
		newNode.Prev!.Next = newNode;
		newNode.Next!.Prev = newNode;
		this.Count++;
	}
	public T RemoveFirst() {
		if (this._head is null) throw new InvalidOperationException("List is empty");
		T value = this._head.Data;
		this._head = this._head.Next;

		if (this._head is not null) {
			this._head.Prev!.Next = null;
			this._head.Prev = null;
		} else {
			this._tail = null;
		}

		this.Count--;

		return value;
	}
	public T RemoveLast() {
		if (this._tail is null) throw new InvalidOperationException("List is empty");
		T value = this._tail.Data;
		this._tail = this._tail.Prev;

		if (this._tail is not null) {
			this._tail.Next!.Prev = null;
			this._tail.Next = null;
		} else {
			this._head = null;
		}

		this.Count--;

		return value;
	}
	public IEnumerator<T> GetEnumerator() {
		var node = this._head;
		while (node is not null) {
			yield return node.Data;
			node = node.Next;
		}
	}
	public bool IsEmpty() => this.Count == 0;
	public override string ToString() {
		var result = new StringBuilder("[ ");
		foreach (var value in this) {
			result.Append($"{value} ");
		}
		result.Append(']');
		return result.ToString();
	}
	private Node<T> _getNodeAtIndex(int index) {
		if (index < 0 || index >= this.Count) throw new IndexOutOfRangeException();
		var node = this._head;
		while (index-- > 0) {
			node = node!.Next;
		}
		return node!;
	}

	public DoubleLinkedList() {
		this.Count = 0;
	}
	public DoubleLinkedList(T[] elements) {
		this.Count = 0;
		foreach (var i in elements) this.AddLast(i);
	}
}