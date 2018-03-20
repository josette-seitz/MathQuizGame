using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RaycasterScript : MonoBehaviour {

    public GameObject catObj;
    private Animator anim;
    private Collider coll;
    private Questions next;
    private Vector3[] catPos = new Vector3[6];
    private Vector3[] catRot = new Vector3[6];
    private int catIndex = 0;

    void Start()
    {
        catObj.SetActive(false);
        coll = catObj.GetComponent<Collider>();
        anim = catObj.GetComponent<Animator>();
        anim.enabled = false;
        next = GameObject.FindObjectOfType(typeof(Questions)) as Questions;

        catPos[0] = new Vector3(-10.98f, 10.02f, 8.76f);
        catPos[1] = new Vector3(22.4f, 2.95f, -23.6f);
        catPos[2] = new Vector3(-10.41f, -0.62f, -25.23f);
        catPos[3] = new Vector3(-1.44f, 10.2f, 14.59f);
        catPos[4] = new Vector3(2.5f, 10.65f, -25.35f);
        catPos[5] = new Vector3(0f, 1.63f, -0.78f);

        catRot[0] = CatRotate(134.142f);
        catRot[1] = CatRotate(312.485f);
        catRot[2] = CatRotate(14.38f);
        catRot[3] = CatRotate(167.78f);
        catRot[4] = CatRotate(343.986f);
        catRot[5] = CatRotate(180f);

        catObj.transform.position = catPos[catIndex];
        catObj.transform.eulerAngles = catRot[catIndex];
    }

    void FixedUpdate()
    {
        Vector3 fwd = transform.TransformDirection(Vector3.forward);
        RaycastHit hit;

        if (Physics.Raycast(transform.position, fwd, out hit, 500f))
        {
            if (hit.collider.gameObject.name == "Cat")
            {
                ActivateAnim();
                Invoke("TransitionToNextQuestion", 5f);
            }
        }
    }

    private void TransitionToNextQuestion()
    {
        catIndex++;
        if (catIndex < catPos.Length)
        {
            next.NextQuestion();
            anim.enabled = false;
            //Cat's Particle System
            catObj.transform.GetChild(2).gameObject.SetActive(false);
            catObj.transform.position = catPos[catIndex];
            catObj.transform.eulerAngles = catRot[catIndex];
            coll.enabled = true;
        }
        else
        {
            catIndex--;
        }
    }

    private Vector3 CatRotate(float yRotation)
    {
        return new Vector3(0f, yRotation, 0f);
    }

    public void ActivateAnim()
    {
        anim.enabled = true;
        //Cat's Particle System
        catObj.transform.GetChild(2).gameObject.SetActive(true);
        coll.enabled = false;
    }
}
