using Itmo.ObjectOrientedProgramming.Lab3.Creatures;

namespace Itmo.ObjectOrientedProgramming.Lab3.Catalog;

public sealed class CreatureCatalog
{
    private readonly Dictionary<CreaturesType, ICreature> _prototypes;

    public CreatureCatalog(Dictionary<CreaturesType, ICreature> prototypes)
    {
        _prototypes = prototypes;
    }

    public ICreature CreateInstance(CreaturesType creatureType)
    {
        return _prototypes[creatureType].Clone();
    }
}