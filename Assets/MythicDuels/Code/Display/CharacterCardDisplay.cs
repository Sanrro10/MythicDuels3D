using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CharacterCardDisplay : CardDisplay
{
    private CharacterCard characterCard;

    // Si marcas las variables con el atributo SerializeField,
    // puedes establecerlas en el inspector si necesidad de hacerlas públicas

    [SerializeField]
    private Text strengthValue;
    [SerializeField]
    private Text dexterityValue;
    [SerializeField]
    private Text constitutionValue;
    [SerializeField]
    private Text intelligenceValue;
    [SerializeField]
    private Text wisdomValue;
    [SerializeField]
    private Text charismaValue;

    // Los objetos repetidos mejor tratarlos como arrays, esto evita duplicar código
    // y es mas tolerante a cambios (más fácil tener menos o más abilidades2).
    // He hecho que los slots sean prefabs.
    [SerializeField]
    private AbilityDisplay[] abilities;

    // Use this for initialization
    public void SetCharacter(CharacterCard card)
    {
        // Lo que está en la clase base Card, debería hacerse, a su vez, en una clase base de Display (CardDisplay)

        SetCard(card);

        characterCard = card;

        strengthValue.text = GetValue(characterCard.strength);
        dexterityValue.text = GetValue(characterCard.dexterity);
        constitutionValue.text = GetValue(characterCard.constitution);
        intelligenceValue.text = GetValue(characterCard.intelligence);
        wisdomValue.text = GetValue(characterCard.wisdom);
        charismaValue.text = GetValue(characterCard.charisma);

        for (int i = 0; i < abilities.Length; i++)
        {
            if (card.abilities.Length > i)
            {
                abilities[i].gameObject.SetActive(true);
                abilities[i].Init(card.abilities[i]);
            }
            else
            {
                abilities[i].gameObject.SetActive(false);
            }
        }

        //slot1Name.text = characterCard.slot1.name;
        //slot1CastingTime.text = characterCard.slot1.castingtime;
        //slot1Type.text = characterCard.slot1.type;
        //slot1Level.text = characterCard.slot1.level.ToString();
        //slot2Name.text = characterCard.slot2.name;
        //slot2CastingTime.text = characterCard.slot2.castingtime;
        //slot2Type.text = characterCard.slot2.type;
        //slot2Level.text = characterCard.slot2.level.ToString();
        //slot3Name.text = characterCard.slot3.name;
        //slot3CastingTime.text = characterCard.slot3.castingtime;
        //slot3Type.text = characterCard.slot3.type;
        //slot3Level.text = characterCard.slot3.level.ToString();
        //slot4Name.text = characterCard.slot4.name;
        //slot4CastingTime.text = characterCard.slot4.castingtime;
        //slot4Type.text = characterCard.slot4.type;
        //slot4Level.text = characterCard.slot4.level.ToString();
    }

    string GetValue(int value)
    {
        // Esto mejor sacarlo con una fórmula, no?
        // bonificador = Mathf.Floor(value / 2) - 5

        int bonus = Mathf.FloorToInt(value / 2) - 5;

        return $"{bonus} ({value})";

        //if (value == 2 | value == 3) return "-4 (" + value + ")";
        //if (value == 4 | value == 5) return "-3 (" + value + ")";
        //if (value == 6 | value == 7) return "-2 (" + value + ")";
        //if (value == 8 | value == 9) return "-1 (" + value + ")";
        //if (value == 10 | value == 11) return "0 (" + value + ")";
        //if (value == 12 | value == 13) return "1 (" + value + ")";
        //if (value == 14 | value == 15) return "2 (" + value + ")";
        //if (value == 16 | value == 17) return "3 (" + value + ")";
        //if (value == 18 | value == 19) return "4 (" + value + ")";
        //if (value == 20) return "5 (20)";
        //return "-5 (1)";
    }

}
