using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GenericFactory<T> where T : MonoBehaviour
{
    private T original;

    //[SerializeField]
    //private T prefab;


    // He hecho que esta clase no sea un MonoBehaviour (no tiene porque estar en la escena)
    // El prefab, en lugar de arrastrarlo a una variable se lo pasamos en el constructor

    public GenericFactory(T original)
    {
        this.original = original;
    }

    // He hecho este método virtual para poder overridearlo en CharacterCardFactory
    public virtual T Get(Vector3 position, Quaternion rotation, Card card)
    {
        T pf = GameObject.Instantiate(original);
        pf.transform.SetPositionAndRotation(position, rotation);
        return pf;
    }
}