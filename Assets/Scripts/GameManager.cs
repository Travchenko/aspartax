using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;
    private void Awake() // запускается перед запуском или загрузкой игры
    {
        if (GameManager.instance != null) // если создается лишний пустой геймменеджер его хуярит палками этот иф
        {
            Destroy(gameObject);
            return;
        }// проверка лишнего геймменеджера



        instance = this;
        SceneManager.sceneLoaded += LoadState;
        DontDestroyOnLoad(gameObject); // сейвит геймМенеджер перед загрузкой или сейвом
    }
    // resourse
    public List<Sprite> playerSprites;
    public List<Sprite> weaponSprites;

    // references
    public Player player;
    // public weapon
    /*public Weapon weapon;*/

    /*public FloatingTextManager floatingTextManager;

    // floating text
    public void ShowText(string msg, int fontSize, Color color, Vector3 position, Vector3 motion, float duration)
    {
        floatingTextManager.Show(msg, fontSize, color, position, motion, duration);
    }*/


    public void SaveState()
    {
        string str = "";

        str += "0" + "|"; // character skin
        str += "0" + "|"; // weapon skin
        PlayerPrefs.SetString("SaveState", str);
     }
    public void LoadState(Scene s, LoadSceneMode mode)
    {
        if (!PlayerPrefs.HasKey("SaveState"))
            return;
        string[] data = PlayerPrefs.GetString("SaveState").Split('|');
        // Change skin
        // change weapon
    }
}
