﻿using System;
using System.Data;
using System.Configuration;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Xml.Linq;
using System.Data.SqlClient;
using System.Web.SessionState;
using System.IO;
using System.Text;

namespace Latihan
{
    interface ISiswa
    {
        int LihatNilaiRaport(string nis);
        void Pengumuman();
    }

    interface IGuru
    {
        
    }

    public class Controller
    {
        protected SqlConnection koneksi = new SqlConnection(ConfigurationManager.ConnectionStrings["MyConnection"].ConnectionString);
        protected SqlCommand command = new SqlCommand();
        private string query;
        private string nis;
        private string nama;
        private string alamat;
        private string jenis_kelamin;
        private string kota;
        private string sekolah;
        private string nip;
        private string id_mapel;
        private string kelas;
        private string semester;
        private string mapel;
        private string password;

        public string get_nis
        {
            get
            {
                return nis;
            }
            set
            {
                nis = value;
            }
        }
        public string get_nama
        {
            get
            {
                return nama;
            }
            set
            {
                nama = value;
            }
        }
        public string get_alamat
        {
            get
            {
                return alamat;
            }
            set
            {
                alamat = value;
            }
        }
        public string get_jeniskelamin
        {
            get
            {
                return jenis_kelamin;
            }
            set
            {
                jenis_kelamin = value;
            }
        }
        public string get_kota
        {
            get
            {
                return kota;
            }
            set
            {
                kota = value;
            }
        }
        public string get_sekolah
        {
            get
            {
                return sekolah;
            }
            set
            {
                sekolah = value;
            }
        }
        public string get_query
        {
            get
            {
                return query;
            }
            set
            {
                query = value;
            }
        }
        public string get_nip
        {
            get
            {
                return nip;
            }
            set
            {
                nip = value.ToLower();
            }
        }
        public string get_mapel
        {
            get
            {
                return mapel;
            }
            set
            {
                mapel = value.ToLower();
            }
        }
        public string get_kelas
        {
            get
            {
                return kelas;
            }
            set
            {
                kelas = value;
            }
        }
        public string get_semester
        {
            get
            {
                return semester;
            }
            set
            {
                semester = value;
            }
        }
        public string get_pelajaran
        {
            get
            {
                return id_mapel;
            }
            set
            {
                id_mapel = value;
            }
        }
        public string get_password
        {
            get
            {
                return password;
            }
            set
            {
                password = value;
            }
        }

        public DataSet GetDataKota(string sql)
        {
            this.get_query = sql;
            try
            {
                koneksi.Open();
                command.Connection = koneksi;
                command.CommandType = CommandType.Text;
                command.CommandText = query;
                SqlDataAdapter dataadapter = new SqlDataAdapter(command);
                DataSet dataset = new DataSet();
                dataadapter.Fill(dataset);
                return dataset;
            }
            catch (Exception ex)
            {
                ex.Source.ToString();
            }
            finally
            {
                koneksi.Close();
            }
            return null;
        }
        public virtual bool GetUserAndPassword(string id, string pass)
        {
            string query = "SELECT * FROM login WHERE id_panitia=@id_panitia AND password=@password";
            SqlDataReader datareader;
            try
            {
                koneksi.Open();
                command.Connection = koneksi;
                command.CommandType = CommandType.Text;
                command.CommandText = query;
                command.Parameters.Add("@id_panitia", SqlDbType.VarChar).Value = id;
                command.Parameters.Add("@password", SqlDbType.VarChar).Value = pass;
                datareader = command.ExecuteReader();
                if (datareader.Read())
                {
                    return true;
                }
                datareader.Close();
            }
            catch (Exception ex)
            {
                ex.Source.ToString();
            }
            finally
            {
                koneksi.Close();
            }
            return false;
        }
        public string GetNamaPanitia(string id)
        {
            this.get_query = "SELECT * FROM panitia WHERE id_panitia=@id_panitia";
            SqlDataReader datareader;
            try
            {
                koneksi.Open();
                command.Connection = koneksi;
                command.CommandType = CommandType.Text;
                command.CommandText = this.get_query;
                command.Parameters.Add("@id_panitia", SqlDbType.VarChar).Value = id;
                datareader = command.ExecuteReader();
                if (datareader.Read())
                {
                    return datareader.GetValue(1).ToString();
                }
                datareader.Close();             
            }
            catch (Exception ex)
            {
                ex.ToString();
            }
            finally
            {
                koneksi.Close();
            }
            return null;
        }
        public int InsertDataSiswa(string nis, string namasiswa, string alamat, string jeniskelamin, string kota, string sekolah, string panitia)
        {
            this.get_nis = nis;
            this.get_nama = namasiswa;
            this.get_alamat = alamat;
            this.get_jeniskelamin = jeniskelamin;
            this.get_kota = kota;
            this.get_sekolah = sekolah;
            string query = "INSERT INTO siswa VALUES(@nis,@nama,@alamat,@jeniskelamin,@kota,@sekolah,@panitia)";
            int result = 0;
            try
            {
                koneksi.Open();
                command.Connection = koneksi;
                command.CommandType = CommandType.Text;
                command.CommandText = query;
                command.Parameters.Add("@nis", SqlDbType.VarChar).Value = this.get_nis;
                command.Parameters.Add("@nama", SqlDbType.VarChar).Value = this.get_nama;
                command.Parameters.Add("@alamat", SqlDbType.VarChar).Value = this.get_alamat;
                command.Parameters.Add("@jeniskelamin", SqlDbType.VarChar).Value = this.get_jeniskelamin;
                command.Parameters.Add("@kota", SqlDbType.VarChar).Value = this.get_kota;
                command.Parameters.Add("@sekolah", SqlDbType.VarChar).Value = this.get_sekolah;
                command.Parameters.Add("@panitia", SqlDbType.VarChar).Value = panitia;
                result = command.ExecuteNonQuery();
                return result;
            }
            catch (Exception ex)
            {
                ex.Source.ToString();
            }
            finally
            {
                koneksi.Close();
            }
            return 0;
        }

        public int UpdateDataSiswa(string nis, string namasiswa, string alamat, string jeniskelamin, string kota, string sekolah, string panitia)
        {
            this.get_nis = nis;
            this.get_nama = namasiswa;
            this.get_alamat = alamat;
            this.get_jeniskelamin = jeniskelamin;
            this.get_kota = kota;
            this.get_sekolah = sekolah;
            this.get_query = "UPDATE siswa SET namasiswa=@nama,alamat=@alamat,jeniskelamin=@jeniskelamin,kode_kota=@kodekota,asalsekolah=@sekolah,id_panitia=@panitia WHERE nis=@nis";
            int result = 0;
            try
            {
                koneksi.Open();
                command.Connection = koneksi;
                command.CommandType = CommandType.Text;
                command.CommandText = this.get_query;
                command.Parameters.Add("@nama", SqlDbType.VarChar).Value = this.get_nama;
                command.Parameters.Add("@alamat", SqlDbType.VarChar).Value = this.get_alamat;
                command.Parameters.Add("@jeniskelamin", SqlDbType.VarChar).Value = this.get_jeniskelamin;
                command.Parameters.Add("@kodekota", SqlDbType.VarChar).Value = this.get_kota;
                command.Parameters.Add("@sekolah", SqlDbType.VarChar).Value = this.get_sekolah;
                command.Parameters.Add("@panitia", SqlDbType.VarChar).Value = panitia;
                command.Parameters.Add("@nis", SqlDbType.VarChar).Value = this.get_nis;
                result = command.ExecuteNonQuery();
                return result;
            }
            catch (Exception ex)
            {
                ex.Source.ToString();
            }
            finally
            {
                koneksi.Close();
            }
            return 0;
        }

        public int DeleteDataSiswa(string nomer)
        {
            this.get_nis = nomer;
            this.get_query = "DELETE FROM siswa WHERE nis=@nis";
            int result = 0;
            try
            {
                koneksi.Open();
                command.Connection = koneksi;
                command.CommandType = CommandType.Text;
                command.CommandText = this.get_query;
                command.Parameters.Add("@nis", SqlDbType.VarChar).Value = this.get_nis;
                result = command.ExecuteNonQuery();
                return result;
            }
            catch (Exception ex)
            {
                ex.Source.ToString();
            }
            finally
            {
                koneksi.Close();
            }
            return 0;
        }

        public DataSet DisplayDataTable(string query)
        {
            this.get_query = query;
            SqlDataAdapter dataadapter;
            DataSet dataset;
            try
            {
                koneksi.Open();
                command.Connection = koneksi;
                command.CommandType = CommandType.Text;
                command.CommandText = this.get_query;
                dataadapter = new SqlDataAdapter(command);
                dataset = new DataSet();
                dataadapter.Fill(dataset);
                return dataset;
            }
            catch (Exception ex)
            {
                ex.Source.ToString();
            }
            finally
            {
                koneksi.Close();
            }
            return null;
        }

        public string GetNamaAkun(string nis)
        {
            this.get_nis = nis;
            string query = "SELECT namasiswa FROM siswa WHERE nis=@nis";
            SqlDataReader datareader;
            try
            {
                koneksi.Open();
                command.Connection = koneksi;
                command.CommandType = CommandType.Text;
                command.CommandText = query;
                command.Parameters.Add("@nis", SqlDbType.VarChar).Value = this.get_nis;
                datareader = command.ExecuteReader();
                while (datareader.Read())
                {
                    return datareader.GetString(0);
                }
                datareader.Close();
            }
            catch (Exception ex)
            {
                ex.ToString();
            }
            finally
            {
                koneksi.Close();
            }
            return null;
        }

        public double nilai_ratarata(double tugas, double kuis, double ujian)
        {
            return (tugas + kuis + ujian) / 3;
        }

        public int SaveDataRaport(string kelas, string semester, string nis, string pelajaran, string tugas, string kuis, string ujian)
        {
            this.get_query = "INSERT INTO raport VALUES(@kelas,@semester,@nis,@pelajaran,@tugas,@kuis,@ujian)";
            this.get_nis=nis;
            try
            {
                koneksi.Open();
                command.Connection = koneksi;
                command.CommandType = CommandType.Text;
                command.CommandText = this.get_query;
                command.Parameters.Add("@kelas", SqlDbType.VarChar).Value = kelas;
                command.Parameters.Add("@semester", SqlDbType.VarChar).Value = semester;
                command.Parameters.Add("@nis", SqlDbType.VarChar).Value = this.get_nis;
                command.Parameters.Add("@pelajaran", SqlDbType.VarChar).Value = pelajaran;
                command.Parameters.Add("@tugas", SqlDbType.Int).Value = Convert.ToInt32(tugas);
                command.Parameters.Add("@kuis", SqlDbType.Int).Value = Convert.ToInt32(kuis);
                command.Parameters.Add("@ujian", SqlDbType.Int).Value = Convert.ToInt32(ujian);
                return command.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                ex.ToString();
            }
            finally
            {
                koneksi.Close();
            }
            return 0;
        }

        public int EventHapusRaportKelas1Semester1(string kelas, string semester, string nis, string id_mapel)
        {
            this.get_query = "DELETE FROM raport WHERE kelas=@kelas AND semester=@semester AND nis=@nis AND id_mapel=@id_mapel";
            this.get_kelas = kelas;
            this.get_semester = semester;
            this.get_nis = nis;
            this.get_pelajaran = id_mapel;
            try
            {
                koneksi.Open();
                command.Connection = koneksi;
                command.CommandType = CommandType.Text;
                command.CommandText = this.get_query;
                command.Parameters.Add("@kelas", SqlDbType.VarChar).Value = this.get_kelas;
                command.Parameters.Add("@semester", SqlDbType.VarChar).Value = this.get_semester;
                command.Parameters.Add("@nis", SqlDbType.VarChar).Value = this.get_nis;
                command.Parameters.Add("@id_mapel", SqlDbType.VarChar).Value = this.get_pelajaran;
                return command.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                ex.ToString();
            }
            finally
            {
                koneksi.Close();
            }
            return 0;
        }

        public int SavePasswordMahasiswa(string nis, string password)
        {
            this.get_nis = nis;
            this.get_password = password;
            this.get_query = "INSERT INTO loginsiswa VALUES(@nis,@password)";
            try
            {
                koneksi.Open();
                command.Connection = koneksi;
                command.CommandType = CommandType.Text;
                command.CommandText = this.get_query;
                command.Parameters.Add("@nis", SqlDbType.VarChar).Value = this.get_nis;
                command.Parameters.Add("@password", SqlDbType.VarChar).Value = this.get_password;
                return command.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                ex.ToString();
            }
            finally
            {
                koneksi.Close();
            }
            return 0;
        }
    }

    public class siswa : Controller, ISiswa
    {
        public override bool GetUserAndPassword(string id, string pass)
        {
            string query = "SELECT * FROM loginsiswa WHERE nis=@nis AND password=@password";
            SqlDataReader datareader;
            try
            {
                koneksi.Open();
                command.Connection = koneksi;
                command.CommandType = CommandType.Text;
                command.CommandText = query;
                command.Parameters.Add("@nis", SqlDbType.VarChar).Value = id;
                command.Parameters.Add("@password", SqlDbType.VarChar).Value = pass;
                datareader = command.ExecuteReader();
                if (datareader.Read())
                {
                    return true;
                }
                datareader.Close();
            }
            catch (Exception ex)
            {
                ex.ToString();
            }
            finally
            {
                koneksi.Close();
            }
            return base.GetUserAndPassword(id, pass);
        }

        public int LihatNilaiRaport(string nis)
        {
            return 0;
        }

        public void Pengumuman()
        {

        }
    }
}