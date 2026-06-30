Student student = new Student("Kavya", "22L31A05A0");

StudentView view = new StudentView();

StudentController controller = new StudentController(student, view);

controller.UpdateView();