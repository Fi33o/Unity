using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using System.Linq;

public class LevelGenerator : MonoBehaviour
{
	public List<GameObject> platform_prefabs = new List<GameObject>();
	public List<int> platform_chance = new List<int>();
	public List<GameObject> platform_variants = new List<GameObject>();

	public GameObject Player;
	public float platformDistance = 1f;
	public float levelWidth = 3f;
	private float current_level = 1f;
	private Vector3 spawnPos = new Vector3();
	List<GameObject> platforms_active = new List<GameObject>();

	void Start()
	{
		for (int i = 0; i <= platform_prefabs.Count - 1; ++i)
		{
			platform_variants.AddRange(Enumerable.Repeat(platform_prefabs[i], platform_chance[i]));
		}
	}

    private void Update()
    {
		if(platforms_active.Count != 0)
        {
            try
            {
				if (platforms_active[0].transform.position.y < Player.transform.position.y - 5)
				{
					Destroy(platforms_active[0]);
					platforms_active.Remove(platforms_active[0]);

					spawnPos.x = UnityEngine.Random.Range(-levelWidth, levelWidth);
					spawnPos.y = current_level * platformDistance;
					platforms_active.Add(Instantiate(platform_variants[UnityEngine.Random.Range(0, platform_variants.Count)], spawnPos, Quaternion.identity));
					//ItemSpawn();
					current_level += 1f;
				}
			}
            catch
            {
				platforms_active.Remove(platforms_active[0]);
				spawnPos.x = UnityEngine.Random.Range(-levelWidth, levelWidth);
				spawnPos.y = current_level * platformDistance;
				platforms_active.Add(Instantiate(platform_variants[UnityEngine.Random.Range(0, platform_variants.Count)], spawnPos, Quaternion.identity));
				//ItemSpawn();
				current_level += 1f;
			}
		}	
    }

	public void Play()
    {
		current_level = 1f;
		spawnPos.x = 0;
		spawnPos.y = 0;
		platforms_active.Add(Instantiate(platform_variants[0], spawnPos, Quaternion.identity));
		current_level += 1f;
		for (int i = 0; i < 10; i++)
		{
			spawnPos.x = UnityEngine.Random.Range(-levelWidth, levelWidth);
			spawnPos.y = current_level * platformDistance;
			platforms_active.Add(Instantiate(platform_variants[0], spawnPos, Quaternion.identity));
			current_level += 1f;
		}
	}

	public void Reset()
    {
		foreach(GameObject p in platforms_active)
        {
			Destroy(p);
		}
		platforms_active.Clear();
	}
}