using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Headquarters : MonoBehaviour
{
    public GameObject textBoxObject;
    public Text textBoxComponent, timer;
    public string textForTextObject;

    public float timeToGetBriefcases = 120;

    public float timeElapsed = 0;

    private void Update() 
    {
        timeElapsed += Time.deltaTime;
        var timeLeft = timeToGetBriefcases - timeElapsed;
        timer.text = string.Format("{0:0}:{1:00.00}", (int)(timeLeft/60), timeLeft%60);
        if (timeElapsed > timeToGetBriefcases)
        {
            SceneManager.LoadScene("Failure");
        }
    }

    private void OnTriggerEnter2D(Collider2D other) 
    {
        if (other.gameObject.CompareTag("Player"))
        {
            var inventory = other.GetComponent<Inventory>();
            if (inventory.FoundAllNeededBriefcases())
            {
                GameState.LogTime(timeElapsed);
                SceneManager.LoadScene("Success");
            }
            else
            {
                textBoxObject.SetActive(true);
                textBoxComponent.text = textForTextObject;
            }
        }
    }
    private void OnTriggerExit2D(Collider2D other) 
    {
        if (other.gameObject.CompareTag("Player"))
        {
            textBoxObject.gameObject.SetActive(false);
        }
    }
}
