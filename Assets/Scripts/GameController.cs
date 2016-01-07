using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class GameController : MonoBehaviour
{
    private string playerControllerTag = "Player";
    private string winMsg = "You Win!";
    private string failMsg = "You Died!";
    private ThirdPersonAnimatorController player;
    private int count;
    public Text coinCount;
    public Text winText;
    public Text instructions;
    public AudioSource coinSound;
    // number of coins to collect to win the game
    public int winCoinCount;

    // Use this for initialization
    void Start()
    {
        GameObject gameObject = GameObject.FindGameObjectWithTag(playerControllerTag);
        if (gameObject != null)
        {
            player = gameObject.GetComponent<ThirdPersonAnimatorController>();
        }
        if (player == null)
        {
            Debug.Log("Cannot find '" + playerControllerTag + "' in " + this.GetType().Name + "!");
        }
        count = 0;
        setCoinCountText();
        hideWinText();
    }

    // Update is called once per frame
    void Update()
    {
        if (count >= winCoinCount) //|| player.dead)
        {
            showWinText();
        }
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("PickUp"))
        {
            other.gameObject.SetActive(false);
            count++;
            setCoinCountText();
            instructions.gameObject.SetActive(false);
            coinSound.Play();
        }
    }

    public void killPlayer()
    {
        player.dead = true;
    }

    private void setCoinCountText()
    {
        coinCount.text = "Coins: " + count.ToString();
    }

    void showWinText()
    {
        winText.gameObject.SetActive(true);
        //if (player.dead)
        //{
        //    winText.text = failMsg;
        //}
        //else
        //{
            winText.text = winMsg;
        //}
    }

    void hideWinText()
    {
        winText.gameObject.SetActive(false);
    }
}
