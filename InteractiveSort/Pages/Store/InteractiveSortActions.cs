namespace InteractiveSort.Pages.Store;

public record GetDogs(int Count = 10);

public record StartMergeSort(string[] Input);

public record NewComparison(string ItemOne, string ItemTwo);

public record ComparisonResult(bool ItemOneIsGreater);

public record MergeSortCompleted(string[] Sorted);