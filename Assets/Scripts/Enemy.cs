using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour {
    Rigidbody2D enemyRb;
    float timeBeforeChange;
    public float delay = .5f;
    public float speed = .5f;
    // Start is called before the first frame update
    void Start() {
        enemyRb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update() {

        enemyRb.velocity = Vector2.right * speed;

        if (timeBeforeChange < Time.time) {
            speed *= -1;
            timeBeforeChange = Time.time + delay;
        }
    }
}
