using UnityEngine;
using System.Collections;

public class CompleteAltarController : MonoBehaviour
{
    public static CompleteAltarController Instance;

    private static float SCORE_TO_ADD_PER_SECOND = 1;

    private float timer;
    private int newTimerValue = 1;
    public int numHits;

    // Use this for initialization
    void Start()
    {
        Instance = this;
        numHits = 0;
    }

    private void OnTriggerEnter2D(Collider2D playerCollider)
    {
        numHits++;
        GameController.instance.beginAuction |= numHits >= 2;
    }

    private void OnTriggerStay2D(Collider2D playerCollider)
    {
        numHits = 1;
        timer += Time.deltaTime;
        if ((int)timer != (int)newTimerValue && GameController.instance.currentState == GameController.GameStates.FreePlay)
        {
            newTimerValue = (int)timer;
            playerCollider.gameObject.GetComponent<CompletePlayerController>().currentScore += SCORE_TO_ADD_PER_SECOND;
            MenuToggle.Instance.UpdatePlayerScores();
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        numHits = 0;
    }
}
