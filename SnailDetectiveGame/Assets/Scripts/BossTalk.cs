using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class BossTalk : MonoBehaviour
{
    public static BossTalk Instance { get; private set; }

    public GameObject dBox;
    public GameObject dText;
    private Coroutine dialogCo;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);


        }
        else
        {
            Destroy(gameObject);
        }
    }
    public void StartDialog(string text)
    {
        dBox.SetActive(true);
        dialogCo = StartCoroutine(TypeText(text));
    }

    public void HideDialog()
    {
        dBox.SetActive(false);
        StopCoroutine(dialogCo);
    }

    IEnumerator TypeText(string text)
    {
        dText.GetComponent<TextMeshProUGUI>().text = "";
        foreach (char c in text.ToCharArray())
        {
            dText.GetComponent<TextMeshProUGUI>().text += c;
            yield return new WaitForSeconds(0.1f);
        }
    }

    }
