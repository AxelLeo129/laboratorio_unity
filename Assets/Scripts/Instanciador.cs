using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Instanciador : MonoBehaviour
{
    [SerializeField]  private Object player_prefab;
    GameObject player;

    // Start is called before the first frame update
    void Start()
    {
        this.player = Instantiate(player_prefab, new Vector3(2.76f, 0, 8.86f), Quaternion.identity) as GameObject;
    }

    // Update is called once per frame
    void Update()
    {
        if (player_prefab && !this.player && Input.GetKeyDown(KeyCode.Return))
            this.player = Instantiate(player_prefab, new Vector3(2.76f, 0, 8.86f), Quaternion.identity) as GameObject;
    }
}
