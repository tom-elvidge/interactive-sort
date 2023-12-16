namespace MergeSortWeb.Pages.Store;

public class InteractiveMergeSort<T>
{
    public T[] Array;
    public bool IsComplete;

    public T? ComparisonItemOne;
    public T? ComparisonItemTwo;

    private int _n;
    private int _left;
    private int _currentSize;
    private int _mid;
    private int _right;

    private int _n1;
    private int _n2;
    private T[] _leftSubarray;
    private T[] _rightSubarray;
    private int _i;
    private int _j;
    private int _k;
    private int _i1;
    private int _i2;
    
    public InteractiveMergeSort(T[] array)
    {
        Array = array;
    }

    public void Start()
    {
        _n = Array.Length;
        _left = 0;
        _currentSize = 1;

        Merge();
    }

    public void Resume(bool itemOneIsGreater)
    {
        if (itemOneIsGreater)
        {
            Array[_k] = _leftSubarray[_i1];
            _i1++;
        }
        else
        {
            Array[_k] = _rightSubarray[_i2];
            _i2++;
        }

        _k++;

        Shared();
    }
    
    private void Merge()
    {
        // Move onto next size up and continue
        if (_left >= _n - 1)
        {
            _currentSize *= 2;
            _left = 0;
        }
        
        // base case all merged
        if (_currentSize >= _n)
        {
            ComparisonItemOne = default(T);
            ComparisonItemTwo = default(T);
            IsComplete = true;
            return;
        }
        
        _mid = Math.Min(_left + _currentSize - 1, _n - 1);
        _right = Math.Min(_left + 2 * _currentSize - 1, _n - 1);
        
        _n1 = _mid - _left + 1;
        _n2 = _right - _mid;

        // Create temporary arrays
        _leftSubarray = new T[_n1];
        _rightSubarray = new T[_n2];

        // Copy data to temporary arrays L[] and R[]
        for (_i = 0; _i < _n1; _i++)
            _leftSubarray[_i] = Array[_left + _i];
        for (_j = 0; _j < _n2; _j++)
            _rightSubarray[_j] = Array[_mid + 1 + _j];

        // Merge the temporary arrays back into arr[l..r]
        _k = _left; // Initial index of merged subarray
        _i1 = 0;
        _i2 = 0; // Initial indices of first and second sub arrays

        Shared();
    }

    private void Shared()
    {
        if (_i1 < _n1 && _i2 < _n2)
        {
            ComparisonItemOne = _leftSubarray[_i1];
            ComparisonItemTwo = _rightSubarray[_i2];
            return;
        }

        // Copy the remaining elements of L[], if any
        while (_i1 < _n1)
        {
            Array[_k] = _leftSubarray[_i1];
            _i1++;
            _k++;
        }

        // Copy the remaining elements of R[], if any
        while (_i2 < _n2)
        {
            Array[_k] = _rightSubarray[_i2];
            _i2++;
            _k++;
        }

        // Move onto next pair of sub arrays
        _left += 2 * _currentSize;

        Merge();
    }
}