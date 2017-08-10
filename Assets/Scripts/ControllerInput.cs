using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControllerInput : MonoBehaviour {

    // Use this for initialization

    public PlayerData player;

    public AudioClip fireClip, reloadClip, emptyClip;

    public AudioSource audioSource;



    public GameObject Spawner;
    public GameObject UI;

    public Transform gunBarrel;

    public int clipSize;

    public GameObject muzzleFlash;
    public int numBullets;
    public int numKilled;

    private bool inAction;
     
	void Start () {
        audioSource = GetComponent<AudioSource>();
        audioSource.clip = fireClip;
        numBullets = clipSize;
	}

    // Update is called once per frame
    void Update () {
        checkPlayButtons();
        checkUIButtons();
    }

    void checkPlayButtons()
    {
        if (!inAction&&!UI.activeInHierarchy)
        {
            if (OVRInput.Get(OVRInput.Button.PrimaryTouchpad) || Input.GetKeyDown("r"))
            {
                Reload();
                audioSource.Play();
            }
            else if (OVRInput.Get(OVRInput.Button.PrimaryIndexTrigger) || Input.GetKeyDown("g"))
            {
                if (numBullets > 0)
                {
                    Fire();
                    StartCoroutine(PauseInAction(0.5f));
                }
                else
                {
                    audioSource.clip = emptyClip;
                    StartCoroutine(PauseInAction(0.2f));
                }
                audioSource.Play();
            }
        }
    }

    void checkUIButtons()
    {
        if ((OVRInput.Get(OVRInput.Button.PrimaryTouchpad) && OVRInput.Get(OVRInput.Button.PrimaryIndexTrigger)) || Input.GetKeyDown("u"))
        {
            UI.SetActive(!UI.activeInHierarchy);
        }

        if (UI.activeInHierarchy)
        {
            RaycastHit hit;
            if (Physics.Raycast(transform.position, transform.forward, out hit))
            {
                if (hit.transform.tag == "Button")
                {
                    // Press the button :D
                }
            }
        }
    }

    IEnumerator PauseInAction(float seconds)
    {
        inAction = true;
        yield return new WaitForSeconds(seconds);
        inAction = false;
    }

    private void Fire()
    {
        audioSource.clip = fireClip;
        RaycastGun();
        numBullets--;
        StartCoroutine(fireParticle());
    }

    IEnumerator fireParticle()
    {
        muzzleFlash.SetActive(true);
        yield return new WaitForSeconds(0.1f);
        muzzleFlash.SetActive(false);
    }

    private void Reload()
    {
        audioSource.clip = reloadClip;
        numBullets += player.takeAmmo(clipSize-numBullets);
        if (numBullets == 0)
        {
            audioSource.clip = emptyClip;
            StartCoroutine(PauseInAction(0.2f));
            audioSource.Play();
        }
        else
        {
            audioSource.Play();
            StartCoroutine(PauseInAction(2));
        }
    }

    private void RaycastGun()
    {
        RaycastHit hit;
        if (Physics.Raycast(gunBarrel.position, gunBarrel.forward, out hit))
        {
            //second if statement here
            if (hit.collider.gameObject.CompareTag("Enemy"))
            {
                hit.collider.gameObject.GetComponent<Movement>().Death();
                Spawner.GetComponent<EnemySpawner>().killEnemy();
                numKilled++;
            }
        }
    }

    public bool paused()
    {
        return UI.activeInHierarchy;
    }
}
