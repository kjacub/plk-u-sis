CREATE DATABASE IF NOT EXISTS plk_u_sis_db;

USE plk_u_sis_db;

CREATE TABLE IF NOT EXISTS students (
    student_id VARCHAR(20) PRIMARY KEY,
    full_name VARCHAR(100) NOT NULL,
    gender VARCHAR(20) NOT NULL,
    year_level VARCHAR(30) NOT NULL,
    program VARCHAR(100) NOT NULL,
    contact_number VARCHAR(30) NOT NULL
);
