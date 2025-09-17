using System.Collections;
using System.Drawing;

namespace lab3_2;

class Program {
	static void Main() {
		//===================
		// Generic collection
		//===================
		Console.WriteLine(new string('=',10));
		Console.WriteLine("Generic list");
		List<Trapezoid> genericList = [
			new Trapezoid(10,5,4),
			new Trapezoid(8,2,1),
			new Trapezoid(14,10,6),
			new Trapezoid(15,5,4),
		];
		// Adding an element
		genericList.Add(new Trapezoid(1,2,3));
		// Removing an element
		genericList.RemoveAt(4);
		// Updating an element
		genericList[3] = new Trapezoid(20,15,10);
		// Element look up
		Trapezoid? found = genericList.Find(t => t.Base1 == 8);
		if (found == null) Console.WriteLine("not found");
		else Console.WriteLine(found.ToString());
		Console.WriteLine(new string('=',10));
		// Looping over the elements
		foreach (var i in genericList) {
			Console.WriteLine(i.ToString());
		}
		//===================
		// Non generic collection
		//===================
		Console.WriteLine(new string('=',10));
		Console.WriteLine("Non generic list");
		ArrayList nonGenericList = new(4);
		// Populating the array with previous entries
		foreach (var i in genericList) nonGenericList.Add(i);
		// Adding an element
		nonGenericList.Add(new Trapezoid(2,3,4));
		// Removing an element
		nonGenericList.RemoveAt(4);
		// Updating an element
		nonGenericList[3] = new Trapezoid(13,8,3);
		// Element look up (no built in find function) + looping over the list
		foreach (var i in nonGenericList) {
			if (i is Trapezoid tr) {
				if (tr.Height == 1) {
					Console.WriteLine(tr.ToString());
				}
			}
		}
		//===================
		// Array
		//===================
		Console.WriteLine(new string('=',10));
		Console.WriteLine("Array");
		var array = new Trapezoid[4];
		for (int i = 0; i < genericList.Count && i < array.Length; i++) {
			array[i] = genericList[i];
		}
		// Adding an element
		array = [..array,new Trapezoid(5,6,7)];
		// Removing an element
		array = array.Where((_,index) => index != 4).ToArray();
		// Updating an element
		array[3] = new Trapezoid(19,9,5);
		// Element look up (also no built in method) + looping over the array
		foreach (var i in array) {
			if (i.Base2 == 9) {
				Console.WriteLine(i.ToString());
			}
		}
		nonGenericList.Clear();
		array = [];
		//===================
		// Binary tree
		//===================
		Console.WriteLine(new string('=',10));
		Console.WriteLine("Binary tree");
		var binaryTree = new BinaryTree<Trapezoid>(genericList);
		binaryTree.Insert(new Trapezoid(96,54,12));
		binaryTree.Insert(new Trapezoid(3,2,0.5));
		foreach (var i in binaryTree) Console.WriteLine(i.ToString());
	}
}