using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Mirror;

public class CardDisplay : MonoBehaviour {

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

	//public Text manaText;
	//public Text attackText;
	//public Text healthText;
	//public Text descriptionText;


	public void SetCard (Card card)
	{
		nameText.text = card.name;
		artworkImage.sprite = card.artwork;
		levelText.text = card.level.ToString();
		background.sprite = spriteArray[card.clasS];

	}
	public void play() { 
	}

	public static implicit operator CardDisplay(GameObject v)
    {
        throw new NotImplementedException();
    }
}
