namespace MergeSortWeb.Pages.Store;

public record SetOriginal(string[] Original);

public record ChooseItemOne;

public record ChooseItemTwo;

public record InitialiseMergeSort(
    int N,
    int CurrentSize,
    int LeftStart);

public record Merge(
    string[] Array,
    int Left,
    int Mid,
    int Right);
    
public record NewComparison(string ItemOne, string ItemTwo);

public record ComparisonResult(bool ItemOneIsGreater);
