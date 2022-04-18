using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


// Paul Kent Yochum
// Collection Script
// 4/16/2022

public class Collection : MonoBehaviour
{

    public Text missedText;
    private int missed;

    void Update()
    {
        missedText.text = missed.ToString();    // Updates missed string with missed variable
    }

    private void OnTriggerEnter2D(Collider2D target)    // fruit or spider object destroy when collision with boxCollider2D
    {
        if(target.tag == "Fruit" || target.tag == "Spider")
        {
            Destroy(target.gameObject);
        }

        if(target.tag == "Fruit")    // Updates missed variable +1 for fruit tag that enters boxCollider2D
        {
            missed++;
        }
    }
}
