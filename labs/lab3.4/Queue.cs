namespace lab3_4;

public class MyQueue<T> {
	private readonly LinkedList<T> elements;
	public int Length => this.elements.Count;
	public event EventHandler? QueueCleared;
	public event EventHandler<QueueChangedEventArgs<T>>? ElementAdded;
	public event EventHandler<QueueChangedEventArgs<T>>? ElementRemoved;

	public void Enqueue(T element) {
		this.elements.AddLast(element);
		this.ElementAdded?.Invoke(this, new QueueChangedEventArgs<T>(element));
	}
	public T Pop() {
		if (this.elements.Count == 0) throw new InvalidOperationException("Queue is empty");
		T element = this.elements.First!.Value;
		this.elements.RemoveFirst();
		this.ElementRemoved?.Invoke(this,new QueueChangedEventArgs<T>(element));
		if (this.elements.Count == 0) this.onQueueCleared();
		return element;
	}
	public T Peek() {
		var first = this.elements.First;
		if (first == null) throw new InvalidOperationException("Queue is empty");
		return first.Value;
	}
	public void Clear() {
		this.elements.Clear();
		this.onQueueCleared();
	}
	public MyQueue() {
		this.elements = new LinkedList<T>();
	}
	public MyQueue(T element) {
		this.elements = new LinkedList<T>();
		this.elements.AddLast(element);
	}
	public MyQueue(IEnumerable<T> elements) {
		this.elements = new LinkedList<T>(elements);
	}

	private void onQueueCleared() {
		this.QueueCleared?.Invoke(this, EventArgs.Empty);
	}
}

public class QueueChangedEventArgs<T>(T element) : EventArgs {
	public T Element { get; } = element;
}