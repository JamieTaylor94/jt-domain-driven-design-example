namespace JT.DomainDrivenDesign.Domain.VehicleDomain;

public class Hitbox
{
    private static readonly List<string> ValidHitboxes = new() { "Octane", "Dominus", "Breakout", "Plank" };
    public string Name { get; }

    private Hitbox(string name)
    {
        Name = name;
    }

    public static Hitbox Create(string name)
    {
        if (!ValidHitboxes.Contains(name))
        {
            throw new ArgumentException("Invalid hitbox");
        }

        return new Hitbox(name);
    }
}