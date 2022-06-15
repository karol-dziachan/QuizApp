using QuizApp.App.Abtract;
using QuizApp.Domain.Common;
using QuizApp.Domain.Entity;
using QuizApp.Domain.Enums;

namespace QuizApp.App.Managers;

/*


Console.WriteLine("4. Update question");

Console.WriteLine("6. Play game");
*/

public class QuestionManager
{
    private IService<Question> _questionService; 
    
    public QuestionManager(IService<Question> questionService)
    {
        _questionService = questionService;
    }

    public void Seed()
    {
        List<String> answers = new List<string>();
        answers.Add("example answer 1");
        answers.Add("example answer 2");
        answers.Add("example answer 3");
        answers.Add("example answer 4");
        _questionService.AddItem(new Question(1, "Example question 1", 1, answers,  1));
        _questionService.AddItem(new Question(2, "Example question 2", 1, answers,  1));
        _questionService.AddItem(new Question(3, "Example question 3", 1, answers,  1));
        _questionService.AddItem(new Question(4, "Example question 4", 1, answers,  1));
        _questionService.AddItem(new Question(5, "Example question 5", 1, answers,  1));
        _questionService.AddItem(new Question(6, "Example question 6", 1, answers,  1));
        _questionService.AddItem(new Question(7, "Example question 7", 1, answers,  1));
        _questionService.AddItem(new Question(8, "Example question 8", 1, answers,  1));
        _questionService.AddItem(new Question(9, "Example question 9", 1, answers,  1));
    }

    public int AddNewQuestion()
    {
       // Console.WriteLine(_questionService.GetLastId());
        List<Error> errors = new List<Error>();
        Console.WriteLine();
        Console.WriteLine("Choose the type of question:");
        foreach (QuestionType questionType in EnumsHelpers.getEnumQuestionTypes())
        {
            Console.WriteLine((int)questionType + ". " +questionType);
        }

        int choice;
        var choiceInput = Console.ReadLine();
        Int32.TryParse(choiceInput, out choice);
        if (EnumsHelpers.EnumIndexValidate(choice))
        {
            errors.Add(new Error(300, "Incorrect type a question"));
        }
        
        Console.WriteLine("Write the question:");
        string questionContent = Console.ReadLine();
        string addQuestion;
        List<String> answers = new List<string>();
        do
        {
            Console.WriteLine("Do you want add the answer?");
            addQuestion = Console.ReadLine();

            if (addQuestion.Equals("yes"))
            {
                answers.Add(Console.ReadLine());
            }
        } while (addQuestion == "yes");
        
        Console.WriteLine("What is correct answer?");
        int correctAnswer;
        var correctAnswerInput = Console.ReadLine();
        Int32.TryParse(correctAnswerInput, out correctAnswer);

        if (correctAnswer == 0 || correctAnswer >= answers.Count())
        {
            errors.Add(new Error(301, "Incorrect number a correct answer"));
        }

        if (!errors.Any())
        {
            Console.WriteLine("Some mistakes");
            return -1;
        }

        int addedId = _questionService.GetLastId() + 1;
        Question question = new Question(addedId, questionContent, choice, answers,  correctAnswer - 1);
        _questionService.AddItem(question);

        return addedId;
    }

    public void PrintQuestions()
    {
        Console.WriteLine("");
        if (_questionService.Items.Any())
        {
            foreach (Question question in _questionService.Items)
            {
                Console.WriteLine(question.ToString());
            }
        }
        else
        {
            Console.WriteLine("Empty");
        }
       
    }

    public int RemoveQuestion()
    {
        List<Error> errors = new List<Error>();
        Console.WriteLine("\nEnter the item's id");
        int choice;
        var choiceInput = Console.ReadLine();
        Int32.TryParse(choiceInput, out choice);
        
        Question question = _questionService.GetItemById(choice);
        if (question == null)
        {
            errors.Add(new Error(404, "Entity not found"));
        }

        if (errors.Any())
        {
            Console.WriteLine("Some mistakes");
            return -1;
        }
        
        int deletedId = _questionService.RemoveItem(question);
        return deletedId; 
    }

    public Question? GetQuestionById()
    {
        List<Error> errors = new List<Error>();
        Console.WriteLine("\nEnter the item's id");
        int choice;
        var choiceInput = Console.ReadLine();
        Int32.TryParse(choiceInput, out choice);
        
        Question question = _questionService.GetItemById(choice);
        if (question == null)
        {
            errors.Add(new Error(404, "Entity not found"));
        }

        if (errors.Any())
        {
            Console.WriteLine("Entity not found");
            return null;
        }

        return question;

    }

    public int UpdateQuestion()
    {
        List<Error> errors = new List<Error>();
        Console.WriteLine("\nEnter the item's id");
        int choiceId;
        var choiceIdInput = Console.ReadLine();
        Int32.TryParse(choiceIdInput, out choiceId);
        
        Question questionById = _questionService.GetItemById(choiceId);
        
        if (questionById == null)
        {
            errors.Add(new Error(404, "Entity not found"));
        }
        
        Console.WriteLine("Choose the type of question:");
        foreach (QuestionType questionType in EnumsHelpers.getEnumQuestionTypes())
        {
            Console.WriteLine((int)questionType + ". " +questionType);
        }

        int choice;
        var choiceInput = Console.ReadLine();
        Int32.TryParse(choiceInput, out choice);
        if (EnumsHelpers.EnumIndexValidate(choice))
        {
            errors.Add(new Error(300, "Incorrect type a question"));
        }
        
        Console.WriteLine("Write the question:");
        string questionContent = Console.ReadLine();
        string addQuestion;
        List<String> answers = new List<string>();
        do
        {
            Console.WriteLine("Do you want add the answer?");
            addQuestion = Console.ReadLine();

            if (addQuestion.Equals("yes"))
            {
                answers.Add(Console.ReadLine());
            }
        } while (addQuestion == "yes");
        
        Console.WriteLine("What is correct answer?");
        int correctAnswer;
        var correctAnswerInput = Console.ReadLine();
        Int32.TryParse(correctAnswerInput, out correctAnswer);

        if (correctAnswer == 0 || correctAnswer >= answers.Count())
        {
            errors.Add(new Error(301, "Incorrect number a correct answer"));
        }

        if (!errors.Any())
        {
            foreach (Error error in errors)
            {
                Console.WriteLine(error.Content);
            }
            Console.WriteLine("Some mistakes");
            return -1;
        }
        
        Question question = new Question(choiceId, questionContent, choice, answers,  correctAnswer - 1);
        int updatedId = _questionService.UpdateItem(question);

        return updatedId;
    }
    
}