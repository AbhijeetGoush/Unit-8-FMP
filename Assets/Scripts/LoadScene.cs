using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadScene : MonoBehaviour
{
    public GameObject player;

    private void Start()
    {
        player = GameObject.FindWithTag("Player");
    }

    public async void LoadScene2()
    {
        
        await Task.Delay(1000);
        SceneManager.LoadScene("Level2");
        player.transform.position = new Vector3(-8, -2);
    }


}
