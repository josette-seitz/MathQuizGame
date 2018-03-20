using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParticleSystemScript : MonoBehaviour {

    private ParticleSystem catPS;
    //Color startPS = Color.black;

    // Use this for initialization
    void Start () {
        Color orange = new Color32(219, 171, 68, 255);
        Color purple = new Color32(87, 26, 176, 255);
        Color red = new Color32(238, 33, 63, 255);

        catPS = this.GetComponent<ParticleSystem>();

        //ParticleSystem.MainModule start = catPS.main;
        //start.startColor = orange;

        GradientColorKey[] gradientColorKey = new GradientColorKey[3];
        gradientColorKey[0].color = orange;
        gradientColorKey[0].time = 0.35f;

        gradientColorKey[1].color = purple;
        gradientColorKey[1].time = 0.60f;

        gradientColorKey[2].color = red;
        gradientColorKey[2].time = 1f;

        //Create Gradient alpha
        GradientAlphaKey[] gradientAlphaKey = new GradientAlphaKey[5];
        gradientAlphaKey[0].alpha = 1f;
        gradientAlphaKey[0].time = 0.35f;

        gradientAlphaKey[1].alpha = 1f;
        gradientAlphaKey[1].time = 0.60f;

        gradientAlphaKey[2].alpha = 1f;
        gradientAlphaKey[2].time = 1f;

        //Create Gradient
        Gradient gradients = new Gradient();
        //Default is Blend, so change to Fixed 
        gradients.mode = GradientMode.Fixed;
        gradients.SetKeys(gradientColorKey, gradientAlphaKey);

        //Create Color from Gradient
        ParticleSystem.MinMaxGradient colors = new ParticleSystem.MinMaxGradient();
        colors.mode = ParticleSystemGradientMode.RandomColor;
        colors.gradient = gradients;

        //Assign the color to particle
        //To call startColor, store main in a temp variable first
        ParticleSystem.MainModule assignColor = catPS.main;
        assignColor.startColor= colors;


    }
	
	// Update is called once per frame
	void Update () {
		
	}
}
