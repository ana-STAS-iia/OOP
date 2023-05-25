
namespace CCircle
{
    partial class FormCircles
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
            this.isWorkingWithCtrl = new System.Windows.Forms.CheckBox();
            this.isMultipleSelection = new System.Windows.Forms.CheckBox();
            this.colorDialog = new System.Windows.Forms.ColorDialog();
            this.btColor = new System.Windows.Forms.Button();
            this.pnlPaint = new System.Windows.Forms.Panel();
            this.radioButtonTr = new System.Windows.Forms.RadioButton();
            this.radioButtonCir = new System.Windows.Forms.RadioButton();
            this.radioButtonSq = new System.Windows.Forms.RadioButton();
            this.SuspendLayout();
            // 
            // isWorkingWithCtrl
            // 
            this.isWorkingWithCtrl.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.isWorkingWithCtrl.AutoSize = true;
            this.isWorkingWithCtrl.Location = new System.Drawing.Point(47, 420);
            this.isWorkingWithCtrl.Name = "isWorkingWithCtrl";
            this.isWorkingWithCtrl.Size = new System.Drawing.Size(66, 21);
            this.isWorkingWithCtrl.TabIndex = 0;
            this.isWorkingWithCtrl.Text = "CTRL";
            this.isWorkingWithCtrl.UseVisualStyleBackColor = true;
            // 
            // isMultipleSelection
            // 
            this.isMultipleSelection.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.isMultipleSelection.AutoSize = true;
            this.isMultipleSelection.Location = new System.Drawing.Point(179, 420);
            this.isMultipleSelection.Name = "isMultipleSelection";
            this.isMultipleSelection.Size = new System.Drawing.Size(97, 21);
            this.isMultipleSelection.TabIndex = 1;
            this.isMultipleSelection.Text = "MULTIPLE";
            this.isMultipleSelection.UseVisualStyleBackColor = true;
            // 
            // btColor
            // 
            this.btColor.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.btColor.Location = new System.Drawing.Point(313, 413);
            this.btColor.Name = "btColor";
            this.btColor.Size = new System.Drawing.Size(36, 33);
            this.btColor.TabIndex = 3;
            this.btColor.UseVisualStyleBackColor = true;
            this.btColor.Click += new System.EventHandler(this.btColor_Click);
            // 
            // pnlPaint
            // 
            this.pnlPaint.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.pnlPaint.BackColor = System.Drawing.SystemColors.ControlLight;
            this.pnlPaint.Location = new System.Drawing.Point(12, 12);
            this.pnlPaint.Name = "pnlPaint";
            this.pnlPaint.Size = new System.Drawing.Size(808, 392);
            this.pnlPaint.TabIndex = 2;
            this.pnlPaint.Paint += new System.Windows.Forms.PaintEventHandler(this.pnlPaint_Paint);
            this.pnlPaint.MouseDown += new System.Windows.Forms.MouseEventHandler(this.pnlPaint_MouseDown);
            // 
            // radioButtonTr
            // 
            this.radioButtonTr.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.radioButtonTr.AutoSize = true;
            this.radioButtonTr.Location = new System.Drawing.Point(396, 419);
            this.radioButtonTr.Name = "radioButtonTr";
            this.radioButtonTr.Size = new System.Drawing.Size(112, 21);
            this.radioButtonTr.TabIndex = 4;
            this.radioButtonTr.TabStop = true;
            this.radioButtonTr.Text = "Треугольник";
            this.radioButtonTr.UseVisualStyleBackColor = true;
            // 
            // radioButtonCir
            // 
            this.radioButtonCir.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.radioButtonCir.AutoSize = true;
            this.radioButtonCir.Location = new System.Drawing.Point(556, 420);
            this.radioButtonCir.Name = "radioButtonCir";
            this.radioButtonCir.Size = new System.Drawing.Size(58, 21);
            this.radioButtonCir.TabIndex = 5;
            this.radioButtonCir.TabStop = true;
            this.radioButtonCir.Text = "Круг";
            this.radioButtonCir.UseVisualStyleBackColor = true;
            // 
            // radioButtonSq
            // 
            this.radioButtonSq.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.radioButtonSq.AutoSize = true;
            this.radioButtonSq.Location = new System.Drawing.Point(682, 420);
            this.radioButtonSq.Name = "radioButtonSq";
            this.radioButtonSq.Size = new System.Drawing.Size(84, 21);
            this.radioButtonSq.TabIndex = 6;
            this.radioButtonSq.TabStop = true;
            this.radioButtonSq.Text = "Квадрат";
            this.radioButtonSq.UseVisualStyleBackColor = true;
            // 
            // FormCircles
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(832, 453);
            this.Controls.Add(this.radioButtonSq);
            this.Controls.Add(this.radioButtonCir);
            this.Controls.Add(this.radioButtonTr);
            this.Controls.Add(this.btColor);
            this.Controls.Add(this.pnlPaint);
            this.Controls.Add(this.isMultipleSelection);
            this.Controls.Add(this.isWorkingWithCtrl);
            this.KeyPreview = true;
            this.MinimumSize = new System.Drawing.Size(850, 500);
            this.Name = "FormCircles";
            this.Text = "FormCircles";
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.FormCircles_KeyDown);
            this.KeyUp += new System.Windows.Forms.KeyEventHandler(this.FormCircles_KeyUp);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.CheckBox isWorkingWithCtrl;
        private System.Windows.Forms.CheckBox isMultipleSelection;
        private System.Windows.Forms.ColorDialog colorDialog;
        private System.Windows.Forms.Button btColor;
        private System.Windows.Forms.Panel pnlPaint;
        private System.Windows.Forms.RadioButton radioButtonTr;
        private System.Windows.Forms.RadioButton radioButtonCir;
        private System.Windows.Forms.RadioButton radioButtonSq;
    }
}

