using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AbilityDisplay : MonoBehaviour
{

    [SerializeField]
	private Text name;

    [SerializeField]
    private Text castingTime;

    [SerializeField]
    private Text type;

    [SerializeField]
    private Text level;

    internal void Init(Ability ability)
	{
        name.text = ability.name;
        castingTime.text = ability.castingtime;
        type.text = ability.type;
        level.text = ability.level.ToString();
    }
}
