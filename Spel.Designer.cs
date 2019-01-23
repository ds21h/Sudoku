namespace Sudoku
{
    partial class Spel
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
            this.txtCijfer = new System.Windows.Forms.TextBox();
            this.btnLosOp = new System.Windows.Forms.Button();
            this.btnOpzetten = new System.Windows.Forms.Button();
            this.btnNieuw = new System.Windows.Forms.Button();
            this.btnPotlood = new System.Windows.Forms.Button();
            this.btnPotloodInvullen = new System.Windows.Forms.Button();
            this.txtPotlood = new System.Windows.Forms.TextBox();
            this.btnPotloodWis = new System.Windows.Forms.Button();
            this.btnGenereer = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // txtCijfer
            // 
            this.txtCijfer.Font = new System.Drawing.Font("Microsoft Sans Serif", 20F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtCijfer.Location = new System.Drawing.Point(45, 12);
            this.txtCijfer.Name = "txtCijfer";
            this.txtCijfer.Size = new System.Drawing.Size(38, 38);
            this.txtCijfer.TabIndex = 0;
            this.txtCijfer.Text = "9";
            this.txtCijfer.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.txtCijfer.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtCijfer_KeyDown);
            this.txtCijfer.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtCijfer_KeyPress);
            // 
            // btnLosOp
            // 
            this.btnLosOp.Location = new System.Drawing.Point(509, 370);
            this.btnLosOp.Name = "btnLosOp";
            this.btnLosOp.Size = new System.Drawing.Size(75, 23);
            this.btnLosOp.TabIndex = 1;
            this.btnLosOp.Text = "Oplossen";
            this.btnLosOp.UseVisualStyleBackColor = true;
            this.btnLosOp.Click += new System.EventHandler(this.btnLosOp_Click);
            // 
            // btnOpzetten
            // 
            this.btnOpzetten.Location = new System.Drawing.Point(509, 341);
            this.btnOpzetten.Name = "btnOpzetten";
            this.btnOpzetten.Size = new System.Drawing.Size(75, 23);
            this.btnOpzetten.TabIndex = 2;
            this.btnOpzetten.Text = "Opzetten";
            this.btnOpzetten.UseVisualStyleBackColor = true;
            this.btnOpzetten.Click += new System.EventHandler(this.btnOpzetten_Click);
            // 
            // btnNieuw
            // 
            this.btnNieuw.Location = new System.Drawing.Point(509, 53);
            this.btnNieuw.Name = "btnNieuw";
            this.btnNieuw.Size = new System.Drawing.Size(75, 23);
            this.btnNieuw.TabIndex = 3;
            this.btnNieuw.Text = "Nieuw Spel";
            this.btnNieuw.UseVisualStyleBackColor = true;
            this.btnNieuw.Click += new System.EventHandler(this.btnNieuw_Click);
            // 
            // btnPotlood
            // 
            this.btnPotlood.Location = new System.Drawing.Point(509, 102);
            this.btnPotlood.Name = "btnPotlood";
            this.btnPotlood.Size = new System.Drawing.Size(75, 23);
            this.btnPotlood.TabIndex = 4;
            this.btnPotlood.Text = "Potlood";
            this.btnPotlood.UseVisualStyleBackColor = true;
            this.btnPotlood.Click += new System.EventHandler(this.btnPotlood_Click);
            // 
            // btnPotloodInvullen
            // 
            this.btnPotloodInvullen.Enabled = false;
            this.btnPotloodInvullen.Location = new System.Drawing.Point(509, 131);
            this.btnPotloodInvullen.Name = "btnPotloodInvullen";
            this.btnPotloodInvullen.Size = new System.Drawing.Size(75, 23);
            this.btnPotloodInvullen.TabIndex = 5;
            this.btnPotloodInvullen.Text = "Invullen";
            this.btnPotloodInvullen.UseVisualStyleBackColor = true;
            this.btnPotloodInvullen.Click += new System.EventHandler(this.btnPotloodInvullen_Click);
            // 
            // txtPotlood
            // 
            this.txtPotlood.Font = new System.Drawing.Font("Microsoft Sans Serif", 6F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtPotlood.Location = new System.Drawing.Point(108, 31);
            this.txtPotlood.Name = "txtPotlood";
            this.txtPotlood.Size = new System.Drawing.Size(17, 17);
            this.txtPotlood.TabIndex = 6;
            this.txtPotlood.Text = "9";
            this.txtPotlood.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.txtPotlood.Visible = false;
            // 
            // btnPotloodWis
            // 
            this.btnPotloodWis.Enabled = false;
            this.btnPotloodWis.Location = new System.Drawing.Point(509, 160);
            this.btnPotloodWis.Name = "btnPotloodWis";
            this.btnPotloodWis.Size = new System.Drawing.Size(75, 23);
            this.btnPotloodWis.TabIndex = 7;
            this.btnPotloodWis.Text = "Wissen";
            this.btnPotloodWis.UseVisualStyleBackColor = true;
            this.btnPotloodWis.Click += new System.EventHandler(this.btnPotloodWis_Click);
            // 
            // btnGenereer
            // 
            this.btnGenereer.Location = new System.Drawing.Point(509, 415);
            this.btnGenereer.Name = "btnGenereer";
            this.btnGenereer.Size = new System.Drawing.Size(75, 23);
            this.btnGenereer.TabIndex = 8;
            this.btnGenereer.Text = "Genereer";
            this.btnGenereer.UseVisualStyleBackColor = true;
            this.btnGenereer.Click += new System.EventHandler(this.btnGenereer_Click);
            // 
            // Spel
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(641, 496);
            this.Controls.Add(this.btnGenereer);
            this.Controls.Add(this.btnPotloodWis);
            this.Controls.Add(this.txtPotlood);
            this.Controls.Add(this.btnPotloodInvullen);
            this.Controls.Add(this.btnPotlood);
            this.Controls.Add(this.btnNieuw);
            this.Controls.Add(this.btnOpzetten);
            this.Controls.Add(this.btnLosOp);
            this.Controls.Add(this.txtCijfer);
            this.Name = "Spel";
            this.Text = "Form1";
            this.Paint += new System.Windows.Forms.PaintEventHandler(this.Spel_Paint);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txtCijfer;
        private System.Windows.Forms.Button btnLosOp;
        private System.Windows.Forms.Button btnOpzetten;
        private System.Windows.Forms.Button btnNieuw;
        private System.Windows.Forms.Button btnPotlood;
        private System.Windows.Forms.Button btnPotloodInvullen;
        private System.Windows.Forms.TextBox txtPotlood;
        private System.Windows.Forms.Button btnPotloodWis;
        private System.Windows.Forms.Button btnGenereer;
    }
}

