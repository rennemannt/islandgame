using UnityEngine;
using System.Collections;

public class KillByContact : MonoBehaviour
{
    private string gameControllerTag = "GameController";
    private GameController gameController;
    
    // Use this for initialization
    void Start()
    {
        GameObject gameObject = GameObject.FindGameObjectWithTag(gameControllerTag);
        if (gameObject != null)
        {
            gameController = gameObject.GetComponent<GameController>();
        }
        if (gameController == null)
        {
            Debug.Log("Cannot find '"+ gameControllerTag + "' in " + this.GetType().Name + "!");
        }
    }

    // Update is called once per frame
    void Update()
    {

    }

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Zombie")
        {
            gameController.killPlayer();
        }
    }
}
