using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinBlock : Block
{
    public GameObject Coin;
    bool Alive = true;
    protected override void Action(MovementController player)
    {
        if (Alive)
        {
            Destroy(transform.GetChild(1).gameObject);
            //transform.Translate(new Vector3(0.0f, 1.5f, 1.5f));
            //transform.Rotate(new Vector3(-90.0f, 0.0f, 0.0f));
            player.Coins++;
            GameObject instance = Instantiate(Coin, transform.position + Vector3.up * 5, Quaternion.identity);
            Destroy(instance, 3.0f);
            
            Alive = false;
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
