using System;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using SalaryCalculator;

namespace UnitTestSalaryCalculator
{
    [TestClass]
    public class UnitTest1
    {
        readonly LaunchProcesses launchProcesses = new LaunchProcesses();

        [TestMethod]
        //Test if there is one nonexistent path
        public void Path_Not_Found() 
        {
            launchProcesses.OpenFiles("juio", @"..\\TestFiles\SalaryTable.txt");
            Assert.AreEqual(0, launchProcesses.returEmployeesList.Count); //List should return empty without crashing

        }

        [TestMethod]
        //Test if both paths are nonexistent 
        public void Paths_Not_Fund()
        {
            launchProcesses.OpenFiles("juio", "piopo");
            Assert.AreEqual(0, launchProcesses.returEmployeesList.Count); //List should return empty without crashing
        }

        [TestMethod]
        //Test with the data provided for this excercise
        public void Data_Provided()
        {
            launchProcesses.OpenFiles(@"..\\TestFiles\SampleProvied.txt", @"..\\TestFiles\SalaryTable.txt");
            Assert.AreEqual("RENE", launchProcesses.returEmployeesList[0].Name);
            Assert.AreEqual(215, launchProcesses.returEmployeesList[0].PayCheck);
            Assert.AreEqual("ASTRID", launchProcesses.returEmployeesList[1].Name);
            Assert.AreEqual(85, launchProcesses.returEmployeesList[1].PayCheck);
        }

        [TestMethod]
        //Test with the max amount of data mention for this exercise
        public void Max_Set_Data()
        {
            launchProcesses.OpenFiles(@"..\\TestFiles\MaxSetData.txt", @"..\\TestFiles\SalaryTable.txt");
            Assert.AreEqual("RENE", launchProcesses.returEmployeesList[0].Name);
            Assert.AreEqual(215, launchProcesses.returEmployeesList[0].PayCheck);
            Assert.AreEqual("ASTRID", launchProcesses.returEmployeesList[1].Name);
            Assert.AreEqual(85, launchProcesses.returEmployeesList[1].PayCheck);
            Assert.AreEqual("MARIO", launchProcesses.returEmployeesList[2].Name);
            Assert.AreEqual(85, launchProcesses.returEmployeesList[2].PayCheck);
            Assert.AreEqual("ROXANA", launchProcesses.returEmployeesList[3].Name);
            Assert.AreEqual(110, launchProcesses.returEmployeesList[3].PayCheck);
        }

        [TestMethod]
        //Test if the hours worked are in different pay ranges
        public void Two_Different_Pay_Ranges()
        {
            launchProcesses.OpenFiles(@"..\\TestFiles\TwoPayRanges.txt", @"..\\TestFiles\SalaryTable.txt");
            Assert.AreEqual("RENE", launchProcesses.returEmployeesList[0].Name);
            Assert.AreEqual(215, launchProcesses.returEmployeesList[0].PayCheck);
            Assert.AreEqual("ASTRID", launchProcesses.returEmployeesList[1].Name);
            Assert.AreEqual(85, launchProcesses.returEmployeesList[1].PayCheck);
            Assert.AreEqual("MARIO", launchProcesses.returEmployeesList[2].Name);
            Assert.AreEqual(200, launchProcesses.returEmployeesList[2].PayCheck);
        }

        [TestMethod]
        //Test if the hours worked are in different pay ranges
        public void Three_Different_Pay_Ranges()
        {
            launchProcesses.OpenFiles(@"..\\TestFiles\ThreePayRanges.txt", @"..\\TestFiles\SalaryTable.txt");
            Assert.AreEqual("RENE", launchProcesses.returEmployeesList[0].Name);
            Assert.AreEqual(215, launchProcesses.returEmployeesList[0].PayCheck);
            Assert.AreEqual("ASTRID", launchProcesses.returEmployeesList[1].Name);
            Assert.AreEqual(85, launchProcesses.returEmployeesList[1].PayCheck);
            Assert.AreEqual("MARIO", launchProcesses.returEmployeesList[2].Name);
            Assert.AreEqual(240, launchProcesses.returEmployeesList[2].PayCheck);
        }
    }
}
