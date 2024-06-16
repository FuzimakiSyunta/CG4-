using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UIElements;
using TMPro;

public class GameManagerScript : MonoBehaviour
{
    public GameObject block;
    public GameObject goal;
    public GameObject coin;
    public TextMeshProUGUI scoreText;
    public static int score = 0;
    public GameObject goalParticle;
    public 

    int[,] map = {
         {1,1,1,1,1,1,1,1,1,1, 1,1,1,1,1,1,1,1,1,1, 1,1,1,1,1,1,1,1,1,1, 1,1,1,1,1,1,1,1,1,1},
         {1,0,0,0,0,0,0,0,0,0, 0,0,0,0,0,0,0,0,0,0, 0,3,0,0,0,0,0,0,0,0, 0,0,0,0,0,0,0,0,0,1},
         {1,0,0,0,0,0,0,0,0,0, 0,0,0,0,0,0,0,0,0,0, 0,0,0,0,0,0,0,0,0,0, 0,0,0,0,0,3,0,0,0,1},
         {1,0,0,0,0,0,0,0,0,0, 0,0,0,0,0,0,0,1,1,1, 0,0,0,0,0,0,0,0,0,0, 0,1,1,0,0,0,0,0,2,1},
         {1,0,0,0,0,0,0,3,0,0, 0,1,1,0,0,0,0,0,0,0, 0,0,0,0,0,0,0,0,0,0, 0,0,0,0,0,0,1,1,1,1},
         {1,0,0,0,0,0,0,0,0,0, 0,0,0,0,0,0,0,0,0,0, 0,0,0,0,0,1,1,1,0,0, 0,0,0,0,0,0,0,0,0,1},
         {1,0,0,0,0,0,0,0,0,0, 0,0,0,3,0,0,0,0,0,0, 0,0,1,1,1,1,0,0,0,0, 0,0,0,0,0,0,0,0,0,1},
         {1,0,0,0,0,0,3,0,0,0, 0,0,0,0,0,0,0,3,0,0, 0,0,0,0,0,0,0,0,0,0, 0,0,0,0,0,0,0,0,0,1},
         {1,0,0,0,0,1,1,1,0,0, 0,0,0,0,0,1,1,1,1,1, 0,0,0,0,3,0,3,0,0,0, 0,0,0,3,0,0,0,0,0,1},
         {1,1,1,1,1,1,1,1,1,1, 1,1,1,1,1,1,1,1,1,1, 1,1,1,1,1,1,1,1,1,1, 1,1,1,1,1,1,1,1,1,1},
    };

    // Start is called before the first frame update
    void Start()
    {
        Vector3 position = Vector3.zero;
        Instantiate(block, position, Quaternion.identity);
        
        score = 0;

        for (int x = 0; x <40; x++)
        {
            for (int y = 0; y < 10; y++)
            {
                
                if (map[y, x] == 1)
                {
                    Instantiate(block,new Vector3(x,map.GetLength(0)-y,0),Quaternion.identity);
                }
                if (map[y, x] == 2)
                {
                    Instantiate(goal, new Vector3(x, map.GetLength(0) - y, 0), Quaternion.identity);
                    goalParticle.transform.position = position;
                }
                if (map[y, x] == 3)
                {
                    Instantiate(coin, new Vector3(x, map.GetLength(0) - y, 0), Quaternion.identity);
                }

            }
        }
      
       
    }

    // Update is called once per frame
    void Update()
    {
        float stick = Input.GetAxis("Horizontal");
        if (GoalScript.isGameClear == true)
        {
            if (Input.GetKeyDown(KeyCode.Space)|| Input.GetKeyDown("joystick button 0"))
            {
                SceneManager.LoadScene("TitleScene");
            }
        }
        

        scoreText.text = "SCORE" + score;
    }
}
