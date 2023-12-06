# QuizProjectBlazor

## Quiz app
### About
This is a fullstack project using Blazor Webassembly and ASP.NET Core to make a Quiz application. The logic is being handled on server side. It uses view models to send data from the server to the razor client.
It utilizes view models to decrease the risk of unneccessary data being sent.

### Functionality 
The user can register an account, create a quiz and add questions with either free text answers or multiple choice answers, choose to set a time limit of the quiz.

### Try it out
Preferably you use localDb and add your connection string like this: Data Source=(localdb)\\.;Initial Catalog={your connection string} Integrated Security=True

### Database
The ER-model of the database goes like this:

• One user can have many quizzes
• One quiz can have many questions
• One question has one quiz


Editor: Visual Studio 2022
Programming language: C#, HTML, CSS
ASP.NET CORE / Blazor
ORM: Entity Framework (Codefirst)
