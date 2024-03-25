using Forma1_új.Model;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Forma1_új.ViewModel.Helpers
{
    public class SqlData
    {
        static string conStr = "Server=localhost;Database=forma1;Uid=root;Pwd=;";
        static MySqlConnection con = new(conStr);

        public static List<Csapat> Select()
        {
            List<Csapat> csapatok = new List<Csapat>();
            csapatok.Add(new Csapat());
            con.Open();
            MySqlCommand cmd = new MySqlCommand("SELECT * FROM csapatok", con);
            MySqlDataReader reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                csapatok.Add(new Csapat(reader));
            }
            con.Close();
            return csapatok;
        }

        public static List<Versenyző> VSelect()
        {
            List<Versenyző> versenyzők = new List<Versenyző>();
            con.Open();
            string sql = "SELECT v.ID, v.név, v.születés, v.nemzet, v.magasság, v.csapatID, c.csapatnév " + 
                        "FROM csapatok c INNER JOIN versenyzők v ON c.ID = v.csapatID " + 
                        "WHERE v.név LIKE '%e%' AND c.csapatnév LIKE '%';";
            MySqlCommand cmd = new MySqlCommand(sql, con);
            MySqlDataReader reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                versenyzők.Add(new Versenyző(reader));
            }
            con.Close();
            return versenyzők;
        }
    }
}
