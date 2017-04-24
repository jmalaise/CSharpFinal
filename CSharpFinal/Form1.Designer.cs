namespace CSharpFinal
{
    partial class frmMain
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
            this.components = new System.ComponentModel.Container();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.resetToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.exitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.characterToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.characterFormToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.itemsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.itemFormToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.resetToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.clearFormToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.dgvMain = new System.Windows.Forms.DataGridView();
            this.grpSearch = new System.Windows.Forms.GroupBox();
            this.btnSearchExact = new System.Windows.Forms.Button();
            this.btnSearchLike = new System.Windows.Forms.Button();
            this.radItem = new System.Windows.Forms.RadioButton();
            this.radCharacter = new System.Windows.Forms.RadioButton();
            this.txtSearch = new System.Windows.Forms.TextBox();
            this.errProvider = new System.Windows.Forms.ErrorProvider(this.components);
            this.menuStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvMain)).BeginInit();
            this.grpSearch.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.errProvider)).BeginInit();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.resetToolStripMenuItem,
            this.characterToolStripMenuItem,
            this.itemsToolStripMenuItem,
            this.resetToolStripMenuItem1});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(508, 24);
            this.menuStrip1.TabIndex = 3;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // resetToolStripMenuItem
            // 
            this.resetToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.exitToolStripMenuItem});
            this.resetToolStripMenuItem.Name = "resetToolStripMenuItem";
            this.resetToolStripMenuItem.Size = new System.Drawing.Size(35, 20);
            this.resetToolStripMenuItem.Text = "&File";
            // 
            // exitToolStripMenuItem
            // 
            this.exitToolStripMenuItem.Name = "exitToolStripMenuItem";
            this.exitToolStripMenuItem.Size = new System.Drawing.Size(92, 22);
            this.exitToolStripMenuItem.Text = "&Exit";
            this.exitToolStripMenuItem.Click += new System.EventHandler(this.exitToolStripMenuItem_Click);
            // 
            // characterToolStripMenuItem
            // 
            this.characterToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.characterFormToolStripMenuItem});
            this.characterToolStripMenuItem.Name = "characterToolStripMenuItem";
            this.characterToolStripMenuItem.Size = new System.Drawing.Size(67, 20);
            this.characterToolStripMenuItem.Text = "&Character";
            // 
            // characterFormToolStripMenuItem
            // 
            this.characterFormToolStripMenuItem.Name = "characterFormToolStripMenuItem";
            this.characterFormToolStripMenuItem.Size = new System.Drawing.Size(149, 22);
            this.characterFormToolStripMenuItem.Text = "Character Form";
            this.characterFormToolStripMenuItem.Click += new System.EventHandler(this.characterFormToolStripMenuItem_Click);
            // 
            // itemsToolStripMenuItem
            // 
            this.itemsToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.itemFormToolStripMenuItem});
            this.itemsToolStripMenuItem.Name = "itemsToolStripMenuItem";
            this.itemsToolStripMenuItem.Size = new System.Drawing.Size(46, 20);
            this.itemsToolStripMenuItem.Text = "&Items";
            // 
            // itemFormToolStripMenuItem
            // 
            this.itemFormToolStripMenuItem.Name = "itemFormToolStripMenuItem";
            this.itemFormToolStripMenuItem.Size = new System.Drawing.Size(123, 22);
            this.itemFormToolStripMenuItem.Text = "Item Form";
            this.itemFormToolStripMenuItem.Click += new System.EventHandler(this.itemFormToolStripMenuItem_Click);
            // 
            // resetToolStripMenuItem1
            // 
            this.resetToolStripMenuItem1.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.clearFormToolStripMenuItem});
            this.resetToolStripMenuItem1.Name = "resetToolStripMenuItem1";
            this.resetToolStripMenuItem1.Size = new System.Drawing.Size(47, 20);
            this.resetToolStripMenuItem1.Text = "&Reset";
            // 
            // clearFormToolStripMenuItem
            // 
            this.clearFormToolStripMenuItem.Name = "clearFormToolStripMenuItem";
            this.clearFormToolStripMenuItem.Size = new System.Drawing.Size(126, 22);
            this.clearFormToolStripMenuItem.Text = "Clear Form";
            // 
            // dgvMain
            // 
            this.dgvMain.AllowUserToAddRows = false;
            this.dgvMain.AllowUserToDeleteRows = false;
            this.dgvMain.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvMain.Location = new System.Drawing.Point(12, 100);
            this.dgvMain.Name = "dgvMain";
            this.dgvMain.ReadOnly = true;
            this.dgvMain.Size = new System.Drawing.Size(484, 335);
            this.dgvMain.TabIndex = 4;
            // 
            // grpSearch
            // 
            this.grpSearch.Controls.Add(this.btnSearchExact);
            this.grpSearch.Controls.Add(this.btnSearchLike);
            this.grpSearch.Controls.Add(this.radItem);
            this.grpSearch.Controls.Add(this.radCharacter);
            this.grpSearch.Controls.Add(this.txtSearch);
            this.grpSearch.Location = new System.Drawing.Point(13, 28);
            this.grpSearch.Name = "grpSearch";
            this.grpSearch.Size = new System.Drawing.Size(483, 66);
            this.grpSearch.TabIndex = 5;
            this.grpSearch.TabStop = false;
            this.grpSearch.Text = "Quick Search";
            // 
            // btnSearchExact
            // 
            this.btnSearchExact.Location = new System.Drawing.Point(385, 19);
            this.btnSearchExact.Name = "btnSearchExact";
            this.btnSearchExact.Size = new System.Drawing.Size(92, 40);
            this.btnSearchExact.TabIndex = 4;
            this.btnSearchExact.Text = "Search Exact";
            this.btnSearchExact.UseVisualStyleBackColor = true;
            this.btnSearchExact.Click += new System.EventHandler(this.btnSearchExact_Click);
            // 
            // btnSearchLike
            // 
            this.btnSearchLike.Location = new System.Drawing.Point(278, 20);
            this.btnSearchLike.Name = "btnSearchLike";
            this.btnSearchLike.Size = new System.Drawing.Size(101, 40);
            this.btnSearchLike.TabIndex = 3;
            this.btnSearchLike.Text = "Search";
            this.btnSearchLike.UseVisualStyleBackColor = true;
            this.btnSearchLike.Click += new System.EventHandler(this.btnSearchLike_Click);
            // 
            // radItem
            // 
            this.radItem.AutoSize = true;
            this.radItem.Location = new System.Drawing.Point(169, 42);
            this.radItem.Name = "radItem";
            this.radItem.Size = new System.Drawing.Size(45, 17);
            this.radItem.TabIndex = 2;
            this.radItem.TabStop = true;
            this.radItem.Text = "Item";
            this.radItem.UseVisualStyleBackColor = true;
            this.radItem.CheckedChanged += new System.EventHandler(this.radItem_CheckedChanged);
            // 
            // radCharacter
            // 
            this.radCharacter.AutoSize = true;
            this.radCharacter.Location = new System.Drawing.Point(169, 19);
            this.radCharacter.Name = "radCharacter";
            this.radCharacter.Size = new System.Drawing.Size(71, 17);
            this.radCharacter.TabIndex = 1;
            this.radCharacter.TabStop = true;
            this.radCharacter.Text = "Character";
            this.radCharacter.UseVisualStyleBackColor = true;
            this.radCharacter.CheckedChanged += new System.EventHandler(this.radCharacter_CheckedChanged);
            // 
            // txtSearch
            // 
            this.txtSearch.Location = new System.Drawing.Point(6, 29);
            this.txtSearch.Name = "txtSearch";
            this.txtSearch.Size = new System.Drawing.Size(100, 20);
            this.txtSearch.TabIndex = 0;
            // 
            // errProvider
            // 
            this.errProvider.ContainerControl = this;
            // 
            // frmMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(508, 447);
            this.Controls.Add(this.grpSearch);
            this.Controls.Add(this.dgvMain);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "frmMain";
            this.Text = "Overview";
            this.Load += new System.EventHandler(this.frmMain_Load);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvMain)).EndInit();
            this.grpSearch.ResumeLayout(false);
            this.grpSearch.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.errProvider)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem resetToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem exitToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem characterToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem itemsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem resetToolStripMenuItem1;
        private System.Windows.Forms.DataGridView dgvMain;
        private System.Windows.Forms.GroupBox grpSearch;
        private System.Windows.Forms.Button btnSearchExact;
        private System.Windows.Forms.Button btnSearchLike;
        private System.Windows.Forms.RadioButton radItem;
        private System.Windows.Forms.RadioButton radCharacter;
        private System.Windows.Forms.TextBox txtSearch;
        private System.Windows.Forms.ToolStripMenuItem characterFormToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem itemFormToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem clearFormToolStripMenuItem;
        private System.Windows.Forms.ErrorProvider errProvider;
    }
}

