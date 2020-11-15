using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Builder
{
    public partial class FormRequirementModify : Form
    {
        int selected_project;
        int selected_r;
        FakeFeatureRepository fake;
        FakeRequiremnetRepository fakeRequiremnet;
        
        public FormRequirementModify(int project, int selected_requirement)
        {
            InitializeComponent();
            this.CenterToParent();
            selected_project = project;
            fake = new FakeFeatureRepository(selected_project);
            fakeRequiremnet = new FakeRequiremnetRepository(selected_project);
            selected_r = selected_requirement;
        }

        private void FormRequirementModify_Load(object sender, EventArgs e)
        {
            this.CenterToParent();
            List<Feature> features = fake.GetAll(selected_project);
            Requirement req = fakeRequiremnet.GetRequirementByID(selected_r);
            richTextBox1.Text = req.Statement;
            foreach (Feature f in features)
            {
                comboBox1.Items.Add(f.Title);
                if (f.Id == req.FeatureId)
                {
                    comboBox1.SelectedItem = f.Title;
                }
                comboBox1.Items.Add(f.Title);
            }
            if (comboBox1.Items.Count < 1)
            {
                comboBox1.Enabled = false;
            }
            
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBox1.SelectedIndex > 0)
            {
                richTextBox1.Enabled = true;
                btnModify.Enabled = true;
            }
            else
            {
                richTextBox1.Enabled = false;
                btnModify.Enabled = false;
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnModify_Click(object sender, EventArgs e)
        {
            Requirement requirement = new Requirement();
            Feature feature = fake.GetFeatureByTitle(comboBox1.SelectedItem.ToString());
            requirement.FeatureId = feature.Id;
            requirement.Statement = richTextBox1.Text.Trim();
            MessageBox.Show(requirement.Statement);
            requirement.ProjectId = selected_project;
            requirement.Id = selected_r;
            string result = fakeRequiremnet.Modify(requirement);
            if (result == FakeFeatureRepository.NO_ERROR)
            {
                MessageBox.Show("Requirement Modified Successfully");
            }
            else
            {
                MessageBox.Show("Requirement not added, " + result, "Attention");
            }
            this.Close();
        }
    }
}
