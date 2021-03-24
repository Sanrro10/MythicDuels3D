using System;
using System.Collections.Generic;
using System.Linq;

public class CardPile : List<CardDisplay>
{
    private static Random rng = new Random();

    public void Shuffle()
    {
        int n = this.Count;
        while (n > 1)
        {
            n--;
            int k = rng.Next(n + 1);
            var value = this[k];
            this[k] = this[n];
            this[n] = value;
        }
    }

    public IEnumerable<CardDisplay> Pick(int amount) {
        var cards = this.Take(amount).ToArray();
        foreach (var card in cards)
        {
            Remove(card);
        }
        return cards;
    }


}
