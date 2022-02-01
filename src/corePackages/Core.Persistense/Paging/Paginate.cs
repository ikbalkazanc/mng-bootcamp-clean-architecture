namespace Core.Persistense.Paging;

internal class Paginate<T> : IPaginate<T>
{
    internal Paginate(IEnumerable<T> source, int index, int size, int from)
    {
        var enumerable = source as T[] ?? source.ToArray();

        if (from > index)
            throw new ArgumentException($"indexFrom: {from} > pageIndex: {index}, must indexFrom <= pageIndex");

        if (source is IQueryable<T> querable)
        {
            Index = index;
            Size = size;
            From = from;
            Count = querable.Count();
            Pages = (int)Math.Ceiling(Count / (double)Size);

            Items = querable.Skip((Index - From) * Size).Take(Size).ToList();
        }
        else
        {
            Index = index;
            Size = size;
            From = from;

            Count = enumerable.Count();
            Pages = (int)Math.Ceiling(Count / (double)Size);

            Items = enumerable.Skip((Index - From) * Size).Take(Size).ToList();
        }
    }

    internal Paginate()
    {
        Items = new T[0];
    }

    public int From { get; set; }
    public int Index { get; set; }
    public int Size { get; set; }
    public int Count { get; set; }
    public int Pages { get; set; }
    public IList<T> Items { get; set; }
    public bool HasPrevious => Index - From > 0;
    public bool HasNext => Index - From + 1 < Pages;
}

public static class Paginate
{
    public static IPaginate<T> Empty<T>()
    {
        return new Paginate<T>();
    }

    public static IPaginate<TResult> From<TResult, TSource>(IPaginate<TSource> source,
        Func<IEnumerable<TSource>, IEnumerable<TResult>> converter)
    {
        //return new Paginate<TSource, TResult>(source, converter);
        return new Paginate<TResult>();
    }
}