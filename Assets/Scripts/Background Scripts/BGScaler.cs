using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BGScaler : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        SpriteRenderer sr = GetComponent<SpriteRenderer>();
        Vector3 temp = transform.localScale;
        float width = sr.sprite.bounds.size.x, worldHeight = Camera.main.orthographicSize * 2f,worlWidth = worldHeight * Screen.width/Screen.height;
        temp.x = worlWidth / width;
        transform.localScale = temp;
    }

}
