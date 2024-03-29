﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsAppArman
{
    public partial class SudentData : Form
    {
        List<int> studentId = new List<int> { };
        List<string> studentName = new List<string> { };
        List<string> studentMobile = new List<string> { };
        List<int> studentAge = new List<int> { };
        List<string> studentAddress = new List<string> { };
        List<double> studentGpaPoint = new List<double> { };

        public SudentData()
        {
            InitializeComponent();
        }

        private void addStudentData_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(idTextBox.Text))
            {
                MessageBox.Show("ID canNotBe Null");
                return;
            }
            if (idTextBox.Text.Length != 4)
            {

                MessageBox.Show("id Must Be in 4 Number");
                return;

            }

            else if(nameTextBox.Text.Length > 30)
            {
                MessageBox.Show("Name Must Be In 30 Characters");

            }
            else if(mobileTextBox.Text.Length !=11)
            {
                MessageBox.Show("MObile Number Must Be In 11 Digit");

            }
            else if (ageTextBox.Text.Length > 100)
            {
                MessageBox.Show("Wrong age as a student");
            }
            else if(addressTextBox.Text.Length >= 50)
            {
                MessageBox.Show("Sorry Addres Contains Too Many Word ");

            }
            else if(gpaTextBox.Text.Length >= 4.00)
            {
                MessageBox.Show("Sorry GPA Must Be in Out OF 4..");

            }
            else
            {

                AddStudentInfo(Convert.ToInt32(idTextBox.Text), nameTextBox.Text, mobileTextBox.Text, Convert.ToInt32(ageTextBox.Text), addressTextBox.Text, Convert.ToDouble(gpaTextBox.Text));
                MessageBox.Show("Data inserted Successfully");
                MaxAndMinInfo();
                AvgAndTotal();



            }
            
        }
        private void AddStudentInfo(int id, string name, string mobile, int age, string address, double gpaPoint)
        {
            studentId.Add(id);
            studentName.Add(name);
            studentMobile.Add(mobile);
            studentAge.Add(age);
            studentAddress.Add(address);
            studentGpaPoint.Add(gpaPoint);

        }
        private void MaxAndMinInfo()
        {

           
            double studentGpaPointMax = studentGpaPoint.Max();
            double studentGpaPointMin = studentGpaPoint.Min();

            if (studentGpaPointMax <= Convert.ToDouble(gpaTextBox.Text))
            {
                maxTextBox.Text = studentGpaPointMax.ToString();
                var maxGpaindex = studentGpaPoint.IndexOf(studentGpaPoint.Max());
                maxStudentNameTextBox.Text = studentName[maxGpaindex];

            }
            else if (studentGpaPointMin >= Convert.ToDouble(gpaTextBox.Text))
            {
                minStudentTextBox.Text = studentGpaPointMin.ToString();
                var minGpaindex = studentGpaPoint.IndexOf(studentGpaPoint.Min());
                minStudentNameextBox.Text = studentName[minGpaindex];
               
            }
            return;
                           
           
        }
        private void AvgAndTotal()
        {
            avgTextBox.Text = studentGpaPoint.Sum().ToString();
            totalTextBox.Text = studentGpaPoint.Average().ToString();
        }
       
        private void ShowStudentInfo()
        {
            string message = "";
            for(int i = 0; i<studentName.Count(); i++)
            {
                message += studentId[i]+"\n" + studentName[i]+"\n" + studentMobile[i]+"\n" + studentAge[i]+"\n" + studentAddress[i]+"\n" + studentGpaPoint[i]+"\n"; 

            }
            showRichTextBox.Text = message;
        }

        private void showButton_Click(object sender, EventArgs e)
        {
            ShowStudentInfo();
        }
        private void SearchStudentInfoById()
        {
            if (string.IsNullOrEmpty(idTextBox.Text))
            {
                MessageBox.Show("This is empty");
                return;
            }
            if (studentId.Contains(Convert.ToInt32(idTextBox.Text)))
            {
                int index = studentId.IndexOf(Convert.ToInt32(idTextBox.Text));
                MessageBox.Show(studentId[index]+"\n"+ studentName[index]+"\n" + studentMobile[index]+"\n" + studentAge[index]+"\n" + studentAddress[index]+"\n" + studentGpaPoint[index]+"\n");

            }
            else
            {
                MessageBox.Show("sorry data not available");
            }

        }
        private void SearchStudentInfoByName()
        {
            if (string.IsNullOrEmpty(nameTextBox.Text))
            {
                MessageBox.Show("This is empty");
                return;
            }
            if (studentName.Contains(nameTextBox.Text))
            {
                int index = studentName.IndexOf(nameTextBox.Text);
                MessageBox.Show(studentName[index] + "\n" + studentId[index] + "\n" + studentMobile[index] + "\n" + studentAge[index] + "\n" + studentAddress[index] + "\n" + studentGpaPoint[index] + "\n");
                return;
            }
        }
        private void SearchStudentInfoByMobile()
        {
            if (string.IsNullOrEmpty(mobileTextBox.Text))
            {
                MessageBox.Show("This is empty");
                return;
            }

            if (studentMobile.Contains(mobileTextBox.Text))
            {
                int index = studentMobile.IndexOf(mobileTextBox.Text);
                MessageBox.Show(studentMobile[index] + "\n" + studentId[index] + "\n" + studentName[index] + "\n" + studentAge[index] + "\n" + studentAddress[index] + "\n" + studentGpaPoint[index] + "\n");
                return;
            }
        }

        private void SearchButton_Click(object sender, EventArgs e)
        {
            if(idRadioButton.Checked == true)
            {
                SearchStudentInfoById();

            }else if(nameRadioButton.Checked == true)
            {
                SearchStudentInfoByName();

            }else if(mobileRadioButton.Checked == true)
            {
                SearchStudentInfoByMobile();
            }
            else
            {
                MessageBox.Show("Please Select Any One to search");
            }
        }
    }
}
