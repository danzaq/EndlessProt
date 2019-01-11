using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class GameManager : MonoBehaviour {

	public static GameManager current { get; private set; }

	private List<Block> _blocks;

	// Use this for initialization
	public float slowness = 10f;
    public TextMeshProUGUI textMesh;
    private string time = "";
    public static string finalTime = "";
	

	private void Awake()
	{
		if (current == null)
		{
			current = this;
		}
		else
		{
			DestroyImmediate(this);
		}
	}

	private void Start()
	{
		Input.simulateMouseWithTouches = true;
	}

    void Update()
    {
        time = Time.timeSinceLevelLoad.ToString("f0");
        textMesh.text = (time + "s");
    }

    public void EndGame()
	{
		StartCoroutine(RestartLevel());
	}

	IEnumerator RestartLevel()
	{
		Time.timeScale = 1f / slowness;
		Time.fixedDeltaTime = Time.fixedDeltaTime / slowness;

		yield return new WaitForSeconds(2f / slowness);

		while (_blocks.Count > 0)
		{
			Block b = _blocks[0];
			_blocks.Remove(b);

			Destroy(b.gameObject);
		}

		Time.timeScale = 1f;
		Time.fixedDeltaTime = Time.fixedDeltaTime * slowness;
        finalTime = (time + "s");

        SceneManager.LoadScene(1);
	}

	public void RegisterBlock(Block b)
	{
		if (_blocks == null) _blocks = new List<Block>();
		_blocks.Add(b);
	}

	public void UnregisterBlock(Block b)
	{
		if (_blocks == null) _blocks = new List<Block>();
		_blocks.Remove(b);
		Destroy(b.gameObject);
	}
}
