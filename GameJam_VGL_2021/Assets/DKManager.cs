using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DKManager : MonoBehaviour
{

    public GameObject tonneauPrefab;

    public Transform tonneauSpawn;

    public float spawnDelayMin = 1;
    public float spawnDelayMax = 2;
    public int nbrTonneau;

    

    IEnumerator SpawnTonneau()
    {
        for (int i = 0; i < nbrTonneau; i++)
        {
            GameObject tonneau = Instantiate(tonneauPrefab, tonneauSpawn.position, Quaternion.Euler(-90, 0, 0));
            tonneau.GetComponent<DKTonneau>().GoToLeft();
            yield return new WaitForSeconds(Random.Range(spawnDelayMin, spawnDelayMax));
        }
    }

    private void Start()
    {
        StartCoroutine("SpawnTonneau");
    }
}
