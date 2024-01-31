using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnableArea : MonoBehaviour
{
    public GameObject volunteer;
    private Camera cam;

    void Start() {
        cam = Camera.main;
    }

    void OnMouseDown() {
        if (GameManager.instance.volunteersRemaining <= 0) {
            return;
        }

        Vector3 mousePosition = cam.ScreenToWorldPoint(Input.mousePosition);
        mousePosition.z = 0f;
        Instantiate(volunteer, mousePosition, Quaternion.identity);

        GameManager.instance.SpawnedVolunteer();
    }
}
