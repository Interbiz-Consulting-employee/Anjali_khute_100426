use studentManagementDB ;


-- Table Creation Query
CREATE TABLE University (
    UniversityId INT IDENTITY(1,1) PRIMARY KEY,
    UniversityName VARCHAR(100) NOT NULL,
    UniversityType VARCHAR(20) NOT NULL
        CHECK (UniversityType IN ('Public','Private','Central','State','Deemed','Open')),
    UniversityGrade VARCHAR(5) NOT NULL
        CHECK (UniversityGrade IN ('A++','A+','A','B+','B','C')),
    UniversityAddress VARCHAR(255) NOT NULL,
    CONSTRAINT UQ_UniversityName UNIQUE (UniversityName)
);


CREATE TABLE College (
    CollegeId INT IDENTITY(1,1) PRIMARY KEY,
    CollegeName VARCHAR(100) NOT NULL,
    CollegeType VARCHAR(20) NOT NULL
        CHECK (CollegeType IN ('Government','Private','Autonomous','Aided','Unaided','Professional')),
    CollegeAddress VARCHAR(255) NOT NULL,
    UniversityId INT NULL,
    CONSTRAINT UQ_College_University UNIQUE (CollegeName, UniversityId),
    CONSTRAINT FK_College_University
        FOREIGN KEY (UniversityId) REFERENCES University(UniversityId)
);


CREATE TABLE Department (
    DepartmentId INT IDENTITY(1,1) PRIMARY KEY,
    DepartmentName VARCHAR(50) NOT NULL
        CHECK (DepartmentName IN
        ('Computer Science','Information Technology','Mechanical Engineering',
         'Civil Engineering','Electrical Engineering','Electronics and Communication')),
    NumberOfClass INT NOT NULL DEFAULT 1,
    DepartmentHead VARCHAR(100) NULL,
    CollegeId INT NOT NULL,
    CONSTRAINT FK_Department_College
        FOREIGN KEY (CollegeId) REFERENCES College(CollegeId)
);


CREATE TABLE Professor (
    ProfessorId INT IDENTITY(1,1) PRIMARY KEY,
    ProfessorName VARCHAR(100) NOT NULL,
    ProfessorAddress VARCHAR(255) NOT NULL,
    ProfessorAge INT NOT NULL,
    Salary DECIMAL(10,2) NOT NULL,
    DepartmentId INT NOT NULL,
    CONSTRAINT FK_Professor_Department
        FOREIGN KEY (DepartmentId) REFERENCES Department(DepartmentId)
);


CREATE TABLE Student (
    StudentId INT IDENTITY(1,1) PRIMARY KEY,
    StudentName VARCHAR(100) NOT NULL,
    StudentAddress VARCHAR(255) NOT NULL,
    Age INT NOT NULL,
    StudentPercentage DECIMAL(5,2) NULL,
    StudentMarks INT NULL,
    StudentResult VARCHAR(10) NULL
        CHECK (StudentResult IN ('Pass','Fail')),
    DepartmentId INT NOT NULL,
    CONSTRAINT FK_Student_Department
        FOREIGN KEY (DepartmentId) REFERENCES Department(DepartmentId)
);


-- show tables name
SELECT name 
FROM sys.tables;

SELECT * FROM sys.tables;


-- Insert Query
INSERT INTO University 
(UniversityName, UniversityType, UniversityGrade, UniversityAddress)
VALUES
('AAAAAA', 'Public',  'A',  'UniversityAddress 1'),
('BBBBBB', 'Private', 'B',  'UniversityAddress 2'),
('CCCCCC', 'Deemed',  'A+', 'UniversityAddress 3');


INSERT INTO College 
(CollegeName, CollegeType, CollegeAddress, UniversityId)
VALUES
('College1', 'Government', 'CollegeAddress 1', 1),
('College2', 'Private',    'CollegeAddress 2', 1),
('College3', 'Autonomous', 'CollegeAddress 3', 2),
('College4', 'Aided',      'CollegeAddress 4', 2),
('College5', 'Professional','CollegeAddress 5', 3);


INSERT INTO Department 
(DepartmentName, NumberOfClass, DepartmentHead, CollegeId)
VALUES
('Computer Science', 3, 'Anil Sharma', 1),
('Mechanical Engineering', 2, 'Rajesh Verma', 1),
('Computer Science', 2, 'Neha Kulkarni', 2),
('Civil Engineering', 1, 'Sunita Patil', 3),
('Information Technology', 1, 'Mahima Sahu', 4);


INSERT INTO Professor 
(ProfessorName, ProfessorAddress, ProfessorAge, Salary, DepartmentId)
VALUES
('Prof A', 'ProfessorAddress 1', 45, 60000.00, 1),
('Prof B', 'ProfessorAddress 2', 50, 45000.00, 2),
('Prof C', 'ProfessorAddress 3', 40, 55000.00, 3),
('Prof D', 'ProfessorAddress 4', 38, 70000.00, 3),
('Prof E', 'ProfessorAddress 5', 42, 50000, 4),
('Prof F', 'ProfessorAddress 6', 39, 48000.00, 5);


INSERT INTO Student 
(StudentName, StudentAddress, Age, StudentPercentage, StudentMarks, StudentResult, DepartmentId)
VALUES
('Anjali', 'StudentAddress 1', 20, 85.00, 340, 'Pass', 1),
('Riya', 'StudentAddress 2', 21, 72.00, 288, 'Pass', 1),
('Prakash', 'StudentAddress 3', 22, 65.00, 260, 'Pass', 2),
('Raghav', 'StudentAddress 4', 19, 55.00, 220, 'Pass', 3),
('Vandana', 'StudentAddress 5', 21, 32.00, 140, 'Fail', 3),
('Abhishek', 'StudentAddress 6', 23, 22.00, 125, 'Fail', 4);


-- Fetch Query

SELECT * from University ;
SELECT * from College ;
SELECT * from Department ;
SELECT * from Professor ;
SELECT * from Student ;


-- Q1. Get the list of students who belong with a University Name is �AAAAAA�.

SELECT s.StudentName,  s.StudentAddress, s.Age, s.StudentPercentage, s.StudentMarks, s.StudentResult, u.UniversityName
FROM Student s
JOIN Department d ON s.DepartmentId = d.DepartmentId
JOIN College c ON d.CollegeId = c.CollegeId
JOIN University u ON c.UniversityId = u.UniversityId
WHERE u.UniversityName = 'AAAAAA';


-- Q2. Group the students university-wise, college-wise, and department-wise.

SELECT 
    u.UniversityName,
    c.CollegeName,
    d.DepartmentName,
    COUNT(s.StudentId) TotalStudents
FROM Student s
JOIN Department d ON s.DepartmentId = d.DepartmentId
JOIN College c ON d.CollegeId = c.CollegeId
JOIN University u ON c.UniversityId = u.UniversityId
GROUP BY u.UniversityName, c.CollegeName, d.DepartmentName;



-- Q3. Get the list of professors (University name, 'Collegename' , 'DepartmentName', 'ProfessorId', 'ProfessorName', 'ProfessorAddress', 'ProfessorAge') whose salary is more than $ 50,000.00

SELECT 
    u.UniversityName,
    c.CollegeName,
    d.DepartmentName,
    p.ProfessorId,
    p.ProfessorName,
    p.ProfessorAddress,
    p.ProfessorAge,
    p.Salary
FROM Professor p
JOIN Department d ON p.DepartmentId = d.DepartmentId
JOIN College c ON d.CollegeId = c.CollegeId
JOIN University u ON c.UniversityId = u.UniversityId
WHERE p.Salary > 50000;



-- Q4. Get the sum of salary whose belonging university Name is �BBBBBB�

SELECT SUM(p.Salary) AS TotalSalary
FROM Professor p
JOIN Department d ON p.DepartmentId = d.DepartmentId
JOIN College c ON d.CollegeId = c.CollegeId
JOIN University u ON c.UniversityId = u.UniversityId
WHERE u.UniversityName = 'BBBBBB';



-- Q5. Count students university-wise who have passed the first, second and third division.

SELECT 
    u.UniversityName,
    COUNT(CASE WHEN s.StudentPercentage >= 60 THEN 1 ELSE NULL END) AS FirstDivision,
    COUNT(CASE WHEN s.StudentPercentage >= 50 AND s.StudentPercentage < 60 THEN 1 ELSE NULL END) AS SecondDivision,
    COUNT(CASE WHEN s.StudentPercentage >= 35 AND s.StudentPercentage < 50 THEN 1 ELSE NULL END) AS ThirdDivision
FROM Student s
JOIN Department d ON s.DepartmentId = d.DepartmentId
JOIN College c ON d.CollegeId = c.CollegeId
JOIN University u ON c.UniversityId = u.UniversityId
GROUP BY u.UniversityName;



-- Q6. Get List of students who study in the �Computer Science� department

SELECT s.StudentName, d.DepartmentName
FROM Student s
JOIN Department d ON s.DepartmentId = d.DepartmentId
WHERE d.DepartmentName = 'Computer Science';



-- Q7. Get the name of the university who have passed with maximum marks.

SELECT 
    u.UniversityName,
    MAX(s.StudentMarks) AS MaxMarks
FROM Student s
JOIN Department d ON s.DepartmentId = d.DepartmentId
JOIN College c ON d.CollegeId = c.CollegeId
JOIN University u ON c.UniversityId = u.UniversityId
GROUP BY u.UniversityName;



-- Q8. Get list of students who study in grade �A� University

SELECT s.StudentName, u.UniversityName, u.UniversityGrade
FROM Student s
JOIN Department d ON s.DepartmentId = d.DepartmentId
JOIN College c ON d.CollegeId = c.CollegeId
JOIN University u ON c.UniversityId = u.UniversityId
WHERE u.UniversityGrade = 'A';



-- Q9. The percentage of passed students who belong with a University Name is �AAAAAA�

SELECT 
    ROUND(100 * SUM(CASE WHEN s.StudentResult = 'Pass' THEN 1 ELSE 0 END) / COUNT(*), 2) AS PassPercentage
FROM Student s
JOIN Department d ON s.DepartmentId = d.DepartmentId
JOIN College c ON d.CollegeId = c.CollegeId
JOIN University u ON c.UniversityId = u.UniversityId
WHERE u.UniversityName = 'AAAAAA';



-- Q10. Get the percentage of the result college wise.

SELECT 
    c.CollegeName,
    ROUND(100 * SUM(CASE WHEN s.StudentResult = 'Pass' THEN 1 ELSE 0 END) / COUNT(*), 2) AS PassPercentage
FROM Student s
JOIN Department d ON s.DepartmentId = d.DepartmentId
JOIN College c ON d.CollegeId = c.CollegeId
GROUP BY c.CollegeName;