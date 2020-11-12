using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TextEditor
{
    public partial class frmOptions : Form
    {
        public frmOptions()
        {
            InitializeComponent();
        }

        private void frmOptions_Load(object sender, EventArgs e)
        {
            // Iezīmē ar saiti aktualizē rādāmo noklusēto fontu:
            RefreshDefaultFontLinkLabel();
        }

        private void RefreshDefaultFontLinkLabel()
        {
            if (Properties.Settings.Default.DefaultFont != null)
            {
                Font fontSetting = Properties.Settings.Default.DefaultFont;
                // Iezīmei ar saiti uzstāda rādāmo fontu un tā izmēru:
                lnkDefaultFont.Text
                = string.Format("{0} ({1})", fontSetting.Name, fontSetting.Size);
            }
        }

        private void lnkDefaultFont_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            if (DialogResult.OK == dlgFont.ShowDialog())
            {
                // Atceras dialogā izvēlēto fontu:
                Properties.Settings.Default.DefaultFont = dlgFont.Font;
                RefreshDefaultFontLinkLabel();
            }
        }

        private void txtDefaultFolder_Validating(object sender, CancelEventArgs e)
        {
            // noskaidro, vai izvēlētais katalogs eksistē
            e.Cancel = txtDefaultFolder.Text.Length > 0
            && !System.IO.Directory.Exists(txtDefaultFolder.Text);
            // Ja katalogs neeksistē, uzstāda teksta lauka kļūdas izcēlumu,
            // citādi atceļ lauka izcēlumu, gadījumam, ja tas bija uzstādīts.
            erpOptions.SetError(txtDefaultFolder
            , e.Cancel
            ? "Katalogam ir jābūt izveidotam un pieejamam."
           : "");
        }

        private void btnBrowse_Click(object sender, EventArgs e)
        {
            // vēlreiz pārbauda ievadīto vērtību pareizību
            if (!ValidateChildren(ValidationConstraints.Enabled))
            {
                // Šādi uzstādījumu dialoga logs netiks aizvērts:
                DialogResult = DialogResult.None;
            }
            else
            {
                // Uzstādījumu izmaiņu apstiprināšana:
                Properties.Settings.Default.Save();
                DialogResult = DialogResult.OK;
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            // Uzstādījumu izmaiņu atcelšana:
            Properties.Settings.Default.Reload();
        }
    }
}
