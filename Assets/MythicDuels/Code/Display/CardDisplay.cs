using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Mirror;

public class CardDisplay : NetworkBehaviour {

	[SerializeField]
	private Text nameText;

	[SerializeField]
	private Text levelText;

	[SerializeField]
	private Image artworkImage;

	[SerializeField]
	public Image background;

	[SerializeField]
	private Sprite[] spriteArray;

    public CardMove cardMove;

    [Header("Outline")]
    public Image cardOutline;
    public Color readyColor;
    [HideInInspector] public int handIndex;
    [HideInInspector] public PlayerType playerType;

    public void RemoveCard()
    {
        Destroy(gameObject);
    }

    public void UpdateFieldCardInfo(CardInfo card)
    {

        artworkImage.sprite = card.image;
        levelText.text = card.level;
        nameText.text = card.name;
    }

    private void Update()
    {
        if (playerType == PlayerType.PLAYER && cardMove != null)
        {
            Player player = Player.localPlayer;
            int manaCost = levelText.text.ToInt();
            if (Player.gameManager.isOurTurn)
            {
                cardMove.canDrag = player.deck.CanPlayCard(manaCost);
                cardOutline.color = cardMove.canDrag ? readyColor : Color.clear;
            }
        }
    }

    public Card originalCard;

	//public Text manaText;
	//public Text attackText;
	//public Text healthText;
	//public Text descriptionText;


	public void SetCard (Card card, int index, PlayerType playerT)
	{
		originalCard = card;
		nameText.text = card.name;
		artworkImage.sprite = card.artwork;
		levelText.text = card.level.ToString();
		background.sprite = spriteArray[card.clasS];
        handIndex = index;
        playerType = playerT;

    }
    public void Play()
    {

    }

	public static implicit operator CardDisplay(GameObject v)
    {
        throw new NotImplementedException();
    }
}
