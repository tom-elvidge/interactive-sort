using System.Collections.Immutable;
using Fluxor;

namespace MergeSortWeb.Pages.Store;

[FeatureState]
public record MergeSortState(
    string[] Original,
    string[] Sorted,
    int N,
    int CurrentSize,
    int LeftStart,
    int Mid,
    int RightEnd,
    (string, string) Comparison)
{
    public MergeSortState() : this(
        Array.Empty<string>(),
        Array.Empty<string>(),
        0,
        0,
        0,
        0,
        0,
        (string.Empty, string.Empty))
    {
    }
}