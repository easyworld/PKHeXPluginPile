namespace PluginPile.Sorting {
  partial class SettingsForm {
    /// <summary>
    /// Required designer variable.
    /// </summary>
    private System.ComponentModel.IContainer components = null;

    /// <summary>
    /// Clean up any resources being used.
    /// </summary>
    /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
    protected override void Dispose(bool disposing) {
      if (disposing && (components != null)) {
        components.Dispose();
      }
      base.Dispose(disposing);
    }

    #region Windows Form Designer generated code

    /// <summary>
    /// Required method for Designer support - do not modify
    /// the contents of this method with the code editor.
    /// </summary>
    private void InitializeComponent() {
      this.propertyGrid = new System.Windows.Forms.PropertyGrid();
      this.SuspendLayout();
      //
      // propertyGrid
      //
      this.propertyGrid.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
            | System.Windows.Forms.AnchorStyles.Left)
            | System.Windows.Forms.AnchorStyles.Right)));
      this.propertyGrid.Location = new System.Drawing.Point(0, 0);
      this.propertyGrid.Margin = new System.Windows.Forms.Padding(0);
      this.propertyGrid.Name = "propertyGrid";
      this.propertyGrid.Size = new System.Drawing.Size(315, 400);
      this.propertyGrid.TabIndex = 0;
      //
      // SettingsForm
      //
      this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
      this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
      this.ClientSize = new System.Drawing.Size(314, 401);
      this.Controls.Add(this.propertyGrid);
      this.Name = "SettingsForm";
      this.ShowIcon = false;
      this.Text = "Sorting Plugin Settings";
      this.ResumeLayout(false);

    }

    #endregion

    public System.Windows.Forms.PropertyGrid propertyGrid;
  }
}
