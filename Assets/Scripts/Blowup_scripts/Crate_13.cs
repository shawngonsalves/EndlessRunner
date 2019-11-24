using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Crate_13 : MonoBehaviour
{
    // Start is called before the first frame update
    // public GameObject crate;
    public GameObject effect;

    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    public void Explode()
    {

        Instantiate(effect, this.gameObject.transform.position, this.gameObject.transform.rotation);
        Destroy(this.gameObject);

    }


}