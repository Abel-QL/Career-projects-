// See https://aka.ms/new-console-template for more information
using Tarea1;

Console.WriteLine ("Hello, World!");

Teacher profesor = new Teacher{
    Id = 1, FirstName = "Profesor", LastName = "El más duro", Birthdate = DateTime.Now,
    Salary = 100, Role = "NORMAL", Cedula = "123", EntryDate = DateTime.Now.AddDays (-2), asignatura = "matematicas", Email = "teacher@gmail.com", course = "edeficio 4"
};

// prueba empleado
Console.WriteLine ("===== INFORMACIÓN DEL EMPLEADO/PROFESOR =====\n");
Console.WriteLine ($@"
ID: {profesor.Id}
Nombre completo: {profesor.FirstName} {profesor.LastName}
Cédula: {profesor.Cedula}
Fecha de nacimiento: {profesor.Birthdate}
Fecha de ingreso: {profesor.EntryDate}
Cargo: {profesor.asignatura}
Curso: {profesor.course}
Rol: {profesor.Role}
Salario: RD$ {profesor.Salary}
Correo electrónico: {profesor.Email}
");

Console.WriteLine ("---------------------------------");

Student estudiante = new Student (){
    id = 1, StudentId = 12313, FirstName = "Estudiante", LastName = "Promedio", Birthdate = DateTime.Now.AddDays (-10),
    calification = "A+", carreer = "Desarrollo de software", Cedula = "12131", EntryDate = DateTime.Now.AddDays (-2), isFormerStudent = false,
    IsActive = true,
    Email = "EstudianteP@gmail.com",
    Role = "ESTUDIANTE"
};

Console.WriteLine ("===== INFORMACIÓN DEL ESTUDIANTE =====\n");

Console.WriteLine ($@"
ID Interno: {estudiante.id}
Matrícula: {estudiante.StudentId}
Nombre completo: {estudiante.FirstName} {estudiante.LastName}
Cédula: {estudiante.Cedula}
Fecha de nacimiento: {estudiante.Birthdate:dd/MM/yyyy}
Fecha de ingreso: {estudiante.EntryDate:dd/MM/yyyy}
Carrera: {estudiante.carreer}
Calificación: {estudiante.calification}
Estado: {(estudiante.IsActive ? "Activo" : "Inactivo")}
Egresado: {(estudiante.isFormerStudent ? "Sí" : "No")}
Correo electrónico: {estudiante.Email}
Rol: {estudiante.Role}
");