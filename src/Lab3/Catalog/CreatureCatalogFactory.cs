using Itmo.ObjectOrientedProgramming.Lab3.Configuration;
using Itmo.ObjectOrientedProgramming.Lab3.Creatures;

namespace Itmo.ObjectOrientedProgramming.Lab3.Catalog;

public class CreatureCatalogFactory
{
    public static CreatureCatalog Create(ICreatureBuilderFactory builderFactory)
    {
        var prototypes = new Dictionary<CreaturesType, ICreature>
        {
            [CreaturesType.CombatAnalyst] = builderFactory.CreateCombatAnalystBuilder().Build(),
            [CreaturesType.EvilFighter] = builderFactory.CreateEvilFighterBuilder().Build(),
            [CreaturesType.ImmortalHorror] = builderFactory.CreateImmortalHorrorBuilder().Build(),
            [CreaturesType.MasterAmulets] = builderFactory.CreateMasterAmuletsBuilder().Build(),
            [CreaturesType.MimicChest] = builderFactory.CreateMimicChestBuilder().Build(),
        };
        return new CreatureCatalog(prototypes);
    }
}