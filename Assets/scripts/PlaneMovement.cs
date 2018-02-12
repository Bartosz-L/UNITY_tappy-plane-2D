using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlaneMovement : MonoBehaviour {

    public float FlyingAngle = 60f;
    public float FallAngle = -70f;

    public float CurrentAngle = 0f;

    public float Speed = 3f;
	
	// Update is called once per frame
	void Update () {
        // angle of movement
        var targetAngle = Input.GetKey(KeyCode.Space) ? FlyingAngle : FallAngle;
        CurrentAngle = Mathf.Lerp(CurrentAngle, targetAngle, Time.deltaTime * 2f);
        transform.rotation = Quaternion.Euler(Vector3.forward * CurrentAngle);
        // direction and speed of movement
        transform.Translate(Vector3.right * Speed * Time.deltaTime);

        if (Mathf.Abs(transform.position.y) > 2.2f)
        {
            SceneManager.LoadScene("gameover");
        }

	}
}
