using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mazo : ScriptableObject {

	List<Ability> habilityCards = new List<Ability>(30);
	List<CharacterCard_old> characterCards = new List<CharacterCard_old>(4);

	public List<Ability> getHabilityCards()
    {
		return habilityCards;
    }

	public List<CharacterCard_old> getCharacterCards()
	{
		return characterCards;
	}

}
