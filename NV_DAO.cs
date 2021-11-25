using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;
using System.Data.SqlClient;

namespace QLNV
{
    class NV_DAO
    {
        /* String strCon = ConfigurationManager.ConnectionStrings["strCon"].ConnectionString;*/ // in App.config 
        MydbDataContext db = new MydbDataContext(ConfigurationManager.ConnectionStrings["strCon"].ConnectionString); // in App.config 
        public List<ChitietNV> laytatca()
        {
            //List<thongtinnv> nhanviens = new List<thongtinnv>();
            //SqlConnection con = new SqlConnection(strCon);
            //con.Open(); 
            //String strCom = "SELECT * FROM Chitietnv"; 
            //SqlCommand com = new SqlCommand(strCom, con); 
            //SqlDataReader dr = com.ExecuteReader();
            //    while (dr.Read())
            //    {
            //        thongtinnv nhanvien = new thongtinnv()
            //        {
            //            Manv = (int)dr["Manv"],
            //            Tennv = (String)dr["Ten"],
            //            Chucvu = (String)dr["Chucvu"],
            //            Phongban = (String)dr["Phongban"],
            //            Chuthich = (String)dr["Chuthich"]
            //        };
            //        nhanviens.Add(nhanvien);
            //    }
            //    con.Close();
            //    return nhanviens;

            db.ObjectTrackingEnabled = false;
            List<ChitietNV> nhanviens = db.ChitietNVs.ToList();
            return nhanviens;

        }


        public List<ChitietNV> Selectbyword(String keyword)
         {
            //List<thongtinnv> nhanviens = new List<thongtinnv>();
            //SqlConnection con = new SqlConnection(strCon);
            //con.Open();
            //String strCom = "SELECT * FROM Chitietnv WHERE Ten LIKE '%" + keyword + "%'";
            //SqlCommand com = new SqlCommand(strCom, con);
            //SqlDataReader dr = com.ExecuteReader();
            //while (dr.Read())
            //{
            //    thongtinnv nhanvien = new thongtinnv()
            //    {
            //        Manv = (int)dr["Manv"],
            //        Tennv = (String)dr["Ten"],
            //        Chucvu = (String)dr["Chucvu"],
            //        Phongban = (String)dr["Phongban"],
            //        Chuthich = (String)dr["Chuthich"]
            //    };
            //    nhanviens.Add(nhanvien);
            //}
            //con.Close();
            //return nhanviens;
            List<ChitietNV> Nhanviens = db.ChitietNVs.Where(b => b.Ten.Contains(keyword)).ToList();
            return Nhanviens;
        }


        public ChitietNV Selectbycode(int manv) 
        {
            //thongtinnv nhanvien = null;
            //SqlConnection con = new SqlConnection(strCon);
            //con.Open();
            //String strCom = "SELECT * FROM Chitietnv WHERE Manv=" + manv;
            //SqlCommand com = new SqlCommand(strCom, con);
            //SqlDataReader dr = com.ExecuteReader();
            //if (dr.Read())
            //{
            //    nhanvien = new thongtinnv()
            //    {
            //        Manv = (int)dr["Manv"],
            //        Tennv = (String)dr["Ten"],
            //        Chucvu = (String)dr["Chucvu"],
            //        Phongban = (String)dr["Phongban"],
            //        Chuthich = (String)dr["Chuthich"]
            //    };
            //}
            //con.Close();
            //return nhanvien;
            ChitietNV nhanvien = db.ChitietNVs.SingleOrDefault(b => b.Manv == manv);
            return nhanvien;
        }

        public bool Insert(ChitietNV newnhanvien)
        {
            //bool result = false;
            //SqlConnection con = new SqlConnection(strCon);
            //con.Open();
            //String strCom = "INSERT INTO Chitietnv(Ten,Chucvu,Phongban,Chuthich) VALUES(@Ten,@Chucvu,@Phongban,@Chuthich)";
            //SqlCommand com = new SqlCommand(strCom, con);
            //com.Parameters.Add(new SqlParameter("@Ten", newnhanvien.Tennv));
            //com.Parameters.Add(new SqlParameter("@Chucvu", newnhanvien.Chucvu));
            //com.Parameters.Add(new SqlParameter("@Phongban", newnhanvien.Phongban));
            //com.Parameters.Add(new SqlParameter("@Chuthich", newnhanvien.Chuthich));
            //try
            //{
            //    result = com.ExecuteNonQuery() > 0;
            //}
            //catch
            //{
            //    result = false;
            //}
            //con.Close();
            //return result;
            try
            {
                db.ChitietNVs.InsertOnSubmit(newnhanvien);
                db.SubmitChanges();
                return true;
            }
            catch { return false; }
        }

        public bool Delete(int manv)
        {
            //bool result = false;
            //SqlConnection con = new SqlConnection(strCon);
            //con.Open();
            //String strCom = "DELETE FROM Chitietnv WHERE Manv=@Manv";
            //SqlCommand com = new SqlCommand(strCom, con);
            //com.Parameters.Add(new SqlParameter("@Manv", manv));
            //try
            //{
            //    result = com.ExecuteNonQuery() > 0;
            //}
            //catch
            //{
            //    result = false;
            //}
            //con.Close();
            //return result;

            ChitietNV dbnhanvien = db.ChitietNVs.SingleOrDefault(b => b.Manv == manv);
            if (db.ChitietNVs != null)
            {
                try
                {
                    db.ChitietNVs.DeleteOnSubmit(dbnhanvien);
                    db.SubmitChanges();
                    return true;
                }
                catch { return false; }
            }
            return false;
        }


        public bool Update(ChitietNV newnhanvien)
        {
            //bool result = false;
            //SqlConnection con = new SqlConnection(strCon);
            //con.Open();
            //String strCom = "UPDATE Chitietnv SET Ten=@Ten,Chucvu=@Chucvu,Phongban=@Phongban,Chuthich=@Chuthich WHERE Manv=@Manv";
            //SqlCommand com = new SqlCommand(strCom, con);
            //com.Parameters.Add(new SqlParameter("@Ten", newnhanvien.Tennv));
            //com.Parameters.Add(new SqlParameter("@Chucvu", newnhanvien.Chucvu));
            //com.Parameters.Add(new SqlParameter("@Phongban", newnhanvien.Phongban));
            //com.Parameters.Add(new SqlParameter("@Chuthich", newnhanvien.Chuthich));
            //com.Parameters.Add(new SqlParameter("@Manv", newnhanvien.Manv));
            //try
            //{
            //    result = com.ExecuteNonQuery() > 0;
            //}
            //catch
            //{
            //    result = false;
            //}
            //con.Close();
            //return result;
            ChitietNV dbnhanvien = db.ChitietNVs.SingleOrDefault(b => b.Manv == newnhanvien.Manv);
            if(dbnhanvien != null)
            {
                try
                {
                    dbnhanvien.Ten = newnhanvien.Ten;
                    dbnhanvien.Chucvu = newnhanvien.Chucvu;
                    dbnhanvien.Phongban = newnhanvien.Phongban;
                    dbnhanvien.Chuthich = newnhanvien.Chuthich;
                    db.SubmitChanges();
                    return true;
                }
                catch { return false; }

            }
            return false;
        }
    }
        
}
