// See https://aka.ms/new-console-template for more information
using QuizApp.App.Concrete;
using QuizApp.App.Managers;

Console.WriteLine("Hello");

Service service = new Service();
QuestionManager questionManager = new QuestionManager(service);
questionManager.Seed();

while (true)
{
    
    
    Console.WriteLine("Chose action:");
    Console.WriteLine("1. Add question");
    Console.WriteLine("2. Remove question");
    Console.WriteLine("3. Get question by id");
    Console.WriteLine("4. Update question");
    Console.WriteLine("5. Show all questions");
    Console.WriteLine("6. Play game");

    var choice = Console.ReadKey();

    switch (choice.KeyChar)
    {
        case '1':
            var addedId = questionManager.AddNewQuestion();
            Console.WriteLine("Added id: " + addedId);
            break;
        case '2':
            var deletedId = questionManager.RemoveQuestion();
            Console.WriteLine("Deleted id: " + deletedId);
            break;
        case '3':
            var question = questionManager.GetQuestionById();
            if (question != null)
            {
                Console.WriteLine(question.ToString());
            }
            break;
        case '4':
            var updatedId = questionManager.UpdateQuestion();
            Console.WriteLine("Update id: " + updatedId);
            break;
        case '5':
            questionManager.PrintQuestions();
            break;
        case '6':
            break;
        default:
            Console.WriteLine("Wrong action");
            break;

    }
}