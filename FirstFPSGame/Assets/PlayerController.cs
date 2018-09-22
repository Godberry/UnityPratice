using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour {

    private Animator AnimatorController;
	// Use this for initialization
	void Start () {
        AnimatorController = this.GetComponent<Animator>();
	}

    public float m_fMoveSpeed;
    float nCurrentSpeed = 0;

	// Update is called once per frame
	void Update () {
        float fResult = 0;
        if (Input.GetKey(KeyCode.W))
            fResult += m_fMoveSpeed;

        nCurrentSpeed = fResult;

        this.transform.position += Time.deltaTime * nCurrentSpeed * this.transform.forward;

        AnimatorController.SetFloat("Speed", nCurrentSpeed);
    }
}
