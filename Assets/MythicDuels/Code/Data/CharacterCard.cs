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
	public int range;
	public int clasS;

	public Ability[] abilities;


}
