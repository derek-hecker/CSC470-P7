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
    public partial class FormModifyFeature : Form
    {
        int _SelectedProjectId;
        int featureID;
        FakeFeatureRepository FakeFeature;
        Feature selectedFeauture;
        Feature temporaryFeature;
        public FormModifyFeature(int project, int feat)
        {
            InitializeComponent();
            _SelectedProjectId = project;
            featureID = feat;

        }

        private void btnModify_Click(object sender, EventArgs e)
        {
            
            temporaryFeature.Title = textBoxTitle.Text.Trim();
            temporaryFeature.Id = selectedFeauture.Id;
            temporaryFeature.ProjectId = selectedFeauture.ProjectId;
            string result = FakeFeature.Modify(temporaryFeature);
            if (result != FakeFeatureRepository.NO_ERROR)
            {
                MessageBox.Show("Error modifying feature. Error: " + result);
            }
            else
            {
                MessageBox.Show("Feature modification successful.", "Information");
                this.Close();
            }
        }


        private void FormModifyFeature_Load(object sender, EventArgs e)
        {
            this.CenterToScreen();
            FakeFeature = new FakeFeatureRepository(_SelectedProjectId);
            selectedFeauture = FakeFeature.GetFeatureByID(featureID);
            textBoxTitle.Text = selectedFeauture.Title;
            temporaryFeature = new Feature();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
