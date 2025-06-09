CREATE TABLE Questions
(
    QuestionID INT PRIMARY KEY IDENTITY(1,1),
    QuestionText VARCHAR(MAX) NOT NULL,
    CorrectAnswer VARCHAR(MAX) NOT NULL,
    OptionA VARCHAR(MAX),
    OptionB VARCHAR(MAX),
    OptionC VARCHAR(MAX),
    OptionD VARCHAR(MAX)
)

CREATE TABLE ExaminerAccounts
(
    ExaminerID INT PRIMARY KEY IDENTITY(1,1),
    Username VARCHAR(50) UNIQUE NOT NULL,
    Password VARCHAR(50) NOT NULL,
	FullName VARCHAR(100),
    Email VARCHAR(100),
	ProfilePicture VARBINARY(MAX),
)

CREATE TABLE StudentsAccounts
(
    StudentID INT PRIMARY KEY IDENTITY(1,1),
    Username VARCHAR(50) UNIQUE NOT NULL,
    Password VARCHAR(50) NOT NULL,
    FullName VARCHAR(100),
    Email VARCHAR(100),
	ProfilePicture VARBINARY(MAX),
	HasActiveRequests bit Default 0
)

INSERT INTO ExaminerAccounts (Username, Password) 
VALUES ('Dairo', '2828')

INSERT INTO StudentsAccounts (Username, Password, FullName, Email)
VALUES ('Zizo', '1234', 'Ziad Magdi', 'ziad@gmail.com'),
       ('Yakout', '1234', 'Omar Yakout', 'omaryakout@gmail.com'),
	   ('Joumana','1234','Joumana Emad','joumana@gmail.com'),
	   ('Malak','1234','Malak Amr','malak@gmail.com')

INSERT INTO Questions (QuestionText, CorrectAnswer, OptionA, OptionB, OptionC, OptionD)
VALUES ('Calculate 18/3-7+2*5', '9', '5', '9', '-2', '15'),
       ('What is 7 × 8?', '56', '54', '56', '64', '72'),
	   ('What is 15% of 200?','30','20','25','30','35'),
	   ('What is the value of π (pi) to two decimal places?','3.14','3.17','3.13','3.24','3.14'),
	   ('If a number is divided by 5 and gives 20, what is the number?','100','50','100','150','200'),
	   ('What is the square root of 144?','12','10','12','14','16'),
	   ('Simplify: 8+2×5−4','16','16','18','24','26'),
	   ('How many degrees are in a right angle?','90','45','90','180','360'),
	   ('What is the result of 81÷9?','9','7','8','9','10'),
	   ('If 6x = 42, what is x?','7','6','7','8','9'),
	   ('A triangle has angles 60°, 60°, and x°. What is x?','60°','30°','40°','60°','90°')


CREATE TABLE QuizRequests (
    RequestID INT PRIMARY KEY IDENTITY(1,1),
    StudentID INT NOT NULL FOREIGN KEY REFERENCES StudentsAccounts(StudentID),
    Status NVARCHAR(10) CHECK (Status IN ('Pending', 'Accepted', 'Rejected')),
    RequestTimestamp DATETIME DEFAULT GETDATE()
)

CREATE TABLE Quizzes (
    QuizID INT PRIMARY KEY IDENTITY(1,1),
    StudentID INT NOT NULL FOREIGN KEY REFERENCES StudentsAccounts(StudentID),
    Score INT DEFAULT 0,
    Status NVARCHAR(10) CHECK (Status IN ('Pending', 'Graded')),
    QuizDate DATETIME DEFAULT GETDATE()
)

CREATE TABLE QuizQuestions (
    QuizQuestionID INT PRIMARY KEY IDENTITY(1,1),
    QuizID INT NOT NULL FOREIGN KEY REFERENCES Quizzes(QuizID),
    QuestionID INT NOT NULL FOREIGN KEY REFERENCES Questions(QuestionID),
    StudentAnswer NVARCHAR(255) NULL,
    IsCorrect BIT NULL
)

CREATE OR ALTER TRIGGER CheckIsCorrect
ON QuizQuestions
AFTER INSERT
AS
BEGIN
    UPDATE QQ
    SET QQ.IsCorrect = CASE 
                           WHEN QQ.StudentAnswer = Q.CorrectAnswer THEN 1
                           ELSE 0
                       END
    FROM QuizQuestions QQ
    INNER JOIN INSERTED I ON QQ.QuizQuestionID = I.QuizQuestionID
    INNER JOIN Questions Q ON I.QuestionID = Q.QuestionID

    UPDATE QZ
    SET QZ.Score = QZ.Score + 1
    FROM Quizzes QZ
    INNER JOIN INSERTED I ON QZ.QuizID = I.QuizID
    INNER JOIN QuizQuestions QQ ON I.QuizQuestionID = QQ.QuizQuestionID
    WHERE QQ.IsCorrect = 1
END

