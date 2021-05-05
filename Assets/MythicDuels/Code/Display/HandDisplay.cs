using UnityEngine;

public class HandDisplay : MonoBehaviour
{

    [SerializeField]
    private float spacing = 1;
    
    public void UpdateCards(CardPile hand)
    {
        // Ubicar las cartas en su sitio, lo mejor sería ponerlas en la misma posición que hand display 
        // y luego separarlas entre sí

        var totalSpace = spacing * (hand.Count - 1);

        for (int i = 0; i < hand.Count; i++)
        {
            var card = hand[i];

            float positionOffset = -totalSpace / 2f + spacing * i;

            card.transform.position = transform.position + transform.right * positionOffset;
            card.transform.rotation = transform.rotation;
        }
    }
}
