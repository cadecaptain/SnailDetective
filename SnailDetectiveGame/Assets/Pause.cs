using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pause : MonoBehaviour
{
    //private AudioSource source;
    // Start is called before the first frame update
    void Start()
    {
        //source = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void Awake() {
        GameManager.Instance.Pause();
        //source.Play();
    }
}
