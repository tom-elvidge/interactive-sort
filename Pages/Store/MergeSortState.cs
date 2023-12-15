using Fluxor;

namespace MergeSortWeb.Pages.Store;

[FeatureState]
public record MergeSortState(int Count)
{
    public MergeSortState() : this(0)
    {
    }
}