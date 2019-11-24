using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlowupPrefab : MonoBehaviour
{

    public Transform player;
    public Transform effect;
    public AudioClip explosionClip;
    public bool playerNear;

    // Start is called before the first frame update
    void Start()
    {
        playerNear = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (playerNear == true && Input.GetKeyDown(KeyCode.F))
        {

            Instantiate(effect, this.gameObject.transform.position, this.gameObject.transform.rotation);
            AudioSource.PlayClipAtPoint(explosionClip, transform.position);
            Destroy(this.gameObject);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        playerNear = true;
    }

    private void OnTriggerExit(Collider other)
    {
        playerNear = false;
    }
}
