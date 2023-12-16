using System.Net.Http.Json;
using System.Text.Json;
using Fluxor;

namespace InteractiveSort.Pages.Store;

public record DogsResponse(string[] Message, string Status);

public class InteractiveSortEffects
{
    private readonly IState<InteractiveSortState> _state;
    private readonly IHttpClientFactory _httpClientFactory;

    private InteractiveMergeSort<string>? _mergeSort;

    public InteractiveSortEffects(
        IState<InteractiveSortState> state,
        IHttpClientFactory httpClientFactory)
    {
        _state = state;
        _httpClientFactory = httpClientFactory;
    }

    [EffectMethod]
    public async Task Handle(GetDogs action, IDispatcher dispatcher)
    {
        var dogClient = _httpClientFactory.CreateClient();
        
        dogClient.BaseAddress = new Uri("https://dog.ceo");
        
        var dogs = await dogClient.GetFromJsonAsync<DogsResponse>(
            $"api/breeds/image/random/{action.Count}",
            new JsonSerializerOptions(JsonSerializerDefaults.Web));

        if (dogs == null) return;

        dispatcher.Dispatch(new StartMergeSort(dogs.Message));
    }

    [EffectMethod]
    public Task Handle(StartMergeSort action, IDispatcher dispatcher)
    {
        var copy = new string[action.Input.Length];
        for (var i = 0; i < action.Input.Length; i++) copy[i] = action.Input[i];
        
        _mergeSort = new InteractiveMergeSort<string>(copy);
        _mergeSort.Merge();

        if (_mergeSort.ComparisonItemOne == null || _mergeSort.ComparisonItemTwo == null)
            return Task.CompletedTask;
        
        dispatcher.Dispatch(new NewComparison(_mergeSort.ComparisonItemOne, _mergeSort.ComparisonItemTwo));
        return Task.CompletedTask;
    }
    
    [EffectMethod]
    public Task Handle(ComparisonResult action, IDispatcher dispatcher)
    {
        if (_mergeSort == null)
            return Task.CompletedTask;
        
        _mergeSort.Resume(action.ItemOneIsGreater);

        if (_mergeSort.IsComplete)
        {
            dispatcher.Dispatch(new MergeSortCompleted(_mergeSort.Array));
            return Task.CompletedTask;
        }
        
        if (_mergeSort?.ComparisonItemOne == null || _mergeSort?.ComparisonItemTwo == null)
            return Task.CompletedTask;
        
        dispatcher.Dispatch(new NewComparison(_mergeSort.ComparisonItemOne, _mergeSort.ComparisonItemTwo));
        return Task.CompletedTask;
    }
}