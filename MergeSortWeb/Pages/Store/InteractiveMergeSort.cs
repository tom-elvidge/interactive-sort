namespace MergeSortWeb.Pages.Store;

public class InteractiveMergeSort<T>
{
    public readonly T[] Array;
    public bool IsComplete;
    public T? ComparisonItemOne;
    public T? ComparisonItemTwo;
    
    private int _left;
    private int _currentSize;
    private int _mid;
    private int _right;
    
    private T[] _leftSubarray;
    private T[] _rightSubarray;
    private int _arrayIndex;
    private int _leftSubarrayIndex;
    private int _rightSubarrayIndex;
    
    public InteractiveMergeSort(T[] array)
    {
        Array = array;
        _leftSubarray = new T[] { };
        _rightSubarray = new T[] { };
        _left = 0;
        _currentSize = 1;
    }

    public void Resume(bool itemOneIsGreater)
    {
        if (itemOneIsGreater)
        {
            Array[_arrayIndex] = _leftSubarray[_leftSubarrayIndex];
            _leftSubarrayIndex++;
        }
        else
        {
            Array[_arrayIndex] = _rightSubarray[_rightSubarrayIndex];
            _rightSubarrayIndex++;
        }

        _arrayIndex++;

        Shared();
    }
    
    public void Merge()
    {
        // Move onto next size up and continue
        if (_left >= Array.Length- 1)
        {
            _currentSize *= 2;
            _left = 0;
        }
        
        // base case all merged
        if (_currentSize >= Array.Length)
        {
            ComparisonItemOne = default(T);
            ComparisonItemTwo = default(T);
            IsComplete = true;
            return;
        }
        
        _mid = Math.Min(_left + _currentSize - 1, Array.Length- 1);
        _right = Math.Min(_left + 2 * _currentSize - 1, Array.Length- 1);

        // Create temporary arrays
        _leftSubarray = new T[_mid - _left + 1];
        _rightSubarray = new T[_right - _mid];

        // Copy data to temporary arrays L[] and R[]
        for (var i = 0; i < _leftSubarray.Length; i++)
            _leftSubarray[i] = Array[_left + i];
        for (var j = 0; j < _rightSubarray.Length; j++)
            _rightSubarray[j] = Array[_mid + 1 + j];

        // Merge the temporary arrays back into arr[l..r]
        _arrayIndex = _left; // Initial index of merged subarray
        _leftSubarrayIndex = 0;
        _rightSubarrayIndex = 0; // Initial indices of first and second sub arrays

        Shared();
    }

    private void Shared()
    {
        if (_leftSubarrayIndex < _leftSubarray.Length && _rightSubarrayIndex < _rightSubarray.Length)
        {
            ComparisonItemOne = _leftSubarray[_leftSubarrayIndex];
            ComparisonItemTwo = _rightSubarray[_rightSubarrayIndex];
            return;
        }

        // Copy the remaining elements of L[], if any
        while (_leftSubarrayIndex < _leftSubarray.Length)
        {
            Array[_arrayIndex] = _leftSubarray[_leftSubarrayIndex];
            _leftSubarrayIndex++;
            _arrayIndex++;
        }

        // Copy the remaining elements of R[], if any
        while (_rightSubarrayIndex < _rightSubarray.Length)
        {
            Array[_arrayIndex] = _rightSubarray[_rightSubarrayIndex];
            _rightSubarrayIndex++;
            _arrayIndex++;
        }

        // Move onto next pair of sub arrays
        _left += 2 * _currentSize;

        Merge();
    }
}