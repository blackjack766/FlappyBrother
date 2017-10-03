using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BGLooper : MonoBehaviour {

    int numBGPanels = 6;

    float pipeMax = 0.15f;
    float pipeMin = -0.7f;

    void Start() {
        GameObject[] pipes = GameObject.FindGameObjectsWithTag("Pipe");

        foreach (GameObject pipe in pipes) { 
            Vector3 pos = pipe.transform.position;
            pos.y = Random.Range(pipeMin, pipeMax);
            pipe.transform.position = pos;
        }
    } 

    private void OnTriggerEnter2D(Collider2D collider) {
        Debug.Log("Triggered: " + collider.name);

        float widthofBGOjbect = ((BoxCollider2D)collider).size.x;

        Vector3 pos = collider.transform.position;

        pos.x += widthofBGOjbect * numBGPanels;

        collider.transform.position = pos;

        if(collider.tag == "Pipes")  {
            pos.y = Random.Range(pipeMin, pipeMax);


        }
    } 
}
