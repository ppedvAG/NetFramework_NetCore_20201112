using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data; //war standardmäßig dabei
using System.Data.SqlClient; // das habe ich via NuGet Packet Manager heruntergeladen
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using FirebirdSql;
using FirebirdSql.Data;
using FirebirdSql.Data.FirebirdClient;

namespace ADONET_DBAccess_NET5
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string connectionString = "Data Source=SURFACE-KW4;Initial Catalog=AdventureWorks2017;Integrated Security=True;";
            DataTable resultTable = new DataTable();


            int id = 85;
            //Variante 1: Hardcodiertes SQL in String (hat allerdings nachteile)
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                
                try
                {
                    //Hier könnte ein Fehler passieren....z.b keine Verbindung zur Datenbank
                    connection.Open();
                    //BEispiel 1: Eine einfache Abfrage
                    //SqlCommand command = new SqlCommand("SELECT TOP(100) * FROM Person.Person", connection);

                    //Anti-Beispiel, wie man einen Parameter (id) in das Query bekommt. 
                    //SqlCommand command = new SqlCommand("SELECT TOP(100) * FROM Person.Person WHERE Id =" + id, connection); ' - Zeichen an einem String hinzufügen 

                    #region Alternative zu "SELECT TOP(100) * FROM Person.Person WHERE Id =" + id, connection
                    //Beispiel 2: Parameterwerte in SQLQuery mithilfe von SqlCommand.Parameters
                    string query = "SELECT TOP(100) * FROM Person.Person Where BusinessEntityID = @ID";


                    SqlCommand command = new SqlCommand(query, connection);
                    command.Parameters.Add("@ID", SqlDbType.Int);
                    command.Parameters["@ID"].Value = 91;
                    #endregion

                    SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(command);
                    sqlDataAdapter.Fill(resultTable); //Hier wird SQL Query ausgeführt und das Ergebnis wird zurück geliefert. 

                    //Beispiel 3: DataReader -> schnellste Variante zum auslesen von Daten
                    SqlDataReader reader = command.ExecuteReader();
                    
                    // Call Read before accessing data.
                    while (reader.Read())
                    {
                        ReadSingleRow((IDataRecord)reader);
                    }

                    // Call Close when done reading.
                    reader.Close();


                }
                catch (Exception ex)
                {
                    //Wenn ein Fehler passiert, kann ich diesen Loggen -> ex.Message oder ex.ToString() 
                }
                finally
                {
                    //Wird ausgeführt, wenn der Quellcode keinen Fehler verursacht 
                    connection.Close();
                }
            }


            if (resultTable.Rows.Count > 0)
            {
                this.dataGridView1.DataSource = resultTable;
                
            }
        }


        private static void ReadSingleRow(IDataRecord record)
        {
            Debug.WriteLine(String.Format("{0}, {1}", record[0], record[1]));
        }

        private void button2_Click(object sender, EventArgs e)
        {
            //using (FbConnection fbConnection = new FbConnection("conectionstring abc irgendwas")
            //{
            //    fbConnection.Open();
            //    FbCommand fbCommand = new FbCommand("Select irgendwas", fbConnection);
            //}

            decimal money = 1234234234234m;
        }
    }
}
