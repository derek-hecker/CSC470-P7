using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace P5
{
    public partial class IssueDashboard : Form
    {
        AppUser _currentAppUser;
        int _SelectedProjectId;
        public IssueDashboard(AppUser _CurrentAppUser, int selected_id)
        {
            _currentAppUser = _CurrentAppUser;
            _SelectedProjectId = selected_id;
            InitializeComponent();
        }

        private void IssueDashboard_Load(object sender, EventArgs e)
        {

        }
    }
}
