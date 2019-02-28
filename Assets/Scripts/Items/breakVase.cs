using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class breakVase : MonoBehaviour {

    public GameObject broken;
    public GameObject unbroken;
    public GameObject key;

    public void Break() {
        broken.SetActive(true);
        unbroken.SetActive(false);
        StartCoroutine(disableCollision());
        GameObject newKey = Instantiate(key);
        newKey.transform.position = transform.position;
    }

    private IEnumerator disableCollision() {
        yield return new WaitForSeconds(1);
        GetComponent<BoxCollider>().enabled = false;
    }
}
