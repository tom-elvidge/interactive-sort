using Fluxor;

namespace MergeSortWeb.Pages.Store;

public class MergeSortEffects
{
    private readonly IState<MergeSortState> _state;

    public MergeSortEffects(IState<MergeSortState> state)
    {
        _state = state;
    }

    [EffectMethod]
    public void Handle(SetOriginal action, IDispatcher dispatcher)
    {
    }
    
    private int CalcMid(int n, int leftStart, int currentSize) => Math.Min(leftStart + currentSize - 1, n - 1);
    
    private int CalcRightEnd(int n, int leftStart, int currentSize) => Math.Min(leftStart + 2 * currentSize - 1, n - 1);
}