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