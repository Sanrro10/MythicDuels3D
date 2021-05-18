using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEditor;

[Serializable]
public struct CardAndAmount
{
	public Card card;
	public int amount;
}
public class Card : ScriptableObject {

	public new string name;

	public Sprite artwork;

	public int level;

	public int clasS;

    [SerializeField] string id = "";
    public string CardID { get { return id; } }

    // We can't pass ScriptableCards over the Network, but we can pass uniqueIDs.
    // Throughout this project, you'll find that I've passed uniqueIDs through the Server,
    static Dictionary<string, Card> _cache;
    public static Dictionary<string, Card> Cache
    {
        get
        {
            if (_cache == null)
            {
                // Load all ScriptableCards from our Resources folder
                Card[] cards = Resources.LoadAll<Card>("");

                _cache = cards.ToDictionary(card => card.CardID, card => card);
            }
            return _cache;
        }
    }

    // Called when casting abilities or spells
    public virtual void Cast(Entity caster, Entity target)
    {

    }

    private void OnValidate()
    {
        // Get a unique identifier from the asset's unique 'Asset Path' (ex : Resources/Weapons/Sword.asset)
        // You're free to set your own uniqueIDs instead of using this current system, but unless
        // you know what you're doing, I wouldn't recommend changing this in the inspector.
        // If you do change it and want to change back, just erase the uniqueID in the inspector and it will refill itself.
        if (CardID == "")
        {
#if UNITY_EDITOR
            string path = AssetDatabase.GetAssetPath(this);
            id = AssetDatabase.AssetPathToGUID(path);
#endif
        }
    }
}
