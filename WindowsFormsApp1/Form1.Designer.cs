namespace WindowsFormsApp1
{
    partial class Form1
    {
        /// <summary>
        /// Variável de designer necessária.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Limpar os recursos que estão sendo usados.
        /// </summary>
        /// <param name="disposing">true se for necessário descartar os recursos gerenciados; caso contrário, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Código gerado pelo Windows Form Designer

        /// <summary>
        /// Método necessário para suporte ao Designer - não modifique 
        /// o conteúdo deste método com o editor de código.
        /// </summary>
        private void InitializeComponent()
        {
            this.Train = new System.Windows.Forms.Button();
            this.button3 = new System.Windows.Forms.Button();
            this.button4 = new System.Windows.Forms.Button();
            this.webcambox = new System.Windows.Forms.PictureBox();
            this.pboxpesquisada = new System.Windows.Forms.PictureBox();
            this.lbresposta = new System.Windows.Forms.Label();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.button1 = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.LbIndexPesquisa = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.textBox2 = new System.Windows.Forms.TextBox();
            this.lbretorno = new System.Windows.Forms.Label();
            this.button2 = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.webcambox)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pboxpesquisada)).BeginInit();
            this.SuspendLayout();
            // 
            // Train
            // 
            this.Train.Location = new System.Drawing.Point(165, 452);
            this.Train.Name = "Train";
            this.Train.Size = new System.Drawing.Size(0, 23);
            this.Train.TabIndex = 1;
            this.Train.Text = "Treino";
            this.Train.UseVisualStyleBackColor = true;
            this.Train.Click += new System.EventHandler(this.Train_Click);
            // 
            // button3
            // 
            this.button3.Location = new System.Drawing.Point(260, 452);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(0, 23);
            this.button3.TabIndex = 2;
            this.button3.Text = "button3";
            this.button3.UseVisualStyleBackColor = true;
            // 
            // button4
            // 
            this.button4.Location = new System.Drawing.Point(734, 329);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(145, 23);
            this.button4.TabIndex = 3;
            this.button4.Text = "Pesquisar";
            this.button4.UseVisualStyleBackColor = true;
            this.button4.Click += new System.EventHandler(this.button4_Click);
            // 
            // webcambox
            // 
            this.webcambox.Location = new System.Drawing.Point(22, 9);
            this.webcambox.Name = "webcambox";
            this.webcambox.Size = new System.Drawing.Size(644, 364);
            this.webcambox.TabIndex = 4;
            this.webcambox.TabStop = false;
            // 
            // pboxpesquisada
            // 
            this.pboxpesquisada.Location = new System.Drawing.Point(692, 151);
            this.pboxpesquisada.Name = "pboxpesquisada";
            this.pboxpesquisada.Size = new System.Drawing.Size(211, 155);
            this.pboxpesquisada.TabIndex = 5;
            this.pboxpesquisada.TabStop = false;
            // 
            // lbresposta
            // 
            this.lbresposta.AutoSize = true;
            this.lbresposta.Location = new System.Drawing.Point(669, 9);
            this.lbresposta.Name = "lbresposta";
            this.lbresposta.Size = new System.Drawing.Size(42, 13);
            this.lbresposta.TabIndex = 6;
            this.lbresposta.Text = "id_face";
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(672, 37);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(100, 20);
            this.textBox1.TabIndex = 7;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(672, 72);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(283, 42);
            this.button1.TabIndex = 8;
            this.button1.Text = "Gravar foto";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(669, 135);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(86, 13);
            this.label1.TabIndex = 9;
            this.label1.Text = "Foto Encontrada";
            this.label1.Click += new System.EventHandler(this.label1_Click);
            // 
            // LbIndexPesquisa
            // 
            this.LbIndexPesquisa.AutoSize = true;
            this.LbIndexPesquisa.Location = new System.Drawing.Point(871, 135);
            this.LbIndexPesquisa.Name = "LbIndexPesquisa";
            this.LbIndexPesquisa.Size = new System.Drawing.Size(79, 13);
            this.LbIndexPesquisa.TabIndex = 10;
            this.LbIndexPesquisa.Text = "000000000000";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(806, 9);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(36, 13);
            this.label2.TabIndex = 11;
            this.label2.Text = "nome ";
            // 
            // textBox2
            // 
            this.textBox2.Location = new System.Drawing.Point(790, 37);
            this.textBox2.Name = "textBox2";
            this.textBox2.Size = new System.Drawing.Size(165, 20);
            this.textBox2.TabIndex = 12;
            // 
            // lbretorno
            // 
            this.lbretorno.AutoSize = true;
            this.lbretorno.Location = new System.Drawing.Point(48, 402);
            this.lbretorno.Name = "lbretorno";
            this.lbretorno.Size = new System.Drawing.Size(79, 13);
            this.lbretorno.TabIndex = 13;
            this.lbretorno.Text = "000000000000";
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(734, 378);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(145, 23);
            this.button2.TabIndex = 14;
            this.button2.Text = "Chapeu Bruxa";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(962, 440);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.lbretorno);
            this.Controls.Add(this.textBox2);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.LbIndexPesquisa);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.lbresposta);
            this.Controls.Add(this.pboxpesquisada);
            this.Controls.Add(this.webcambox);
            this.Controls.Add(this.button4);
            this.Controls.Add(this.button3);
            this.Controls.Add(this.Train);
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.webcambox)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pboxpesquisada)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Button Train;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.Button button4;
        private System.Windows.Forms.PictureBox webcambox;
        private System.Windows.Forms.PictureBox pboxpesquisada;
        private System.Windows.Forms.Label lbresposta;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label LbIndexPesquisa;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox textBox2;
        private System.Windows.Forms.Label lbretorno;
        private System.Windows.Forms.Button button2;
    }
}

