using System;
using System.IO;
using System.Threading.Tasks;

namespace AsyncFileOWinForm
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
            this.lblSource = new System.Windows.Forms.Label();
            this.lblTarget = new System.Windows.Forms.Label();
            this.txtSource = new System.Windows.Forms.TextBox();
            this.txtTarget = new System.Windows.Forms.TextBox();
            this.btnFindTarget = new System.Windows.Forms.Button();
            this.btnAsyncCopy = new System.Windows.Forms.Button();
            this.btnSyncCopy = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.pbCopy = new System.Windows.Forms.ProgressBar();
            this.test = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // lblSource
            // 
            this.lblSource.AutoSize = true;
            this.lblSource.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.lblSource.Location = new System.Drawing.Point(91, 99);
            this.lblSource.Name = "lblSource";
            this.lblSource.Size = new System.Drawing.Size(45, 12);
            this.lblSource.TabIndex = 0;
            this.lblSource.Text = "Source";
            // 
            // lblTarget
            // 
            this.lblTarget.AutoSize = true;
            this.lblTarget.Location = new System.Drawing.Point(91, 162);
            this.lblTarget.Name = "lblTarget";
            this.lblTarget.Size = new System.Drawing.Size(41, 12);
            this.lblTarget.TabIndex = 1;
            this.lblTarget.Text = "Target";
            // 
            // txtSource
            // 
            this.txtSource.Location = new System.Drawing.Point(168, 100);
            this.txtSource.Name = "txtSource";
            this.txtSource.Size = new System.Drawing.Size(412, 21);
            this.txtSource.TabIndex = 11;
            // 
            // txtTarget
            // 
            this.txtTarget.Location = new System.Drawing.Point(168, 154);
            this.txtTarget.Name = "txtTarget";
            this.txtTarget.Size = new System.Drawing.Size(412, 21);
            this.txtTarget.TabIndex = 10;
            // 
            // btnFindTarget
            // 
            this.btnFindTarget.Location = new System.Drawing.Point(598, 153);
            this.btnFindTarget.Name = "btnFindTarget";
            this.btnFindTarget.Size = new System.Drawing.Size(55, 22);
            this.btnFindTarget.TabIndex = 8;
            this.btnFindTarget.Text = "...";
            this.btnFindTarget.UseVisualStyleBackColor = true;
            this.btnFindTarget.Click += new System.EventHandler(this.btnFindTarget_Click);
            // 
            // btnAsyncCopy
            // 
            this.btnAsyncCopy.Location = new System.Drawing.Point(168, 212);
            this.btnAsyncCopy.Name = "btnAsyncCopy";
            this.btnAsyncCopy.Size = new System.Drawing.Size(126, 35);
            this.btnAsyncCopy.TabIndex = 2;
            this.btnAsyncCopy.Text = "Async Copy";
            this.btnAsyncCopy.UseVisualStyleBackColor = true;
            this.btnAsyncCopy.Click += new System.EventHandler(this.btnAsyncCopy_Click);
            // 
            // btnSyncCopy
            // 
            this.btnSyncCopy.Location = new System.Drawing.Point(348, 212);
            this.btnSyncCopy.Name = "btnSyncCopy";
            this.btnSyncCopy.Size = new System.Drawing.Size(126, 35);
            this.btnSyncCopy.TabIndex = 3;
            this.btnSyncCopy.Text = "Sync Copy";
            this.btnSyncCopy.UseVisualStyleBackColor = true;
            this.btnSyncCopy.Click += new System.EventHandler(this.btnSyncCopy_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.Location = new System.Drawing.Point(527, 212);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(126, 35);
            this.btnCancel.TabIndex = 4;
            this.btnCancel.Text = "Cancel";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // pbCopy
            // 
            this.pbCopy.Location = new System.Drawing.Point(168, 271);
            this.pbCopy.Name = "pbCopy";
            this.pbCopy.Size = new System.Drawing.Size(485, 41);
            this.pbCopy.TabIndex = 5;
            // 
            // test
            // 
            this.test.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.test.Location = new System.Drawing.Point(598, 100);
            this.test.Name = "test";
            this.test.Size = new System.Drawing.Size(55, 22);
            this.test.TabIndex = 12;
            this.test.Text = "...";
            this.test.UseVisualStyleBackColor = true;
            this.test.Click += new System.EventHandler(this.test_Click);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.test);
            this.Controls.Add(this.lblTarget);
            this.Controls.Add(this.lblSource);
            this.Controls.Add(this.txtTarget);
            this.Controls.Add(this.txtSource);
            this.Controls.Add(this.btnFindTarget);
            this.Controls.Add(this.btnAsyncCopy);
            this.Controls.Add(this.btnSyncCopy);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.pbCopy);
            this.Name = "MainForm";
            this.Text = "Async File Copy";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblSource;
        private System.Windows.Forms.Label lblTarget;
        private System.Windows.Forms.TextBox txtSource;
        private System.Windows.Forms.TextBox txtTarget;
        private System.Windows.Forms.Button btnFindTarget;
        private System.Windows.Forms.Button btnAsyncCopy;
        private System.Windows.Forms.Button btnSyncCopy;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.ProgressBar pbCopy;
        private System.Windows.Forms.Button test;
    }
}

