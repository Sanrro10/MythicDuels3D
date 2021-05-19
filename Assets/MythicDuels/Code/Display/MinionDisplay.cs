using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MinionDisplay : Entity
{
    private CharacterCardDisplay characterCardDisplay;

    // Si marcas las variables con el atributo SerializeField,
    // puedes establecerlas en el inspector si necesidad de hacerlas públicas

    [SerializeField]
    private Text healthText;
    [SerializeField]
    private Text attackText;
    [SerializeField]
    private Text manaText;
    [SerializeField]
    private Text armorClassText;
    [SerializeField]
    public SpriteRenderer weapon;
    private bool isStrengh;
    private bool hasReaction;
    private int range;
    private int armorClass;
    private int health;
    private int attack;
    private int mana;
    private int clasS;



    // Use this for initialization
    public void SetMinion(CharacterCardDisplay card)
    {
        characterCardDisplay = card;
        health = card.characterCard.constitution * card.characterCard.level;
        healthText.text = health.ToString();
        hasReaction = true;
        //range = card.characterCard.range;
        //rangeText.text = range.ToString();
        if(card.characterCard.dexterity + 2 > card.characterCard.strength)
        {
            isStrengh = false;
            //attackType.text = "DEX";
            if(range == 1)
            {
                attack = (int)((4 + card.characterCard.dexterity) * card.characterCard.level*0.8);
            }
            else
            {
                attack = 3 + card.characterCard.dexterity;
            }
            
        }
        //classText.text = card.classText.text;
        clasS = card.characterCard.clasS;
        if (clasS == 0 | clasS == 4 | clasS == 5 | clasS == 8) //Clases sin maná
        {
            mana = card.characterCard.level * 0;
        }
        else
        {
            if (clasS == 7) //Mana de Ranger
            {
                mana = card.characterCard.level * 2;
            }
            else
            {
                if (clasS == 10) //mana de wizard
                {
                    mana = card.characterCard.level * 4;
                }
                else //clases con bastante maná pero no como wizard
                {
                    mana = card.characterCard.level * 3;
                }
            }
        }
        attackText.text = attack.ToString();
        
        manaText.text = mana.ToString();

        
    }

}

