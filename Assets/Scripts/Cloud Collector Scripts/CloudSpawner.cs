﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CloudSpawner : MonoBehaviour
{
    [SerializeField]
    private GameObject[] clouds;

    private float distanceBetweenClouds = 3f, minX, maxX,lastCloudPositionY,controlX;

    [SerializeField]
    private GameObject[] collectables;

    private GameObject player;

    void Awake()
    {
        controlX = 0;
        setMinAndMaxX();
        CreateClouds();
        player = GameObject.Find("Player");

        for (int i = 0; i < collectables.Length; i++)
        {
            collectables[i].SetActive(false);
        }
    }
    void Start()
    {
        PositionThePlayer();
    }

    void setMinAndMaxX()
    {
        Vector3 bounds = Camera.main.ScreenToViewportPoint(new Vector3(Screen.width,Screen.height, 0));
        maxX = bounds.x - 0.5f;
        minX = -bounds.x + 0.5f;
    }

    void Shuffle(GameObject[] arraytoShuffle)
    {
        for (int i = 0; i < arraytoShuffle.Length; i++)
        {
            GameObject temp = arraytoShuffle[i];
            int random = Random.Range(i, arraytoShuffle.Length);
            arraytoShuffle[i] = arraytoShuffle[random];
            arraytoShuffle[random] = temp;
        }
    }

    void CreateClouds()
    {
        Shuffle(clouds);
        float positionY=0f;
        for (int i = 0; i < clouds.Length; i++)
        {
            Vector3 temp = clouds[i].transform.position;
            temp.y = positionY;
            temp.x = Random.Range(minX, maxX);

            if (controlX == 0)
            {
                temp.x = Random.Range(0.0f, maxX);
                controlX++;
            }
            else if (controlX==1)
            {
                temp.x = Random.Range(0.0f, minX);
                controlX++;
            }
            else if (controlX == 2)
            {
                temp.x = Random.Range(1.0f, maxX);
                controlX++;
            }
            else if (controlX == 3)
            {
                temp.x = Random.Range(-1.0f, minX);
                controlX = 0;
            }

            lastCloudPositionY = positionY;
            clouds[i].transform.position = temp;
            positionY -= distanceBetweenClouds;

        }
    }

    void PositionThePlayer()
    {
        GameObject[] darkClouds = GameObject.FindGameObjectsWithTag("Deadly");
        GameObject[] cloudsInGames = GameObject.FindGameObjectsWithTag("Cloud");
        for (int i = 0; i < darkClouds.Length; i++)
        {
            if (darkClouds[i].transform.position.y == 0f)
            {
                Vector3 t = darkClouds[i].transform.position;
                darkClouds[i].transform.position = new Vector3(cloudsInGames[0].transform.position.x,cloudsInGames[0].transform.position.y,cloudsInGames[0].transform.position.z);

                cloudsInGames[0].transform.position = t;

            }
        }

        Vector3 temp = cloudsInGames[0].transform.position;
        for (int i = 1; i < cloudsInGames.Length; i++)
        {
            if (temp.y < cloudsInGames[i].transform.position.y)
            {
                temp = cloudsInGames[i].transform.position;
            }
        }

        temp.y += 0.8f;

        player.transform.position = temp;
    }

    void OnTriggerEnter2D(Collider2D target)
    {
        if (target.tag=="Cloud" || target.tag == "Deadly")
        {
            if (target.transform.position.y == lastCloudPositionY)
            {
                Shuffle(clouds);
                Shuffle(collectables);
                Vector3 temp = target.transform.position;

                for (int i = 0; i < clouds.Length; i++)
                {
                    if (!clouds[i].activeInHierarchy)
                    {
                        if (controlX == 0)
                        {
                            temp.x = Random.Range(0.0f, maxX);
                            controlX++;
                        }
                        else if (controlX == 1)
                        {
                            temp.x = Random.Range(0.0f, minX);
                            controlX++;
                        }
                        else if (controlX == 2)
                        {
                            temp.x = Random.Range(1.0f, maxX);
                            controlX++;
                        }
                        else if (controlX == 3)
                        {
                            temp.x = Random.Range(-1.0f, minX);
                            controlX = 0;
                        }

                        temp.y -= distanceBetweenClouds;
                        lastCloudPositionY = temp.y;
                        clouds[i].transform.position = temp;
                        clouds[i].SetActive(true);

                        int random = Random.Range(0, collectables.Length);
                        if (clouds[i].tag != "Deadly")
                        {
                            if (!collectables[random].activeInHierarchy)
                            {
                                Vector3 temp2 = clouds[i].transform.position;
                                temp2.y += 0.7f;
                                if (collectables[random].tag == "Life")
                                {
                                    if (PlayerScore.lifeCount < 2)
                                    {
                                        collectables[random].transform.position = temp2;
                                        collectables[random].SetActive(true);
                                    }
                                }
                                else
                                {
                                    collectables[random].transform.position = temp2;
                                    collectables[random].SetActive(true);
                                }
                            }
                        }
                    }
                }
            }
        }
    }
}
