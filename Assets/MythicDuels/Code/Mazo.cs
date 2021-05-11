using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mazo : ScriptableObject {

	List<Card> mazo = new List<Card>(30);

	public List<Card> getDeck()
    {
		return mazo;
    }

}
