namespace MobilityScm.Modelo.Vistas
{
    partial class TareaConteo
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.UiListaTareas = new Resco.Controls.AdvancedList.AdvancedList();
            this.TASK_ID = new Resco.Controls.AdvancedList.TextCell();
            this.UiBotonAceptarTarea = new Resco.Controls.AdvancedList.ButtonCell();
            this.REGIMEN = new Resco.Controls.AdvancedList.TextCell();
            this.PRIORITY = new Resco.Controls.AdvancedList.TextCell();
            this.Task = new Resco.Controls.AdvancedList.RowTemplate();
            this.SuspendLayout();
            // 
            // UiListaTareas
            // 
            this.UiListaTareas.DataRows.Clear();
            this.UiListaTareas.Dock = System.Windows.Forms.DockStyle.Fill;
            this.UiListaTareas.GradientBackColor = new Resco.Controls.AdvancedList.GradientColor(System.Drawing.Color.FromArgb(((int)(((byte)(1)))), ((int)(((byte)(40)))), ((int)(((byte)(71))))), System.Drawing.Color.Transparent, System.Drawing.Color.Transparent, System.Drawing.Color.FromArgb(((int)(((byte)(5)))), ((int)(((byte)(78)))), ((int)(((byte)(132))))), Resco.Controls.AdvancedList.FillDirection.Horizontal);
            this.UiListaTareas.Location = new System.Drawing.Point(0, 0);
            this.UiListaTareas.Name = "UiListaTareas";
            this.UiListaTareas.Size = new System.Drawing.Size(240, 400);
            this.UiListaTareas.TabIndex = 1;
            this.UiListaTareas.Templates.Add(this.Task);
            this.UiListaTareas.ButtonClick += new Resco.Controls.AdvancedList.ButtonEventHandler(this.UiListaTareas_ButtonClick);
            this.UiListaTareas.KeyUp += new System.Windows.Forms.KeyEventHandler(this.TareaConteo_KeyUp);
            // 
            // TASK_ID
            // 
            this.TASK_ID.CellSource.ColumnName = "TASK_ID";
            this.TASK_ID.DesignName = "TASK_ID";
            this.TASK_ID.ForeColor = System.Drawing.Color.White;
            this.TASK_ID.FormatString = "Tarea: {0}";
            this.TASK_ID.Location = new System.Drawing.Point(1, 4);
            this.TASK_ID.Name = "TASK_ID";
            this.TASK_ID.Size = new System.Drawing.Size(162, 16);
            this.TASK_ID.TextFont = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular);
            // 
            // UiBotonAceptarTarea
            // 
            this.UiBotonAceptarTarea.ButtonStyle = Resco.Controls.AdvancedList.ButtonCell.ButtonType.VistaStyleImageButton;
            this.UiBotonAceptarTarea.DesignName = "UiBotonAceptarTarea";
            this.UiBotonAceptarTarea.Location = new System.Drawing.Point(166, 3);
            this.UiBotonAceptarTarea.Selectable = true;
            this.UiBotonAceptarTarea.Size = new System.Drawing.Size(70, 38);
            this.UiBotonAceptarTarea.Text = "ACEPTAR";
            // 
            // REGIMEN
            // 
            this.REGIMEN.CellSource.ColumnName = "REGIMEN";
            this.REGIMEN.DesignName = "REGIMEN";
            this.REGIMEN.ForeColor = System.Drawing.Color.White;
            this.REGIMEN.FormatString = "Regimen: {0}";
            this.REGIMEN.Location = new System.Drawing.Point(0, 45);
            this.REGIMEN.Name = "REGIMEN";
            this.REGIMEN.Size = new System.Drawing.Size(108, 19);
            // 
            // PRIORITY
            // 
            this.PRIORITY.CellSource.ColumnName = "PRIORITY";
            this.PRIORITY.DesignName = "PRIORITY";
            this.PRIORITY.ForeColor = System.Drawing.Color.White;
            this.PRIORITY.FormatString = "Prioridad: {0}";
            this.PRIORITY.Location = new System.Drawing.Point(111, 45);
            this.PRIORITY.Name = "PRIORITY";
            this.PRIORITY.Size = new System.Drawing.Size(129, 19);
            // 
            // Task
            // 
            this.Task.BackColor = System.Drawing.Color.Transparent;
            this.Task.CellTemplates.Add(this.TASK_ID);
            this.Task.CellTemplates.Add(this.UiBotonAceptarTarea);
            this.Task.CellTemplates.Add(this.REGIMEN);
            this.Task.CellTemplates.Add(this.PRIORITY);
            this.Task.Height = 65;
            this.Task.Name = "Task";
            // 
            // TareaConteo
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.Controls.Add(this.UiListaTareas);
            this.Name = "TareaConteo";
            this.Size = new System.Drawing.Size(240, 400);
            this.KeyUp += new System.Windows.Forms.KeyEventHandler(this.TareaConteo_KeyUp);
            this.ResumeLayout(false);

        }

        #endregion

        internal Resco.Controls.AdvancedList.AdvancedList UiListaTareas;
        private Resco.Controls.AdvancedList.RowTemplate Task;
        private Resco.Controls.AdvancedList.TextCell TASK_ID;
        private Resco.Controls.AdvancedList.ButtonCell UiBotonAceptarTarea;
        private Resco.Controls.AdvancedList.TextCell REGIMEN;
        private Resco.Controls.AdvancedList.TextCell PRIORITY;

    }
}
