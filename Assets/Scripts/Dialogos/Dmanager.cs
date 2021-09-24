using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;
public class Dmanager : MonoBehaviour
{
    [System.Serializable]
    public struct _sentence
    {
        public int _character;
        public string _2say;
        public bool _active;
        public bool _deactive;
    }

    public TextMeshProUGUI[] _textContainers;
    public _sentence[] _sentences;

    [SerializeField]
    public GameObject[] _dialogBoxes;
    [SerializeField]
    public float _speedWrite;
    private int _index = 0;


    void Start()
    {
        CleanText();
        if (_sentences[_index]._active == true)
        {
            EnableDisableBox(true);
        }
        StartCoroutine(Talk());
    }

    void Update()
    {
        if (Input.GetKeyDown("t"))
        {
            ContinueDialog();
        }
        if (Input.GetKeyDown("f"))
        {
            SceneManager.LoadScene("Level1");
        }
    }
    public void CleanText()
    {
        for (int i = 0; i < _textContainers.Length; i++)
        {
            _textContainers[i].text = "";
        }
    }
    IEnumerator Talk()
    {
        _textContainers[_sentences[_index]._character].text = "";
        foreach (char letra in _sentences[_index]._2say.ToCharArray())
        {
            //if (_index < _sentences.Length)
            //{
            _textContainers[_sentences[_index]._character].text += letra;
            yield return new WaitForSeconds(_speedWrite);
            //}

        }
    }
    public void EnableDisableBox(bool enable)
    {
        _dialogBoxes[_sentences[_index]._character].SetActive(enable);
    }
    public void ContinueDialog()
    {
        if (_index < _sentences.Length)
        {
            if (_sentences[_index]._deactive)
            {
                EnableDisableBox(false);
            }
            _index += 1;
        }

        if (_index < _sentences.Length)
        {
            if (_sentences[_index]._active == true)
            {
                EnableDisableBox(true);
            }
            StartCoroutine(Talk());
        }
        else
        {
            CleanText();
        }
    }

}
