using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;

public class GoalScript : MonoBehaviour
{
    public GameObject gameClearText;
    public static bool isGameClear =false;
    private void OnTriggerEnter(Collider other)
    {
        gameClearText.SetActive(true);
        isGameClear = true;
    }
    // Start is called before the first frame update
    void Start()
    {
        isGameClear=false;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
