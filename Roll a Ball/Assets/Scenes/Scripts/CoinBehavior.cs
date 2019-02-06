using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinBehavior : MonoBehaviour
{
    GameBehavior GBS;
    private float rotateSpeed = 10f;
    // Start is called before the first frame update

    private void Awake()
    {
        GBS = GameObject.Find("GameBehavior").GetComponent<GameBehavior>();
        GBS.cur_coins++;
    }
 
    // Update is called once per frame
    void Update()
    {
        transform.Rotate(Vector3.left * rotateSpeed);    
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            Destroy(gameObject);
            GBS.cur_coins--;
            //adding score...
            GBS.UpdateUI();
        }
    }
}
