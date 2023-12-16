using Fluxor;

namespace InteractiveSort.Pages.Store;

public static class InteractiveSortReducer
{
    [ReducerMethod]
    public static InteractiveSortState Handle(InteractiveSortState state, StartMergeSort action) => state with
    {
        Input = action.Input,
        Sorting = true,
        ComparisonCount = 0,
        EstimateTotalComparisons = (int) Math.Round(action.Input.Length * Math.Log2(action.Input.Length))
    };
    
    [ReducerMethod]
    public static InteractiveSortState Handle(InteractiveSortState state, NewComparison action) => state with
    {
        ItemOne = action.ItemOne,
        ItemTwo = action.ItemTwo
    };

    [ReducerMethod]
    public static InteractiveSortState Handle(InteractiveSortState state, ComparisonResult action) => state with
    {
        ComparisonCount = state.ComparisonCount + 1
    };
    
    [ReducerMethod]
    public static InteractiveSortState Handle(InteractiveSortState state, MergeSortCompleted action) => state with
    {
        Sorted = action.Sorted,
        Sorting = false
    };
}