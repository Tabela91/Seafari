using UnityEngine;
using System.Collections;
using System.Collections.Generic;//used to create List
using System.Linq; //method to ToList the questions
using UnityEngine.UI;// to use Text 
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour {

    public GameObject timeUpWarning;//time up text

    public Question[] questions;
    //This list will persist between scenes and will contain all questions we have not yet answered.
    private static List<Question> unansweredQuestions;
    private Question currentQuestion; //stores the current question value

    [SerializeField]//to make it appear in the inspector
    private Text questionText; //text object for the UI
    [SerializeField]
    private Text answer1Text;
    [SerializeField]
    private Text answer2Text;
    [SerializeField]
    private Text answer3Text;
    [SerializeField]
    private Text answer4Text;
    [SerializeField]
    private float timeBetweenQuestions = 1f; //sets delay before next question;

    public Text scoreUIText; // assign it from inspector
    public Text globalUIText;
    public float timeLimit;//assigned from inspector. The time limit to answer a question in.
    private bool runTimer = false;//boolean to control Timer activation
    private bool buttonsActive = true;//activates buttons 

    IEnumerator StartTimer()
    {//waits for a few seconds and then sets the timer to true (active)
        yield return new WaitForSeconds(3f);
        runTimer = true;

    }

    void Start()
    {
        StartCoroutine(StartTimer());//activates the Timer
        //created an array of questions filled in the inspector. When running the game for the first time we will
        // load those questions into a list of unanswered questions.
        if (unansweredQuestions == null || unansweredQuestions.Count == 0)
        {
            unansweredQuestions = questions.ToList<Question>();
        }

        SetCurrentQuestion();

        timeUpWarning = GameObject.Find("TimeUp");
        timeUpWarning.SetActive(false);
        
    }

    void Update()
    {
        if (runTimer)//if timer is active
        {
            TimerCountdown();//begin timer countdown method
        }
        
    }

    void TimerCountdown()
    {
        //creates a 'time remaining' variable which is equal to the time limit minus Time.deltatime
        float remaining = timeLimit -= Time.deltaTime;
        globalUIText.text = remaining.ToString("#0");//assigns the current value of 'remaining' to the Text UI
        if (timeLimit <= 0)//if the timer reaches zero
        {
            timeLimit = 0;//timer is set to zero
            runTimer = false;//timer is deactivated
            buttonsActive = false;//deactivates buttons
            timeUpWarning.SetActive(true);
            StartCoroutine(TransitionToNextQuestion());//begins transition to next scene
        }

    }

    void SetCurrentQuestion()
    {
        //generates a random int as an index from the list. It will then load the question which matches this 
        //random index.
        int randomQuestionIndex = Random.Range(0, unansweredQuestions.Count);
        currentQuestion = unansweredQuestions[randomQuestionIndex];

        //sets UI Text to the Question text stored in the array list 
        questionText.text = currentQuestion.questionText;
        answer1Text.text = currentQuestion.A1Text;
        answer2Text.text = currentQuestion.A2Text;
        answer3Text.text = currentQuestion.A3Text;
        answer4Text.text = currentQuestion.A4Text;
    }

    IEnumerator TransitionToNextQuestion()
    {
        //this will then remove the selected question from the index so that once it is answered, 
        //it cannot be selected randomly again.
        unansweredQuestions.Remove(currentQuestion);

        yield return new WaitForSeconds(timeBetweenQuestions);
        //this will reload the scene with the next question
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);        
    }

    public void UserSelectA1()//if user selects A1 button
    {
        if (buttonsActive)
        {
            runTimer = false;//timer is deactivated
            if (currentQuestion.A1correct == true)//checks if A1 is the correct answer
            {
                Debug.Log("CORRECT!");//if yes, outputs CORRECT
            }
            else
            {
                Debug.Log("WRONG!");//otherwise outputs WRONG
            }
            StartCoroutine(TransitionToNextQuestion());//begin transition to next scene
        }
    }

    public void UserSelectA2()
    {
        if (buttonsActive)
        {
            runTimer = false;//timer is deactivated
            if (currentQuestion.A2correct == true)
            {
                Debug.Log("CORRECT!");
            }
            else
            {
                Debug.Log("WRONG!");
            }
            StartCoroutine(TransitionToNextQuestion());
        }
    }
    public void UserSelectA3()
    {
        if (buttonsActive)
        {
            runTimer = false;//timer is deactivated
            if (currentQuestion.A3correct == true)
            {
                Debug.Log("CORRECT!");
            }
            else
            {
                Debug.Log("WRONG!");
            }
            StartCoroutine(TransitionToNextQuestion());
        }
    }

    public void UserSelectA4()
    {
        if (buttonsActive)
        {
            runTimer = false;//timer is deactivated
            if (currentQuestion.A4correct == true)
            {
                Debug.Log("CORRECT!");
            }
            else
            {
                Debug.Log("WRONG!");
            }
            StartCoroutine(TransitionToNextQuestion());
        }
    }

}
