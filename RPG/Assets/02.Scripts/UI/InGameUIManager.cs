using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InGameUIManager : MonoBehaviour
{
    public static InGameUIManager instance;
    
    public CMDState CMDState;
    [SerializeField] private GameObject statsView;
    [SerializeField] private GameObject inventoryView;
    [SerializeField] private GameObject equipmentView;
    [SerializeField] private GameObject talkBox;
    [SerializeField] private GameObject reinforceView;

    public int GetActiveUICount()
    {
        int count = 0;
        if (statsView.activeSelf)
            count++;
        if (inventoryView.activeSelf)
            count++;
        if (equipmentView.activeSelf)
            count++;
        if (talkBox.activeSelf)
            count++;
        if (reinforceView.activeSelf)
            count++;
        return count;
    }

    private void Awake()
    {
        if (instance != null)
            Destroy(instance);
        instance = this;

        StartCoroutine(E_Init());
    }

    IEnumerator E_Init()
    {
        // ?̱??? ?ν??Ͻ?ȭ
        statsView.SetActive(true); 
        inventoryView.SetActive(true);
        equipmentView.SetActive(true);
        talkBox.SetActive(true);

        yield return new WaitUntil(() => StatsView.instance != null &&
                                         InventoryView.instance != null &&
                                         EquipmentsView.instance != null);

        yield return new WaitUntil(() => StatsView.instance.CMDState == CMDState.Ready &&
                                         InventoryView.instance.CMDState == CMDState.Ready &&
                                         EquipmentsView.instance.CMDState == CMDState.Ready);

        CMDState = CMDState.Ready;
    }


    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.I))
        {
            inventoryView.SetActive(inventoryView.activeSelf == false);
        }

        if (Input.GetKeyDown(KeyCode.O))
        {
            equipmentView.SetActive(equipmentView.activeSelf == false);
        }

        if (Input.GetKeyDown(KeyCode.P))
        {
            statsView.SetActive(statsView.activeSelf == false);
        }
    }
}
