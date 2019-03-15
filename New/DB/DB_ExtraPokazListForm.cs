using BSB.Common.DB;
using Oracle.DataAccess.Client;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;

namespace ARM_User.New.DB
{
    class DB_ExtraPokazListForm
    {
        private OracleConnection pConncection;

        public DB_ExtraPokazListForm(OracleConnection conn)
        {
            pConncection = conn;
        }
        public void getReadList(ref DataSet ds, DateTime date_)
        {
            if (ds.Tables.Contains("TableList1"))   ds.Tables["TableList1"].Clear();

            OracleCommand cmd = pConncection.CreateCommand();
            try
            {
                cmd.BindByName = true;
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "PREPARED.g_read_g_extra_pokaz_list"; //gzet_manual_obl --> get_adm_users                
                cmd.Parameters.Add("cur", OracleDbType.RefCursor, ParameterDirection.Output);
                cmd.Parameters.Add("date_", OracleDbType.Date, date_.Date, ParameterDirection.Input);
                cmd.Parameters.Add("err_code", OracleDbType.Int16, ParameterDirection.Output);
                cmd.Parameters.Add("err_msg", OracleDbType.Clob, ParameterDirection.Output);

                OracleDataAdapter oda = new OracleDataAdapter(cmd);
                try
                {
                    oda.Fill(ds.Tables["TableList1"]);                    
                }
                catch (Exception oe)
                {
                    DBSupport.DBErrorHandler(942, oe.Message + Environment.NewLine + "(occured in DB_ExtraPokazListForm.getReadList)");
                }
                finally
                {
                    oda.Dispose();
                }
            }
            finally
            {
                cmd.Dispose();
            }
        }
        public void getReadList2(ref DataSet ds, DateTime date_, Int32 id_)
        {
            if (ds.Tables.Contains("TableList2")) ds.Tables["TableList2"].Clear();

            OracleCommand cmd = pConncection.CreateCommand();
            try
            {
                cmd.BindByName = true;
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "PREPARED.g_read_g_extra_pokaz_list2"; //gzet_manual_obl --> get_adm_users                
                cmd.Parameters.Add("cur", OracleDbType.RefCursor, ParameterDirection.Output);
                cmd.Parameters.Add("date_", OracleDbType.Date, date_.Date, ParameterDirection.Input);
                cmd.Parameters.Add("id_", OracleDbType.Decimal, id_, ParameterDirection.Input);
                cmd.Parameters.Add("err_code", OracleDbType.Int16, ParameterDirection.Output);
                cmd.Parameters.Add("err_msg", OracleDbType.Clob, ParameterDirection.Output);

                OracleDataAdapter oda = new OracleDataAdapter(cmd);
                try
                {
                    oda.Fill(ds.Tables["TableList2"]);
                }
                catch (Exception oe)
                {
                    DBSupport.DBErrorHandler(942, oe.Message + Environment.NewLine + "(occured in DB_ExtraPokazListForm.getReadList)");
                }
                finally
                {
                    oda.Dispose();
                }
            }
            finally
            {
                cmd.Dispose();
            }
        }
        public void getPopupRead(ref DataSet ds, DateTime date_, Int32 id_=0)
        {
            if (ds.Tables.Contains("TablePopup")) ds.Tables["TablePopup"].Clear();

            OracleCommand cmd = pConncection.CreateCommand();
            try
            {
                cmd.BindByName = true;
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "PREPARED.g_read_g_extra_pokaz_popup";
                cmd.Parameters.Add("cur", OracleDbType.RefCursor, ParameterDirection.Output);
                cmd.Parameters.Add("id_", OracleDbType.Int32, id_, ParameterDirection.Input);
                cmd.Parameters.Add("date_", OracleDbType.Date, date_.Date, ParameterDirection.Input);
                cmd.Parameters.Add("err_code", OracleDbType.Int16, ParameterDirection.Output);
                cmd.Parameters.Add("err_msg", OracleDbType.Clob, ParameterDirection.Output);

                OracleDataAdapter oda = new OracleDataAdapter(cmd);
                try
                {
                    oda.Fill(ds.Tables["TablePopup"]);
                }
                catch (Exception oe)
                {
                    DBSupport.DBErrorHandler(942, oe.Message + Environment.NewLine + "(occured in DB_ExtraPokazListForm.getReadList)");
                }
                finally
                {
                    oda.Dispose();
                }
            }
            finally
            {
                cmd.Dispose();
            }
        }
        // ADD FORM STORE PROCEDURES
        public void viewCusomerMap(
                                    // IN
                                    Int32 customer_sid_,
                                    DateTime report_date_,
                                    Int32 abs_dimension_id_,
                                    Int32 pokaz_id_,
                                    // out
                                    out String dim_name_,
                                    out String part_name_,
                                    out String abs_name_,
                                    out String abs_code_,
                                    out String customer_name_,
                                    out String customer_no_)

        {
            dim_name_ = "";
            part_name_ = "";
            abs_name_ = "";
            abs_code_ = "";
            customer_name_ = "";
            customer_no_ = "";


            try
            { 
                OracleCommand cmd = pConncection.CreateCommand();
            
                cmd.BindByName = true;
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "PREPARED.pkg_interface_orepations.pro_view_customer_map"; //PREPARED

                cmd.Parameters.Add("customer_sid_", OracleDbType.Int32, ParameterDirection.Input); 
                cmd.Parameters.Add("report_date_", OracleDbType.TimeStamp, ParameterDirection.Input);
                cmd.Parameters.Add("abs_dimension_id_", OracleDbType.Int32, ParameterDirection.Input);
                cmd.Parameters.Add("pokaz_id_", OracleDbType.Int32, ParameterDirection.Input);

                cmd.Parameters.Add("dim_name_", OracleDbType.Varchar2, ParameterDirection.Output);
                cmd.Parameters.Add("part_name_", OracleDbType.Varchar2, ParameterDirection.Output);
                cmd.Parameters.Add("abs_name_", OracleDbType.Varchar2, ParameterDirection.Output);
                cmd.Parameters.Add("abs_code_", OracleDbType.Varchar2, ParameterDirection.Output);
                cmd.Parameters.Add("customer_name_", OracleDbType.Varchar2, ParameterDirection.Output);
                cmd.Parameters.Add("customer_no_", OracleDbType.Varchar2, ParameterDirection.Output);

                cmd.Parameters["customer_sid_"].Value = customer_sid_;
                cmd.Parameters["report_date_"].Value = report_date_;
                cmd.Parameters["abs_dimension_id_"].Value = abs_dimension_id_;
                cmd.Parameters["pokaz_id_"].Value = pokaz_id_;

                cmd.Parameters["dim_name_"].Size = 1024;
                cmd.Parameters["part_name_"].Size = 1024;
                cmd.Parameters["abs_name_"].Size = 1024;
                cmd.Parameters["abs_code_"].Size = 1024;
                cmd.Parameters["customer_name_"].Size = 1024;
                cmd.Parameters["customer_no_"].Size = 1024;

                cmd.ExecuteNonQuery();
            }
            catch (Exception oe)
            {
                DBSupport.DBErrorHandler(942, oe.Message + Environment.NewLine + "(occured in DB_ExtraPokazListForm.viewCusomerMap)");
            }
        }
        public void insertLoansAddMap(Int32 loan_sid_, DateTime report_date_, Int32 abs_constant_dimension_id_, String map_value_, String note_)
        {
            try
            {
                OracleCommand cmd = pConncection.CreateCommand();
                cmd.BindByName = true;
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "PREPARED.pkg_interface_orepations.pro_insert_loans_add_map";
                cmd.Parameters.Add("loan_sid_", OracleDbType.Int32, loan_sid_, ParameterDirection.Input);
                cmd.Parameters.Add("report_date_", OracleDbType.Date, report_date_, ParameterDirection.Input);
                cmd.Parameters.Add("abs_constant_dimension_id_", OracleDbType.Int32, abs_constant_dimension_id_, ParameterDirection.Input);
                cmd.Parameters.Add("map_value_", OracleDbType.Varchar2, map_value_, ParameterDirection.Input);
                cmd.Parameters.Add("note_", OracleDbType.Varchar2, note_, ParameterDirection.Input);
                cmd.ExecuteNonQuery();
            }
            catch(Exception oe)
            {
                DBSupport.DBErrorHandler(942, oe.Message + Environment.NewLine + "(occured in DB_ExtraPokazListForm.insertCostomerMap)");
            }
        }
        public void updateLoansAddMap(Int32 loan_sid_, DateTime report_date_, Int32 abs_constant_dimension_id_, String map_value_, String note_)
        {
            try
            {
                OracleCommand cmd = pConncection.CreateCommand();
                cmd.BindByName = true;
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "PREPARED.pkg_interface_orepations.pro_update_loans_add_map";
                cmd.Parameters.Add("loan_sid_", OracleDbType.Int32, loan_sid_, ParameterDirection.Input);
                cmd.Parameters.Add("report_date_", OracleDbType.Date, report_date_, ParameterDirection.Input);
                cmd.Parameters.Add("abs_constant_dimension_id_", OracleDbType.Int32, abs_constant_dimension_id_, ParameterDirection.Input);
                cmd.Parameters.Add("map_value_", OracleDbType.Varchar2, map_value_, ParameterDirection.Input);
                cmd.Parameters.Add("note_", OracleDbType.Varchar2, note_, ParameterDirection.Input);
                cmd.ExecuteNonQuery();
            }
            catch (Exception oe)
            {
                DBSupport.DBErrorHandler(942, oe.Message + Environment.NewLine + "(occured in DB_ExtraPokazListForm.updateCostomerMap)");
            }
        }
        public void deleteLoansDeleteMap(Int32 loan_sid_, DateTime report_date_, Int32 abs_constant_loans_map_id_ )
        {
            try
            {
                OracleCommand cmd = pConncection.CreateCommand();
                cmd.BindByName = true;
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "PREPARED.pkg_interface_orepations.pro_delete_loans_add_map";
                cmd.Parameters.Add("loan_sid_", OracleDbType.Int32, loan_sid_, ParameterDirection.Input);
                cmd.Parameters.Add("report_date_", OracleDbType.Date, report_date_, ParameterDirection.Input);
                cmd.Parameters.Add("abs_constant_loans_map_id_", OracleDbType.Int32, abs_constant_loans_map_id_, ParameterDirection.Input);                
                cmd.ExecuteNonQuery();
            }
            catch (Exception oe)
            {
                DBSupport.DBErrorHandler(942, oe.Message + Environment.NewLine + "(occured in DB_ExtraPokazListForm.deleteCostomerMap)");
            }
        }
        public void insertCostomerMap(Int32 customer_sid_, DateTime report_date_, Int32 abs_dimension_id_, Int32 pokaz_id_ )
        {
            try
            {
                OracleCommand cmd = pConncection.CreateCommand();
                cmd.BindByName = true;
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "PREPARED.pkg_interface_orepations.pro_insert_customer_map";
                cmd.Parameters.Add("customer_sid_", OracleDbType.Int32, customer_sid_, ParameterDirection.Input);
                cmd.Parameters.Add("report_date_", OracleDbType.Date, report_date_, ParameterDirection.Input);
                cmd.Parameters.Add("abs_dimension_id_", OracleDbType.Int32, abs_dimension_id_, ParameterDirection.Input);
                cmd.Parameters.Add("pokaz_id_", OracleDbType.Int32, pokaz_id_, ParameterDirection.Input);                
                cmd.ExecuteNonQuery();
            }
            catch (Exception oe)
            {
                DBSupport.DBErrorHandler(942, oe.Message + Environment.NewLine + "(occured in DB_ExtraPokazListForm.insertCostomerMap)");
            }
        }
        public void updateLoansAddMap(Int32 customer_sid_, DateTime report_date_, Int32 abs_dimension_id_, Int32 pokaz_id_)
        {
            try
            {
                OracleCommand cmd = pConncection.CreateCommand();
                cmd.BindByName = true;
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "PREPARED.pkg_interface_orepations.pro_update_customer_map";
                cmd.Parameters.Add("customer_sid_", OracleDbType.Int32, customer_sid_, ParameterDirection.Input);
                cmd.Parameters.Add("report_date_", OracleDbType.Date, report_date_, ParameterDirection.Input);
                cmd.Parameters.Add("abs_dimension_id_", OracleDbType.Int32, abs_dimension_id_, ParameterDirection.Input);
                cmd.Parameters.Add("pokaz_id_", OracleDbType.Int32, pokaz_id_, ParameterDirection.Input);
                cmd.ExecuteNonQuery();
            }
            catch (Exception oe)
            {
                DBSupport.DBErrorHandler(942, oe.Message + Environment.NewLine + "(occured in DB_ExtraPokazListForm.updateCostomerMap)");
            }
        }
        public void deleteLoansDeleteMap(Int32 customer_sid_, DateTime report_date_, Int32 abs_dimension_id_, Int32 pokaz_id_)
        {
            try
            {
                OracleCommand cmd = pConncection.CreateCommand();
                cmd.BindByName = true;
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "PREPARED.pkg_interface_orepations.pro_delete_customer_map";
                cmd.Parameters.Add("customer_sid_", OracleDbType.Int32, customer_sid_, ParameterDirection.Input);
                cmd.Parameters.Add("report_date_", OracleDbType.Date, report_date_, ParameterDirection.Input);
                cmd.Parameters.Add("abs_dimension_id_", OracleDbType.Int32, abs_dimension_id_, ParameterDirection.Input);
                cmd.Parameters.Add("pokaz_id_", OracleDbType.Int32, pokaz_id_, ParameterDirection.Input);
                cmd.ExecuteNonQuery();
            }
            catch (Exception oe)
            {
                DBSupport.DBErrorHandler(942, oe.Message + Environment.NewLine + "(occured in DB_ExtraPokazListForm.deleteCostomerMap)");
            }
        }
    }
}
