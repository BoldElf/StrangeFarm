using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class SceneDependenciesContainer : Dependency
{
    //[SerializeField] private RaceStateTracker raceStateTracker;
    [SerializeField] private UINotification uINotification;


    protected override void BindAll(MonoBehaviour monoBehaviourInScene)
    {
        //Bind<RaceStateTracker>(raceStateTracker, monoBehaviourInScene);
        Bind<UINotification>(uINotification, monoBehaviourInScene);
    }

    private void Awake()
    {
        FindAllObjectToBind();
    }

}

