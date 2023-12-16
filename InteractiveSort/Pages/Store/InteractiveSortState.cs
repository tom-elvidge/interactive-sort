using Fluxor;

namespace InteractiveSort.Pages.Store;

[FeatureState]
public record InteractiveSortState(
    bool Sorting,
    string[] Input,
    string[] Sorted,
    string ItemOne,
    string ItemTwo,
    int ComparisonCount,
    int EstimateTotalComparisons)
{
    public InteractiveSortState() : this(
        false,
        Array.Empty<string>(),
        Array.Empty<string>(),
        string.Empty,
        string.Empty,
        0,
        0)
    {
    }
}