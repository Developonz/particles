namespace particles
{
    partial class Form1
    {
        /// <summary>
        /// Обязательная переменная конструктора.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Освободить все используемые ресурсы.
        /// </summary>
        /// <param name="disposing">истинно, если управляемый ресурс должен быть удален; иначе ложно.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Код, автоматически созданный конструктором форм Windows

        /// <summary>
        /// Требуемый метод для поддержки конструктора — не изменяйте 
        /// содержимое этого метода с помощью редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.picDisplay = new System.Windows.Forms.PictureBox();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.tbDirection = new System.Windows.Forms.TrackBar();
            this.tbSpreading = new System.Windows.Forms.TrackBar();
            this.rbTeleport = new System.Windows.Forms.RadioButton();
            this.rbBlackEater = new System.Windows.Forms.RadioButton();
            this.rbEmitter = new System.Windows.Forms.RadioButton();
            this.rbDeMagnite = new System.Windows.Forms.RadioButton();
            this.rbMagnite = new System.Windows.Forms.RadioButton();
            this.tbPowerGravitone = new System.Windows.Forms.TrackBar();
            this.tbPowerAntiGraviton = new System.Windows.Forms.TrackBar();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            ((System.ComponentModel.ISupportInitialize)(this.picDisplay)).BeginInit();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.tbDirection)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tbSpreading)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tbPowerGravitone)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tbPowerAntiGraviton)).BeginInit();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // picDisplay
            // 
            this.picDisplay.Location = new System.Drawing.Point(13, 13);
            this.picDisplay.Name = "picDisplay";
            this.picDisplay.Size = new System.Drawing.Size(1412, 743);
            this.picDisplay.TabIndex = 0;
            this.picDisplay.TabStop = false;
            this.picDisplay.MouseMove += new System.Windows.Forms.MouseEventHandler(this.picDisplay_MouseMove);
            // 
            // timer1
            // 
            this.timer1.Enabled = true;
            this.timer1.Interval = 40;
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.tbDirection);
            this.groupBox1.Controls.Add(this.tbSpreading);
            this.groupBox1.Location = new System.Drawing.Point(13, 13);
            this.groupBox1.Margin = new System.Windows.Forms.Padding(4);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Padding = new System.Windows.Forms.Padding(4);
            this.groupBox1.Size = new System.Drawing.Size(381, 155);
            this.groupBox1.TabIndex = 10;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Полузнки управление спавном частиц";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(303, 86);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(62, 16);
            this.label2.TabIndex = 5;
            this.label2.Text = "Расброс";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(303, 23);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(73, 16);
            this.label1.TabIndex = 4;
            this.label1.Text = "Вращение";
            // 
            // tbDirection
            // 
            this.tbDirection.Location = new System.Drawing.Point(8, 23);
            this.tbDirection.Margin = new System.Windows.Forms.Padding(4);
            this.tbDirection.Maximum = 359;
            this.tbDirection.Name = "tbDirection";
            this.tbDirection.Size = new System.Drawing.Size(299, 56);
            this.tbDirection.TabIndex = 1;
            // 
            // tbSpreading
            // 
            this.tbSpreading.Location = new System.Drawing.Point(8, 86);
            this.tbSpreading.Margin = new System.Windows.Forms.Padding(4);
            this.tbSpreading.Maximum = 359;
            this.tbSpreading.Name = "tbSpreading";
            this.tbSpreading.Size = new System.Drawing.Size(299, 56);
            this.tbSpreading.TabIndex = 3;
            // 
            // rbTeleport
            // 
            this.rbTeleport.AutoSize = true;
            this.rbTeleport.Location = new System.Drawing.Point(835, 36);
            this.rbTeleport.Margin = new System.Windows.Forms.Padding(4);
            this.rbTeleport.Name = "rbTeleport";
            this.rbTeleport.Size = new System.Drawing.Size(92, 20);
            this.rbTeleport.TabIndex = 13;
            this.rbTeleport.TabStop = true;
            this.rbTeleport.Text = "Телепорт";
            this.rbTeleport.UseVisualStyleBackColor = true;
            // 
            // rbBlackEater
            // 
            this.rbBlackEater.AutoSize = true;
            this.rbBlackEater.Location = new System.Drawing.Point(608, 36);
            this.rbBlackEater.Margin = new System.Windows.Forms.Padding(4);
            this.rbBlackEater.Name = "rbBlackEater";
            this.rbBlackEater.Size = new System.Drawing.Size(202, 20);
            this.rbBlackEater.TabIndex = 12;
            this.rbBlackEater.TabStop = true;
            this.rbBlackEater.Text = "Черный пожиратель(Дыра)";
            this.rbBlackEater.UseVisualStyleBackColor = true;
            // 
            // rbEmitter
            // 
            this.rbEmitter.AutoSize = true;
            this.rbEmitter.Location = new System.Drawing.Point(425, 36);
            this.rbEmitter.Margin = new System.Windows.Forms.Padding(4);
            this.rbEmitter.Name = "rbEmitter";
            this.rbEmitter.Size = new System.Drawing.Size(167, 20);
            this.rbEmitter.TabIndex = 11;
            this.rbEmitter.TabStop = true;
            this.rbEmitter.Text = "Точка спавна частиц";
            this.rbEmitter.UseVisualStyleBackColor = true;
            // 
            // rbDeMagnite
            // 
            this.rbDeMagnite.AutoSize = true;
            this.rbDeMagnite.Location = new System.Drawing.Point(947, 135);
            this.rbDeMagnite.Margin = new System.Windows.Forms.Padding(4);
            this.rbDeMagnite.Name = "rbDeMagnite";
            this.rbDeMagnite.Size = new System.Drawing.Size(122, 20);
            this.rbDeMagnite.TabIndex = 15;
            this.rbDeMagnite.TabStop = true;
            this.rbDeMagnite.Text = "АнтиГравитон";
            this.rbDeMagnite.UseVisualStyleBackColor = true;
            // 
            // rbMagnite
            // 
            this.rbMagnite.AutoSize = true;
            this.rbMagnite.Location = new System.Drawing.Point(947, 72);
            this.rbMagnite.Margin = new System.Windows.Forms.Padding(4);
            this.rbMagnite.Name = "rbMagnite";
            this.rbMagnite.Size = new System.Drawing.Size(90, 20);
            this.rbMagnite.TabIndex = 14;
            this.rbMagnite.TabStop = true;
            this.rbMagnite.Text = "Гравитон";
            this.rbMagnite.UseVisualStyleBackColor = true;
            // 
            // tbPowerGravitone
            // 
            this.tbPowerGravitone.Location = new System.Drawing.Point(8, 23);
            this.tbPowerGravitone.Margin = new System.Windows.Forms.Padding(4);
            this.tbPowerGravitone.Maximum = 200;
            this.tbPowerGravitone.Minimum = 30;
            this.tbPowerGravitone.Name = "tbPowerGravitone";
            this.tbPowerGravitone.Size = new System.Drawing.Size(299, 56);
            this.tbPowerGravitone.TabIndex = 1;
            this.tbPowerGravitone.Value = 30;
            // 
            // tbPowerAntiGraviton
            // 
            this.tbPowerAntiGraviton.Location = new System.Drawing.Point(8, 86);
            this.tbPowerAntiGraviton.Margin = new System.Windows.Forms.Padding(4);
            this.tbPowerAntiGraviton.Maximum = 200;
            this.tbPowerAntiGraviton.Minimum = 30;
            this.tbPowerAntiGraviton.Name = "tbPowerAntiGraviton";
            this.tbPowerAntiGraviton.Size = new System.Drawing.Size(299, 56);
            this.tbPowerAntiGraviton.TabIndex = 3;
            this.tbPowerAntiGraviton.Value = 30;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.tbPowerGravitone);
            this.groupBox2.Controls.Add(this.tbPowerAntiGraviton);
            this.groupBox2.Location = new System.Drawing.Point(1099, 36);
            this.groupBox2.Margin = new System.Windows.Forms.Padding(4);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Padding = new System.Windows.Forms.Padding(4);
            this.groupBox2.Size = new System.Drawing.Size(305, 155);
            this.groupBox2.TabIndex = 16;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Полузнки силы";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1437, 768);
            this.Controls.Add(this.rbDeMagnite);
            this.Controls.Add(this.rbMagnite);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.rbTeleport);
            this.Controls.Add(this.rbBlackEater);
            this.Controls.Add(this.rbEmitter);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.picDisplay);
            this.Name = "Form1";
            this.Text = "Form1";
            ((System.ComponentModel.ISupportInitialize)(this.picDisplay)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.tbDirection)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tbSpreading)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tbPowerGravitone)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tbPowerAntiGraviton)).EndInit();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox picDisplay;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TrackBar tbDirection;
        private System.Windows.Forms.TrackBar tbSpreading;
        private System.Windows.Forms.RadioButton rbTeleport;
        private System.Windows.Forms.RadioButton rbBlackEater;
        private System.Windows.Forms.RadioButton rbEmitter;
        private System.Windows.Forms.RadioButton rbDeMagnite;
        private System.Windows.Forms.RadioButton rbMagnite;
        private System.Windows.Forms.TrackBar tbPowerGravitone;
        private System.Windows.Forms.TrackBar tbPowerAntiGraviton;
        private System.Windows.Forms.GroupBox groupBox2;
    }
}

