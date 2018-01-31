using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerPerspectiveController : MonoBehaviour {
    private float MovementSpeed;

    void Start () {
        MovementSpeed = 10f;
	}

	void Update () {
        transform.position += Vector3.Normalize(new Vector3(Input.GetAxisRaw("Horizontal"), 0f, Input.GetAxisRaw("Vertical"))) * MovementSpeed * Time.deltaTime;
    }
}
