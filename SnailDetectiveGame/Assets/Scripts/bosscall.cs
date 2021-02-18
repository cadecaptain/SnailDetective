using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bosscall : MonoBehaviour
{
    public string myText;
    private AudioSource source;

    // Start is called before the first frame update
    void Start()
    {
        source = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            GameManager.Instance.StartDialog(myText);
            source.Play();
            Debug.Log("Played");
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            GameManager.Instance.HideDialog();
            source.Stop();
        }
    }
}
