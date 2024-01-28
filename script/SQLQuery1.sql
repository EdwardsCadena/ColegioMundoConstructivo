create database ColegioMundoConstructivo
USE [ColegioMundoConstructivo]


-- Create Courses table
CREATE TABLE [dbo].[Courses](
	[Id] INT IDENTITY(1,1) NOT NULL PRIMARY KEY,
	[Name] NVARCHAR(50) NOT NULL,
	[TeacherId] INT,
	[CreatedBy] NVARCHAR(50),
	[CreatedAt] DATETIME,
	[UpdatedBy] NVARCHAR(50),
	[UpdatedAt] DATETIME
) 

-- Create Grades table
CREATE TABLE [dbo].[Grades](
	[Id] INT IDENTITY(1,1) NOT NULL PRIMARY KEY,
	[Score] INT NOT NULL,
	[StudentId] INT,
	[CourseId] INT,
	[CreatedBy] NVARCHAR(50),
	[CreatedAt] DATETIME,
	[UpdatedBy] NVARCHAR(50),
	[UpdatedAt] DATETIME
) 

-- Create Students table
CREATE TABLE [dbo].[Students](
	[Id] INT IDENTITY(1,1) NOT NULL PRIMARY KEY,
	[FirstName] NVARCHAR(50) NOT NULL,
	[LastName] NVARCHAR(50) NOT NULL,
	[IdentityDocument] NVARCHAR(50) NOT NULL,
	[CellPhone] NVARCHAR(50),
	[Email] NVARCHAR(50),
	[BirthDate] DATE,
	[CreatedBy] NVARCHAR(50),
	[CreatedAt] DATETIME,
	[UpdatedBy] NVARCHAR(50),
	[UpdatedAt] DATETIME
) 

-- Create Teachers table
CREATE TABLE [dbo].[Teachers](
	[Id] INT IDENTITY(1,1) NOT NULL PRIMARY KEY,
	[FirstName] NVARCHAR(50) NOT NULL,
	[LastName] NVARCHAR(50) NOT NULL,
	[IdentityDocument] NVARCHAR(50) NOT NULL,
	[CellPhone] NVARCHAR(50),
	[Email] NVARCHAR(50),
	[BirthDate] DATE,
	[CreatedBy] NVARCHAR(50),
	[CreatedAt] DATETIME,
	[UpdatedBy] NVARCHAR(50),
	[UpdatedAt] DATETIME
) 

-- Create Users table
CREATE TABLE [dbo].[Users](
	[Id] INT IDENTITY(1,1) NOT NULL PRIMARY KEY,
	[Email] NVARCHAR(50),
	[Password] NVARCHAR(250),
	[DateCreation] DATETIME
) 


-- Insertar datos en la tabla Students
INSERT INTO Students (FirstName, LastName, IdentityDocument, CellPhone, Email, BirthDate, CreatedBy, CreatedAt, UpdatedBy, UpdatedAt)
VALUES 
    ('John', 'Doe', '1000000001', '1234567890', 'john@student.com', '2000-01-01', 'admin', GETDATE(), 'admin', GETDATE()),
    ('Jane', 'Doe', '1000000002', '1234567891', 'jane@student.com', '2000-02-02', 'admin', GETDATE(), 'admin', GETDATE()),
    ('Alice', 'Johnson', '1000000003', '1234567892', 'alice@student.com', '2000-03-03', 'admin', GETDATE(), 'admin', GETDATE()),
    ('Bob', 'Johnson', '1000000004', '1234567893', 'bob@student.com', '2000-04-04', 'admin', GETDATE(), 'admin', GETDATE()),
    ('Charlie', 'Smith', '1000000005', '1234567894', 'charlie@student.com', '2000-05-05', 'admin', GETDATE(), 'admin', GETDATE()),
    ('David', 'Smith', '1000000006', '1234567895', 'david@student.com', '2000-06-06', 'admin', GETDATE(), 'admin', GETDATE()),
    ('Emily', 'Johnson', '1000000007', '1234567896', 'emily@student.com', '2000-07-07', 'admin', GETDATE(), 'admin', GETDATE()),
    ('Frank', 'Doe', '1000000008', '1234567897', 'frank@student.com', '2000-08-08', 'admin', GETDATE(), 'admin', GETDATE()),
    ('Grace', 'Smith', '1000000009', '1234567898', 'grace@student.com', '2000-09-09', 'admin', GETDATE(), 'admin', GETDATE()),
    ('Harry', 'Johnson', '1000000010', '1234567899', 'harry@student.com', '2000-10-10', 'admin', GETDATE(), 'admin', GETDATE());

-- Insertar datos en la tabla Teachers
INSERT INTO Teachers (FirstName, LastName, IdentityDocument, CellPhone, Email, BirthDate, CreatedBy, CreatedAt, UpdatedBy, UpdatedAt)
VALUES 
    ('Emma', 'Williams', '2000000001', '1234567800', 'emma@teacher.com', '1980-11-11', 'admin', GETDATE(), 'admin', GETDATE()),
    ('Oliver', 'Williams', '2000000002', '1234567801', 'oliver@teacher.com', '1980-12-12', 'admin', GETDATE(), 'admin', GETDATE()),
    ('Sophia', 'Brown', '2000000003', '1234567802', 'sophia@teacher.com', '1981-01-01', 'admin', GETDATE(), 'admin', GETDATE()),
    ('Liam', 'Brown', '2000000004', '1234567803', 'liam@teacher.com', '1981-02-02', 'admin', GETDATE(), 'admin', GETDATE()),
    ('Ava', 'Taylor', '2000000005', '1234567804', 'ava@teacher.com', '1981-03-03', 'admin', GETDATE(), 'admin', GETDATE()),
    ('Noah', 'Brown', '2000000006', '1234567805', 'noah@teacher.com', '1981-04-04', 'admin', GETDATE(), 'admin', GETDATE()),
    ('Isabella', 'Taylor', '2000000007', '1234567806', 'isabella@teacher.com', '1981-05-05', 'admin', GETDATE(), 'admin', GETDATE()),
    ('Jack', 'Brown', '2000000008', '1234567807', 'jack@teacher.com', '1981-06-06', 'admin', GETDATE(), 'admin', GETDATE()),
    ('Mia', 'Williams', '2000000009', '1234567808', 'mia@teacher.com', '1981-07-07', 'admin', GETDATE(), 'admin', GETDATE()),
    ('Jacob', 'Taylor', '2000000010', '1234567809', 'jacob@teacher.com', '1981-08-08', 'admin', GETDATE(), 'admin', GETDATE());
-- Insertar datos en la tabla Courses
INSERT INTO Courses (Name, TeacherId, CreatedBy, CreatedAt, UpdatedBy, UpdatedAt)
VALUES 
    ('Math', 1, 'admin', GETDATE(), 'admin', GETDATE()),
    ('English', 2, 'admin', GETDATE(), 'admin', GETDATE()),
    ('Science', 3, 'admin', GETDATE(), 'admin', GETDATE()),
    ('History', 4, 'admin', GETDATE(), 'admin', GETDATE()),
    ('Geography', 5, 'admin', GETDATE(), 'admin', GETDATE()),
    ('Physics', 6, 'admin', GETDATE(), 'admin', GETDATE()),
    ('Chemistry', 7, 'admin', GETDATE(), 'admin', GETDATE()),
    ('Biology', 8, 'admin', GETDATE(), 'admin', GETDATE()),
    ('Art', 9, 'admin', GETDATE(), 'admin', GETDATE()),
    ('Music', 10, 'admin', GETDATE(), 'admin', GETDATE());

-- Insertar datos en la tabla Grades
INSERT INTO Grades (Score, StudentId, CourseId, CreatedBy, CreatedAt, UpdatedBy, UpdatedAt)
VALUES 
    (85, 1, 1, 'admin', GETDATE(), 'admin', GETDATE()),
    (90, 2, 2, 'admin', GETDATE(), 'admin', GETDATE()),
    (95, 3, 3, 'admin', GETDATE(), 'admin', GETDATE()),
    (80, 4, 4, 'admin', GETDATE(), 'admin', GETDATE()),
    (88, 5, 5, 'admin', GETDATE(), 'admin', GETDATE()),
    (92, 6, 6, 'admin', GETDATE(), 'admin', GETDATE()),
    (78, 7, 7, 'admin', GETDATE(), 'admin', GETDATE()),
    (96, 8, 8, 'admin', GETDATE(), 'admin', GETDATE()),
    (85, 9, 9, 'admin', GETDATE(), 'admin', GETDATE()),
    (90, 10, 10, 'admin', GETDATE(), 'admin', GETDATE());