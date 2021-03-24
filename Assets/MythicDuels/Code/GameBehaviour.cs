using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameBehaviour : MonoBehaviour
{
    //public Mazo mazo;

    //// Estos Slots deberían ser una lista
    //public GameObject deckGameObject;

    
    //public GameObject characterSlot1; //Cambiar por un Vector3 y un Quaternion al saber que las posiciones son las correctas
    //public GameObject characterSlot2;
    //public GameObject characterSlot3;
    //public GameObject characterSlot4;
    //public GameObject characterSlot5;

    //private ArrayList characterHand;
    //private ArrayList abilityHand;


    [SerializeField]
    private Card[] availableCards;

    [SerializeField]
    private HandDisplay playerHandDisplay;

    [SerializeField]
    private HandDisplay rivalHandDisplay;

    [SerializeField]
    private CharacterCardDisplay characterCardDisplayOriginal;

    private CharacterCardFactory characterCardFactory;

    private Player local;
    private Player rival;

    private void Awake()
    {
        characterCardFactory = new CharacterCardFactory(characterCardDisplayOriginal);
    }


    // Cuando sea networking, esto no debería lanzarse en el Start, sino haya dos jugadores unidos a la partida y el 
    // jugador que Hostea la partida pulsa empezar. Además, solo el jugador que hostea debería crear los mazos 
    // y sincronizarlos por red.
    void StartGame()
    {
        var playerCards = BuildDecks();
        playerCards.Shuffle();
        var rivalCards = BuildDecks();
        playerCards.Shuffle();

        var local = new Player(playerHandDisplay, playerCards);
        var rival = new Player(rivalHandDisplay, rivalCards);

        local.Draw(7);
        rival.Draw(7);
    }

    public CardPile BuildDecks()
    {
        var cards = new CardPile();

        foreach (var card in availableCards)
        {
            //if (card is CharacterCard)
            //{
                var cardDisplay = characterCardFactory.Get(Vector3.zero, Quaternion.identity, card);
            /*} else { card is AbilityCard) {


            } */
            cards.Add(cardDisplay);
        }

        return cards;

        //Quaternion rotacion = Quaternion.Euler(0f, 0f, 0f);
        //CharacterCardPrefab prefab = characterCardFactory.GetNewInstance(characterSlot1.transform.position, rotacion, mazo.getCharacterCards()[0]);
        //characterHand.Add(prefab);
        //prefab = characterCardFactory.GetNewInstance(characterSlot2.transform.position, rotacion, mazo.getCharacterCards()[0]);
        //characterHand.Add(prefab);
        //prefab = characterCardFactory.GetNewInstance(characterSlot3.transform.position, rotacion, mazo.getCharacterCards()[0]);
        //characterHand.Add(prefab);
        //prefab = characterCardFactory.GetNewInstance(characterSlot4.transform.position, rotacion, mazo.getCharacterCards()[0]);
        //characterHand.Add(prefab);
        //prefab = characterCardFactory.GetNewInstance(characterSlot5.transform.position, rotacion, mazo.getCharacterCards()[0]);
        //characterHand.Add(prefab);

        //for (int i = 0; i < mazo.getHabilityCards().Count; i++)
        //{
        //prefab = factory.GetNewInstance(deckGameObject.transform.position, rotacion); //Sumarle altura con cada carta
        //prefab.gameObject.
        //abilityDeck.Add(prefab);
        //}
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
