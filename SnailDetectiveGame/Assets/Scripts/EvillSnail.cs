using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class EvillSnail : MonoBehaviour
{

    public List<GameObject> locs;

    private Queue<GameObject> glocs;

    public float duration = 1f;

    // Start is called before the first frame update
    void Start()
    {
        glocs = new Queue<GameObject>();
        foreach (GameObject go in locs)
        {
            glocs.Enqueue(go);
        }
        Next();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void Next()
    {
        GameObject pong = glocs.Dequeue();
        StartCoroutine(LerpPosition(pong.transform.position));
        glocs.Enqueue(pong);
    }

    IEnumerator LerpPosition(Vector3 target)
    {
        float time = 0;
        Vector3 start = transform.position;

        while (time< duration)
        {
            transform.position = Vector3.Lerp(start, target, time / duration);
            time += Time.deltaTime;
            yield return null;
        }
        transform.position = target;
        Next();
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            StartCoroutine(LoadYourAsyncScene("youwin"));
        }

    }

    IEnumerator LoadYourAsyncScene(string scene)
    {
        AsyncOperation asyncLoad = SceneManager.LoadSceneAsync(scene);
        while (!asyncLoad.isDone)
        {
            yield return null;
        }
    }
}
