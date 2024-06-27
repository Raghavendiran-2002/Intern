function Person(name, age) {
  this.name = name;
  this.age = age;
}

Person.prototype.greet = function () {
  console.log("Hi, my name is " + this.name);
};

function Student(name, age, studentId) {
  Person.call(this, name, age);
  this.studentId = studentId;
}

Student.prototype = Object.create(Person.prototype);
Student.prototype.constructor = Student;

Student.prototype.study = function () {
  console.log(this.name + " is studying.");
};

let student = new Student("Raju", 22, "T12345");
student.greet();
student.study();
