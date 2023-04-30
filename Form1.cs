using System;
using System.Configuration;
using System.Drawing;
using System.IO;
using System.Windows.Forms;
using Gestiune_Biciclete_Consola;



namespace Gestiune_Bicicleta_UI
{
   public partial class Form1 : Form
   {
      private Clase_bicicleta adminClaseBicicleta;

      private Label lblModel;
      private Label lblBrand;
      private Label lblPret;

      private Label[] lblsModel;
      private Label[] lblsBrand;
      private Label[] lblsPret;

      private const int LATIME_CONTROL = 100;
      private const int DIMENSIUNE_PAS_Y = 30;
      private const int DIMENSIUNE_PAS_X = 120;
      public Form1()
      {
         string numeFisier = ConfigurationManager.AppSettings["NumeFisier"];
         string locatieFisierSolutie = Directory.GetParent(System.IO.Directory.GetCurrentDirectory()).Parent.Parent.FullName;
         string caleCompletaFisier = locatieFisierSolutie + "\\" + numeFisier;
         adminClaseBicicleta = new Clase_bicicleta(caleCompletaFisier);

         InitializeComponent();

         //setare proprietati
         this.Size = new Size(500, 200);
         this.StartPosition = FormStartPosition.Manual;
         this.Location = new Point(100, 100);
         this.Font = new Font("Arial", 9, FontStyle.Bold);
         this.ForeColor = Color.LimeGreen;
         this.Text = "Informatii biciclete";

         //adaugare control de tip Label pentru 'Model';
         lblModel = new Label();
         lblModel.Width = LATIME_CONTROL;
         lblModel.Text = "Model";
         lblModel.Left = DIMENSIUNE_PAS_X;
         lblModel.ForeColor = Color.DarkGreen;
         this.Controls.Add(lblModel);

         //adaugare control de tip Label pentru 'Brand';
         lblBrand = new Label();
         lblBrand.Width = LATIME_CONTROL;
         lblBrand.Text = "Brand";
         lblBrand.Left = 2 * DIMENSIUNE_PAS_X;
         lblBrand.ForeColor = Color.DarkGreen;
         this.Controls.Add(lblBrand);

         //adaugare control de tip Label pentru 'Pret';
         lblPret = new Label();
         lblPret.Width = LATIME_CONTROL;
         lblPret.Text = "Pret";
         lblPret.Left = 3 * DIMENSIUNE_PAS_X;
         lblPret.ForeColor = Color.DarkGreen;
         this.Controls.Add(lblPret);
      }

      private void Form1_Load(object sender, EventArgs e)
      {
         AfiseazaBiciclete();
      }

      private void AfiseazaBiciclete()
      {
         Bicicleta[] biciclete = adminBicicletaConsola.GetBiciclete(out int nrBiciclete);

         lblsModel = new Label[nrBiciclete];
         lblsBrand = new Label[nrBiciclete];
         lblsPret = new Label[nrBiciclete];

         int i = 0;
         foreach (Bicicleta bicicleta in biciclete)
         {
            //adaugare control de tip Label pentru numele studentilor;
            lblsModel[i] = new Label();
            lblsModel[i].Width = LATIME_CONTROL;
            lblsModel[i].Text = bicicleta.Model;
            lblsModel[i].Left = DIMENSIUNE_PAS_X;
            lblsModel[i].Top = (i + 1) * DIMENSIUNE_PAS_Y;
            this.Controls.Add(lblsModel[i]);

            //adaugare control de tip Label pentru prenumele studentilor
            lblsBrand[i] = new Label();
            lblsBrand[i].Width = LATIME_CONTROL;
            lblsBrand[i].Text = bicicleta.Model;
            lblsBrand[i].Left = 2 * DIMENSIUNE_PAS_X;
            lblsBrand[i].Top = (i + 1) * DIMENSIUNE_PAS_Y;
            this.Controls.Add(lblsBrand[i]);

            //adaugare control de tip Label pentru notele studentilor
            lblsPret[i] = new Label();
            lblsPret[i].Width = LATIME_CONTROL;
            lblsPret[i].Text = string.Join(" ", bicicleta.Pret);
            lblsPret[i].Left = 3 * DIMENSIUNE_PAS_X;
            lblsPret[i].Top = (i + 1) * DIMENSIUNE_PAS_Y;
            this.Controls.Add(lblsPret[i]);
            i++;
         }
      }
   }
}