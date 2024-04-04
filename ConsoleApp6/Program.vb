Imports System

Public Class Student
    ' Fields to store student details
    Public Property StudentID As Integer
    Public Property Name As String
    Public Property Age As Integer

    ' Constructor to initialize student details
    Public Sub New(id As Integer, name As String, age As Integer)
        Me.StudentID = id
        Me.Name = name
        Me.Age = age
    End Sub
End Class

Module Program
    Dim Students As New List(Of Student)

    Sub Main(args As String())
        Dim choice As Integer

        Do
            Console.WriteLine("1. Insert Student")
            Console.WriteLine("2. Delete Student")
            Console.WriteLine("3. Update Student")
            Console.WriteLine("4. Display All Students")
            Console.WriteLine("5. Exit")
            Console.Write("Enter your choice: ")
            choice = Convert.ToInt32(Console.ReadLine())

            Select Case choice
                Case 1
                    InsertStudent()
                Case 2
                    DeleteStudent()
                Case 3
                    UpdateStudent()
                Case 4
                    DisplayAllStudents()
                Case 5
                    Exit Do
                Case Else
                    Console.WriteLine("Invalid choice. Please try again.")
            End Select
        Loop While choice <> 5
    End Sub

    ' Method to insert a new student
    Sub InsertStudent()
        Console.Write("Enter Student ID: ")
        Dim id As Integer = Convert.ToInt32(Console.ReadLine())
        ' Check if the student ID already exists
        If Students.Exists(Function(s) s.StudentID = id) Then
            Console.WriteLine($"Student with ID {id} already exists. Insertion failed.")
            Return
        End If

        Console.Write("Enter Student Name: ")
        Dim name As String = Console.ReadLine()
        Console.Write("Enter Student Age: ")
        Dim age As Integer = Convert.ToInt32(Console.ReadLine())

        Dim newStudent As New Student(id, name, age)
        Students.Add(newStudent)
        Console.WriteLine($"Student {name} added successfully.")
    End Sub

    ' Method to delete a student
    Sub DeleteStudent()
        Console.Write("Enter Student ID to delete: ")
        Dim idToDelete As Integer = Convert.ToInt32(Console.ReadLine())
        Dim studentToDelete As Student = Students.Find(Function(s) s.StudentID = idToDelete)
        If studentToDelete IsNot Nothing Then
            Students.Remove(studentToDelete)
            Console.WriteLine($"Student with ID {idToDelete} deleted successfully.")
        Else
            Console.WriteLine($"Student with ID {idToDelete} not found.")
        End If
    End Sub

    ' Method to update student details
    Sub UpdateStudent()
        Console.Write("Enter Student ID to update: ")
        Dim idToUpdate As Integer = Convert.ToInt32(Console.ReadLine())
        Dim studentToUpdate As Student = Students.Find(Function(s) s.StudentID = idToUpdate)
        If studentToUpdate IsNot Nothing Then
            Console.Write("Enter new Student Name: ")
            studentToUpdate.Name = Console.ReadLine()
            Console.Write("Enter new Student Age: ")
            studentToUpdate.Age = Convert.ToInt32(Console.ReadLine())
            Console.WriteLine($"Student with ID {idToUpdate} details updated successfully.")
        Else
            Console.WriteLine($"Student with ID {idToUpdate} not found.")
        End If
    End Sub

    ' Method to display all students
    Sub DisplayAllStudents()
        If Students.Count > 0 Then
            Console.WriteLine("List of Students:")
            For Each student As Student In Students
                Console.WriteLine($"ID: {student.StudentID}, Name: {student.Name}, Age: {student.Age}")
            Next
        Else
            Console.WriteLine("No students found.")
        End If
    End Sub
End Module
