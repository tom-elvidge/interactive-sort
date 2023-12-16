using FluentAssertions;
using MergeSortWeb.Pages.Store;

namespace MergeSortWeb.Tests;

public class Tests
{
    [Test]
    public void SortColorsAndAssertIntermediateSteps()
    {
        var ims = new InteractiveMergeSort<string>(new [] { "Red", "Green", "Blue", "Yellow", "Purple" });
        
        ims.Merge();

        ims.ComparisonItemOne.Should().Be("Red");
        ims.ComparisonItemTwo.Should().Be("Green");
        
        ims.Resume(true);
        
        ims.ComparisonItemOne.Should().Be("Blue");
        ims.ComparisonItemTwo.Should().Be("Yellow");
        
        ims.Resume(true);
        
        ims.ComparisonItemOne.Should().Be("Red");
        ims.ComparisonItemTwo.Should().Be("Blue");
        
        ims.Resume(true);
        
        ims.ComparisonItemOne.Should().Be("Green");
        ims.ComparisonItemTwo.Should().Be("Blue");
        
        ims.Resume(true);
        
        ims.ComparisonItemOne.Should().Be("Red");
        ims.ComparisonItemTwo.Should().Be("Purple");
        
        ims.Resume(true);
        
        ims.ComparisonItemOne.Should().Be("Green");
        ims.ComparisonItemTwo.Should().Be("Purple");
        
        ims.Resume(false);

        ims.ComparisonItemOne.Should().BeNull();
        ims.ComparisonItemTwo.Should().BeNull();
        ims.IsComplete.Should().BeTrue();
        
        ims.Array.Should().BeEquivalentTo(new[] { "Red", "Purple", "Green", "Blue", "Yellow" });
    }
    
    [Test]
    public void SortColorsAndAssertIntermediateSteps2()
    {
        var ims = new InteractiveMergeSort<string>(new [] { "Red", "Green", "Blue", "Yellow", "Purple" });
        
        ims.Merge();

        ims.ComparisonItemOne.Should().Be("Red");
        ims.ComparisonItemTwo.Should().Be("Green");
        
        ims.Resume(true);
        
        ims.ComparisonItemOne.Should().Be("Blue");
        ims.ComparisonItemTwo.Should().Be("Yellow");
        
        ims.Resume(false);
        
        ims.ComparisonItemOne.Should().Be("Red");
        ims.ComparisonItemTwo.Should().Be("Yellow");
        
        ims.Resume(true);
        
        ims.ComparisonItemOne.Should().Be("Green");
        ims.ComparisonItemTwo.Should().Be("Yellow");
        
        ims.Resume(false);
        
        ims.ComparisonItemOne.Should().Be("Green");
        ims.ComparisonItemTwo.Should().Be("Blue");
        
        ims.Resume(true);
        
        ims.ComparisonItemOne.Should().Be("Red");
        ims.ComparisonItemTwo.Should().Be("Purple");
        
        ims.Resume(true);
        
        ims.ComparisonItemOne.Should().Be("Yellow");
        ims.ComparisonItemTwo.Should().Be("Purple");
        
        ims.Resume(false);

        ims.ComparisonItemOne.Should().BeNull();
        ims.ComparisonItemTwo.Should().BeNull();
        ims.IsComplete.Should().BeTrue();
        
        ims.Array.Should().BeEquivalentTo(new[] { "Red", "Purple", "Yellow", "Green", "Blue" });
    }

    [Test]
    public void SortListOfIntegers()
    {
        // arrange
        var nums = new List<int> { 4, 7, 4, 290, 3, 33, 96, 6965, 4322, 33, 2, 101, 0, 2334, -22, 24, 99, 432 };
        
        // act
        var ims = new InteractiveMergeSort<int>(nums.ToArray());
        
        ims.Merge();
        
        while (!ims.IsComplete)
        {
            ims.Resume(ims.ComparisonItemOne >= ims.ComparisonItemTwo);    
        }
        
        // assert
        ims.Array.Should().BeEquivalentTo(nums.OrderDescending().ToArray(), options => options.WithStrictOrdering());
    }
}