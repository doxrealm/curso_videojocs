using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameplayManager : MonoBehaviour {

    public class StoryNode{
        public string history;
        public string[] answers;
        public StoryNode[] nextNode;
		public bool isFinal = false;
        public delegate void NodeVisited();
        public NodeVisited nodeVisited;
    }

    public Text historyText;
    public Transform answersParent;
    public GameObject buttonAnswer;
    public GameObject pauseMenu;
    private StoryNode current;
    void Start()
    {

        Debug.Log("INICIO DESDE GAMEPLAY Manager");
        pauseMenu.SetActive(false);
        current = StoryFiller.FillStory();
        Debug.Log("Rellenando datos");
        Debug.Log(current);

        historyText.text = "";
        FillUI();
    }

    void Update() {
        if (Input.GetKeyUp(KeyCode.Escape)) {
            pauseMenu.SetActive(!pauseMenu.activeSelf);
        }
    }

    public void RestartScene() {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    public void LoadStartScene() {
        SceneManager.LoadScene("Pantalla Inicial");
    }

    void AnswerSelected(int index)
    {
        print(index);
        historyText.text += "\n" + current.answers[index];
        if (!current.isFinal)
        {
            current = current.nextNode[index];
            FillUI();
        }
        else
        {
            //Final de partida
            pauseMenu.SetActive(true);
            //SceneManager.LoadScene("Pantalla Final");
        }
    }
    void FillUI() {
        historyText.text = "\n" + "\n" + current.history;

        if (current.nodeVisited != null) current.nodeVisited();

        foreach (Transform child in answersParent.transform)
        {
            Destroy(child.gameObject);
        }

        bool isLeft = true;
        float height = 50;
        int index = 0;
        foreach (string answer in current.answers)
        {
            GameObject buttonAnswerCopy = Instantiate(buttonAnswer);
            buttonAnswerCopy.transform.parent = answersParent;
            float x = buttonAnswerCopy.GetComponent<RectTransform>().rect.x * 1.1f;


            buttonAnswerCopy.GetComponent<RectTransform>().localPosition = new Vector3(isLeft ? x : -x, height, 0);


            if (!isLeft) height += buttonAnswerCopy.GetComponent<RectTransform>().rect.y * 2.5f;


            isLeft = !isLeft;
            Filllistener(buttonAnswerCopy.GetComponent<Button>(), index);
            buttonAnswerCopy.GetComponentInChildren<Text>().text = answer;

            index++;
        }
    }
            void Filllistener(Button button, int index)
            {
                button.onClick.AddListener(() => {
                    AnswerSelected(index);
                });
            }
    }