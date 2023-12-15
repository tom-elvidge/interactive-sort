using Fluxor;

namespace MergeSortWeb.Pages.Store;

public class MergeSortEffects
{
    [EffectMethod]
    public Task Handle(IncrementCount action, IDispatcher dispatcher)
    {
        Console.WriteLine("The count was incremented!");
        
        return Task.CompletedTask;
    }
}