using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using P5;

namespace Builder
{
    public partial class FormCreateFeature : Form
    {
        int selected_project_id;
        FakeFeatureRepository fakeFeature;
        FakeIssueStatusRepository fakeIssueStatus = new FakeIssueStatusRepository();
        
        public FormCreateFeature(int selected_project)
        {
            InitializeComponent();
            this.CenterToParent();
            selected_project_id = selected_project;
            fakeFeature = new FakeFeatureRepository(selected_project);

        }

        private void btnCreate_Click(object sender, EventArgs e)
        {
            Feature feature = new Feature();
            feature.ProjectId = selected_project_id;
            feature.Title = textBox1.Text.Trim();
            string result = fakeFeature.Add(feature);
            if (result == FakeFeatureRepository.NO_ERROR)
            {
                MessageBox.Show("Feature Added Successfully");
            }
            else
            {
                MessageBox.Show("Feature not added, " + result, "Attention");
            }
            this.Close();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
