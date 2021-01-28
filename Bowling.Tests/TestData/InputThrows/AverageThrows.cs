using System.Collections;
using System.Collections.Generic;

namespace Bowling.Tests.TestData.InputThrows
{
    public class AverageThrows : IEnumerable<object[]>
    {
        private readonly List<object[]> _data = new List<object[]>
        {
            new object[] {new List<int> {2, 3, 5, 4, 9, 1, 2, 5, 3, 2, 4, 2, 3, 3, 4, 6, 10, 3, 2}}
        };

        public IEnumerator<object[]> GetEnumerator() => _data.GetEnumerator();
        IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
    }
}