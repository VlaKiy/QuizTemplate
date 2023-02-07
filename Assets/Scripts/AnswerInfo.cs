using UnityEngine;
using UnityEngine.UI;

public class AnswerInfo : MonoBehaviour
{
    public string ask;
    public string[] answers;
    public int rightAnswer;

    public GameObject[] prefabs;

    public bool isMake = false;

    private int answerCount = 0; 

    private void Start()
    {
        if (isMake)
        {
            MakeUI(prefabs[0], -1, 145);
            MakeUI(prefabs[1], -1, 27);
            MakeUI(prefabs[2], -268, -56);
            MakeUI(prefabs[3], 266, -56);
            MakeUI(prefabs[4], -268, -190);
            MakeUI(prefabs[5], 266, -190);
        }
    }
    public void MakeUI(GameObject prefab, int posX, int posY)
    {
        var p = Instantiate(prefab);
        var rt = p.GetComponent<RectTransform>();
        p.transform.SetParent(transform);
        p.transform.localPosition = new Vector3(transform.localPosition.x, 0f, transform.localPosition.z);
        if (posX == -1)
        {
            rt.anchoredPosition = new Vector2(rt.anchoredPosition.x, posY);
        }
        else
        {
            rt.anchoredPosition = new Vector2(posX, posY);
        }
        
        p.transform.localScale = new Vector3(1f, 1f, 1f);

        MakeText(p);
    }

    void MakeText(GameObject p)
    {
        var pText = p.GetComponent<Text>();

        if (pText)
        {
            pText.text = ask;
        }
        else if(p.GetComponentInChildren<Text>())
        {
            pText = p.GetComponentInChildren<Text>();
            pText.text = answers[answerCount];
            answerCount++;
        }
        else
        {

        }
    }
}
