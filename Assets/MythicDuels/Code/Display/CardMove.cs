using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.EventSystems;

[RequireComponent(typeof(Collider))]
public class CardMove : MonoBehaviour, IBeginDragHandler, IDragHandler, IEndDragHandler, IPointerEnterHandler, IPointerExitHandler
{

    // IBeginDragHandler, IEndDragHandler, IDragHandler
    // Estos interfaces son de Unity, para que funcionen hay que poner un PhysicsRaycast a la cámara y un EventSystem en la escena.
    // En la escena "Cartas" ya está configurado.
    

    // Pasos a seguir:
    // - Falta hacer que al soltarlas se compruebe si se han soltado sobre un objeto en el que se puedan soltar.
    // - Si no han impactado contra nada deberían volver a la mano.
    // - Si han impactado contra algo debería comprobarse si es una jugada válida
    //    - Si es válida ejecutarla,
    //    - Si no es válida, devolver la carta a la mano.

    private bool isDragging;
    private bool isEnabled = true;
    //private CardDisplay card;
    private Vector3 position;
    private Quaternion rotation;


    [Header("Card Properties")]
    public CardDisplay card;
    public CanvasGroup canvasGroup;

    [Header("Card Hover")]
    public bool canHover = false; // Hover and Drag are false by default and set to true when the card is instantiated.

    [Header("Card Drag")]
    public bool canDrag = false;
    public GameObject EmptyCard; // Used for creating an empty placeholder card where our current card used to be.
    private GameObject temp;

    private void Start()
    {
        //card = this.gameObject;
    }
    public void OnBeginDrag(PointerEventData eventData)
    {
        if (!canDrag) return;
        if (!isEnabled)
        {
            return;
        }
        temp = Instantiate(EmptyCard);
        temp.transform.SetParent(this.transform.parent, false);

        temp.transform.SetSiblingIndex(transform.GetSiblingIndex());
        position = transform.position;
        rotation = transform.rotation;
        isDragging = true;
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        if (!canDrag) return;
        if (!isEnabled || !isDragging)
        {
            return;
        }
        isDragging = false;
        Ray ray = Camera.main.ScreenPointToRay(eventData.position);

        Debug.DrawRay(ray.origin, ray.direction, Color.red);
        if (Physics.Raycast(ray, out RaycastHit hitInfo, float.MaxValue, LayerMask.GetMask("Player Zone")))
        {
            transform.position = new Vector3(hitInfo.transform.position.x, hitInfo.transform.position.y+(float)0.2, hitInfo.transform.position.z);
            transform.rotation = Quaternion.identity;
            //card.play();
        }
        else
        {
            transform.position = position;
            transform.rotation = rotation;

        }


    }
    public void OnDrag(PointerEventData eventData)
    {
        if (!canDrag) return;
        if (!isDragging)
        {
            return;
        }

        UpdatePosition(eventData.position);
    }


    private void UpdatePosition(Vector2 position)
    {
        if (isDragging)
        {
            Ray ray = Camera.main.ScreenPointToRay(position);

            Debug.DrawRay(ray.origin, ray.direction, Color.red);

            if (Physics.Raycast(ray, out RaycastHit hitInfo, float.MaxValue, LayerMask.GetMask("GameTerrain")))
            {
                transform.position = hitInfo.point + gameObject.transform.forward * -0.01f;
                transform.rotation = Quaternion.identity;
            }
        }
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        // If we can't hover, return.
        if (!canHover) return;

        // Move card locally
        card.transform.localScale = new Vector2(0.8f, 0.8f);
        card.transform.localPosition = new Vector2(card.transform.localPosition.x, 190);
        int index = card.transform.GetSiblingIndex();

        // Move corresponding card on opponent's screen
        Player.gameManager.isHovering = true;
        Player.gameManager.CmdOnCardHover(-25, index);
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        if (!canHover) return;

        // Return to normal
        card.transform.localScale = new Vector2(0.5f, 0.5f);
        card.transform.localPosition = new Vector2(card.transform.localPosition.x, 0);
        int index = card.handIndex;

        // Move corresponding card back to normal on opponent's screen
        Player.gameManager.CmdOnCardHover(0, index);
        Player.gameManager.isHovering = false;
    }
}
