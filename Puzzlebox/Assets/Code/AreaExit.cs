using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class AreaExit : MonoBehaviour
{
    // Start is called before the first frame update
    public string areaToLoad;
    public string areaTransitionName;

    public AreaEntrance entrance;
    public float waitToLoad = 1f;
    public bool shouldLoadAfterFade;

    void Start()
    {
        entrance.transitionName = areaTransitionName;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Player") {

            //SceneManager.LoadScene(areaToLoad);

            shouldLoadAfterFade = true;
            UIFade.instance.FadeToBlack();

            Player.instance.areaTransitionName = this.areaTransitionName;
        }
    }
}
