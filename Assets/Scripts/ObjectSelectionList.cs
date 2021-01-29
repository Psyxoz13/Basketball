using System.Collections.Generic;

public static class ObjectSelectionList
{
    public static ObjectSelectionList<T> ToSelectionList<T>(this IEnumerable<T> list)
    {
        return CreateSelectionList(list);
    }

    private static ObjectSelectionList<T> CreateSelectionList<T>(IEnumerable<T> collection)
    {
        var selectionList = new ObjectSelectionList<T>();
        selectionList.Collection.AddRange(collection);

        return selectionList;
    }
}

public class ObjectSelectionList<T>
{
    public List<T> Collection = new List<T>();

    public int SelectedIndex { get; set; } = 0;

    public T this[int index]
    {
        get
        {
            return Collection[index];
        }
        set
        {
            Collection[index] = value;
        }
    }

    public T Next()
    {
        var index = GetCorrecteIndex(++SelectedIndex);
        return Collection[index];
    }

    public T Previous()
    {
        var index = GetCorrecteIndex(--SelectedIndex);
        return Collection[index];
    }

    private int GetCorrecteIndex(int index)
    {
        if (index > Collection.Count - 1)
        {
            index = 0;
        }
        if (index < 0)
        {
            index = Collection.Count - 1;
        }

        return SelectedIndex = index;
    }
}

