CREATE DATABASE ClinicTracker

USE ClinicTracker

CREATE TABLE Doctor(Id INT NOT NULL PRIMARY KEY, Name VARCHAR(20),Age INT, Gender VARCHAR(5), DateOfBirth DATETIME, Specialization VARCHAR(30),Experience DECIMAL(3,3))
DROP TABLE Doctor
sp_help Doctor

CREATE TABLE Patient( Id INT NOT NULL PRIMARY KEY, Name VARCHAR(20), Age INT, Disease VARCHAR(30), Gender VARCHAR(5), DateOfBirth DATETIME, MajorDisease VARCHAR(30));


CREATE TABLE Appointment( Id INT NOT NULL PRIMARY KEY, Name VARCHAR(20), Age INT, Disease VARCHAR(30), Gender VARCHAR(5), DateOfBirth DATETIME, AppointmentToDoctor VARCHAR(30), AppointmentDate DATETIME);

sp_help Patient


CREATE TABLE Nurses(Id INT NOT NULL PRIMARY KEY, Name VARCHAR(20),Age INT, Gender VARCHAR(5), DateOfBirth DATETIME, Specialization VARCHAR(30),Experience DECIMAL(3,3))
DROP TABLE Nurses
sp_help Nurses

CREATE TABLE SpecializedDepartment (Id INT NOT NULL PRIMARY KEY, Name VARCHAR(30), Department_Head VARCHAR(30))