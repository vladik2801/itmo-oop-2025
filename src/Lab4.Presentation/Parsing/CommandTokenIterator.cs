using System.Collections;

namespace Itmo.ObjectOrientedProgramming.Lab4.Presentation.Parsing;

public class CommandTokenIterator : IEnumerator<string>
{
    private readonly string[] _tokens;
    private int _index;

    public CommandTokenIterator(string line)
    {
        _tokens = line.Split(' ');
        _index = -1;
    }

    public string Current
        => _index >= 0 && _index < _tokens.Length
            ? _tokens[_index]
            : throw new InvalidOperationException("No current token");

    object IEnumerator.Current => Current;

    public bool MoveNext()
    {
        if (_index + 1 >= _tokens.Length) return false;
        _index++;
        return true;
    }

    public void Reset()
    {
        _index = -1;
    }

    public void Dispose() { }
}