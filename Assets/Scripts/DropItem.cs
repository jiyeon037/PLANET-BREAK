using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DropItem : MonoBehaviour {

    Rigidbody2D rb2d;
    Vector2 dropPow;
    float timer;

    private void Start()
    {
        int updown = Random.Range(1, 5);
        int leftright = Random.Range(-2, 3);

        rb2d = gameObject.GetComponent<Rigidbody2D>();

        dropPow = new Vector2(leftright, updown);
        this.rb2d.AddForce(dropPow, ForceMode2D.Impulse);
    }
    private void Update()
    {
        timer += Time.deltaTime;

        if(timer >= 0.3f)
        {
            rb2d.Sleep();
        }
        
    }
}
