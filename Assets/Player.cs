using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class Player : MonoBehaviour {
	private int count;
	public Text coinCount;
	public Text winText;
	// number of coins to collect to win the game
	public int winCoinCount; 

	// Use this for initialization
	void Start () {
		count = 0;
		setCoinCountText ();
		hideWinText ();
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnTriggerEnter(Collider other) {
		if (other.gameObject.CompareTag ("PickUp")) {
			other.gameObject.SetActive(false);
			count++;
			setCoinCountText ();
			if (count >= winCoinCount)
				showWinText ();
		}
	}

	void setCoinCountText() {
		coinCount.text = "Coins: " + count.ToString ();
	}

	void showWinText() {
		winText.gameObject.SetActive (true);
	}

	void hideWinText() {
		winText.gameObject.SetActive (false);
	}
}
