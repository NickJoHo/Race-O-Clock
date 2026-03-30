using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TankAI : MonoBehaviour
{
    public GameObject Tank;

    private float spawnDelayMin = 2f;
    private float spawnDelayMax = 5f;

    private float spawnRateMin = 6f;
    private float spawnRateMax = 10f;

    public Vector3 spawnPos1 = new Vector3(-6.5f, 0.1f, 181);
    public Vector3 spawnPos2 = new Vector3(6.5f, 0.1f, 181);

    private float endBound = -10f;
    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating("spawnObjects1", Random.Range(spawnDelayMin, spawnDelayMax), Random.Range(spawnRateMin, spawnRateMax));
        InvokeRepeating("spawnObjects2", Random.Range(spawnDelayMin, spawnDelayMax), Random.Range(spawnRateMin, spawnRateMax));
    }

    // Update is called once per frame
    void Update()
    {
        if (Tank.transform.position.z < endBound)
        {
            Destroy(Tank);
        }

    }

    void spawnObjects1()
    {
        Instantiate(Tank, spawnPos1, Tank.transform.rotation);

    }

    void spawnObjects2()
    {
        Instantiate(Tank, spawnPos2, Tank.transform.rotation);

    }
}