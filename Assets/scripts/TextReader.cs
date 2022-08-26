using System.Collections;
using UnityEngine;
using TMPro;

public class TextReader : MonoBehaviour
{
    public static TextReader instance;

    [SerializeField] TextAsset test;
    [SerializeField] TextMeshProUGUI textArea;
    [SerializeField] GameObject dialogueBox;
    [SerializeField] float textSpeed;
    private int currentLine = 0;
    public string[] lines;
    private bool isReading = false;

    private void Start()
    {
        if (instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(gameObject);
        }

        textArea.text = "";
        lines = test.text.Split('\n');
        //StartCoroutine(ReadLine(lines[currentLine], textArea));
        //currentLine++;
    }

    private void Update()
    {
        if(Input.GetMouseButton(0) && !isReading)
        {
            if (currentLine >= lines.Length)
            {
                dialogueBox.SetActive(false);
                return;
            }

            StartCoroutine(ReadLine(lines[currentLine], textArea));
            currentLine++;
        }
    }

    public IEnumerator ReadLine (string text, TextMeshProUGUI area)
    {
        dialogueBox.SetActive(true);
        isReading = true;
        int length = text.Length;
        area.text = "";

        for (int i=0; i<length; i++)
        {
            area.text += text[i];
            yield return new WaitForSeconds(textSpeed);
        }

        isReading = false;
    }
}
