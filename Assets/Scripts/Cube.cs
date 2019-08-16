using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cube : MonoBehaviour
{
    public Player player;

    void Update()
    {
        if (transform.position.y < -2)
        {
            player.Down();
            Destroy(gameObject);
        }
    }
}
