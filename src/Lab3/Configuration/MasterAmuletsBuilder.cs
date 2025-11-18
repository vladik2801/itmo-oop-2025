using Itmo.ObjectOrientedProgramming.Lab3.Creatures;
using Itmo.ObjectOrientedProgramming.Lab3.Modifiers;
using Itmo.ObjectOrientedProgramming.Lab3.ValueObject;

namespace Itmo.ObjectOrientedProgramming.Lab3.Configuration;

public class MasterAmuletsBuilder : ICreatureBuilder
{
    private readonly ModifierApplier _modifierApplier = new();
    private HealthPoint _healthPoint = new HealthPoint(0);
    private AttackPoint _attackPoint = new AttackPoint(0);
    private bool _isMagicShield = false;
    private bool _isAttackSkill = false;

    public MasterAmuletsBuilder WithBaseStats(HealthPoint healthPoint, AttackPoint attackPoint)
    {
        _healthPoint = healthPoint;
        _attackPoint = attackPoint;
        return this;
    }

    public MasterAmuletsBuilder WithMagicShield()
    {
        _isMagicShield = true;
        return this;
    }

    public MasterAmuletsBuilder WithAttackSkill()
    {
        _isAttackSkill = true;
        return this;
    }

    public ICreature Build()
    {
        ICreature creature = new MasterAmulets(_healthPoint, _attackPoint);

        if (_isMagicShield)
        {
            creature = _modifierApplier.Apply(creature, ModifiersType.MagicShield);
        }

        if (_isAttackSkill)
        {
            creature = _modifierApplier.Apply(creature, ModifiersType.AttackSkill);
        }

        return creature;
    }
}