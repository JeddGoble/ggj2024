using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Goal : MonoBehaviour
{
    void OnTriggerEnter2D(Collider2D other) 
    {
        if (other.tag == "Volunteer") 
        {
            Volunteer vol = other.gameObject.GetComponent<Volunteer>();
            vol.SwapToBriefcase();
            GameManager.instance.GoalTouched();
            gameObject.SetActive(false);
        }
    }
}
