using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GemBehaviour : MonoBehaviour
{
	[Header("References")]
	public GameObject gemVisuals;
	public GameObject collectedParticleSystem;
	public CircleCollider2D gemCollider2D;
	//public int gemScore;
	private float durationOfCollectedParticleSystem;

	private DisplayScore displayscoreScript;

	void Start()
	{
		//gemScore = 0;
		durationOfCollectedParticleSystem = collectedParticleSystem.GetComponent<ParticleSystem>().main.duration;
		displayscoreScript = GameObject.FindGameObjectWithTag("score").GetComponent<DisplayScore>();
	}

	void OnTriggerEnter2D(Collider2D theCollider)
	{
		if (theCollider.CompareTag ("Player")) {
			GemCollected ();
		}
	}

	void GemCollected()
	{
		gemCollider2D.enabled = false;
		gemVisuals.SetActive (false);
		collectedParticleSystem.SetActive (true);
		//gemScore++;
		displayscoreScript.score++;
		Invoke ("DeactivateGemGameObject", durationOfCollectedParticleSystem);

	}

	void DeactivateGemGameObject()
	{
		gameObject.SetActive (false);
	}
}
