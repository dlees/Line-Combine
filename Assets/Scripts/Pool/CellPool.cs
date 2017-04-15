using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class CellPool : MonoBehaviour, CellPipeContainer
{
    public GameObject ContentPanel;
    public GameObject ListItemPrefab;

    private Dictionary<int, PoolItemController> typeToControllerPool = new Dictionary<int, PoolItemController>();

    public void startup()
    {
        for (int i = 0; i < 16; i++)
        {
            addTemplate(i);
        }
    }
    
    public void addTemplate(int type)
    {
        GameObject newListItem = Instantiate(ListItemPrefab) as GameObject;
        PoolItemController controller = newListItem.GetComponent<PoolItemController>();

        GameObject template = (GameObject)Instantiate(controller.block);
        template.GetComponent<CellPipes>().setupBasedOnBlockTypeInTileset(type);

        template.transform.parent = newListItem.transform;
        template.transform.position = Vector3.zero;
        template.transform.localScale = controller.block.transform.localScale;
        Destroy(controller.block);
        controller.block = template;
        controller.block.GetComponent<CellPipes>().container = this;
        controller.block.GetComponent<CellPipes>().boardIndex = new Vector2(type,0);
        
        typeToControllerPool[type] = controller;

        newListItem.transform.parent = ContentPanel.transform;
        newListItem.transform.localScale = Vector3.one;

    }
    
    public void deleteAll() {
        foreach (Transform child in ContentPanel.transform)
        {
            GameObject.Destroy(child.gameObject);
        }
        typeToControllerPool.Clear();
    }

    public void addType(int type)
    {
        ++typeToControllerPool[type].numAvailable;
    }

    public void removeType(int type)
    {
        --typeToControllerPool[type].numAvailable;
    }

    public void logNumOfEachType()
    {
        string typeMessage = "";
        for (int i = 0; i < 15; i++)
        {
            typeMessage += typeToControllerPool[i].numAvailable + " ";
        }
        Debug.Log(typeMessage);
    }

    public GameObject getObjectOfType(int type)
    {
        return typeToControllerPool[type].block;
    }
}
