using Fluxor;

namespace MergeSortWeb.Pages.Store;

public static class MergeSortReducer
{
    [ReducerMethod]
    public static MergeSortState Handle(MergeSortState state, StartMergeSort action) => state with
    {
        Input = action.Input,
        Sorting = true,
        ComparisonCount = 0,
        EstimateTotalComparisons = (int) Math.Round(action.Input.Length * Math.Log2(action.Input.Length))
    };
    
    [ReducerMethod]
    public static MergeSortState Handle(MergeSortState state, NewComparison action) => state with
    {
        ItemOne = action.ItemOne,
        ItemTwo = action.ItemTwo
    };

    [ReducerMethod]
    public static MergeSortState Handle(MergeSortState state, ComparisonResult action) => state with
    {
        ComparisonCount = state.ComparisonCount + 1
    };
    
    [ReducerMethod]
    public static MergeSortState Handle(MergeSortState state, MergeSortCompleted action) => state with
    {
        Sorted = action.Sorted,
        Sorting = false
    };
}