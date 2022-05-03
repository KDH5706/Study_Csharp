
namespace UsingControls
{
    partial class MainForm
    {
        /// <summary>
        /// 필수 디자이너 변수입니다.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 사용 중인 모든 리소스를 정리합니다.
        /// </summary>
        /// <param name="disposing">관리되는 리소스를 삭제해야 하면 true이고, 그렇지 않으면 false입니다.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form 디자이너에서 생성한 코드

        /// <summary>
        /// 디자이너 지원에 필요한 메서드입니다. 
        /// 이 메서드의 내용을 코드 편집기로 수정하지 마세요.
        /// </summary>
        private void InitializeComponent()
        {
            this.lblFont = new System.Windows.Forms.Label();
            this.txtSampleText = new System.Windows.Forms.TextBox();
            this.cboFont = new System.Windows.Forms.ComboBox();
            this.chkBold = new System.Windows.Forms.CheckBox();
            this.chkltalic = new System.Windows.Forms.CheckBox();
            this.grpFont = new System.Windows.Forms.GroupBox();
            this.grpBar = new System.Windows.Forms.GroupBox();
            this.pgDummy = new System.Windows.Forms.ProgressBar();
            this.tbDummy = new System.Windows.Forms.TrackBar();
            this.btnModal = new System.Windows.Forms.Button();
            this.btnModaless = new System.Windows.Forms.Button();
            this.btbMsgBox = new System.Windows.Forms.Button();
            this.grpForm = new System.Windows.Forms.GroupBox();
            this.grpTreeList = new System.Windows.Forms.GroupBox();
            this.tvDummy = new System.Windows.Forms.TreeView();
            this.lvDummy = new System.Windows.Forms.ListView();
            this.btnAddRoot = new System.Windows.Forms.Button();
            this.btnAddChild = new System.Windows.Forms.Button();
            this.grpFont.SuspendLayout();
            this.grpBar.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.tbDummy)).BeginInit();
            this.grpForm.SuspendLayout();
            this.grpTreeList.SuspendLayout();
            this.SuspendLayout();
            // 
            // lblFont
            // 
            this.lblFont.AutoSize = true;
            this.lblFont.Location = new System.Drawing.Point(19, 40);
            this.lblFont.Name = "lblFont";
            this.lblFont.Size = new System.Drawing.Size(29, 12);
            this.lblFont.TabIndex = 0;
            this.lblFont.Text = "Font";
            this.lblFont.Click += new System.EventHandler(this.lblFont_Click);
            // 
            // txtSampleText
            // 
            this.txtSampleText.Location = new System.Drawing.Point(21, 83);
            this.txtSampleText.Name = "txtSampleText";
            this.txtSampleText.Size = new System.Drawing.Size(353, 21);
            this.txtSampleText.TabIndex = 1;
            this.txtSampleText.Text = "Hello, C#";
            this.txtSampleText.TextChanged += new System.EventHandler(this.txtSampleText_TextChanged);
            // 
            // cboFont
            // 
            this.cboFont.FormattingEnabled = true;
            this.cboFont.Location = new System.Drawing.Point(54, 37);
            this.cboFont.Name = "cboFont";
            this.cboFont.Size = new System.Drawing.Size(197, 20);
            this.cboFont.TabIndex = 2;
            this.cboFont.SelectedIndexChanged += new System.EventHandler(this.cboFont_SelectedIndexChanged);
            // 
            // chkBold
            // 
            this.chkBold.AutoSize = true;
            this.chkBold.Font = new System.Drawing.Font("굴림", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.chkBold.Location = new System.Drawing.Point(260, 41);
            this.chkBold.Name = "chkBold";
            this.chkBold.Size = new System.Drawing.Size(50, 16);
            this.chkBold.TabIndex = 3;
            this.chkBold.Text = "굵게";
            this.chkBold.UseVisualStyleBackColor = true;
            this.chkBold.CheckedChanged += new System.EventHandler(this.chkBold_CheckedChanged);
            // 
            // chkltalic
            // 
            this.chkltalic.AutoSize = true;
            this.chkltalic.Font = new System.Drawing.Font("굴림", 9F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.chkltalic.Location = new System.Drawing.Point(314, 41);
            this.chkltalic.Name = "chkltalic";
            this.chkltalic.Size = new System.Drawing.Size(60, 16);
            this.chkltalic.TabIndex = 4;
            this.chkltalic.Text = "이탤릭";
            this.chkltalic.UseVisualStyleBackColor = true;
            this.chkltalic.CheckedChanged += new System.EventHandler(this.chkItalic_CheckedChanged);
            // 
            // grpFont
            // 
            this.grpFont.Controls.Add(this.chkltalic);
            this.grpFont.Controls.Add(this.txtSampleText);
            this.grpFont.Controls.Add(this.cboFont);
            this.grpFont.Controls.Add(this.chkBold);
            this.grpFont.Controls.Add(this.lblFont);
            this.grpFont.Location = new System.Drawing.Point(22, 24);
            this.grpFont.Name = "grpFont";
            this.grpFont.Size = new System.Drawing.Size(398, 152);
            this.grpFont.TabIndex = 5;
            this.grpFont.TabStop = false;
            this.grpFont.Text = "ComboBox, CheckBox, TextBox";
            // 
            // grpBar
            // 
            this.grpBar.Controls.Add(this.pgDummy);
            this.grpBar.Controls.Add(this.tbDummy);
            this.grpBar.Location = new System.Drawing.Point(22, 191);
            this.grpBar.Name = "grpBar";
            this.grpBar.Size = new System.Drawing.Size(398, 147);
            this.grpBar.TabIndex = 6;
            this.grpBar.TabStop = false;
            this.grpBar.Text = "TrackBar & ProgressBar";
            // 
            // pgDummy
            // 
            this.pgDummy.Location = new System.Drawing.Point(21, 96);
            this.pgDummy.Maximum = 20;
            this.pgDummy.Name = "pgDummy";
            this.pgDummy.Size = new System.Drawing.Size(353, 30);
            this.pgDummy.TabIndex = 1;
            this.pgDummy.Click += new System.EventHandler(this.pgDummy_Click);
            // 
            // tbDummy
            // 
            this.tbDummy.Location = new System.Drawing.Point(21, 35);
            this.tbDummy.Maximum = 20;
            this.tbDummy.Name = "tbDummy";
            this.tbDummy.Size = new System.Drawing.Size(353, 45);
            this.tbDummy.TabIndex = 0;
            this.tbDummy.Scroll += new System.EventHandler(this.tbDummy_Scroll);
            // 
            // btnModal
            // 
            this.btnModal.Location = new System.Drawing.Point(19, 32);
            this.btnModal.Name = "btnModal";
            this.btnModal.Size = new System.Drawing.Size(79, 33);
            this.btnModal.TabIndex = 7;
            this.btnModal.Text = "Modal";
            this.btnModal.UseVisualStyleBackColor = true;
            this.btnModal.Click += new System.EventHandler(this.btnModal_Click);
            // 
            // btnModaless
            // 
            this.btnModaless.Location = new System.Drawing.Point(113, 32);
            this.btnModaless.Name = "btnModaless";
            this.btnModaless.Size = new System.Drawing.Size(77, 33);
            this.btnModaless.TabIndex = 8;
            this.btnModaless.Text = "Modaless";
            this.btnModaless.UseVisualStyleBackColor = true;
            this.btnModaless.Click += new System.EventHandler(this.btnModaless_Click);
            // 
            // btbMsgBox
            // 
            this.btbMsgBox.Location = new System.Drawing.Point(205, 32);
            this.btbMsgBox.Name = "btbMsgBox";
            this.btbMsgBox.Size = new System.Drawing.Size(169, 33);
            this.btbMsgBox.TabIndex = 9;
            this.btbMsgBox.Text = "MessageBox";
            this.btbMsgBox.UseVisualStyleBackColor = true;
            this.btbMsgBox.Click += new System.EventHandler(this.btbMsgBox_Click);
            // 
            // grpForm
            // 
            this.grpForm.Controls.Add(this.btbMsgBox);
            this.grpForm.Controls.Add(this.btnModaless);
            this.grpForm.Controls.Add(this.btnModal);
            this.grpForm.Location = new System.Drawing.Point(22, 359);
            this.grpForm.Name = "grpForm";
            this.grpForm.Size = new System.Drawing.Size(398, 81);
            this.grpForm.TabIndex = 10;
            this.grpForm.TabStop = false;
            this.grpForm.Text = "Modal&&Modaless";
            // 
            // grpTreeList
            // 
            this.grpTreeList.Controls.Add(this.btnAddChild);
            this.grpTreeList.Controls.Add(this.btnAddRoot);
            this.grpTreeList.Controls.Add(this.lvDummy);
            this.grpTreeList.Controls.Add(this.tvDummy);
            this.grpTreeList.Location = new System.Drawing.Point(22, 462);
            this.grpTreeList.Name = "grpTreeList";
            this.grpTreeList.Size = new System.Drawing.Size(398, 256);
            this.grpTreeList.TabIndex = 11;
            this.grpTreeList.TabStop = false;
            this.grpTreeList.Text = "TreeView&&ListView";
            // 
            // tvDummy
            // 
            this.tvDummy.Location = new System.Drawing.Point(15, 44);
            this.tvDummy.Name = "tvDummy";
            this.tvDummy.Size = new System.Drawing.Size(177, 156);
            this.tvDummy.TabIndex = 0;
            this.tvDummy.AfterSelect += new System.Windows.Forms.TreeViewEventHandler(this.tvDummy_AfterSelect);
            // 
            // lvDummy
            // 
            this.lvDummy.HideSelection = false;
            this.lvDummy.Location = new System.Drawing.Point(207, 44);
            this.lvDummy.Name = "lvDummy";
            this.lvDummy.Size = new System.Drawing.Size(177, 156);
            this.lvDummy.TabIndex = 1;
            this.lvDummy.UseCompatibleStateImageBehavior = false;
            this.lvDummy.View = System.Windows.Forms.View.Details;
            this.lvDummy.SelectedIndexChanged += new System.EventHandler(this.lvDummy_SelectedIndexChanged);
            // 
            // btnAddRoot
            // 
            this.btnAddRoot.Location = new System.Drawing.Point(15, 209);
            this.btnAddRoot.Name = "btnAddRoot";
            this.btnAddRoot.Size = new System.Drawing.Size(83, 33);
            this.btnAddRoot.TabIndex = 10;
            this.btnAddRoot.Text = "루트 추가";
            this.btnAddRoot.UseVisualStyleBackColor = true;
            this.btnAddRoot.Click += new System.EventHandler(this.btnAddRoot_Click);
            // 
            // btnAddChild
            // 
            this.btnAddChild.Location = new System.Drawing.Point(109, 209);
            this.btnAddChild.Name = "btnAddChild";
            this.btnAddChild.Size = new System.Drawing.Size(83, 33);
            this.btnAddChild.TabIndex = 11;
            this.btnAddChild.Text = "자식 추가";
            this.btnAddChild.UseVisualStyleBackColor = true;
            this.btnAddChild.Click += new System.EventHandler(this.btnAddChild_Click);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(550, 784);
            this.Controls.Add(this.grpTreeList);
            this.Controls.Add(this.grpForm);
            this.Controls.Add(this.grpBar);
            this.Controls.Add(this.grpFont);
            this.Name = "MainForm";
            this.Text = "Control Test";
            this.Load += new System.EventHandler(this.MainForm_Load);
            this.grpFont.ResumeLayout(false);
            this.grpFont.PerformLayout();
            this.grpBar.ResumeLayout(false);
            this.grpBar.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.tbDummy)).EndInit();
            this.grpForm.ResumeLayout(false);
            this.grpTreeList.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label lblFont;
        private System.Windows.Forms.TextBox txtSampleText;
        private System.Windows.Forms.ComboBox cboFont;
        private System.Windows.Forms.CheckBox chkBold;
        private System.Windows.Forms.CheckBox chkltalic;
        private System.Windows.Forms.GroupBox grpFont;
        private System.Windows.Forms.GroupBox grpBar;
        private System.Windows.Forms.TrackBar tbDummy;
        private System.Windows.Forms.ProgressBar pgDummy;
        private System.Windows.Forms.Button btnModal;
        private System.Windows.Forms.Button btnModaless;
        private System.Windows.Forms.Button btbMsgBox;
        private System.Windows.Forms.GroupBox grpForm;
        private System.Windows.Forms.GroupBox grpTreeList;
        private System.Windows.Forms.Button btnAddChild;
        private System.Windows.Forms.Button btnAddRoot;
        private System.Windows.Forms.ListView lvDummy;
        private System.Windows.Forms.TreeView tvDummy;
    }
}

