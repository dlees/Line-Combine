using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class PoolItemController : MonoBehaviour {
    public GameObject block;
    public Text numAvailableText;
    public int numAvailable = 0;
    public GameObject disabledBlocker;

    void Update()
    {
        numAvailableText.text = numAvailable.ToString();

        if (numAvailable <= 0)
        {
            block.GetComponent<BoxCollider2D>().enabled = false;
            disabledBlocker.SetActive(true);
        }
        else
        {
            block.GetComponent<BoxCollider2D>().enabled = true;
            disabledBlocker.SetActive(false);
        }
    }
}
