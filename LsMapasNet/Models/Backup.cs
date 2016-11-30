using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using System.Linq;
using System.Web;

namespace LsMapasNet.Models
{
    public class Backup
    {
        public bool BackupDataBase(out string patharquivo)
        {
            try
            {
                string file = "C:\\Backups\\backup.sql";

                patharquivo = file;

                var constring = ConfigurationManager.ConnectionStrings["LsMapaContextconnectionString"].ConnectionString;

                if (!Directory.Exists("C:\\Backups"))
                    Directory.CreateDirectory("C:\\Backups");
                else
                {
                    Directory.Delete("C:\\Backups", true);
                    Directory.CreateDirectory("C:\\Backups");
                }


                using (MySqlConnection conn = new MySqlConnection(constring))
                {
                    using (MySqlCommand cmd = new MySqlCommand())
                    {

                        using (MySqlBackup mb = new MySqlBackup(cmd))
                        {
                            cmd.Connection = conn;
                            conn.Open();
                            mb.ExportToFile(file);
                            conn.Close();
                        }
                    }
                }
                return true;
            }
            catch(Exception Ex)
            {
                patharquivo = string.Empty;
                return false;
            }
        }
    }
}