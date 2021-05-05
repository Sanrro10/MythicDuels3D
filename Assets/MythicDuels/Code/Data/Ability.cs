using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New AbilityCard", menuName = "Card/AbilityCard")]
public class Ability : ScriptableObject
{
	public new string name;

	public int range;
	public int level;
	public string gameClass; // Collection??
	public string castingtime; // Collection??
	public string type; // Collection??

}

