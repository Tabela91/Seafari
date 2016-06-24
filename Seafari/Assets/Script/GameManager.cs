using UnityEngine;
using System.Collections;
using System.Collections.Generic;//used to create List
using System.Linq; //method to ToList the questions
using UnityEngine.UI;// to use Text 
using UnityEngine.SceneManagement;
public class GameManager : MonoBehaviour {

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

    void Start()
    {
        //created an array of questions filled in the inspector. When running the game for the first time we will
        // load those questions into a list of unanswered questions.
        if(unansweredQuestions == null || unansweredQuestions.Count == 0)
        {
            unansweredQuestions = questions.ToList<Question>();
        }

        SetCurrentQuestion();


        /* Use this to test questions against the correct answers.
        if (currentQuestion.A1correct == true)
        {
            Debug.Log(currentQuestion.questionText + " Answer 1 is correct = " + currentQuestion.A1correct);
        }
        if (currentQuestion.A2correct == true)
        {
            Debug.Log(currentQuestion.questionText + " Answer 2 is correct = " + currentQuestion.A2correct);
        }
        if(currentQuestion.A3correct == true)
        {
            Debug.Log(currentQuestion.questionText + " Answer 3 is correct = " + currentQuestion.A3correct);
        }
        if(currentQuestion.A4correct == true)
        {
            Debug.Log(currentQuestion.questionText + " Answer 4 is correct = " + currentQuestion.A4correct);
        }
        */
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

    public void UserSelectA1()
    {
        if (currentQuestion.A1correct == true)
        {
            Debug.Log("CORRECT!");
        }
        else
        {
            Debug.Log("WRONG!");
        }

        StartCoroutine(TransitionToNextQuestion());
    }

    public void UserSelectA2()
    {
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

    public void UserSelectA3()
    {
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

    public void UserSelectA4()
    {
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
