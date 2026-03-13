namespace Algorithms.lab3;

class BinaryTree<T> where T : IComparable<T> {
	public class Node(T value,Node? parent,BinaryTree<T> tree) {
		public T Value { get; internal set; } = value;
		public Node? Left { get; internal set; }
		public Node? Right { get; internal set; }
		public Node? Parent { get; internal set; } = parent;
		public BinaryTree<T>? Tree { get; internal set; } = tree;
	}
	private Node? _root;
	public Node? Root => this._root;
	public void Insert(T element) => this._root = this._recursiveInsert(element,this._root,null);
	private Node _recursiveInsert(T element,Node? node,Node? parent) {
		if (node is null) return new Node(element,parent,this);
		int compared = element.CompareTo(node.Value);
		if (compared < 0) {
			node.Left = this._recursiveInsert(element,node.Left,node);
		} else if (compared > 0) {
			node.Right = this._recursiveInsert(element,node.Right,node);
		} else {
			throw new InvalidOperationException("Cannot add an element with the same key");
		}
		return node;
	}
	public IEnumerator<Node> GetEnumerator() => _traverseNode(this._root).GetEnumerator();
	private static IEnumerable<Node> _traverseNode(Node? node) {
		if (node is null) yield break;
		if (node.Left is not null) {
			foreach (var i in _traverseNode(node.Left)) yield return i;
		}
		yield return node;
		if (node.Right is not null) {
			foreach (var i in _traverseNode(node.Right)) yield return i;
		}
	}
	#region PART 2
	public IEnumerable<Node> Where(Predicate<T> predicate) {
		var list = new List<Node>();
		foreach (var i in this) {
			if (predicate(i.Value)) list.Add(i);
		}
		return list;
	}
	#endregion
	#region PART 3
	public void Remove(Node node) {
		if (this != node.Tree) throw new ArgumentException("The node does not belong to this tree",nameof(node));
		// 2 children
		if (node.Left is not null && node.Right is not null) {
			Node successor = node.Right;
			while (successor.Left is not null) {
				successor = successor.Left;
			}
			node.Value = successor.Value;
			this.Remove(successor);
			return;
		}
		// 0 or 1 child
		Node? child = node.Left ?? node.Right;
		// removing the root
		if (node.Parent is null) {
			this._root = child;
			if (child is not null) {
				child.Parent = null;
			}
			return;
		}
		// replacing node in parent;
		if (node.Parent.Left == node) {
			node.Parent.Left = child;
		} else {
			node.Parent.Right = child;
		}
	}
	#endregion
	// private Node<T> root = null!;

	// public void Insert(T element) => this.root = _recursiveInsert(this.root,element);
	// public IEnumerator<Node<T>> GetEnumerator() => _traverseNode(this.root).GetEnumerator();
	// // PART 2 CODE
	// public IEnumerable<Node<T>> Where(Predicate<T> predicate) {
	// 	var list = new List<Node<T>>();
	// 	foreach (var i in this) {
	// 		if (predicate(i.Value)) list.Add(i);
	// 	}
	// 	return list;
	// }
	// //
	// // PART 3 CODE
	// public void RemoveAllWhere(Predicate<T> predicate) {
	// 	while (true) {
	// 		Node<T> parent = null!;
	// 		Node<T> node = this.root;
	// 		if (_findNode(this.root,null,predicate,ref node,ref parent)) {
	// 			this._deleteNode(node,parent);
	// 		} else break;
	// 	}
	// }
	// private static bool _findNode(Node<T> current,Node<T> parent,Predicate<T> predicate,ref Node<T> found,ref Node<T> foundParent) {
	// 	if (current is null)
	// 		return false;
	// 	if (predicate(current.Value)) {
	// 		found = current;
	// 		foundParent = parent;
	// 		return true;
	// 	}
	// 	return _findNode(current.Left,current,predicate,ref found,ref foundParent)
	// 		|| _findNode(current.Right,current,predicate,ref found,ref foundParent);
	// }
	// private void _deleteNode(Node<T> node,Node<T> parent) {
	// 	// node has 0 or 1 child
	// 	if (node.Left is null || node.Right is null) {
	// 		Node<T> child = (node.Left ?? node.Right)!;

	// 		if (parent is null)
	// 			this.root = child;
	// 		else if (parent.Left == node)
	// 			parent.Left = child;
	// 		else
	// 			parent.Right = child;
	// 		return;
	// 	}

	// 	// node has two children
	// 	Node<T> successorParent = node;
	// 	Node<T> successor = node.Right;

	// 	while (successor.Left is not null) {
	// 		successorParent = successor;
	// 		successor = successor.Left;
	// 	}

	// 	node.Value = successor.Value;

	// 	if (successorParent.Left == successor)
	// 		successorParent.Left = successor.Right;
	// 	else
	// 		successorParent.Right = successor.Right;
	// }

	// }
}