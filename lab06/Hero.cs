using System.Collections;

namespace lab06;

public class Hero : IEnumerable<string>
{
    public int Length => 3;

    public string this[string i]
    {
        get
        {
            return i.ToLower() switch
            {
                "body" => Body,
                "head" => Head,
                "legs" => Legs,
                _ => throw new ArgumentOutOfRangeException()
            };
        }
    }
    public string LeftHand { get; set; }
    public string RightHand { get; set; }
    public string Head { get; set; }
    public string Body { get; set; }
    public string Legs { get; set; }
    public string[] Items { get; set; }

    public IEnumerator<string> GetEnumerator()
    {
        yield return LeftHand;
        yield return RightHand;
        yield return Head;
        yield return Body;
        yield return Legs;
        foreach (var item in Items)
        {
            yield return item;
        }
    }

    IEnumerator IEnumerable.GetEnumerator()
    {
        return GetEnumerator();
    }
}