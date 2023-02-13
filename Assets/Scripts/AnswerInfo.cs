using UnityEngine;
using UnityEngine.UI;

public class AnswerInfo : MonoBehaviour
{
    [SerializeField] private GameObject _nextAsk;
    [SerializeField] private string _ask;
    [SerializeField] private string[] _answers;
    [SerializeField] private GameObject[] _UIPrefabs;

    private bool _isStart = true;
    private int _answerCount = 0;

    private void Start()
    {
        if (_isStart)
        {
            MakeUI(_UIPrefabs[0], new Vector2(0, 145), true);
            MakeUI(_UIPrefabs[1], new Vector2(0, 27), true);
            MakeUI(_UIPrefabs[2], new Vector2(-268, -56));
            MakeUI(_UIPrefabs[3], new Vector2(266, -56));
            MakeUI(_UIPrefabs[4], new Vector2(-268, -190));
            MakeUI(_UIPrefabs[5], new Vector2(266, -190));
        }
    }

    private void MakeUI(GameObject prefab, Vector2 pos, bool isMiddleX = false)
    {
        var UIprefab = Instantiate(prefab);
        var rt = UIprefab.GetComponent<RectTransform>();
        UIprefab.transform.SetParent(transform);
        UIprefab.transform.localPosition = new Vector3(transform.localPosition.x, 0f, transform.localPosition.z);

        if (isMiddleX)
        {
            rt.anchoredPosition = new Vector2(rt.anchoredPosition.x, pos.y);
        }
        else 
        {
            rt.anchoredPosition = new Vector2(pos.x, pos.y);
        }

        UIprefab.transform.localScale = new Vector3(1f, 1f, 1f);

        MakeText(UIprefab);
    }

    private void MakeText(GameObject UIprefab)
    {
        var UIprefabText = UIprefab.GetComponent<Text>();

        if (UIprefabText)
        {
            UIprefabText.text = _ask;
        }
        else if(UIprefab.GetComponentInChildren<Text>())
        {
            UIprefabText = UIprefab.GetComponentInChildren<Text>();
            UIprefabText.text = _answers[_answerCount];

            _answerCount++;
        }
    }

    public GameObject GetNextAsk()
    {
        return _nextAsk;
    }
}
