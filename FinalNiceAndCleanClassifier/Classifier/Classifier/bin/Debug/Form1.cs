using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SelectionForm
{
    public partial class SelectionForm : Form
    {
        public List<string> SelectedItems = new List<string>();
        public List<int> SelectedInds = new List<int>();


        
        public SelectionForm(List<string> names, string Description, string Title, bool SelectAll)
        {
            InitializeComponent();
            if (names == null || names.Count == 0)
                return;

            // Set window title and description label
            this.Text = Title;
            DescriptionLabel.Text = Description;
            SelectAllCheckBox.Checked = SelectAll;

            // Setup listview
            for (int i = 0; i < names.Count; i++)
            {
                listView1.Items.Add(names[i]);
                listView1.Items[i].Checked = SelectAll;
            }
                
        }


        // OK button
        private void button1_Click(object sender, EventArgs e)
        {
            if (listView1.CheckedItems.Count == 0)
                return;

            SelectedItems = new List<string>();
            SelectedInds = new List<int>();
            for (int i = 0; i < listView1.CheckedItems.Count; i++)
            {
                SelectedInds.Add(i);
                SelectedItems.Add(listView1.CheckedItems[i].Text);
            }
            this.Close();
        }


        // Cancel button
        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void SelectAllCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            for (int i = 0; i < listView1.Items.Count; i++)
                listView1.Items[i].Checked = SelectAllCheckBox.Checked;
        }
    }
}
