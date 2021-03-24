using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{

    private readonly HandDisplay handDisplay;

    private CardPile hand;

    private CardPile deck;

    private CardPile discard;

    public Player(HandDisplay handDisplay, CardPile cards)
    {
        this.handDisplay = handDisplay;

        hand = new CardPile();
        deck = cards;
        discard = new CardPile();
    }

    internal void Draw(int amount)
    {
        var drawnCards = deck.Pick(amount);

        AddCardsToHand(drawnCards);
    }

    private void AddCardsToHand(IEnumerable<CardDisplay> drawnCards)
    {
        hand.AddRange(drawnCards);

        handDisplay.UpdateCards(hand);
    }
}
