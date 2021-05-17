using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Mirror;

public class PlayerManager : NetworkBehaviour
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

    [Client]
    public override void OnStartClient()
    {
        base.OnStartClient();
        var playerCards = BuildDecks();
        playerCards.Shuffle();

        Player player = new Player(playerHandDisplay, playerCards);

        player.CmdDraw(4);
    }

    [Server]
    public override void OnStartServer()
    {
        base.OnStartServer();
        characterCardFactory = new CharacterCardFactory(characterCardDisplayOriginal);
    }
    public CardPile BuildDecks()
    {
        var cards = new CardPile();

        foreach (var card in availableCards)
        {
            //if (card is CharacterCard)
            //{
                var cardDisplay = characterCardFactory.Get(Vector3.zero, Quaternion.identity, card);
                //CharacterCardDisplay cardDisplay = CharacterCardDisplay.Instantiate(characterCardDisplayOriginal, Vector3.zero, Quaternion.identity);

                cardDisplay.SetCharacter(card as CharacterCard);

                NetworkServer.Spawn(cardDisplay.gameObject, connectionToClient);
            /*} else { card is AbilityCard) {


            } */
            cards.Add(cardDisplay);
        }

        return cards;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
