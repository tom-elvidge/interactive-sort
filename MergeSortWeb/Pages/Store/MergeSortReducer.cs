using Fluxor;

namespace MergeSortWeb.Pages.Store;

public static class MergeSortReducer
{
    [ReducerMethod]
    public static MergeSortState Handle(MergeSortState state, SetOriginal action) => state with
    {
        Original = action.Original
    };
}