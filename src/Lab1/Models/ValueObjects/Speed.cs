namespace Itmo.ObjectOrientedProgramming.Lab1.Models.ValueObjects;

public sealed record Speed
{
    public double SpeedMC { get; }

    public Speed(double speedInp)
    {
        if (speedInp < 0) throw new ArgumentOutOfRangeException(nameof(speedInp), "Speed must be positive!");
        SpeedMC = speedInp;
    }
}