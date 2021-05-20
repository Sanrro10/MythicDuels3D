using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Mirror;

public class MinionDisplay : Entity
{
    [SyncVar, HideInInspector] public CardInfo card;

    // Si marcas las variables con el atributo SerializeField,
    // puedes establecerlas en el inspector si necesidad de hacerlas públicas
    public Image image;
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
    [SerializeField]
    public CharacterCardDisplay CharacterCardDisplayPrefab;
    private bool isStrengh;
    private bool hasReaction;
    private int range;
    private int armorClass;
    private int health;
    private int attack;
    private int mana;
    private int clasS;

    [Header("Card Hover")]
    public CharacterCardDisplay cardHover;



    // Use this for initialization
    public void SetMinion(CharacterCard card)
    {
        health = card.constitution * card.level;
        healthText.text = health.ToString();
        hasReaction = true;
        cardHover = Instantiate(CharacterCardDisplayPrefab);
        cardHover.SetCharacter()
        //range = card.characterCard.range;
        //rangeText.text = range.ToString();
        if(card.dexterity + 2 > card.strength)
        {
            isStrengh = false;
            //attackType.text = "DEX";
            if(range == 1)
            {
                attack = (int)((4 + card.dexterity) * card.level*0.8);
            }
            else
            {
                attack = 3 + card.dexterity;
            }
            
        }
        //classText.text = card.classText.text;
        clasS = card.clasS;
        if (clasS == 0 | clasS == 4 | clasS == 5 | clasS == 8) //Clases sin maná
        {
            mana = card.level * 0;
        }
        else
        {
            if (clasS == 7) //Mana de Ranger
            {
                mana = card.level * 2;
            }
            else
            {
                if (clasS == 10) //mana de wizard
                {
                    mana = card.level * 4;
                }
                else //clases con bastante maná pero no como wizard
                {
                    mana = card.level * 3;
                }
            }
        }
        attackText.text = attack.ToString();
        
        manaText.text = mana.ToString();

        
    }
    public override void Update()
    {
        base.Update();
        // If we have a card but no sprite, make sure the sprite is up to date since we can't SyncVar the sprite.
        // Useful to avoid bugs when a player was offline when the card spawned, or if they reconnected.
        if (image.sprite == null)
        {
            image.sprite = card.image;

            // Update card hover info
            cardHover.UpdateFieldCardInfo(card);
        }

        SetMinion(cardHover.characterCard);

        if (CanAttack()) attackText.color = Color.green;
        else if (CantAttack()) attackText.color = Color.white;
    }

    [Command(requiresAuthority = false)]
    public void CmdUpdateWaitTurn()
    {
        Debug.LogError("Here");
        if (waitTurn > 0) waitTurn--;
    }

}

