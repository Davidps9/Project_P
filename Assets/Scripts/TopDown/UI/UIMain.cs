using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;
using TMPro;
using System;
using UnityEngine.UI;

public class UIMain : MonoBehaviour
{
    [SerializeField] public GameObject elements;

    [SerializeField] public UnityEngine.UI.Button shopButton;
    [SerializeField] public TextMeshProUGUI goldText = null;
    [SerializeField] public TextMeshProUGUI gemsText = null;
    [SerializeField] public TextMeshProUGUI secondResourceText = null;
    [SerializeField] public GridScript grid;

    private static UIMain instance = null;
    public static UIMain Instance { get { return instance; } }

    [SerializeField] public BuidingsClass buildings;

    private bool active = true; public bool isActive { get { return active; } }

    private void Awake()
    {
        instance = this; 
        foreach (Buildings building in buildings.buildings)
        {
            if (building.prefab.GetComponent<Building>() == null)
            {
                building.prefab.AddComponent<Building>();

            }
        }
        elements.SetActive(true);
        
    }
    private void Start()
    {
        shopButton.onClick.AddListener(ShopButtonClicked);

    }
    private void ShopButtonClicked()
    {
        active = false;
        UIShop.instance.elements.SetActive(true);
        SetStatus(active);
    }

    public void SetStatus(bool status)
    {
        active = status;
        elements.SetActive(status);
    }
}
