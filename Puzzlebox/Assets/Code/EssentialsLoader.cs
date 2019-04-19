using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EssentialsLoader : MonoBehaviour{
    // Start is called before the first frame update
    public GameObject UIScreen;
    public GameObject player;
    void Start()
    {
        if (UIFade.instance == null) {
            Instantiate(UIScreen);
        }

        if (Player.instance == null) {
            Player clone = Instantiate(player).GetComponent<Player>();
            Player.instance = clone;
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
