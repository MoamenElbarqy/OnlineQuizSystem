# OnlineQuizSystem APIs

## Create Quiz Request

```
POST /quizzes [By Instructor]
```
```
{
    "title": "C++ Basics Quiz",
    "startDate": "2024-07-01T10:00:00Z",
    "endDate": "2024-07-01T11:00:00Z,
    "questions": [
        {
            "questionText": "What is a pointer in C++?",
            "Choices": [
                "A variable that stores memory address",
                "A type of function",
                "A loop structure",
                "An error handling mechanism"
            ],
            "correctChoiceIndex": 0
        },
        {
            "questionText": "Which of the following is used to define a constant in C++?",
            "Choices": [
                "#define",
                "const",
                "final",
                "static"
            ],
            "correctChoiceIndex": 1
        }
    ]
}
```

### Create Quiz Response

```
201 Created
```
```
{
    
}
```

## Auth Controller

- `POST /register` - Register a new user (student or instructor)
- `POST /login` - Authenticate a user and return a JWT token
- `POST /logout` - Invalidate the user's JWT token
- `POST /refresh-token` - Refresh the JWT token
  

### Quiz Controller

- `POST /quizzes` - Create a new quiz
- `PUT /quizzes/{quizId}` - Update an existing quiz
- `DELETE /quizzes/{quizId}` - Delete a quiz
- `GET /quizzes` - Retrieve all quizzes created by the instructor
- `GET /quizzes/{quizId}/submissions` - Retrieve Quiz By Sepcific Quiz ID

  
## Attempts Controller

- `POST /quizzes/{quizId}/attempts/` - Submit a new quiz attempt (Student only)
- `GET /quizzes/{quizId}/attempts/` - Retrieve all attempts for a specific quiz (Instructor only)
- `GET /attempts/` - Retrieve All Attempts For Specific Student