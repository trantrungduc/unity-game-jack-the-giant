using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerScore : MonoBehaviour
{
    [SerializeField]
    private AudioClip coinClip, lifeClip;
    private CameraScript cameraScript;

    private bool countScore;
    private Vector3 previusPosition;
    public static int scoreCount, lifeCount, coinCount;
    
    void Awake()
    {
        cameraScript = Camera.main.GetComponent<CameraScript>();
    }
    void Start()
    {
        previusPosition = transform.position;
        countScore = true;
    }

    // Update is called once per frame
    void Update()
    {
        CountScore();
    }

    void CountScore()
    {
        if (countScore)
        {
            if (transform.position.y < previusPosition.y)
            {
                scoreCount++;
            }
            previusPosition = transform.position;
            GamePlayController.instance.SetScore(scoreCount);
        }
    }

    void OnTriggerEnter2D(Collider2D target)
    {
        if (target.tag == "Coin")
        {
            coinCount++;
            scoreCount += 200;
            AudioSource.PlayClipAtPoint(coinClip,transform.position);
            target.gameObject.SetActive(false);

            GamePlayController.instance.SetScore(scoreCount);
            GamePlayController.instance.SetCoinScore(coinCount);
        }
        if (target.tag == "Life")
        {
            lifeCount++;
            scoreCount += 300;

            AudioSource.PlayClipAtPoint(lifeClip, transform.position);
            target.gameObject.SetActive(false);

            GamePlayController.instance.SetScore(scoreCount);
            GamePlayController.instance.SetLifeScore(lifeCount);
        }

        if (target.tag == "Bounds" || target.tag=="Deadly")
        {
            cameraScript.moveCamera = false;
            countScore = false;
            lifeCount--;
            transform.position = new Vector3(500, 500, 0);

            GamePlayController.instance.SetLifeScore(lifeCount);
            GameManager.instance.CheckGameStatus(scoreCount, coinCount, lifeCount);
        }
        
    }
}
