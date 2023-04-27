
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
            this.pnlPaint = new System.Windows.Forms.Panel();
            this.SuspendLayout();
            // 
            // isWorkingWithCtrl
            // 
            this.isWorkingWithCtrl.AutoSize = true;
            this.isWorkingWithCtrl.Location = new System.Drawing.Point(31, 417);
            this.isWorkingWithCtrl.Name = "isWorkingWithCtrl";
            this.isWorkingWithCtrl.Size = new System.Drawing.Size(66, 21);
            this.isWorkingWithCtrl.TabIndex = 0;
            this.isWorkingWithCtrl.Text = "CTRL";
            this.isWorkingWithCtrl.UseVisualStyleBackColor = true;
            // 
            // isMultipleSelection
            // 
            this.isMultipleSelection.AutoSize = true;
            this.isMultipleSelection.Location = new System.Drawing.Point(163, 417);
            this.isMultipleSelection.Name = "isMultipleSelection";
            this.isMultipleSelection.Size = new System.Drawing.Size(97, 21);
            this.isMultipleSelection.TabIndex = 1;
            this.isMultipleSelection.Text = "MULTIPLE";
            this.isMultipleSelection.UseVisualStyleBackColor = true;
            // 
            // pnlPaint
            // 
            this.pnlPaint.BackColor = System.Drawing.SystemColors.ControlLight;
            this.pnlPaint.Location = new System.Drawing.Point(12, 12);
            this.pnlPaint.Name = "pnlPaint";
            this.pnlPaint.Size = new System.Drawing.Size(776, 389);
            this.pnlPaint.TabIndex = 2;
            this.pnlPaint.Paint += new System.Windows.Forms.PaintEventHandler(this.pnlPaint_Paint);
            this.pnlPaint.MouseDown += new System.Windows.Forms.MouseEventHandler(this.pnlPaint_MouseDown);
            // 
            // FormCircles
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.pnlPaint);
            this.Controls.Add(this.isMultipleSelection);
            this.Controls.Add(this.isWorkingWithCtrl);
            this.KeyPreview = true;
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
        private System.Windows.Forms.Panel pnlPaint;
    }
}

