namespace Backend;

public class DoublyLinkedList<T> where T : IComparable<T>
{
    private DoubleNode<T>? _head;
    private DoubleNode<T>? _tail;
    private bool _ascending = true;

    private int Compare(T a, T b) => _ascending ? a.CompareTo(b) : b.CompareTo(a);

    public DoublyLinkedList()
    {
        _head = null;
        _tail = null;
    }

    public void InsertAtBeginning(T data)
    {
        var newNode = new DoubleNode<T>(data);
        if (_head == null)
        {
            _head = newNode;
            _tail = newNode;
            return;
        }
        newNode.Next = _head;
        _head.Prev = newNode;
        _head = newNode;
    }

    public void InsertAtEnd(T data)
    {
        var newNode = new DoubleNode<T>(data);
        if (_tail == null)
        {
            _head = newNode;
            _tail = newNode;
            return;
        }
        _tail.Next = newNode;
        newNode.Prev = _tail;
        _tail = newNode;
    }

    public bool Contains(T data)
    {
        var current = _head;
        while (current != null)
        {
            if (current.Data!.Equals(data))
            {
                return true;
            }
            current = current.Next;
        }
        return false;
    }

    public void Remove(T data)
    {
        var current = _head;
        while (current != null)
        {
            if (current.Data!.Equals(data))
            {
                if (current == _head && current == _tail)
                {
                    _head = null;
                    _tail = null;
                    return;
                }

                if (current == _head)
                {
                    _head = _head.Next;
                    _head!.Prev = null;
                    return;
                }

                if (current == _tail)
                {
                    _tail = _tail.Prev;
                    _tail!.Next = null;
                    return;
                }

                current.Prev!.Next = current.Next;
                current.Next!.Prev = current.Prev;
                return;
            }
            current = current.Next;
        }
    }

    public override string ToString()
    {
        var output = string.Empty;
        var current = _head;
        while (current != null)
        {
            output += $"{current.Data} <-> ";
            current = current.Next;
        }
        return $"{output} null";
    }

    public string ToStringReverse()
    {
        var output = string.Empty;
        var current = _tail;
        while (current != null)
        {
            output += $"{current.Data} <-> ";
            current = current.Prev;
        }
        return $"{output} null";
    }

    public void AddOrdered(T data)
    {
        var newNode = new DoubleNode<T>(data);

        if (_head == null)
        {
            _head = newNode;
            _tail = newNode;
            return;
        }

        if (Compare(newNode.Data!, _head.Data!) < 0)
        {
            newNode.Next = _head;
            _head.Prev = newNode;
            _head = newNode;
            return;
        }

        var current = _head;
        while (current != null && Compare(newNode.Data!, current.Data!) >= 0)
        {
            current = current.Next;
        }

        if (current == null)
        {
            _tail!.Next = newNode;
            newNode.Prev = _tail;
            _tail = newNode;
        }
        else
        {
            var prevNode = current.Prev;

            prevNode!.Next = newNode;
            newNode.Prev = prevNode;

            newNode.Next = current;
            current.Prev = newNode;
        }
    }

    public void SortDescending()
    {
        if (!_ascending) return;
        _ascending = false;

        if (_head == null || _head == _tail)
        {
            return;
        }

        var current = _head;
        DoubleNode<T>? temp = null;

        while (current != null)
        {
            temp = current.Prev;

            current.Prev = current.Next;
            current.Next = temp;

            current = current.Prev;
        }

        temp = _head;
        _head = _tail;
        _tail = temp;
    }

    public List<T> GetModes()
    {
        var modes = new List<T>();
        if (_head == null) return modes;

        var frequencies = new Dictionary<T, int>();
        var current = _head;

        while (current != null)
        {
            if (current.Data != null)
            {
                if (frequencies.ContainsKey(current.Data))
                {
                    frequencies[current.Data]++;
                }
                else
                {
                    frequencies[current.Data] = 1;
                }
            }
            current = current.Next;
        }

        if (frequencies.Count == 0) return modes;

        int maxFrequency = 0;
        foreach (var pair in frequencies)
        {
            if (pair.Value > maxFrequency)
            {
                maxFrequency = pair.Value;
            }
        }

        foreach (var pair in frequencies)
        {
            if (pair.Value == maxFrequency)
            {
                modes.Add(pair.Key);
            }
        }

        return modes;
    }

    public void PrintOccurrencesGraph()
    {
        if (_head == null)
        {
            Console.WriteLine("La lista está vacía, no hay elementos para graficar.");
            return;
        }

        var frequencies = new Dictionary<T, int>();
        var current = _head;

        while (current != null)
        {
            if (current.Data != null)
            {
                if (frequencies.ContainsKey(current.Data))
                {
                    frequencies[current.Data]++;
                }
                else
                {
                    frequencies[current.Data] = 1;
                }
            }
            current = current.Next;
        }

        Console.WriteLine("\n--- Gráfico de Ocurrencias ---");
        foreach (var pair in frequencies)
        {
            string barras = new string('*', pair.Value);
            Console.WriteLine($"{pair.Key,-12} | {barras} ({pair.Value})");
        }
    }

    public void RemoveAll(T data)
    {
        if (_head == null)
        {
            Console.WriteLine("Lista de ocurrencias vacía");
            return;
        }

        var current = _head;

        while (current != null)
        {
            var nextNode = current.Next;

            if (current.Data!.CompareTo(data) == 0)
            {
                if (current == _head)
                {
                    _head = _head.Next;
                    if (_head != null) _head.Prev = null;
                    else _tail = null;
                }
                else if (current == _tail)
                {
                    _tail = _tail.Prev;
                    if (_tail != null) _tail.Next = null;
                }
                else
                {
                    current.Prev!.Next = current.Next;
                    current.Next!.Prev = current.Prev;
                }
            }
            current = nextNode;
        }
    }
}