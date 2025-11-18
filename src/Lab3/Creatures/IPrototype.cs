namespace Itmo.ObjectOrientedProgramming.Lab3.Creatures;

public interface IPrototype<T> where T : IPrototype<T>
{
    T Clone();
}