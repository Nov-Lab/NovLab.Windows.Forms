
namespace NovLab.Windows.Forms
{
    partial class FrmTestEnumListItem
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.LstEnumType = new System.Windows.Forms.ListBox();
            this.LstEnumMember = new System.Windows.Forms.ListBox();
            this.TxtEnumTypeLst = new System.Windows.Forms.TextBox();
            this.TxtEnumMemberLst = new System.Windows.Forms.TextBox();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.MnuDebug = new System.Windows.Forms.ToolStripMenuItem();
            this.MnuDebug_Unselect = new System.Windows.Forms.ToolStripMenuItem();
            this.MnuDebug_SelectItem = new System.Windows.Forms.ToolStripMenuItem();
            this.MnuSample = new System.Windows.Forms.ToolStripMenuItem();
            this.CboEnumType = new System.Windows.Forms.ComboBox();
            this.CboEnumMember = new System.Windows.Forms.ComboBox();
            this.TxtEnumMemberCbo = new System.Windows.Forms.TextBox();
            this.TxtEnumTypeCbo = new System.Windows.Forms.TextBox();
            this.GrpListBox = new System.Windows.Forms.GroupBox();
            this.TtlEnumTypeLst = new System.Windows.Forms.Label();
            this.TtlEnumValueLst = new System.Windows.Forms.Label();
            this.GrpComboBox = new System.Windows.Forms.GroupBox();
            this.TtlEnumValueCbo = new System.Windows.Forms.Label();
            this.TtlEnumTypeCbo = new System.Windows.Forms.Label();
            this.menuStrip1.SuspendLayout();
            this.GrpListBox.SuspendLayout();
            this.GrpComboBox.SuspendLayout();
            this.SuspendLayout();
            // 
            // LstEnumType
            // 
            this.LstEnumType.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.LstEnumType.Font = new System.Drawing.Font("ＭＳ ゴシック", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.LstEnumType.FormattingEnabled = true;
            this.LstEnumType.ItemHeight = 12;
            this.LstEnumType.Location = new System.Drawing.Point(16, 40);
            this.LstEnumType.Name = "LstEnumType";
            this.LstEnumType.Size = new System.Drawing.Size(360, 304);
            this.LstEnumType.TabIndex = 1;
            this.LstEnumType.SelectedIndexChanged += new System.EventHandler(this.LstEnumType_SelectedIndexChanged);
            // 
            // LstEnumMember
            // 
            this.LstEnumMember.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.LstEnumMember.Font = new System.Drawing.Font("ＭＳ ゴシック", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.LstEnumMember.FormattingEnabled = true;
            this.LstEnumMember.ItemHeight = 12;
            this.LstEnumMember.Location = new System.Drawing.Point(392, 40);
            this.LstEnumMember.Name = "LstEnumMember";
            this.LstEnumMember.Size = new System.Drawing.Size(360, 304);
            this.LstEnumMember.TabIndex = 4;
            this.LstEnumMember.SelectedIndexChanged += new System.EventHandler(this.LstEnumMember_SelectedIndexChanged);
            // 
            // TxtEnumTypeLst
            // 
            this.TxtEnumTypeLst.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.TxtEnumTypeLst.Font = new System.Drawing.Font("ＭＳ ゴシック", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.TxtEnumTypeLst.Location = new System.Drawing.Point(16, 352);
            this.TxtEnumTypeLst.Name = "TxtEnumTypeLst";
            this.TxtEnumTypeLst.ReadOnly = true;
            this.TxtEnumTypeLst.Size = new System.Drawing.Size(360, 19);
            this.TxtEnumTypeLst.TabIndex = 2;
            this.TxtEnumTypeLst.TabStop = false;
            // 
            // TxtEnumMemberLst
            // 
            this.TxtEnumMemberLst.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.TxtEnumMemberLst.Font = new System.Drawing.Font("ＭＳ ゴシック", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.TxtEnumMemberLst.Location = new System.Drawing.Point(392, 352);
            this.TxtEnumMemberLst.Name = "TxtEnumMemberLst";
            this.TxtEnumMemberLst.ReadOnly = true;
            this.TxtEnumMemberLst.Size = new System.Drawing.Size(360, 19);
            this.TxtEnumMemberLst.TabIndex = 5;
            this.TxtEnumMemberLst.TabStop = false;
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.MnuDebug,
            this.MnuSample});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(786, 24);
            this.menuStrip1.TabIndex = 0;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // MnuDebug
            // 
            this.MnuDebug.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.MnuDebug_Unselect,
            this.MnuDebug_SelectItem});
            this.MnuDebug.Name = "MnuDebug";
            this.MnuDebug.Size = new System.Drawing.Size(95, 20);
            this.MnuDebug.Text = "デバッグ操作(&D)";
            // 
            // MnuDebug_Unselect
            // 
            this.MnuDebug_Unselect.Name = "MnuDebug_Unselect";
            this.MnuDebug_Unselect.Size = new System.Drawing.Size(277, 22);
            this.MnuDebug_Unselect.Text = "選択を解除(&R)";
            this.MnuDebug_Unselect.Click += new System.EventHandler(this.MnuDebug_Unselect_Click);
            // 
            // MnuDebug_SelectItem
            // 
            this.MnuDebug_SelectItem.Name = "MnuDebug_SelectItem";
            this.MnuDebug_SelectItem.Size = new System.Drawing.Size(277, 22);
            this.MnuDebug_SelectItem.Text = "DayOfWeek列挙体の「水曜日」を選択(&S)";
            this.MnuDebug_SelectItem.Click += new System.EventHandler(this.MnuDebug_SelectItem_Click);
            // 
            // MnuSample
            // 
            this.MnuSample.Name = "MnuSample";
            this.MnuSample.Size = new System.Drawing.Size(128, 20);
            this.MnuSample.Text = "サンプルコードを実行(&S)";
            // 
            // CboEnumType
            // 
            this.CboEnumType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.CboEnumType.Font = new System.Drawing.Font("ＭＳ ゴシック", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.CboEnumType.FormattingEnabled = true;
            this.CboEnumType.Location = new System.Drawing.Point(16, 40);
            this.CboEnumType.Name = "CboEnumType";
            this.CboEnumType.Size = new System.Drawing.Size(360, 20);
            this.CboEnumType.TabIndex = 1;
            this.CboEnumType.SelectedIndexChanged += new System.EventHandler(this.CboEnumType_SelectedIndexChanged);
            // 
            // CboEnumMember
            // 
            this.CboEnumMember.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.CboEnumMember.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.CboEnumMember.Font = new System.Drawing.Font("ＭＳ ゴシック", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.CboEnumMember.FormattingEnabled = true;
            this.CboEnumMember.Location = new System.Drawing.Point(392, 40);
            this.CboEnumMember.Name = "CboEnumMember";
            this.CboEnumMember.Size = new System.Drawing.Size(360, 20);
            this.CboEnumMember.TabIndex = 4;
            this.CboEnumMember.SelectedIndexChanged += new System.EventHandler(this.CboEnumMember_SelectedIndexChanged);
            // 
            // TxtEnumMemberCbo
            // 
            this.TxtEnumMemberCbo.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.TxtEnumMemberCbo.Font = new System.Drawing.Font("ＭＳ ゴシック", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.TxtEnumMemberCbo.Location = new System.Drawing.Point(392, 64);
            this.TxtEnumMemberCbo.Name = "TxtEnumMemberCbo";
            this.TxtEnumMemberCbo.ReadOnly = true;
            this.TxtEnumMemberCbo.Size = new System.Drawing.Size(360, 19);
            this.TxtEnumMemberCbo.TabIndex = 5;
            this.TxtEnumMemberCbo.TabStop = false;
            // 
            // TxtEnumTypeCbo
            // 
            this.TxtEnumTypeCbo.Font = new System.Drawing.Font("ＭＳ ゴシック", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.TxtEnumTypeCbo.Location = new System.Drawing.Point(16, 64);
            this.TxtEnumTypeCbo.Name = "TxtEnumTypeCbo";
            this.TxtEnumTypeCbo.ReadOnly = true;
            this.TxtEnumTypeCbo.Size = new System.Drawing.Size(360, 19);
            this.TxtEnumTypeCbo.TabIndex = 2;
            this.TxtEnumTypeCbo.TabStop = false;
            // 
            // GrpListBox
            // 
            this.GrpListBox.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.GrpListBox.Controls.Add(this.TtlEnumValueLst);
            this.GrpListBox.Controls.Add(this.TtlEnumTypeLst);
            this.GrpListBox.Controls.Add(this.LstEnumType);
            this.GrpListBox.Controls.Add(this.TxtEnumTypeLst);
            this.GrpListBox.Controls.Add(this.LstEnumMember);
            this.GrpListBox.Controls.Add(this.TxtEnumMemberLst);
            this.GrpListBox.Location = new System.Drawing.Point(8, 32);
            this.GrpListBox.Name = "GrpListBox";
            this.GrpListBox.Size = new System.Drawing.Size(769, 392);
            this.GrpListBox.TabIndex = 1;
            this.GrpListBox.TabStop = false;
            this.GrpListBox.Text = "リストボックスのテスト";
            // 
            // TtlEnumTypeLst
            // 
            this.TtlEnumTypeLst.AutoSize = true;
            this.TtlEnumTypeLst.Location = new System.Drawing.Point(16, 24);
            this.TtlEnumTypeLst.Name = "TtlEnumTypeLst";
            this.TtlEnumTypeLst.Size = new System.Drawing.Size(43, 12);
            this.TtlEnumTypeLst.TabIndex = 0;
            this.TtlEnumTypeLst.Text = "列挙体:";
            // 
            // TtlEnumValueLst
            // 
            this.TtlEnumValueLst.AutoSize = true;
            this.TtlEnumValueLst.Location = new System.Drawing.Point(392, 24);
            this.TtlEnumValueLst.Name = "TtlEnumValueLst";
            this.TtlEnumValueLst.Size = new System.Drawing.Size(260, 12);
            this.TtlEnumValueLst.TabIndex = 3;
            this.TtlEnumValueLst.Text = "列挙値(サンプルコード実行結果もここに反映されます):";
            // 
            // GrpComboBox
            // 
            this.GrpComboBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.GrpComboBox.Controls.Add(this.TtlEnumValueCbo);
            this.GrpComboBox.Controls.Add(this.TtlEnumTypeCbo);
            this.GrpComboBox.Controls.Add(this.CboEnumType);
            this.GrpComboBox.Controls.Add(this.CboEnumMember);
            this.GrpComboBox.Controls.Add(this.TxtEnumMemberCbo);
            this.GrpComboBox.Controls.Add(this.TxtEnumTypeCbo);
            this.GrpComboBox.Location = new System.Drawing.Point(8, 432);
            this.GrpComboBox.Name = "GrpComboBox";
            this.GrpComboBox.Size = new System.Drawing.Size(769, 100);
            this.GrpComboBox.TabIndex = 2;
            this.GrpComboBox.TabStop = false;
            this.GrpComboBox.Text = "コンボボックスのテスト";
            // 
            // TtlEnumValueCbo
            // 
            this.TtlEnumValueCbo.AutoSize = true;
            this.TtlEnumValueCbo.Location = new System.Drawing.Point(392, 24);
            this.TtlEnumValueCbo.Name = "TtlEnumValueCbo";
            this.TtlEnumValueCbo.Size = new System.Drawing.Size(43, 12);
            this.TtlEnumValueCbo.TabIndex = 3;
            this.TtlEnumValueCbo.Text = "列挙値:";
            // 
            // TtlEnumTypeCbo
            // 
            this.TtlEnumTypeCbo.AutoSize = true;
            this.TtlEnumTypeCbo.Location = new System.Drawing.Point(16, 24);
            this.TtlEnumTypeCbo.Name = "TtlEnumTypeCbo";
            this.TtlEnumTypeCbo.Size = new System.Drawing.Size(43, 12);
            this.TtlEnumTypeCbo.TabIndex = 0;
            this.TtlEnumTypeCbo.Text = "列挙体:";
            // 
            // FrmTestEnumListItem
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(786, 541);
            this.Controls.Add(this.GrpComboBox);
            this.Controls.Add(this.GrpListBox);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.MinimumSize = new System.Drawing.Size(802, 580);
            this.Name = "FrmTestEnumListItem";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "EnumListItem クラスのテスト";
            this.Load += new System.EventHandler(this.FrmTestEnumListItem_Load);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.GrpListBox.ResumeLayout(false);
            this.GrpListBox.PerformLayout();
            this.GrpComboBox.ResumeLayout(false);
            this.GrpComboBox.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ListBox LstEnumType;
        private System.Windows.Forms.ListBox LstEnumMember;
        private System.Windows.Forms.TextBox TxtEnumTypeLst;
        private System.Windows.Forms.TextBox TxtEnumMemberLst;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem MnuDebug;
        private System.Windows.Forms.ToolStripMenuItem MnuDebug_Unselect;
        private System.Windows.Forms.ToolStripMenuItem MnuDebug_SelectItem;
        private System.Windows.Forms.ComboBox CboEnumType;
        private System.Windows.Forms.ComboBox CboEnumMember;
        private System.Windows.Forms.TextBox TxtEnumMemberCbo;
        private System.Windows.Forms.TextBox TxtEnumTypeCbo;
        private System.Windows.Forms.ToolStripMenuItem MnuSample;
        private System.Windows.Forms.GroupBox GrpListBox;
        private System.Windows.Forms.Label TtlEnumValueLst;
        private System.Windows.Forms.Label TtlEnumTypeLst;
        private System.Windows.Forms.GroupBox GrpComboBox;
        private System.Windows.Forms.Label TtlEnumValueCbo;
        private System.Windows.Forms.Label TtlEnumTypeCbo;
    }
}