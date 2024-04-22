using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ToggleSwordFX : MonoBehaviour
{
    public KeyCode toggleKey = KeyCode.Space;

    public ParticleSystem FX_Particle;
    public ParticleSystem startParticle;
    public ParticleSystem extinguishParticle;
    public GameObject pointLight;
    public Color bladeColor = Color.black;
    Material mymat;
    bool isPlaying = true;

    private void Start()
    {
        //FX_Particle = GetComponent<ParticleSystem>();
        mymat = GetComponent<Renderer>().material;
    }

    void Update()
    {
        if (Input.GetKeyDown(toggleKey))
        {
            if(isPlaying)
            {
                FX_Particle.Stop();
                pointLight.SetActive(false);
                mymat.SetColor("_EmissionColor", Color.black);
                if (extinguishParticle != null)
                    extinguishParticle.Play();
                isPlaying = false;
            } 
            else
            {
                FX_Particle.Play();
                this.pointLight.SetActive(true);
                mymat.SetColor("_EmissionColor", bladeColor);
                if (startParticle != null)
                    startParticle.Play();
                isPlaying = true;
            }
        }
    }
}
