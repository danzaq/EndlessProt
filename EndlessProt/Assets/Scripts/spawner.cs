using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class spawner : MonoBehaviour {

    public Transform[] spawnPoints;
	public Block[] traffic;
	
	public float timeBetweenWaves = 1f;
	public float timeToSpawn = 2f;
    public float difficulty = 0.01f;
    // Update is called once per frame
    private void Start()
    {
        StartCoroutine(increaseDifficulty());
    }
    void Update () {
		if (Time.time >= timeToSpawn)
		{
			SpawnBlocks();
			timeToSpawn = Time.time + timeBetweenWaves;
		}
	}

	void SpawnBlocks () 
	{
		int randomIndex = Random.Range(1,spawnPoints.Length-1);

		for (int i = 0; i < spawnPoints.Length; i++)
		{
			if(randomIndex != i)
			{
                int randomTraffic = Random.Range(0, traffic.Length);
                Block b = Instantiate<Block>(traffic[randomTraffic], spawnPoints[i].position,spawnPoints[i].rotation);
				GameManager.current.RegisterBlock(b);
			}
		}
	}
    
    IEnumerator increaseDifficulty()
    {
        yield return new WaitForSeconds(3f);
        if (timeBetweenWaves > 0.45)
        {
            timeBetweenWaves = timeBetweenWaves - difficulty;
        }
        
        StartCoroutine(Repeat());
    }
    IEnumerator Repeat()
    {
        yield return new WaitForSeconds(2f);
        StartCoroutine(increaseDifficulty());
    }
}
