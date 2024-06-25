Examination system according to the following business case:

1-Class to represent the Question Object, Question is consisting of ( Header of the question,Body of the question,Mark)
2-System has two types of exams (Final and Practical)
3-The application accept different Question Types:
     a. For Final: Exam (True or False ), MCQ (Choose one answer)
     b. For Practical: Exam MCQ (Choose one answer)
4-Base class Exam describe the common attributes concerning the exam:
     a. Time of exam
     b. Number of Questions
     c. Show Exam Functionality that its implementations will be different for each exam based on its type.
5- Every Exam object is Associated to a Subject.
6- Practical Exam Shows the right answer after finishing the Exam.
7- Final Exam Shows the Questions, Answers and Grade.
8- In the Main you need to declare a subject object to create one type of exam.

