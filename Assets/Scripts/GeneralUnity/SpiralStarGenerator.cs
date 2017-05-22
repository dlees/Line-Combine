using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpiralStarGenerator : MonoBehaviour {

    public SpiralMover StarGO;
    public int numberOnStartup = 30;

    void OnEnable()
    {
        for (int i = 0; i < numberOnStartup; i++)
        {
            Vector2 min = Camera.main.ViewportToWorldPoint(new Vector2(0, 0));
            Vector2 max = Camera.main.ViewportToWorldPoint(new Vector2(1, 1));

            int direction = Random.Range(0, 2) * 2 - 1;

            StarGO.revolutionSpeed = direction * Random.Range(10.0f, 19.0f);
            StarGO.startRadius = Random.Range(.02f, .04f);
            StarGO.spiralIncrease = Random.Range(.75f,  1.5f);

            GameObject star = (GameObject)Instantiate(StarGO.gameObject);

          //  star.transform.position = new Vector2(Random.Range(min.x, max.x), Random.Range(min.y, max.y));
            star.transform.parent = transform;

        }
    }

}
