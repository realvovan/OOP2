using System.Threading.Channels;
using SoftwareDesign.lab2.Models;

namespace SoftwareDesign.lab2.Services;

public class QueueService {
	private readonly Channel<Message> _queue = Channel.CreateUnbounded<Message>();

	public async Task EnqueueAsync(Message message) => await this._queue.Writer.WriteAsync(message);
	public IAsyncEnumerable<Message> DequeueAllAsync() => this._queue.Reader.ReadAllAsync();
}