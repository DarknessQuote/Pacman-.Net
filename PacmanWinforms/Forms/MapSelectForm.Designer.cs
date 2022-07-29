
namespace PacmanWinforms.Forms
{
    partial class MapSelectForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MapSelectForm));
            this.label1 = new System.Windows.Forms.Label();
            this.map1Button = new System.Windows.Forms.Button();
            this.map2Button = new System.Windows.Forms.Button();
            this.map3Button = new System.Windows.Forms.Button();
            this.map4Button = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Consolas", 23F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.label1.ForeColor = System.Drawing.Color.PeachPuff;
            this.label1.Location = new System.Drawing.Point(172, 75);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(230, 46);
            this.label1.TabIndex = 1;
            this.label1.Text = "Select map";
            // 
            // map1Button
            // 
            this.map1Button.BackColor = System.Drawing.Color.Peru;
            this.map1Button.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.map1Button.Font = new System.Drawing.Font("Consolas", 16.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.map1Button.Location = new System.Drawing.Point(127, 208);
            this.map1Button.Name = "map1Button";
            this.map1Button.Size = new System.Drawing.Size(145, 66);
            this.map1Button.TabIndex = 2;
            this.map1Button.Tag = @"Maps\Map1.txt";
            this.map1Button.Text = "Map1";
            this.map1Button.UseVisualStyleBackColor = false;
            this.map1Button.Click += new System.EventHandler(this.MapButton_Click);
            // 
            // map2Button
            // 
            this.map2Button.BackColor = System.Drawing.Color.Peru;
            this.map2Button.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.map2Button.Font = new System.Drawing.Font("Consolas", 16.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.map2Button.Location = new System.Drawing.Point(302, 208);
            this.map2Button.Name = "map2Button";
            this.map2Button.Size = new System.Drawing.Size(145, 66);
            this.map2Button.TabIndex = 3;
            this.map2Button.Tag = @"Maps\Map2.txt";
            this.map2Button.Text = "Map2";
            this.map2Button.UseVisualStyleBackColor = false;
            this.map2Button.Click += new System.EventHandler(this.MapButton_Click);
            // 
            // map3Button
            // 
            this.map3Button.BackColor = System.Drawing.Color.Peru;
            this.map3Button.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.map3Button.Font = new System.Drawing.Font("Consolas", 16.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.map3Button.Location = new System.Drawing.Point(127, 304);
            this.map3Button.Name = "map3Button";
            this.map3Button.Size = new System.Drawing.Size(145, 66);
            this.map3Button.TabIndex = 4;
            this.map3Button.Tag = @"Maps\Map3.txt";
            this.map3Button.Text = "Map3";
            this.map3Button.UseVisualStyleBackColor = false;
            this.map3Button.Click += new System.EventHandler(this.MapButton_Click);
            // 
            // map4Button
            // 
            this.map4Button.BackColor = System.Drawing.Color.Peru;
            this.map4Button.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.map4Button.Font = new System.Drawing.Font("Consolas", 16.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.map4Button.Location = new System.Drawing.Point(302, 304);
            this.map4Button.Name = "map4Button";
            this.map4Button.Size = new System.Drawing.Size(145, 66);
            this.map4Button.TabIndex = 5;
            this.map4Button.Tag = @"Maps\Map4.txt";
            this.map4Button.Text = "Map4";
            this.map4Button.UseVisualStyleBackColor = false;
            this.map4Button.Click += new System.EventHandler(this.MapButton_Click);
            // 
            // MapSelectForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Black;
            this.ClientSize = new System.Drawing.Size(556, 450);
            this.Controls.Add(this.map4Button);
            this.Controls.Add(this.map3Button);
            this.Controls.Add(this.map2Button);
            this.Controls.Add(this.map1Button);
            this.Controls.Add(this.label1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "MapSelectForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Pac-Man";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button map1Button;
        private System.Windows.Forms.Button map2Button;
        private System.Windows.Forms.Button map3Button;
        private System.Windows.Forms.Button map4Button;
    }
}