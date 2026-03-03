CREATE DATABASE EventDb;

USE EventDb;

CREATE TABLE UserInfo(
EmailId VARCHAR(100) PRIMARY KEY,
UserName VARCHAR(50) NOT NULL,
Role VARCHAR(20) NOT NULL
CHECK (Role IN ('Admin','Participant')),
Password VARCHAR(20) NOT NULL,
CHECK (LEN(UserName) BETWEEN 1 AND 50),
CHECK (LEN(Password) BETWEEN 6 AND 20)
);
CREATE TABLE EventDetails(
EventId INT PRIMARY KEY,
EventName VARCHAR(50) NOT NULL,
EventCategory VARCHAR(50) NOT NULL,
EventDate DATETIME NOT NULL,
Description VARCHAR(255),
Status VARCHAR(20) CHECK(Status IN('Active','In-Active')),
CHECK (LEN(EventName) BETWEEN 1 AND 50),
CHECK (LEN(EventCategory) BETWEEN 1 AND 20)
);

CREATE TABLE SpeakersDetails(
SpeakerId INT PRIMARY KEY,
SpeakerName VARCHAR(50) NOT NULL,
CHECK (LEN(SpeakerName) BETWEEN 1 AND 50),);

CREATE TABLE SessionInfo(
SessionId INT PRIMARY KEY,
EventId INT NOT NULL,
SessionTitle VARCHAR(50) NOT NULL,
SpeakerId INT NOT NULL,
Description VARCHAR(255),
SessionStart DATETIME NOT NULL,
SessionEnd DATETIME NOT NULL,
SessionUrl VARCHAR(255),
CHECK(len(SessionTitle) BETWEEN 1 AND 50),
CHECK(SessionEnd>SessionStart),
FOREIGN KEY(EventId) REFERENCES EventDetails(EventId),
FOREIGN KEY(SpeakerId) REFERENCES SpeakersDetails(SpeakerId)
);

CREATE TABLE ParticipantEventDetails(
Id INT PRIMARY KEY,
ParticipantEmailId VARCHAR(100) NOT NULL,
EventId INT NOT NULL,
SessionId INT NOT NULL,
IsAttended bIT NOT NULL CHECK (IsAttended IN(0,1)),
FOREIGN KEY (ParticipantEmailId) REFERENCES UserInfo(EmailId),
FOREIGN KEY (EventId) REFERENCES EventDetails(EventId),
FOREIGN KEY (SessionId) REFERENCES SessionInfo(SessionId)
);

INSERT INTO UserInfo VALUES
('nirupa@gmail.com','Nirupa','Participant','niru@123');

INSERT INTO EventDetails VALUES
(1,'SQL Intro Event','Technology','2026-03-03','Introduction and Hands-On','Active');

INSERT INTO SpeakersDetails VALUES
(1,'Bharat');

INSERT INTO SessionInfo VALUES
(101,1,'SQL',1,'Introduction about SQL','2026-03-03 9:00','2026-03-03 11:00','http://sql-session.com');

INSERT INTO ParticipantEventDetails VALUES
(1,'nirupa@gmail.com',1,101,1);

SELECT * FROM UserInfo;
SELECT * FROM EventDetails;
SELECT * FROM SpeakersDetails;
SELECT * FROM ParticipantEventDetails;