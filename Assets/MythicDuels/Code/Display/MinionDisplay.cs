using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MinionDisplay : MonoBehaviour
{
    private CharacterCardDisplay characterCardDisplay;

    // Si marcas las variables con el atributo SerializeField,
    // puedes establecerlas en el inspector si necesidad de hacerlas públicas

    [SerializeField]
    private Text healthText;
    [SerializeField]
    private Text attackText;
    [SerializeField]
    private Text spellsText;
    [SerializeField]
    private Text rangeText;
    [SerializeField]
    private Text attackType;
    private bool isStrengh;
    private bool hasReaction;
    private int range;
    private int armorClass;
    private int health;
    private int attack;
    private int spells;
    private 



    // Use this for initialization
    public void SetMinion(CharacterCardDisplay card)
    {
        health = card.characterCard.constitution * card.characterCard.level;
        healthText.text = health.ToString();
        hasReaction = true;
        range = card.characterCard.range;
        rangeText.text = range.ToString();
        if(card.characterCard.dexterity + 2 > card.characterCard.strength)
        {
            isStrengh = false;
            attackType.text = "DEX";
            if(range == 1)
            {
                attack = (4 + card.characterCard.dexterity) * card.characterCard.level/2;
            }
            else
            {
                attack = 3 + card.characterCard.dexterity;
            }
            
        }
        attackText.text = attack.ToString();
        spells = minion.spells;
        spellsText.text = spells.ToString();

        
    }

}

