using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParticleDestroy : MonoBehaviour
{

    ParticleSystem p;

	// Use this for initialization
	void Start ()
    {
        p = GetComponent<ParticleSystem>();

        //StartCoroutine(Life());

        Destroy(this.gameObject, p.main.duration);
	}
	
    IEnumerator Life()
    {
        yield return new WaitForSeconds(p.main.duration);

        Destroy(this.gameObject);

        yield return null;
    }

	// Update is called once per frame
	void Update () {
		
	}
}
