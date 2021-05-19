using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New CharacterCard", menuName = "Card/CharacterCard")]
public class CharacterCard : Card
{
	public int strength;
	public int dexterity;
	public int constitution;
	public int intelligence;
	public int wisdom;
	public int charisma;
	public int armorClass;
	public Weapon weapon;

	public Ability[] abilities;

	[Header("Targets")]
	public List<Target> acceptableTargets = new List<Target>();

    [Header("Board Prefab")]
    public MinionDisplay minionPrefab;


    public virtual void Attack(Entity attacker, Entity target)
    {
        // Reduce the target's health by damage dealt.
        target.combat.CmdChangeHealth(-attacker.strength);
        attacker.combat.CmdChangeHealth(-target.strength);
        attacker.DestroyTargetingArrow();
        attacker.combat.CmdIncreaseWaitTurn();
    }

    private void OnValidate()
    {
        // By default, all creatures can only attack enemy creatures and our opponent. We set it here so every card get it's automatically.
        if (acceptableTargets.Count == 0)
        {
            acceptableTargets.Add(Target.ENEMIES);
            acceptableTargets.Add(Target.OPPONENT);
        }
    }
}
