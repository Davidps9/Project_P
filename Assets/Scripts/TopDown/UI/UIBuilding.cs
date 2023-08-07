using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIBuilding : MonoBehaviour
{
    [SerializeField] private int buildingIndex;
    [SerializeField] private Button button;

    private void Start()
    {
        button.onClick.AddListener(Clicked);
    }
    private void Clicked()
    {
        UIShop.instance.SetStatus(false);
        UIMain.Instance.SetStatus(true);

        Vector3 position = new Vector3(0,0.3f,0);
        

        Building building = Instantiate(UIMain.Instance.buildings.buildings[buildingIndex].prefab.GetComponent<Building>(), position, Quaternion.identity);
        //building.PlaceOnGrid(0, 0);

        Building.instance = building;
        
        CameraControll.Instance.isPlacingBuilding = true;

    }
    public void ConfirmBuild()
    {
     //server things   
    }

}
