using System;
using UnityEngine;

public class CharacterCardFactory : GenericFactory<CharacterCardDisplay>
{
    //[SerializeField]
    //private MonoBehaviour prefab;

    // Recibimos el prefab y lo pasamos al constructor de la clase base
    public CharacterCardFactory(CharacterCardDisplay original) : base(original)
    {

    }

    // Me he cargado la clase CharacterCardPrefab, el objeto que instanciamos es un GameObject que tiene el componente
    // CharacterCardDisplay, vamos a operar con este directamente
    public override CharacterCardDisplay Get(Vector3 position, Quaternion rotation, Card card)
    {
        if (!card is CharacterCard)
        {
            throw new InvalidOperationException("Card data should be CharacterCard type.");
        }

        // Uso la clase base para crear la carta
        var cardDisplay = base.Get(position, rotation, card as Card);

        // Esto sobra o se hace en la clase base
        //pf.transform.SetPositionAndRotation(position, rotation);
        //characterCardPrefab.setPrefab(pf);
        //characterCardPrefab.setCharacterCard(card);
        //return characterCardPrefab;

        cardDisplay.SetCharacter(card as CharacterCard);

        return cardDisplay;
    }
}
