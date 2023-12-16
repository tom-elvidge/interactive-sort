using Fluxor;

namespace MergeSortWeb.Pages.Store;

[FeatureState]
public record MergeSortState(
    bool Sorting,
    string[] Input,
    string[] Sorted,
    string ItemOne,
    string ItemTwo,
    int ComparisonCount,
    int EstimateTotalComparisons)
{
    public MergeSortState() : this(
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