using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CardFlipper : MonoBehaviour
{
    public iTween.EaseType easeType;
    public iTween.LoopType loopType;


    public void Flip()
    {
        Debug.Log("Se ha lanzado el Flip");
        iTween.RotateTo(this.gameObject, iTween.Hash("z", 180, "time", 1.5f, "easetype", easeType, "looptype", loopType));
    }
}
