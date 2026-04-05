namespace Algorithms.lab5;

static class InterpolationSearcher {
	public static int Search<T>(
		T[] array,
		int key,
		Func<T,int> keySelector,
		int start = 0,
		int end = -1
	) {
		int low = start;
		int high = end == -1 ? array.Length - 1 : end;

		while (
			low <= high
			&& key >= keySelector(array[low])
			&& key <= keySelector(array[high])
		) {
			if (low == high) {
				if (keySelector(array[low]) == key) {
					return low;
				}
				return -1;
			}

			int lowKey = keySelector(array[low]);
			int highKey = keySelector(array[high]);
			if (highKey == lowKey) break;

			int pos = low + (key - lowKey) * (high - low) / (highKey - lowKey);
			int posKey = keySelector(array[pos]);
			if (posKey == key) return pos;

			if (posKey < key) low = pos + 1;
			else high = pos - 1;
		}
		return -1;
	}
}
