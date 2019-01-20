# AcmeSalaryCalculator
Acme Salary Calculator excercie


Simple C# console application that will calculate the salary of a list of employees your provide based on a pay table for each hour.

This application will first read the required files (EmployeeWorkHours.txt and SalaryTable.txt) placed in "..\AcmeSalaryCalculator/SalaryCalculator/bin/InputFiles". SalaryTable.txt will provide the rate each employee will recieve depending on the hour range he works and depending on the day he works. EmployeeWorkHours.txt on the other hand will contain the list of employees with its respective days and hours worked. With this, program will calculate the hours worked and obtain the total pay the employee should receive.

To run the program, the easiest way to open a command line and navigate to where you cloned folder is. Once you are in "..\AcmeSalaryCalculator/SalaryCalculator" you have to type the following: "csc -define:DEBUG -optimize -out:SalaryCalculation.exe *.cs". This will compile the project and generate a .exe file named SalaryCalculation. After this, you can just type SalaryCalculation.exe to run the program.

It is important to know, that the user can modify the data on the files mentioned above to add employees/hours or to change the rates per hour or day as long as the follow the same format they currently have.

If you have any question I will be happy to anser, my email is m4mariomiguel@gmail.com
