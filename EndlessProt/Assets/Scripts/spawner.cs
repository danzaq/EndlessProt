using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class spawner : MonoBehaviour {

	public Transform[] spawnPoints;
	public Block Block;
	
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
				Block b = Instantiate<Block>(Block, spawnPoints[i].position, Quaternion.identity);
				GameManager.current.RegisterBlock(b);
			}
		}
	}
    
    IEnumerator increaseDifficulty()
    {
        yield return new WaitForSeconds(3f);
        timeBetweenWaves = timeBetweenWaves - difficulty;
        StartCoroutine(Repeat());
    }
    IEnumerator Repeat()
    {
        yield return new WaitForSeconds(2f);
        StartCoroutine(increaseDifficulty());
    }
}
