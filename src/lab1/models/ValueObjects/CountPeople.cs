using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Test.Models.ValueObjects;
public sealed record CountPeople
{
    public readonly int Count;
    
    public CountPeople(int count)
    {
        if (count < 0) throw new ArgumentOutOfRangeException(nameof(count), "Count of people must be positive!");
        Count = count;
    }

}