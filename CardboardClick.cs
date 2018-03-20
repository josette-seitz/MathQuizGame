using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CardboardClick : MonoBehaviour {

    void Start () {
        Renderer obj = GetComponent<Renderer>();
        obj.enabled = false;
	}
}
