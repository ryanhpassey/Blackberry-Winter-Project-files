using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class IceBallSpawner : MonoBehaviour
{
    public Transform iceBallPivot;
    private float iceBallSpinSpeed = 200f;
    private int i;

    public IceBallManager iceBall1;
    public IceBallManager iceBall2;
    public IceBallManager iceBall3;
    /*public IceBallManager iceBall4;
    public IceBallManager iceBall5;
    public IceBallManager iceBall6;*/

    private List<IceBallManager> iceBalls = new List<IceBallManager>();

    void Start()
    {
        i = 0;
        iceBalls.Add(iceBall1);
        iceBalls.Add(iceBall2);
        iceBalls.Add(iceBall3);
    }

    private void FixedUpdate()
    {
        // spins the pivot for the ice balls at a regular interval
        iceBallPivot.Rotate(Vector3.forward * iceBallSpinSpeed * Time.fixedDeltaTime);
    }

    private void SpawnIceBall(IceBallManager iceBall)
    {
        // the ice ball is always there, just activate it
        iceBall.Activate();
    }

    public void OnSpawnIceBall()
    {
        // activate the next on the list. If we're past the length, then restart
        if (i > 2)
            i = 0;
        SpawnIceBall(iceBalls[i]);
        i += 1;
    }
}
