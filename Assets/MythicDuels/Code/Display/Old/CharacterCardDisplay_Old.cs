using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CharacterCardDisplay_Old : MonoBehaviour
{
	public CharacterCard_old characterCard;
	public Text nameText;

	public Image artworkImage;

	public Text levelText;
	public Text strengthValue;
	public Text dexterityValue;
	public Text constitutionValue;
	public Text intelligenceValue;
	public Text wisdomValue;
	public Text charismaValue;
	public Text slot1Name;
	public Text slot1CastingTime;
	public Text slot1Type;
	public Text slot1Level;
	public Text slot2Name;
	public Text slot2CastingTime;
	public Text slot2Type;
	public Text slot2Level;
	public Text slot3Name;
	public Text slot3CastingTime;
	public Text slot3Type;
	public Text slot3Level;
	public Text slot4Name;
	public Text slot4CastingTime;
	public Text slot4Type;
	public Text slot4Level;

    private void Start()
    {
		nameText.text = characterCard.name;

		artworkImage.sprite = characterCard.artwork;

		levelText.text = characterCard.level.ToString();
		strengthValue.text = getValue(characterCard.strength);
		dexterityValue.text = getValue(characterCard.dexterity);
		constitutionValue.text = getValue(characterCard.constitution);
		intelligenceValue.text = getValue(characterCard.intelligence);
		wisdomValue.text = getValue(characterCard.wisdom);
		charismaValue.text = getValue(characterCard.charisma);
		slot1Name.text = characterCard.slot1.name;
		slot1CastingTime.text = characterCard.slot1.castingtime;
		slot1Type.text = characterCard.slot1.type;
		slot1Level.text = characterCard.slot1.level.ToString();
		slot2Name.text = characterCard.slot2.name;
		slot2CastingTime.text = characterCard.slot2.castingtime;
		slot2Type.text = characterCard.slot2.type;
		slot2Level.text = characterCard.slot2.level.ToString();
		slot3Name.text = characterCard.slot3.name;
		slot3CastingTime.text = characterCard.slot3.castingtime;
		slot3Type.text = characterCard.slot3.type;
		slot3Level.text = characterCard.slot3.level.ToString();
		slot4Name.text = characterCard.slot4.name;
		slot4CastingTime.text = characterCard.slot4.castingtime;
		slot4Type.text = characterCard.slot4.type;
		slot4Level.text = characterCard.slot4.level.ToString();
	}

    // Use this for initialization
    public void characterDisplay(CharacterCard_old card)
	{
		characterCard = card;
		nameText.text = characterCard.name;

		artworkImage.sprite = characterCard.artwork;

		levelText.text = characterCard.level.ToString();
		strengthValue.text = getValue(characterCard.strength);
		dexterityValue.text = getValue(characterCard.dexterity);
		constitutionValue.text = getValue(characterCard.constitution);
		intelligenceValue.text = getValue(characterCard.intelligence);
		wisdomValue.text = getValue(characterCard.wisdom);
		charismaValue.text = getValue(characterCard.charisma);
		slot1Name.text = characterCard.slot1.name;
		slot1CastingTime.text = characterCard.slot1.castingtime;
		slot1Type.text = characterCard.slot1.type;
		slot1Level.text = characterCard.slot1.level.ToString();
		slot2Name.text = characterCard.slot2.name;
		slot2CastingTime.text = characterCard.slot2.castingtime;
		slot2Type.text = characterCard.slot2.type;
		slot2Level.text = characterCard.slot2.level.ToString();
		slot3Name.text = characterCard.slot3.name;
		slot3CastingTime.text = characterCard.slot3.castingtime;
		slot3Type.text = characterCard.slot3.type;
		slot3Level.text = characterCard.slot3.level.ToString();
		slot4Name.text = characterCard.slot4.name;
		slot4CastingTime.text = characterCard.slot4.castingtime;
		slot4Type.text = characterCard.slot4.type;
		slot4Level.text = characterCard.slot4.level.ToString();
	}

	string getValue(int value)
    {
		if (value == 2 | value == 3) return "-4 (" + value + ")";
		if (value == 4 | value == 5) return "-3 (" + value + ")";
		if (value == 6 | value == 7) return "-2 (" + value + ")";
		if (value == 8 | value == 9) return "-1 (" + value + ")";
		if (value == 10 | value == 11) return "0 (" + value + ")";
		if (value == 12 | value == 13) return "1 (" + value + ")";
		if (value == 14 | value == 15) return "2 (" + value + ")";
		if (value == 16 | value == 17) return "3 (" + value + ")";
		if (value == 18 | value == 19) return "4 (" + value + ")";
		if (value == 20) return "5 (20)";
		return "-5 (1)";
	}

}
