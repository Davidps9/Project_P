using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class UIShop : MonoBehaviour
{
    [SerializeField] public GameObject elements;
    [SerializeField] private Button closeButton;
    private static UIShop _instance = null;

    public static UIShop instance { get { return _instance; } }


    private void Awake()
    {
        _instance = this;
        elements.SetActive(false);  

    }
    // Start is called before the first frame update
    void Start()
    {
        closeButton.onClick.AddListener(CloseShop);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void SetStatus(bool status)
    {
        elements.SetActive(status);
    }
    private void CloseShop()
    {
        SetStatus(false);
        UIMain.Instance.SetStatus(true);
    }
}
