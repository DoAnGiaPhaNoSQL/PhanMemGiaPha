using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Nhom12_NoSQL
{
    public partial class RelationshipForm : Form
    {
        public RelationshipForm(string name)
        {
            InitializeComponent();
            this.txtName.Text = name;
        }

    }
}
