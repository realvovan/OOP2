using System.Reflection.Metadata.Ecma335;
using System.Text;

namespace Algorithms.lab1;

class DoubleLinkedList<T> {
	public class Node {
		public T Data { get; set; }
		public Node? Next { get; internal set; }
		public Node? Prev { get; internal set; }
		public DoubleLinkedList<T>? Parent { get; internal set; }
		public Node(T value,DoubleLinkedList<T> parent) {
			this.Data = value;
			this.Parent = parent;
		}
}
	private Node? _head;
	private Node? _tail;

	public int Count { get; private set; }
	public Node? First => this._head;
	public Node? Last => this._tail;

	public void AddFirst(T value) {
		var newNode = new Node(value,this);
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
		var newNode = new Node(value,this);
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
	public Node GetNode(int index) {
		if (index < 0 || index >= this.Count) throw new IndexOutOfRangeException();
		var node = this._head;
		while (index-- > 0) {
			node = node!.Next;
		}
		return node!;
	}
	public void Remove(Node node) {
		if (this != node.Parent) throw new ArgumentException("The node does not belong to this list",nameof(node));
		if (node.Prev is null) {
			this.RemoveFirst();
			return;
		}
		if (node.Next is null) {
			this.RemoveLast();
			return;
		}
		node.Prev.Next = node.Next;
		node.Next.Prev = node.Prev;
		node.Next = null;
		node.Prev = null;
		node.Parent = null;
		this.Count--;
	}
	public void InsertAfter(T value,Node node) {
		if (this != node.Parent) throw new ArgumentException("The node does not belong to this list",nameof(node));
		if (node.Next is null) {
			this.AddLast(value);
			return;
		}
		var newNode = new Node(value,this) {
			Prev = node,
			Next = node.Next
		};
		node.Next = newNode;
		newNode.Next!.Prev = newNode;
		this.Count++;
	}
	public void InsertBefore(T value,Node node) {
		if (this != node.Parent) throw new ArgumentException("The node does not belong to this list",nameof(node));
		if (node.Prev is null) {
			this.AddFirst(value);
			return;
		}
		var newNode = new Node(value,this) {
			Next = node,
			Prev = node.Prev
		};
		node.Prev = newNode;
		newNode.Prev!.Next = newNode;
		this.Count++;
	}
	public T RemoveFirst() {
		if (this._head is null) throw new InvalidOperationException("List is empty");
		T value = this._head.Data;
		this._head = this._head.Next;

		if (this._head is not null) {
			this._head.Prev!.Next = null;
			this._head.Prev.Parent = null;
			this._head.Prev = null;
		} else {
			this._tail!.Parent = null;
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
			this._tail.Next.Parent = null;
			this._tail.Next = null;
		} else {
			this._head!.Parent = null;
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

	public DoubleLinkedList() {
		this.Count = 0;
	}
	public DoubleLinkedList(T[] elements) {
		this.Count = 0;
		foreach (var i in elements) this.AddLast(i);
	}
}