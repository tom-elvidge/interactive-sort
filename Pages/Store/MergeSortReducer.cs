using Fluxor;

namespace MergeSortWeb.Pages.Store;

public static class MergeSortReducer
{
    [ReducerMethod]
    public static MergeSortState Handle(MergeSortState state, IncrementCount action) => state with
    {
        Count = state.Count + 1
    };
}