using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Spawn : MonoBehaviour {

    private int width = 100;
    private int height = 50;

	// Use this for initialization
	void Start ()
    {
        System.Random rnd = new System.Random();
        int halfWidth = width / 2;
        int halfHeight = height / 2;

        int side = rnd.Next(0, 4);

        int startX = 0;
        int startY = 0;

        switch (side)
        {
            case 0:
                startX = rnd.Next(0, width) - halfWidth;
                startY = halfHeight;
                break;
            case 1:
                startX = halfWidth;
                startY = rnd.Next(0, height) - halfHeight;
                break;
            case 2:
                startX = rnd.Next(0, width) - halfWidth;
                startY = -halfHeight;
                break;
            case 3:
                startX = -halfWidth;
                startY = rnd.Next(0, height) - halfHeight;
                break;
        }

        transform.position = new Vector2(startX, startY); 
	}
}
