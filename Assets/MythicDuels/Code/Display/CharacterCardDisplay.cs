using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CharacterCardDisplay : CardDisplay
{
    public CharacterCard characterCard;

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
    [SerializeField]
    private Text armorClassValue;
    [SerializeField]
    private Image weapon;
    [SerializeField]
    private MinionDisplay minionDisplayOriginal;

    private MinionFactory<MinionDisplay> minionFactory;

    private void Awake()
    {
        minionFactory = new MinionFactory<MinionDisplay>(minionDisplayOriginal);
    }

    [SerializeField]
    private AbilityDisplay[] abilities;

    // Use this for initialization
    public void SetCharacter(CharacterCard card)
    {

        SetCard(card);

        characterCard = card;

        strengthValue.text = GetValue(characterCard.strength);
        dexterityValue.text = GetValue(characterCard.dexterity);
        constitutionValue.text = GetValue(characterCard.constitution);
        intelligenceValue.text = GetValue(characterCard.intelligence);
        wisdomValue.text = GetValue(characterCard.wisdom);
        charismaValue.text = GetValue(characterCard.charisma);
        armorClassValue.text = characterCard.armorClass.ToString();
        weapon.sprite = card.weapon.sprite;

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
    }

    public void Play()
    {
        var cardDisplay = minionFactory.Get(Vector3.zero, Quaternion.identity, this);
        Destroy(this);

    }

    string GetValue(int value)
    {

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
