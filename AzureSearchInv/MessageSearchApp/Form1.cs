using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MessageSearchApp.Utils;
using System.Diagnostics;

namespace MessageSearchApp {
    public partial class Form1 : Form {
        public Form1 () {
            InitializeComponent();
        }

        private void Form1_Load ( object sender, EventArgs e ) {
            
        }

        private void checkBoxFilter_CheckedChanged ( object sender, EventArgs e ) {
            dateTimeFrom.Enabled = dateTimeTo.Enabled = checkBoxFilter.Checked;
        }

        private void buttonSearch_Click ( object sender, EventArgs e ) {
            txtElapsedTime.Text = string.Empty;
            var oldCursor = Cursor.Current;
            Cursor.Current = Cursors.WaitCursor;
            dgvResults.DataSource = null;
            var dateFrom = dateTimeFrom.Value;
            var dateTo = dateTimeTo.Value;

            if ( !checkBoxFilter.Checked ) {
                dateFrom = DateTime.MinValue;
                dateTo = DateTime.MinValue;
            }
            Stopwatch watch = new Stopwatch();
            try {
                watch.Start();
                dgvResults.DataSource = MessageUtils.GetMessageModels( textMessageSearch.Text, dateFrom, dateTo, checkBoxOneParents.Checked );
            } catch ( Exception ex ) {
                MessageBox.Show(this, ex.Message, "Warning" );
            }
            finally {                
                watch.Stop();                
                txtElapsedTime.Text = watch.Elapsed.ToString();
                Cursor.Current = oldCursor;
            }
        }        
    }
}
