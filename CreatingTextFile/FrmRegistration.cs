using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace CreatingTextFile
{
    public partial class FrmRegistration : Form
    {
        public FrmRegistration()
        {
            InitializeComponent();
        }

        private void regBtn_Click(object sender, EventArgs e)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(studentNumberInput.Text) ||
                    string.IsNullOrWhiteSpace(lastNameInput.Text) ||
                    string.IsNullOrWhiteSpace(firstNameInput.Text) ||
                    string.IsNullOrWhiteSpace(contactNumberInput.Text))
                {
                    MessageBox.Show("Please fill in all required fields.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                int studentNumber = int.Parse(studentNumberInput.Text);
                int age = int.Parse(ageInput.Text);
                string lastName = lastNameInput.Text;
                string firstName = firstNameInput.Text;
                string middleInitial = middleInitialInput.Text;
                string gender = genderInput.SelectedItem?.ToString() ?? "Not Specified";
                string program = programInput.SelectedItem?.ToString() ?? "Not Specified";
                string birthday = birthdayInput.Value.ToShortDateString();
                string contactNumber = contactNumberInput.Text;

                FrmFileName frmFileName = new FrmFileName();
                frmFileName.ShowDialog();

                if (!string.IsNullOrEmpty(FrmFileName.FileName))
                {
                    string docPath = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);
                    string filePath = Path.Combine(docPath, FrmFileName.FileName);

                    using (StreamWriter outputFile = new StreamWriter(filePath))
                    {
                        outputFile.WriteLine($"Student Number: {studentNumber}");
                        outputFile.WriteLine($"Last Name: {lastName}");
                        outputFile.WriteLine($"First Name: {firstName}");
                        outputFile.WriteLine($"Middle Initial: {middleInitial}");
                        outputFile.WriteLine($"Gender: {gender}");
                        outputFile.WriteLine($"Age: {age}");
                        outputFile.WriteLine($"Birthday: {birthday}");
                        outputFile.WriteLine($"Program: {program}");
                        outputFile.WriteLine($"Contact Number: {contactNumber}");
                    }

                    MessageBox.Show("Registration data saved successfully.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (FormatException)
            {
                MessageBox.Show("Please ensure all numeric fields are valid numbers.", "Input Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"An unexpected error occurred: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }


    }
}
