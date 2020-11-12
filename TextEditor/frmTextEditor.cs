using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TextEditor
{
    public partial class frmTextEditor : Form
    {

        /// <summary>
        /// Pazīme, ka teksts ir/nav saglabāts.
        /// </summary>
        private bool textSaved = true;
        /// <summary>
        /// Īpašība, kas kontrolē teksta izmainīšanas pazīmi un atbilstoši
        /// aktualizē formas statusa joslu.
        /// </summary>
        public bool Dirty
        {
            get { return !this.textSaved; }
            set
            {
                this.textSaved = !value;
                stlStatus.Text = !this.textSaved ? "Izmainīts." : "";
            }
        }
        /// <summary>
        /// Teksta redaktorā pašreiz ielādētā faila vārds.
        /// </summary>
        private string sFileName;
        private const string DefaultFileName = "jauns.txt";
        /// <summary>
        /// Teksta redaktorā pašreiz ielādētā faila vārda uzstādīšana un
        /// atgriešana.
        /// </summary>
        public string OpenedFileName
        {
            get { return sFileName.Length == 0 ? DefaultFileName : sFileName; }
            set
            {
                sFileName = ((string)value).Length > 0
          ? sFileName = value : DefaultFileName;
            }
        }
        /// <summary>
        /// Teksta redaktora formas loga virsraksta uzstādīšana, daļu
        /// informācijas iegūstot no lietojumprogrammas asamblejas atribūtiem.
        /// </summary>
        private void SetTitle(string sDocName)
        {
            object[] attributes
            = Assembly.GetExecutingAssembly().GetCustomAttributes(
            typeof(AssemblyProductAttribute), false);
            this.Text = String.Format("{0} - {1}"
            , ((AssemblyProductAttribute)attributes[0]).Product, sDocName);
        }
        /// <summary>
        /// Pazīme, ka teksts vēl ne reizi nav saglabāts.
        /// </summary>
        private bool bNewFile = true;
        /// <summary>
        /// Inicializē teksta redaktora formas loga un elementu īpašības jauna
        /// teksta sākšanas gadījumā.
        /// </summary>
        private void NewFile()
        {
            if (Dirty)
            {
                if (SaveFile(true))
                {
                    txtContent.Clear();
                    bNewFile = true;
                    Dirty = false;
                    sFileName = "";
                    SetTitle(OpenedFileName);
                }
            }
            else
            {
                txtContent.Clear();
                bNewFile = true;
                Dirty = false;
                sFileName = "";
                SetTitle(OpenedFileName);
            }
            txtContent.Font = Properties.Settings.Default.DefaultFont ?? txtContent.Font;
        }
        /// <summary>
        /// Failu apstrādes diagolu filtru konstante.
        /// </summary>
        private const string csFileDialogFilter =
        "Teksta faili|*.txt|Visi faili|*.*";
        /// <summary>
        /// Jauna faila kopijas saglabāšanas metode.
        /// Ja saglabāšana ir veiksmīga, atgriež true.
        /// </summary>
        public bool SaveFileAs()
        {
            dlgSaveFile.Title = "Saglabāt kā";
            dlgSaveFile.Filter = csFileDialogFilter;
            dlgSaveFile.InitialDirectory = Path.GetDirectoryName(OpenedFileName);
            dlgSaveFile.FileName = Path.GetFileName(OpenedFileName);
            // Faila saglabāšanas dialoga parādīšana un rezultāta pārbaude
            if (dlgSaveFile.ShowDialog() != DialogResult.OK)
                return false;
            OpenedFileName = dlgSaveFile.FileName;
            // Ievadītā teksta saglabāšana norādītajā failā
            File.WriteAllText(OpenedFileName, txtContent.Rtf);
            // Formas īpašību aktualizēšana
            bNewFile = Dirty = false;
            SetTitle(OpenedFileName);
            return true;
        }
        /// <summary>
        /// Esoša faila saglabāšanas metode.
        /// Ja parametrā norādīts true, tiek arī izvadīts apstiprinājuma dialogs.
        /// Ja saglabāšana ir veiksmīga, atgriež true.
        /// </summary>
        public bool SaveFile(bool bConfirm)
        {
            // Ja teksts nav mainīts, nekas nav jāsaglabā
            if (!Dirty)
                return true;
            if (bConfirm)
            {
                DialogResult result = MessageBox.Show("Vai saglabāt izmaiņas?"
                , "", MessageBoxButtons.YesNoCancel);
                if (result == DialogResult.No)
                {
                    return true;
                }
                else if (result == DialogResult.Cancel)
                {
                    return false;
                }
            }
            // Ja teksts tiek saglabāts pirmo reizi, tad izvada
            // faila saglabāšanas dialogu
            if (bNewFile)
            {

                if (!String.IsNullOrWhiteSpace(Properties.Settings.Default.DefaultFolder))
                {
                    dlgSaveFile.InitialDirectory = Properties.Settings.Default.DefaultFolder;
                }
                dlgSaveFile.Title = "Saglabāt";
                dlgSaveFile.Filter = csFileDialogFilter;
                dlgSaveFile.FileName = Path.GetFileName(OpenedFileName);
                if (dlgSaveFile.ShowDialog() != DialogResult.OK)
                    return false;
                OpenedFileName = dlgSaveFile.FileName;
                bNewFile = false;
            }
            // Teksta saglabāšana failā
            File.WriteAllText(OpenedFileName, txtContent.Rtf);
            // Formas īpašību aktualizēšana
            Dirty = false;
            SetTitle(OpenedFileName);
            return true;
        }
        /// <summary>
        /// Esoša faila satura ielādēšanas metode.
        /// </summary>
        private void LoadFile()
        {
            // Ja nepieciešams, vispirms saglabā jau atvērto failu
            if (!SaveFile(true))
                return;
            dlgOpenFile.FileName = "";
            dlgOpenFile.Title = "Atvērt";
            dlgOpenFile.Filter = csFileDialogFilter;
            if (dlgOpenFile.ShowDialog() != DialogResult.OK)
                return;
            if (!File.Exists(dlgOpenFile.FileName))
                return;
            // Teksta ielādēšana no faila

            //Brute RTF and plain text loading

            try
            {
                txtContent.Rtf = File.ReadAllText(dlgOpenFile.FileName);
            }
            catch
            {
                txtContent.Text = File.ReadAllText(dlgOpenFile.FileName);

                this.txtContent.SelectAll();

                if (this.txtContent.SelectionFont.Bold)
                    this.txtContent.SelectionFont = new Font(this.txtContent.SelectionFont, this.txtContent.SelectionFont.Style & ~FontStyle.Bold);

                if (this.txtContent.SelectionFont.Italic)
                    this.txtContent.SelectionFont = new Font(this.txtContent.SelectionFont, this.txtContent.SelectionFont.Style & ~FontStyle.Italic);

                if (this.txtContent.SelectionFont.Underline)
                    this.txtContent.SelectionFont = new Font(this.txtContent.SelectionFont, this.txtContent.SelectionFont.Style & ~FontStyle.Underline);

                this.txtContent.Focus();

                this.txtContent.Select(0, 0);

            }


            // Formas īpašību aktualizēšana
            OpenedFileName = dlgOpenFile.FileName;
            bNewFile = Dirty = false;
            SetTitle(OpenedFileName);
        }

        public frmTextEditor()
        {
            InitializeComponent();
            // Būtiski, lai šī metode tiktu izsaukta pēc InitializeComponent()!
            NewFile();

        }

        private void txtContent_TextChanged(object sender, EventArgs e)
        {
            // Tiklīdz teksts tiek izmainīts, aktualizē īpašību:
            Dirty = true;
        }

        private void mnuNew_Click(object sender, EventArgs e)
        {
            try
            {
                NewFile();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void mnuOpen_Click(object sender, EventArgs e)
        {
            try
            {
                LoadFile();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void mnuSave_Click(object sender, EventArgs e)
        {

            try
            {
                SaveFile(false);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void mnuSaveAs_Click(object sender, EventArgs e)
        {
            try
            {
                SaveFileAs();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void mnuExit_Click(object sender, EventArgs e)
        {
            try
            {
                Application.Exit();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void mnuCopy_Click(object sender, EventArgs e)
        {
            try
            {
                if (txtContent.SelectionLength > 0)
                {
                    txtContent.Copy();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void mnuCut_Click(object sender, EventArgs e)
        {
            try
            {
                if (txtContent.SelectionLength > 0)
                {
                    txtContent.Cut();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void mnuPaste_Click(object sender, EventArgs e)
        {
            try
            {
                if (Clipboard.GetDataObject().GetDataPresent(DataFormats.Text) == true)
                {
                    txtContent.Paste();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void mnuSelectFont_Click(object sender, EventArgs e)
        {
            try
            {
                dlgFont.Font = txtContent.Font;
                if (dlgFont.ShowDialog() == DialogResult.OK)
                    txtContent.Font = dlgFont.Font;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void mnuAbout_Click(object sender, EventArgs e)
        {
            try
            {
                (new frmAboutTextEditor()).ShowDialog();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void mnuPrint_Click(object sender, EventArgs e)
        {
            string strText = this.txtContent.Text;
            myReader = new StringReader(strText);
            dlgPrintDocument.DocumentName = this.Text;
            dlgPrint.Document = dlgPrintDocument;
            DialogResult result = dlgPrint.ShowDialog();
            if (result != DialogResult.OK)
                return;
            // Dokumenta priekšapskates dialoga atvēršana
            dlgPrintPreview.Document = dlgPrintDocument;
            dlgPrintPreview.ShowDialog();

        }

        // īslaicīga teksta saglabāšana drukāšanas procesa atbalstam
        private string sTextToPrint;
        private StringReader myReader;

        /*
        private void dlgPrintDocument_PrintPage(object sender, System.Drawing.Printing.PrintPageEventArgs e)
        {
            // Nosaka, cik rakstzīmes un teksta rindas ietilpst tekošajā
            // lappusē:
            int nSymbols = 0;
            int nLines = 0;
            e.Graphics.MeasureString(this.sTextToPrint, txtContent.Font,
            e.MarginBounds.Size, StringFormat.GenericTypographic,
            out nSymbols, out nLines);
            // Izvada tekstu uz drukājamās lappuses:
            e.Graphics.DrawString(this.sTextToPrint
            , txtContent.Font, Brushes.Black
            , e.MarginBounds
           , StringFormat.GenericTypographic);
            // Aktualizē vēl drukājamo tekstu:
            this.sTextToPrint = this.sTextToPrint.Substring(nSymbols);
            e.HasMorePages = (this.sTextToPrint.Length > 0);
            if (!e.HasMorePages)
                this.sTextToPrint = txtContent.Text;

        }
        */
        private void dlgPrintDocument_PrintPage(object sender, System.Drawing.Printing.PrintPageEventArgs e)
        {
            float linesPerPage = 0;
            float yPosition = 0;
            int count = 0;
            float leftMargin = e.MarginBounds.Left;
            float topMargin = e.MarginBounds.Top;
            string line = null;
            Font printFont = this.txtContent.Font;
            this.txtContent.SelectAll();
            Font printFont2 = this.txtContent.SelectionFont;
            SolidBrush myBrush = new SolidBrush(Color.Black);
            // Work out the number of lines per page, using the MarginBounds.  
            linesPerPage = e.MarginBounds.Height / printFont.GetHeight(e.Graphics);
            // Iterate over the string using the StringReader, printing each line.  
            while (count < linesPerPage && ((line = myReader.ReadLine()) != null))
            {
                // calculate the next line position based on the height of the font according to the printing device  
                yPosition = topMargin + (count * printFont.GetHeight(e.Graphics));
                // draw the next line in the rich edit control  
                e.Graphics.DrawString(line, printFont, myBrush, leftMargin, yPosition, new StringFormat());
                count++;
            }
            // If there are more lines, print another page.  
            if (line != null)
                e.HasMorePages = true;
            else
                e.HasMorePages = false;
            myBrush.Dispose();

        }
        private void frmTextEditor_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (Dirty)
            {
                DialogResult formCloseDialogResult = MessageBox.Show("Jūsu veiktās izmaiņas nav saglabātas. Vai saglabāt izmaiņas?"
                , "", MessageBoxButtons.YesNoCancel);
                if (formCloseDialogResult == DialogResult.Yes)
                {
                    SaveFile(false);
                }
                else if (formCloseDialogResult == DialogResult.Cancel)
                {
                    e.Cancel = true;
                }
            }
            if (!bNewFile)
            {
                Properties.Settings.Default.LastFileName = OpenedFileName;
            }
            Properties.Settings.Default.EditorLocation = this.Location;
            Properties.Settings.Default.EditorSize = this.Size;
            Properties.Settings.Default.Save();
        }


        private void mnuPrintPreview_Click(object sender, EventArgs e)
        {
            try
            {
                string strText = this.txtContent.Text; // read string from editor window  
                myReader = new StringReader(strText);
                dlgPrintPreview.Document = this.dlgPrintDocument;
                dlgPrintPreview.ShowDialog(); // Show the print preview dialog, uses print page event to draw preview screen  
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

        }

        private void mnuUndo_Click(object sender, EventArgs e)
        {
            try
            {
                // Determine if last operation can be undone in text box.   
                if (txtContent.CanUndo == true)
                {
                    // Undo the last operation.
                    txtContent.Undo();
                    // Clear the undo buffer to prevent last action from being redone.
                    txtContent.ClearUndo();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }


        private void mnuItalic_Click(object sender, EventArgs e)
        {
            Font oldFont;
            Font newFont;

            // Get the font that is being used in the selected text
            oldFont = this.txtContent.SelectionFont;

            // If the font is using Italic style now, we should remove it
            if (oldFont.Italic)
                newFont = new Font(oldFont, oldFont.Style & ~FontStyle.Italic);
            else
                newFont = new Font(oldFont, oldFont.Style | FontStyle.Italic);

            // Insert the new font
            this.txtContent.SelectionFont = newFont;
            this.txtContent.Focus();
        }

        private void mnuBold_Click(object sender, EventArgs e)
        {
            Font oldFont;
            Font newFont;

            // Get the font that is being used in the selected text
            oldFont = this.txtContent.SelectionFont;

            // If the font is using bold style now, we should remove the
            // Formatting
            if (oldFont.Bold)
                newFont = new Font(oldFont, oldFont.Style & ~FontStyle.Bold);
            else
                newFont = new Font(oldFont, oldFont.Style | FontStyle.Bold);

            // Insert the new font and return focus to the RichTextBox
            this.txtContent.SelectionFont = newFont;
            this.txtContent.Focus();
        }

        private void mnuUnderline_Click(object sender, EventArgs e)
        {
            Font oldFont;
            Font newFont;
            // Get the font that is being used in the selected text
            oldFont = this.txtContent.SelectionFont;

            // If the font is using Underline style now, we should remove it
            if (oldFont.Underline)
                newFont = new Font(oldFont, oldFont.Style & ~FontStyle.Underline);
            else
                newFont = new Font(oldFont, oldFont.Style | FontStyle.Underline);

            // Insert the new font
            this.txtContent.SelectionFont = newFont;
            this.txtContent.Focus();
        }

        private void mnuOptions_Click(object sender, EventArgs e)
        {
            (new frmOptions()).ShowDialog();
        }

        private void frmTextEditor_Load(object sender, EventArgs e)
        {
            this.Size = Properties.Settings.Default.EditorSize;
            this.Location = Properties.Settings.Default.EditorLocation;
            if (Properties.Settings.Default.ReloadLastDocument && !String.IsNullOrWhiteSpace(Properties.Settings.Default.LastFileName))
            {
                try
                {
                    txtContent.Rtf = File.ReadAllText(Properties.Settings.Default.LastFileName);
                }
                catch
                {
                    txtContent.Text = File.ReadAllText(Properties.Settings.Default.LastFileName);

                    this.txtContent.SelectAll();

                    if (this.txtContent.SelectionFont.Bold)
                        this.txtContent.SelectionFont = new Font(this.txtContent.SelectionFont, this.txtContent.SelectionFont.Style & ~FontStyle.Bold);

                    if (this.txtContent.SelectionFont.Italic)
                        this.txtContent.SelectionFont = new Font(this.txtContent.SelectionFont, this.txtContent.SelectionFont.Style & ~FontStyle.Italic);

                    if (this.txtContent.SelectionFont.Underline)
                        this.txtContent.SelectionFont = new Font(this.txtContent.SelectionFont, this.txtContent.SelectionFont.Style & ~FontStyle.Underline);

                    this.txtContent.Focus();

                    this.txtContent.Select(0, 0);

                }
                // Formas īpašību aktualizēšana
                OpenedFileName = Properties.Settings.Default.LastFileName;
                bNewFile = Dirty = false;
                SetTitle(OpenedFileName);
            }
            // Reģistrē dīkstāves notikuma anonīmo metodi:
            Application.Idle += delegate (object sender2, EventArgs e1)
            {
                // katrai iesaistītajai kontrolei uzstāda īpašību Enabled uz
                // true vai false, atkarībā no tā, vai tā dotajā brīdī ir izpildāma
                mnuCopy.Enabled = txtContent.SelectionLength > 0;
                copyToolStripButton.Enabled = mnuCut.Enabled;
                mnuCut.Enabled = mnuCopy.Enabled;
                cutToolStripButton.Enabled = mnuCopy.Enabled;
                mnuPaste.Enabled = true == Clipboard.GetDataObject().GetDataPresent(DataFormats.Text);
                pasteToolStripButton.Enabled = mnuPaste.Enabled;
            };
        }

    }
}
