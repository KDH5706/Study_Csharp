
namespace WindowsFormsApp1
{
    partial class Form1
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
            this.components = new System.ComponentModel.Container();
            this.listView1 = new System.Windows.Forms.ListView();
            this.Colum_Num = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.Colum_Name = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.Colum_Year = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.Colum_Price = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.Colum_Door = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.cmsMenu = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.삭제ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.lblName = new System.Windows.Forms.Label();
            this.lblYear = new System.Windows.Forms.Label();
            this.lblPrice = new System.Windows.Forms.Label();
            this.lblDoor = new System.Windows.Forms.Label();
            this.txtName = new System.Windows.Forms.TextBox();
            this.txtYear = new System.Windows.Forms.TextBox();
            this.txtPrice = new System.Windows.Forms.TextBox();
            this.txtDoor = new System.Windows.Forms.TextBox();
            this.btnSave = new System.Windows.Forms.Button();
            this.btnModify = new System.Windows.Forms.Button();
            this.btnConSearch = new System.Windows.Forms.Button();
            this.btnTotalSearch = new System.Windows.Forms.Button();
            this.cmsMenu.SuspendLayout();
            this.SuspendLayout();
            // 
            // listView1
            // 
            this.listView1.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.Colum_Num,
            this.Colum_Name,
            this.Colum_Year,
            this.Colum_Price,
            this.Colum_Door});
            this.listView1.ContextMenuStrip = this.cmsMenu;
            this.listView1.FullRowSelect = true;
            this.listView1.GridLines = true;
            this.listView1.HideSelection = false;
            this.listView1.Location = new System.Drawing.Point(12, 12);
            this.listView1.Name = "listView1";
            this.listView1.Size = new System.Drawing.Size(384, 180);
            this.listView1.TabIndex = 0;
            this.listView1.UseCompatibleStateImageBehavior = false;
            this.listView1.View = System.Windows.Forms.View.Details;
            this.listView1.SelectedIndexChanged += new System.EventHandler(this.listView1_SelectedIndexChanged);
            // 
            // Colum_Num
            // 
            this.Colum_Num.Text = "번 호";
            this.Colum_Num.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.Colum_Num.Width = 50;
            // 
            // Colum_Name
            // 
            this.Colum_Name.Text = "이 름";
            this.Colum_Name.Width = 57;
            // 
            // Colum_Year
            // 
            this.Colum_Year.Text = "년 식";
            this.Colum_Year.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.Colum_Year.Width = 81;
            // 
            // Colum_Price
            // 
            this.Colum_Price.Text = "가 격";
            this.Colum_Price.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.Colum_Price.Width = 105;
            // 
            // Colum_Door
            // 
            this.Colum_Door.Text = "도 어";
            this.Colum_Door.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.Colum_Door.Width = 100;
            // 
            // cmsMenu
            // 
            this.cmsMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.삭제ToolStripMenuItem});
            this.cmsMenu.Name = "contextMenuStrip1";
            this.cmsMenu.Size = new System.Drawing.Size(99, 26);
            // 
            // 삭제ToolStripMenuItem
            // 
            this.삭제ToolStripMenuItem.Name = "삭제ToolStripMenuItem";
            this.삭제ToolStripMenuItem.Size = new System.Drawing.Size(98, 22);
            this.삭제ToolStripMenuItem.Text = "삭제";
            this.삭제ToolStripMenuItem.Click += new System.EventHandler(this.삭제ToolStripMenuItem_Click);
            // 
            // lblName
            // 
            this.lblName.AutoSize = true;
            this.lblName.Location = new System.Drawing.Point(12, 209);
            this.lblName.Name = "lblName";
            this.lblName.Size = new System.Drawing.Size(29, 12);
            this.lblName.TabIndex = 1;
            this.lblName.Text = "이름";
            // 
            // lblYear
            // 
            this.lblYear.AutoSize = true;
            this.lblYear.Location = new System.Drawing.Point(12, 242);
            this.lblYear.Name = "lblYear";
            this.lblYear.Size = new System.Drawing.Size(29, 12);
            this.lblYear.TabIndex = 2;
            this.lblYear.Text = "년식";
            // 
            // lblPrice
            // 
            this.lblPrice.AutoSize = true;
            this.lblPrice.Location = new System.Drawing.Point(12, 275);
            this.lblPrice.Name = "lblPrice";
            this.lblPrice.Size = new System.Drawing.Size(29, 12);
            this.lblPrice.TabIndex = 3;
            this.lblPrice.Text = "가격";
            // 
            // lblDoor
            // 
            this.lblDoor.AutoSize = true;
            this.lblDoor.Location = new System.Drawing.Point(12, 308);
            this.lblDoor.Name = "lblDoor";
            this.lblDoor.Size = new System.Drawing.Size(29, 12);
            this.lblDoor.TabIndex = 4;
            this.lblDoor.Text = "도어";
            // 
            // txtName
            // 
            this.txtName.Location = new System.Drawing.Point(59, 206);
            this.txtName.Name = "txtName";
            this.txtName.Size = new System.Drawing.Size(116, 21);
            this.txtName.TabIndex = 5;
            // 
            // txtYear
            // 
            this.txtYear.Location = new System.Drawing.Point(59, 239);
            this.txtYear.Name = "txtYear";
            this.txtYear.Size = new System.Drawing.Size(116, 21);
            this.txtYear.TabIndex = 6;
            // 
            // txtPrice
            // 
            this.txtPrice.Location = new System.Drawing.Point(59, 272);
            this.txtPrice.Name = "txtPrice";
            this.txtPrice.Size = new System.Drawing.Size(116, 21);
            this.txtPrice.TabIndex = 7;
            // 
            // txtDoor
            // 
            this.txtDoor.Location = new System.Drawing.Point(59, 305);
            this.txtDoor.Name = "txtDoor";
            this.txtDoor.Size = new System.Drawing.Size(116, 21);
            this.txtDoor.TabIndex = 8;
            // 
            // btnSave
            // 
            this.btnSave.Location = new System.Drawing.Point(300, 206);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(96, 23);
            this.btnSave.TabIndex = 9;
            this.btnSave.Text = "저 장";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // btnModify
            // 
            this.btnModify.Location = new System.Drawing.Point(300, 236);
            this.btnModify.Name = "btnModify";
            this.btnModify.Size = new System.Drawing.Size(96, 23);
            this.btnModify.TabIndex = 10;
            this.btnModify.Text = "수 정";
            this.btnModify.UseVisualStyleBackColor = true;
            this.btnModify.Click += new System.EventHandler(this.btnModify_Click);
            // 
            // btnConSearch
            // 
            this.btnConSearch.Location = new System.Drawing.Point(300, 266);
            this.btnConSearch.Name = "btnConSearch";
            this.btnConSearch.Size = new System.Drawing.Size(96, 23);
            this.btnConSearch.TabIndex = 11;
            this.btnConSearch.Text = "조건검색";
            this.btnConSearch.UseVisualStyleBackColor = true;
            this.btnConSearch.Click += new System.EventHandler(this.btnConSearch_Click);
            // 
            // btnTotalSearch
            // 
            this.btnTotalSearch.Location = new System.Drawing.Point(300, 296);
            this.btnTotalSearch.Name = "btnTotalSearch";
            this.btnTotalSearch.Size = new System.Drawing.Size(96, 23);
            this.btnTotalSearch.TabIndex = 12;
            this.btnTotalSearch.Text = "전체검색";
            this.btnTotalSearch.UseVisualStyleBackColor = true;
            this.btnTotalSearch.Click += new System.EventHandler(this.btnTotalSearch_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(408, 351);
            this.Controls.Add(this.btnTotalSearch);
            this.Controls.Add(this.btnConSearch);
            this.Controls.Add(this.btnModify);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.txtDoor);
            this.Controls.Add(this.txtPrice);
            this.Controls.Add(this.txtYear);
            this.Controls.Add(this.txtName);
            this.Controls.Add(this.lblDoor);
            this.Controls.Add(this.lblPrice);
            this.Controls.Add(this.lblYear);
            this.Controls.Add(this.lblName);
            this.Controls.Add(this.listView1);
            this.Name = "Form1";
            this.Text = "차량 정보 관리 프로그램";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.cmsMenu.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ListView listView1;
        private System.Windows.Forms.ColumnHeader Colum_Num;
        private System.Windows.Forms.ColumnHeader Colum_Name;
        private System.Windows.Forms.ColumnHeader Colum_Year;
        private System.Windows.Forms.ColumnHeader Colum_Price;
        private System.Windows.Forms.ColumnHeader Colum_Door;
        private System.Windows.Forms.Label lblName;
        private System.Windows.Forms.Label lblYear;
        private System.Windows.Forms.Label lblPrice;
        private System.Windows.Forms.Label lblDoor;
        private System.Windows.Forms.TextBox txtName;
        private System.Windows.Forms.TextBox txtYear;
        private System.Windows.Forms.TextBox txtPrice;
        private System.Windows.Forms.TextBox txtDoor;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.Button btnModify;
        private System.Windows.Forms.Button btnConSearch;
        private System.Windows.Forms.Button btnTotalSearch;
        private System.Windows.Forms.ContextMenuStrip cmsMenu;
        private System.Windows.Forms.ToolStripMenuItem 삭제ToolStripMenuItem;
    }
}

