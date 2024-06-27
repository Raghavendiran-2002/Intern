class Person {
  constructor(name, age) {
    this.name = name;
    this.age = age;
  }

  getDetails() {
    return `Name: ${this.name}, Age: ${this.age}`;
  }

  greet() {
    console.log("Hi, my name is " + this.name);
  }
}

class Student extends Person {
  constructor(name, age, studentId, grades = []) {
    super(name, age);
    this.studentId = studentId;
    this._grades = grades;

    this._calculateAverage = function () {
      if (this._grades.length === 0) return 0;
      let total = this._grades.reduce((sum, grade) => sum + grade, 0);
      return total / this._grades.length;
    };
  }

  addGrade(grade) {
    this._grades.push(grade);
  }

  getAverageGrade() {
    return this._calculateAverage();
  }

  getDetails() {
    return `${super.getDetails()}, Student ID: ${
      this.studentId
    }, Average Grade: ${this.getAverageGrade().toFixed(2)}`;
  }
}

let student = new Student("Ram", 30, "P12345", [65, 90, 98]);
student.greet();
console.log(student.getDetails());

student.addGrade(95);
console.log(student.getAverageGrade());
console.log(student.getDetails());

class GraduateStudent extends Student {
  constructor(name, age, studentId, grades, thesisTitle) {
    super(name, age, studentId, grades);
    this.thesisTitle = thesisTitle;
  }

  getDetails() {
    return `${super.getDetails()}, Thesis Title: ${this.thesisTitle}`;
  }
}

let gradStudent = new GraduateStudent(
  "Priya",
  15,
  "Q54321",
  [50, 83, 92],
  "Photography"
);
gradStudent.greet();
console.log(gradStudent.getDetails());
