using System;
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

	public Vector3 handPosition;

	public Quaternion handRotation;


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

	public static implicit operator CardDisplay(GameObject v)
    {
        throw new NotImplementedException();
    }
}
