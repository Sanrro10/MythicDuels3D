using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.EventSystems;

[RequireComponent(typeof(Collider))]
public class CardMove : MonoBehaviour, IBeginDragHandler, IEndDragHandler, IDragHandler
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

    public void OnBeginDrag(PointerEventData eventData)
    {
        if (!isEnabled)
        {
            return;
        }
        isDragging = true;
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        if (!isEnabled || !isDragging)
        {
            return;
        }
        isDragging = false;

        // Comprobar si se ha soltado sobre algo

    }
    public void OnDrag(PointerEventData eventData)
    {
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

}
