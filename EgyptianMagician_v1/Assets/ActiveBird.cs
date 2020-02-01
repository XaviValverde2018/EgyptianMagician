using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class ActiveBird : MonoBehaviour
{
    public Button birdButton;
    public int add;
    public bool birdActivated;
    // Start is called before the first frame update
    void Start()
    {
        add = 0;
    }

    // Update is called once per frame
    void Update()
    {

    }
    public void ActiveBirdHability() {
        StartCoroutine(CountDown());
    }
    IEnumerator CountDown() {
        birdButton.interactable = true;
        add++;
        Debug.Log("Bird activated!");
        yield return new WaitForSeconds(0.1f);
        birdButton.interactable = false;
        add++;
        birdActivated = true;
        yield return new WaitForSeconds(3);
        birdButton.interactable = true;
        add++;
        birdActivated = false;
    }
}
