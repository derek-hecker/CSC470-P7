﻿using Builder;
using System.Windows.Forms;

namespace P5
{
    public partial class FormMain : Form
    {
        private AppUser _CurrentAppUser = new AppUser();
        public int selected_id;
        FakeIssueRepository fakeIssueRepository;
        public FormMain()
        {
            InitializeComponent();
        }

        private void preferencesCreateProjectToolStripMenuItem_Click(object sender, System.EventArgs e)
        {
            FormCreateProject form = new FormCreateProject();
            form.ShowDialog();
        }

        private void FormMain_Load(object sender, System.EventArgs e)
        {
            
            this.CenterToScreen();
            // Force the user to login successfully or abort the application
            DialogResult isOK = DialogResult.OK;
            while (!_CurrentAppUser.IsAuthenticated && isOK == DialogResult.OK)
            {
                FormLogin login = new FormLogin();
                isOK = login.ShowDialog();
                _CurrentAppUser = login._CurrentAppUser;
                login.Dispose();
            }
            if (isOK != DialogResult.OK)
            {
                Close();
                return;
            }
            this.Text = "Main - No Project Selected";
            while (selectAProject() == "")
            {
                DialogResult result = MessageBox.Show("A project must be selected.", "Attention", MessageBoxButtons.OKCancel);
                if (result == DialogResult.Cancel)
                {
                    Close();
                    return;
                }
            }
        }

        private void preferencesSelectProjectToolStripMenuItem_Click(object sender, System.EventArgs e)
        {
            selectAProject();
        }

        private string selectAProject()
        {
            string selectedProject = "";
            FormSelectProject form = new FormSelectProject();
            form.ShowDialog();
            if (form.DialogResult == DialogResult.OK)
            {
                FakePreferenceRepository preferenceRepository = new FakePreferenceRepository();
                preferenceRepository.SetPreference(_CurrentAppUser.UserName,
                                                   FakePreferenceRepository.PREFERENCE_PROJECT_NAME,
                                                   form._SelectedProjectName);
                int selectedProjectId = form._SelectedProjectId;
                preferenceRepository.SetPreference(_CurrentAppUser.UserName,
                                                   FakePreferenceRepository.PREFERENCE_PROJECT_ID,
                                                   selectedProjectId.ToString());
                this.Text = "Main - " + form._SelectedProjectName;
                this.selected_id = form._SelectedProjectId;
                selectedProject = form._SelectedProjectName;
                fakeIssueRepository = new FakeIssueRepository(selectedProjectId);
            }
            form.Dispose();
            return selectedProject;
        }

        private void preferencesModifyProjectToolStripMenuItem_Click(object sender, System.EventArgs e)
        {
            FormModifyProject form = new FormModifyProject(_CurrentAppUser);
            form.ShowDialog();
            form.Dispose();
        }

        private void preferencesRemoveProjectToolStripMenuItem_Click(object sender, System.EventArgs e)
        {
            FormRemoveProject form = new FormRemoveProject(_CurrentAppUser);
            form.ShowDialog();
            form.Dispose();
        }

        private void issuesDashboardToolStripMenuItem_Click(object sender, System.EventArgs e)
        {
            IssueDashboard form = new IssueDashboard(_CurrentAppUser, selected_id);
            form.ShowDialog();
            form.Dispose();
        }

        private void issuesRecordToolStripMenuItem_Click(object sender, System.EventArgs e)
        {
            RecordIssue form = new RecordIssue(_CurrentAppUser, selected_id, fakeIssueRepository);
            form.ShowDialog();
            form.Dispose();
        }

        private void issuesModifyToolStripMenuItem_Click(object sender, System.EventArgs e)
        {
            IssueSelect select = new IssueSelect(_CurrentAppUser, selected_id);
            select.ShowDialog();
            if (select.DialogResult == DialogResult.OK)
            {
                FormModifyIssue form = new FormModifyIssue(select.selectedIssueID, selected_id);
                form.ShowDialog();
                form.Dispose();
            }
            select.Dispose();
        }

        private void issuesRemoveToolStripMenuItem_Click(object sender, System.EventArgs e)
        {
            IssueSelect select = new IssueSelect(_CurrentAppUser, selected_id);
            select.ShowDialog();
            if (select.DialogResult == DialogResult.OK)
            {
                Issue tmp = fakeIssueRepository.GetIssueByID(select.selectedIssueID);
                string del = "Are you sure you want to delete " + tmp.Title;
                DialogResult dialogResult = MessageBox.Show(del, "Confirmation", MessageBoxButtons.YesNo);
                if (dialogResult == DialogResult.Yes)
                {
                    fakeIssueRepository.Remove(tmp);
                }
                else if (dialogResult == DialogResult.No)
                {
                    MessageBox.Show("Delete cancelled", "Attention");
                }
            }
            select.Dispose();
        }

        private void createToolStripMenuItem_Click(object sender, System.EventArgs e)
        {
            FormCreateFeature form = new FormCreateFeature(selected_id);
            form.ShowDialog();
            form.Dispose();
        }

        private void modifyToolStripMenuItem1_Click(object sender, System.EventArgs e)
        {
            FormSelectRequirement formSelectRequirement = new FormSelectRequirement(selected_id);
            formSelectRequirement.ShowDialog();
            if (formSelectRequirement.DialogResult == DialogResult.OK)
            {
                FormRequirementModify formRequirementModify = new FormRequirementModify(selected_id,formSelectRequirement.selectedRequirementID);
                formRequirementModify.ShowDialog();
                formRequirementModify.Dispose();
            }
        }

        private void modifyToolStripMenuItem_Click(object sender, System.EventArgs e)
        {
            FormSelectFeature formSelect = new FormSelectFeature(selected_id);
            formSelect.ShowDialog();
            if (formSelect.DialogResult == DialogResult.OK)
            {
                FormModifyFeature formModify = new FormModifyFeature(selected_id, formSelect.selectedFeatureID);
                formModify.ShowDialog();
                formModify.Dispose();
            }
        }

        private void removeToolStripMenuItem_Click(object sender, System.EventArgs e)
        {
            FormSelectFeature formSelect = new FormSelectFeature(selected_id);
            FakeFeatureRepository fakeFeatureRepository = new FakeFeatureRepository(selected_id);
            FakeRequiremnetRepository fakeRequiremnetRepository = new FakeRequiremnetRepository(selected_id);   
            formSelect.ShowDialog();
            if (formSelect.DialogResult == DialogResult.OK)
            {
                Feature tmp = fakeFeatureRepository.GetFeatureByID(formSelect.selectedFeatureID);
                int count = fakeRequiremnetRepository.CountByFeatureID(formSelect.selectedFeatureID);
                string del = "Are you sure you want to delete " + tmp.Title;
                string associated = "There are one or more requirements associated with this feature. These requirements will be destroyed if you remove this feature. Are you sure you want to remove" + tmp.Title + "?";
                DialogResult dialogResult = MessageBox.Show(del, "Confirmation", MessageBoxButtons.YesNo);
                if (dialogResult == DialogResult.Yes)
                {
                    if (count > 0)
                    {
                        DialogResult dialogResult2 = MessageBox.Show(associated, "Confirmation", MessageBoxButtons.YesNo);
                        if (dialogResult2 == DialogResult.Yes)
                        {
                            fakeFeatureRepository.Remove(tmp);
                            fakeRequiremnetRepository.RemoveByFeatureID(tmp.Id);

                        }
                        else
                        {
                            MessageBox.Show("Delete cancelled", "Attention");
                        }
                        
                    }
                    
                }
                else if (dialogResult == DialogResult.No)
                {
                    MessageBox.Show("Delete cancelled", "Attention");
                }
            }
            formSelect.Dispose();
        }

        private void removeToolStripMenuItem1_Click(object sender, System.EventArgs e)
        {
            FormSelectRequirement form = new FormSelectRequirement(selected_id);
            FakeFeatureRepository fakeFeatureRepository = new FakeFeatureRepository(selected_id);
            FakeRequiremnetRepository fakeRequiremnetRepository = new FakeRequiremnetRepository(selected_id);
            form.ShowDialog();
            Requirement r = fakeRequiremnetRepository.GetRequirementByID(form.selectedRequirementID);
            string del = "Are you sure you want to delete " + r.Statement + " ?";
            DialogResult dialogResult = MessageBox.Show(del, "Confirmation", MessageBoxButtons.YesNo);
            if (form.DialogResult == DialogResult.OK)
            {              
                fakeRequiremnetRepository.Remove(r);
            }
        }
        private void createToolStripMenuItem1_Click(object sender, System.EventArgs e)
        {
            FormCreateRequirement form = new FormCreateRequirement(selected_id);
            form.ShowDialog();
            form.Dispose();
        }

    }
}
