namespace Itmo.ObjectOrientedProgramming.Lab1.Models.ValueObjects;

public sealed record Speed
{
    public readonly double speed;

    public Speed(double speedInp)
    {
        if (speedInp < 0) throw new ArgumentOutOfRangeException(nameof(speedInp), "Speed must be positive!");
        speed = speedInp;
    }
}