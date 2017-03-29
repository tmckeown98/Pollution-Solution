using System.Collections;
using UnityEngine;
using UnityEngine.UI;
using System.Collections.Generic; // Using lists
using System.Linq; //
using UnityEngine.SceneManagement;

public class AnswerChecker : MonoBehaviour {

    public Question[] questions; // Storing all the questions input in unity (inspector)

    private string correctMessage = "Correct! Keep up the good work!";
    private string incorrectMessage = "Wrong! Try again next time! Make sure you read the facts and information shown in the game carefully.";

    public Text OptionOneText;    // Accessing button 1 text
    public Text OptionTwoText;    // Accessing button 2 text
    public Text OptionThreeText;  // Accessing button 3 text
    public Text OptionFourText;   // Accessing button 4 text
    public Text NotifierText;     // Response from the computer

    public Button but1;           // Modifying the first option button
    public Button but2;           // Modifying the second option button
    public Button but3;           // Modifying the third option button
    public Button but4;           // Modifying the fourth option button

    private static List<Question> unansweredQuestions; // Remembering current question
    private Question currentQuestion;                  // obviously store current question the player is on

    [SerializeField]
    private Text questionText; // Store current question

    [SerializeField]
    private float questionDelay = 1f;

    void Start()
    {
        NotifierText.text = ""; // Set to nothing

        // Occurs everytime the scene is loaded
        if (unansweredQuestions == null || unansweredQuestions.Count == 0) // If all the questions are answered then the unanswered questions in the list will be 0, so wont be null
        {
            unansweredQuestions = questions.ToList<Question>(); // Load questions into a list of unanswered questions
        }
        GetRandomQuestion();
    }

    void GetRandomQuestion()
    {   // Choose a random number between 0 and the size-1 of the number of elements in the list
        int randomQuestionIndex = Random.Range(0, unansweredQuestions.Count);
        currentQuestion = unansweredQuestions[randomQuestionIndex];

        switch (randomQuestionIndex)
        {   // Magic numbers because I can
            case 0:
                OptionOneText.text   = "Bacteria";
                OptionTwoText.text   = "Virus";
                OptionThreeText.text = "Bongalong";
                OptionFourText.text  = "Dingamin";
                break;
            case 1:
                OptionOneText.text   = "Q2First";
                OptionTwoText.text   = "Q2Second";
                OptionThreeText.text = "Q2Third";
                OptionFourText.text  = "Q2Fourth";
                break;
            case 2:
                OptionOneText.text   = "Q3First";
                OptionTwoText.text   = "Q3Second";
                OptionThreeText.text = "Q3Third";
                OptionFourText.text  = "Q3Fourth";
                break;
            case 3:
                OptionOneText.text   = "Q4First";
                OptionTwoText.text   = "Q4Second";
                OptionThreeText.text = "Q4Third";
                OptionFourText.text  = "Q4Fourth";
                break;
            case 4:
                OptionOneText.text   = "Q5First";
                OptionTwoText.text   = "Q5Second";
                OptionThreeText.text = "Q5Third";
                OptionFourText.text  = "Q5Fourth";
                break;
            case 5:
                OptionOneText.text   = "Q6First";
                OptionTwoText.text   = "Q6Second";
                OptionThreeText.text = "Q6Third";
                OptionFourText.text  = "Q6Fourth";
                break;
            case 6:
                OptionOneText.text   = "Q7First";
                OptionTwoText.text   = "Q7Second";
                OptionThreeText.text = "Q7Third";
                OptionFourText.text  = "Q7Fourth";
                break;
            case 7:
                OptionOneText.text   = "Q8First";
                OptionTwoText.text   = "Q8Second";
                OptionThreeText.text = "Q8Third";
                OptionFourText.text  = "Q8Fourth";
                break;
            case 8:
                OptionOneText.text   = "Q9First";
                OptionTwoText.text   = "Q9Second";
                OptionThreeText.text = "Q9Third";
                OptionFourText.text  = "Q9Fourth";
                break;
            case 9:
                OptionOneText.text   = "Q10First";
                OptionTwoText.text   = "Q10Second";
                OptionThreeText.text = "Q10Third";
                OptionFourText.text  = "Q10Fourth";
                break;
        }

        questionText.text = currentQuestion.question; // Display the question

        // Remove that question from the list once answered
        unansweredQuestions.RemoveAt(randomQuestionIndex);

    }

    IEnumerator TransitionToNextQuestion()
    {
 
        yield return new WaitForSeconds(questionDelay);

        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex); // Reload current scene
    }

    public void SetGreen(Button name)
    {
        ColorBlock cb = name.colors;
        cb.disabledColor = Color.green;
        name.colors = cb;
    }

    public void SetRed(Button name)
    {
        ColorBlock cb = name.colors;
        cb.disabledColor = Color.red;
        name.colors = cb;
    }

    public void Correct(Button name)
    {
        SetGreen(name);
        name.interactable = false;
        NotifierText.text = correctMessage;
        StartCoroutine(TransitionToNextQuestion());
    }

    public void Incorrect(Button name)
    {
        SetRed(name);
        name.interactable = false;
        NotifierText.text = incorrectMessage;
        StartCoroutine(TransitionToNextQuestion());
    }
    // Selecting the first button
    public void UserSelectOne()
    {
        if (currentQuestion.answerNumber == 0) Correct(but1); 
        else Incorrect(but1); 
    }
    // Selecting the second button
    public void UserSelectTwo()
    {
        if (currentQuestion.answerNumber == 1) Correct(but2);
        else Incorrect(but2);
    }
    // Selecting the third button
    public void UserSelectThree()
    {
        if (currentQuestion.answerNumber == 2) Correct(but3);
        else Incorrect(but3);
    }
    // Selecting the fourth button
    public void UserSelectFour()
    {
        if (currentQuestion.answerNumber == 3) Correct(but4);
        else Incorrect(but4);
    }

}
