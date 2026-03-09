using System.Xml.Linq;

namespace Algorithms.lab3;

class Node<T>(T value) {
	public T Value { get; set; } = value;
	public Node<T> Left { get; set; }
	public Node<T> Right { get; set; }
}

class BinaryTree<T> where T : IComparable<T> {
	private Node<T> root = null!;

	public void Insert(T element) => this.root = _recursiveInsert(this.root,element);
	public IEnumerator<Node<T>> GetEnumerator() => _traverseNode(this.root).GetEnumerator();
	// PART 2 CODE
	public IEnumerable<Node<T>> Where(Predicate<T> predicate) {
		var list = new List<Node<T>>();
		foreach (var i in this) {
			if (predicate(i.Value)) list.Add(i);
		}
		return list;
	}
	//
	// PART 3 CODE
	public void RemoveAllWhere(Predicate<T> predicate) {
		while (true) {
			Node<T> parent = null!;
			Node<T> node = this.root;
			if (_findNode(this.root,null,predicate,ref node,ref parent)) {
				this._deleteNode(node,parent);
			} else break;
		}
	}
	private static bool _findNode(Node<T> current,Node<T> parent,Predicate<T> predicate,ref Node<T> found,ref Node<T> foundParent) {
		if (current is null)
			return false;
		if (predicate(current.Value)) {
			found = current;
			foundParent = parent;
			return true;
		}
		return _findNode(current.Left,current,predicate,ref found,ref foundParent)
			|| _findNode(current.Right,current,predicate,ref found,ref foundParent);
	}
	private void _deleteNode(Node<T> node,Node<T> parent) {
		// node has 0 or 1 child
		if (node.Left is null || node.Right is null) {
			Node<T> child = (node.Left ?? node.Right)!;

			if (parent is null)
				this.root = child;
			else if (parent.Left == node)
				parent.Left = child;
			else
				parent.Right = child;
			return;
		}

		// node has two children
		Node<T> successorParent = node;
		Node<T> successor = node.Right;

		while (successor.Left is not null) {
			successorParent = successor;
			successor = successor.Left;
		}

		node.Value = successor.Value;

		if (successorParent.Left == successor)
			successorParent.Left = successor.Right;
		else
			successorParent.Right = successor.Right;
	}
	private static Node<T> _recursiveInsert(Node<T> node,T element) {
		if (node is null) return new Node<T>(element);
		if (element.CompareTo(node.Value) < 0) {
			node.Left = _recursiveInsert(node.Left,element);
		} else {
			node.Right = _recursiveInsert(node.Right,element);
		}
		return node;
	}
	private static IEnumerable<Node<T>> _traverseNode(Node<T> node) {
		if (node is null) yield break;
		if (node.Left is not null) {
			foreach (var i in _traverseNode(node.Left)) yield return i;
		}
		yield return node;
		if (node.Right is not null) {
			foreach (var i in _traverseNode(node.Right)) yield return i;
		}
	}
}