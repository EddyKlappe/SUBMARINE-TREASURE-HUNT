using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PickUpTreasure : MonoBehaviour {
	public GameObject StoredCollider;
	public GameObject Treasure1;
	public GameObject Treasure2;
	public GameObject Treasure3;
	public GameObject TreasureHook;
	public GameObject TreasureStored1;
	public GameObject TreasureStored2;
	public GameObject TreasureStored3;

	public AudioClip PickUp;
	AudioSource audioSource;

	private int TreasureCount;

	bool PickedThreasureUp;
	bool Treasure1Hooked;
	bool Treasure2Hooked;
	bool Treasure3Hooked;

	void Start () {
		TreasureHook.SetActive(false);
		TreasureStored1.SetActive(false);
		TreasureStored2.SetActive(false);
		TreasureStored3.SetActive(false);

		audioSource = GetComponent<AudioSource>();

		TreasureCount = 0;
	}

	void Update ()
	{
		if (TreasureCount == 3) 
		{
			SceneManager.LoadScene("EndMenuScene");
		}
	}

	void OnTriggerEnter(Collider other)
	{
		if (PickedThreasureUp == false) {
			audioSource.PlayOneShot(PickUp);

			if (other.gameObject.CompareTag("Treasure1"))
			{
				Treasure1.SetActive (false);
				TreasureHook.SetActive(true);
				PickedThreasureUp = true;
				Treasure1Hooked = true;
				Treasure2Hooked = false;
				Treasure3Hooked = false;
				return;
			}

			if (other.gameObject.CompareTag("Treasure2"))
			{
				Treasure2.SetActive (false);
				TreasureHook.SetActive(true);
				PickedThreasureUp = true;
				Treasure1Hooked = false;
				Treasure2Hooked = true;
				Treasure3Hooked = false;
				return;
			}

			if (other.gameObject.CompareTag("Treasure3"))
			{
				Treasure3.SetActive (false);
				TreasureHook.SetActive(true);
				PickedThreasureUp = true;
				Treasure1Hooked = false;
				Treasure2Hooked = false;
				Treasure3Hooked = true;
				return;
			}

			if (other.gameObject.CompareTag("Storage"))
			{
				return;
			}
		}
		
		if (PickedThreasureUp == true) {
			if (other.gameObject.CompareTag("Storage"))
			{
				TreasureHook.SetActive(false);
				PickedThreasureUp = false;

				if (Treasure1Hooked == true) {
					TreasureStored1.SetActive(true);
					TreasureCount = TreasureCount + 1;
					return;
				}

				if (Treasure2Hooked == true) {
					TreasureStored2.SetActive(true);
					TreasureCount = TreasureCount + 1;
					return;
				}

				if (Treasure3Hooked == true) {
					TreasureStored3.SetActive(true);
					TreasureCount = TreasureCount + 1;
					return;
				}
			}

		}

	}
		
			
}
