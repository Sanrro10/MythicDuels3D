using System;
using UnityEngine;


public class MinionFactory<T> where T : MinionDisplay
{
    private T original;

    //[SerializeField]
    //private T prefab;


    // He hecho que esta clase no sea un MonoBehaviour (no tiene porque estar en la escena)
    // El prefab, en lugar de arrastrarlo a una variable se lo pasamos en el constructor

    public MinionFactory(T original)
    {
        this.original = original;
    }

    // He hecho este método virtual para poder overridearlo en CharacterCardFactory
    public virtual MinionDisplay Get(Vector3 position, Quaternion rotation, CharacterCardDisplay characterCardDisplay)
    {

        // Uso la clase base para crear la carta
        MinionDisplay pf = GameObject.Instantiate(original);
        pf.transform.SetPositionAndRotation(position, rotation);

        pf.SetMinion(characterCardDisplay);

        return pf;
    }
}
