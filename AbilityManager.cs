using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AbilityManager : MonoBehaviour
{

    List<ILearnable> _activeAbilities = new List<ILearnable>();

    void Awake ()
    {

    }

    private void LearnAbility(ILearnable ability)
    {
        _activeAbilities.Add(ability);
        ability.Activate();
    }
}
