using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MenuManager : MonoBehaviour
{
    [Header("Menu Icon Positions:")]
    [SerializeField] private Vector2 playPosition;
    [SerializeField] private Vector2 quitPosition;

    
    [Header("Script References:")]
    [SerializeField] private Text txtTitle;
    [SerializeField] private Text txtPlay;
    [SerializeField] private Text txtQuit;
    [SerializeField] private Text txtDev;
    [SerializeField] private RectTransform imgMenuIconRct;
    [SerializeField] private GameObject playerPrefab;
    [SerializeField] private Transform playerSpawnPos;
    [SerializeField] private Animator roofAnim;
    [SerializeField] private GameObject playerHUD;


    private int index = 0;
    private bool isPlaying = false;

    private GameObject player;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        MenuSelection();

        if (isPlaying){
            RemoveMenu();
        }
    }



    private void MenuSelection()
    {
        if (!isPlaying){

            // Move
            if (Input.GetKeyDown(KeyCode.W)){
                if (index == 1){
                    index = 0;
                }else{
                    index = 1;
                }
            }else if (Input.GetKeyDown(KeyCode.S)){
                if (index == 0){
                    index = 1;
                }else{
                    index = 0;
                }
            }

            // Selection
            if (Input.GetKeyDown(KeyCode.Space)){
                if (index == 0){
                    // Play
                    isPlaying = true;
                    roofAnim.Play("Roof Opening");
                    CreatePlayer();
                }else{
                    // Quit
                    Application.Quit();
                }
            }

        }
       
        // Icon position
        if (index == 0){
            imgMenuIconRct.anchoredPosition = playPosition;
        }else{
            imgMenuIconRct.anchoredPosition = quitPosition;
        }

    }

    private void RemoveMenu()
    {
        Color fadeColor = txtTitle.color;
        fadeColor.a -= Time.deltaTime;

        txtTitle.color = fadeColor;
        txtPlay.color = fadeColor;
        txtQuit.color = fadeColor;
        txtDev.color = fadeColor;
        imgMenuIconRct.gameObject.GetComponent<Image>().color = fadeColor;

        if (fadeColor.a <= 0){
            SetCamera();
            playerHUD.SetActive(true);
            Destroy(gameObject);
        }
    }

    private void CreatePlayer()
    {
        player = Instantiate(playerPrefab, playerSpawnPos.position, Quaternion.identity);
        Destroy(playerSpawnPos.gameObject);
    }


    private void SetCamera()
    {
        Camera.main.gameObject.GetComponent<FollowCamera>().target = player.transform;
    }
}
