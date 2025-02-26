﻿using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace IEgypt
{

    public partial class Edit_and_Delete_ADs : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            using (SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["constr"].ConnectionString))
            {
                con.Open();
                int Viewer_id = (int)Session["ID"];
                SqlCommand v = new SqlCommand("SELECT [location], [description] FROM advertisement WHERE viewer_id = " + Convert.ToString(Session["ID"]), con);
                DataTable dtb1 = new DataTable();
                table1.DataSource = v.ExecuteReader();
                table1.DataBind();
                con.Close();
            }
        }
        public int ItemID = 0;

        protected void Button1_Click(object sender, EventArgs e)
        {
            using (SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["constr"].ConnectionString))
            {
                con.Open();
                SqlCommand cmd = new SqlCommand("Edit_Ad", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@ad_id", ItemID);
                cmd.Parameters.AddWithValue("@description", Description.Text);
                cmd.Parameters.AddWithValue("@location", Location.Text);
                con.Close();
            }
        }

        protected void Button2_Click(object sender, EventArgs e)
        {
            using (SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["constr"].ConnectionString))
            {

                con.Open();
                int Viewer_id = (int)Session["ID"];
                SqlCommand cmd = new SqlCommand("Delete_Ads", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@ad_id", ItemID);
                cmd.ExecuteNonQuery();
                con.Close();

            }
        }

        protected void Button3_Click(object sender, EventArgs e)
        {
            //Response.Redirect("Default.aspx?e_id=" + e_id);

        }
        protected void linkselect_Click(object sender, EventArgs e)
        {
            using (SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["constr"].ConnectionString))
            {
                con.Open();
                ItemID = Convert.ToInt32(sender);
                con.Close();
            }
        }

        protected void LinkButton1_Click(object sender, EventArgs e)
        {
            using (SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["constr"].ConnectionString))
            {
                con.Open();
                ItemID = Convert.ToInt32(sender);
                con.Close();
            }
        }

        protected void TextBox1_TextChanged(object sender, EventArgs e)
        {

        }

        protected void TextBox2_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
