namespace Algorithms.lab6;

static class Helper {
	public static int[] GetRandomArray(int size) {
		var rng = new Random();
		int[] arr = new int[size];
		for (int i = 0; i < size; i++) {
			arr[i] = rng.Next(0,100_000);
		}
		return arr;
	}
	private static void _merge(int[] arr,int left,int mid,int right) {
		int i = left;
		int j = mid;
		int k = left;
		int[] temp = new int[arr.Length];

		while (i < mid && j < right) {
			if (arr[i] <= arr[j]) {
				temp[k++] = arr[i++];
			} else {
				temp[k++] = arr[j++];
			}
		}

		while (i < mid) {
			temp[k++] = arr[i++];
		}
		while (j < right) {
			temp[k++] = arr[j++];
		}
		for (int t = left; t < right; t++) {
			arr[t] = temp[t];
		}
	}
	public static void BottomUpMergeSort(int[] arr) {
		int len = arr.Length;

		for (int width = 1; width < len; width *= 2) {
			for (int i = 0; i < len; i += width * 2) {
				int left = i;
				int mid = Math.Min(i + width,len);
				int right = Math.Min(i + 2 * width,len);

				_merge(arr,left,mid,right);
			}
		}
	}
	public static void TopDownMergeSort(int[] arr) {
		if (arr.Length <= 1) return;
		TopDownMergeSort(arr,0,arr.Length - 1);
	}
	private static void TopDownMergeSort(int[] arr,int left,int right) {
		if (left >= right) return;
		
		int mid = (left + right) / 2;

		TopDownMergeSort(arr,left,mid);
		TopDownMergeSort(arr,mid + 1,right);

		_merge(arr,left,mid + 1,right + 1);
	}
}