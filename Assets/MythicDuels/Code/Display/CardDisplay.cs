using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CardDisplay : MonoBehaviour {

	[SerializeField]
	private Text nameText;

	[SerializeField]
	private Text levelText;

	[SerializeField]
	private Image artworkImage;

	//public Text manaText;
	//public Text attackText;
	//public Text healthText;
	//public Text descriptionText;


	public void SetCard (Card card)
	{
		nameText.text = card.name;
		artworkImage.sprite = card.artwork;
		levelText.text = card.level.ToString();

	}
	
}
