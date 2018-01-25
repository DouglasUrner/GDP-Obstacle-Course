using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleController : MonoBehaviour {
		
	public GameObject obstaclePrefab;
	public float spawnDist = 3f;
	
	private bool quitting = false;
	private GameObject player;

	void Start () {
		player = GameObject.Find("Player");
	}

	private void OnApplicationQuit() {
		quitting = true;
	}

	private void OnDestroy() {
		Debug.Log(name + ".OnDestory()");
		
		if (!quitting) {
			var newObstacle = Instantiate(obstaclePrefab);
			var playerPosition = player.transform.position;
			newObstacle.transform.position = playerPosition + new Vector3(Random.RandomRange(0f, spawnDist), Random.RandomRange(0f, spawnDist), 0);
			newObstacle.tag = "Obstacle";
			newObstacle.SetActive(true);
		}
	}
}
