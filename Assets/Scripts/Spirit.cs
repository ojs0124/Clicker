using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spirit : MonoBehaviour
{
    public Player player;

    private float time;

    private void Awake()
    {
        player = GameManager.Instance.Player;
    }

    void Update()
    {
        if(time > 30)
        {
            Destroy(gameObject);
            player.GameData.spiritSpawnedCount -= 1;
        }
        time += Time.deltaTime;
    }
}
