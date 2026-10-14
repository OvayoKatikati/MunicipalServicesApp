using System;
using System.Collections.Generic;

namespace MunicipalServicesApp
{
    /// <summary>
    /// A minimal binary-heap-based priority queue. .NET Framework 4.7.2 does not
    /// ship System.Collections.Generic.PriorityQueue (that type was only added in
    /// .NET 6), so this lightweight implementation satisfies the "Stacks, Queues,
    /// Priority Queues" requirement for this part of the project.
    ///
    /// Lower priority values are dequeued first (min-heap). Used here to always
    /// surface the soonest-occurring event first, regardless of the order events
    /// were added in.
    /// </summary>
    public class SimplePriorityQueue<TItem, TPriority> where TPriority : IComparable<TPriority>
    {
        private readonly List<Tuple<TItem, TPriority>> _heap = new List<Tuple<TItem, TPriority>>();

        public int Count => _heap.Count;

        public void Enqueue(TItem item, TPriority priority)
        {
            _heap.Add(Tuple.Create(item, priority));
            int child = _heap.Count - 1;

            while (child > 0)
            {
                int parent = (child - 1) / 2;
                if (_heap[child].Item2.CompareTo(_heap[parent].Item2) >= 0) break;

                Swap(child, parent);
                child = parent;
            }
        }

        public TItem Dequeue()
        {
            if (_heap.Count == 0)
                throw new InvalidOperationException("The priority queue is empty.");

            TItem result = _heap[0].Item1;
            int lastIndex = _heap.Count - 1;
            _heap[0] = _heap[lastIndex];
            _heap.RemoveAt(lastIndex);
            lastIndex--;

            int parent = 0;
            while (true)
            {
                int left = parent * 2 + 1;
                if (left > lastIndex) break;

                int right = left + 1;
                int smallest = left;
                if (right <= lastIndex && _heap[right].Item2.CompareTo(_heap[left].Item2) < 0)
                    smallest = right;

                if (_heap[parent].Item2.CompareTo(_heap[smallest].Item2) <= 0) break;

                Swap(parent, smallest);
                parent = smallest;
            }

            return result;
        }

        public List<TItem> PeekTopN(int n)
        {
            // Non-destructive snapshot of the n smallest-priority items.
            var clone = new SimplePriorityQueue<TItem, TPriority>();
            clone._heap.AddRange(_heap);

            var results = new List<TItem>();
            while (results.Count < n && clone.Count > 0)
            {
                results.Add(clone.Dequeue());
            }
            return results;
        }

        private void Swap(int a, int b)
        {
            var temp = _heap[a];
            _heap[a] = _heap[b];
            _heap[b] = temp;
        }
    }
}
