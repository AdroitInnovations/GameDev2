using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class FootstepsManager : MonoBehaviour
{
    private PlayerController_FP player;
    public LayerMask groundLayer;
    public float transitionTime = 0.2f;

    //Grass Footsteps
    public AudioSource grassAudio;
    public AudioClip[] grassSteps;
    public AudioMixerSnapshot grassSnapshot;

    //Concrete Footsteps
    public AudioSource concreteAudio;
    public AudioClip[] concreteSteps;
    public AudioMixerSnapshot concreteSnapshot;

    //Dirt Footsteps
    public AudioSource dirtAudio;
    public AudioClip[] dirtSteps;
    public AudioMixerSnapshot dirtSnapshot;

    //Gravel Footsteps
    public AudioSource gravelAudio;
    public AudioClip[] gravelSteps;
    public AudioMixerSnapshot gravelSnapshot;

    //Sand Footsteps
    public AudioSource sandAudio;
    public AudioClip[] sandSteps;
    public AudioMixerSnapshot sandSnapshot;

    //Wood Footsteps
    public AudioSource woodAudio;
    public AudioClip[] woodSteps;
    public AudioMixerSnapshot woodSnapshot;

    //Village music
    public AudioSource villageAudio;
    public AudioClip villageMusic;
    public AudioClip ambientMusic;

    // Use this for initialization
    void Start()
    {
        player = GetComponent<PlayerController_FP>();
    }

    // Update is called once per frame
    void Update()
    {
        RaycastHit hit;

        if (Physics.Raycast(transform.position, -Vector3.up, out hit, 5f, groundLayer))
        {
            if (hit.collider.tag == "Grass")
            {
                grassSnapshot.TransitionTo(transitionTime);
                PlayFootstepSFX(grassAudio, grassSteps);
            }
            else if (hit.collider.tag == "Concrete")
            {
                concreteSnapshot.TransitionTo(transitionTime);
                PlayFootstepSFX(concreteAudio, concreteSteps);
            }
            else if (hit.collider.tag == "Dirt")
            {
                dirtSnapshot.TransitionTo(transitionTime);
                PlayFootstepSFX(dirtAudio, dirtSteps);
            }
            else if (hit.collider.tag == "Gravel")
            {
                gravelSnapshot.TransitionTo(transitionTime);
                PlayFootstepSFX(gravelAudio, gravelSteps);
            }
            else if (hit.collider.tag == "Sand")
            {
                sandSnapshot.TransitionTo(transitionTime);
                PlayFootstepSFX(sandAudio, sandSteps);
            }
            else if (hit.collider.tag == "Wood")
            {
                woodSnapshot.TransitionTo(transitionTime);
                PlayFootstepSFX(woodAudio, woodSteps);
            }
        } 
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.name == "AudioTrigger")
        {
            villageAudio.clip = villageMusic;
            villageAudio.Play();
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.name == "AudioTrigger")
        {
            villageAudio.clip = ambientMusic;
            villageAudio.Play();
        }
    }

    void PlayFootstepSFX(AudioSource aSource, AudioClip[] aClips)
    {
        if (player.isWalking && !aSource.isPlaying)
        {
            int stepCount = Random.Range(0, aClips.Length);

            aSource.clip = aClips[stepCount];
            aSource.Play();
        }
    }



}


