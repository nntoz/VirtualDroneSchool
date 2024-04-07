using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class torus : MonoBehaviour
{
    public learning learningScript;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    void OnTriggerEnter(Collider other)
    {
        //接触したオブジェクトのタグが"Player"のとき
        if(other.CompareTag("Player")){
            learningScript.nextSection();
        }
    }
}
