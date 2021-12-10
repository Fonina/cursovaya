using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.Common;
using System.Windows.Forms;
using System.Data.OleDb;
using System.Data.SqlClient;
using System.IO;


public   class DBhelper
    {
        SqlConnection cn;
        String ServerName;
        String ConStr;

        private struct dataAdepterInfo
        {
            public DataSet ds;
            public DataTable dt;
            public SqlDataAdapter da;
            public object dgv;
        }
        List<dataAdepterInfo> da = new List<dataAdepterInfo>();

        //чтение настроек
        public bool ReadSettings()
        {
            //проверим наличие файла, иначе выходим
            if (!File.Exists("Settings.config"))
                return false;

            try
            {
                //читаем файл настроек
                using (StreamReader sr = new StreamReader("Settings.config", System.Text.Encoding.Default))
                {
                    //получаем строку, если не пустая то
                    String line;
                    if ((line = sr.ReadLine()) != null)
                    {
                        //зададим строку как имя сервера
                        this.SetServer(line);
                    }
                }
            }
            catch (Exception e)
            {
                MessageBox.Show("Ошибка чтения настроек приложения! Подробности:" + e.Message.ToString());
                return false;
            }

            return true;
        }

    private string wrapError(string expError)
        {
            if (expError.Contains("NOT NULL")) return "\n Пожалуйста заполните все поля!\n";

            return "Неизвестная ошибка.";
        }

        public bool GetStatusConnect()
        {
            if (cn == null) return false;
            if (cn.State != ConnectionState.Open) return false;
            
            return true;
        }


        public void SetServer(String ServerName)
        {
            this.ServerName = ServerName;

        }


        public bool Connect()
        {
            ConStr = "Data Source=" + ServerName + ";Initial Catalog=kursovaya;Integrated Security=True;Connection Timeout=1;";
            cn = new SqlConnection(ConStr);
            try { cn.Open(); }
            catch (Exception e)
            {
                MessageBox.Show("Ошибка соединения с БД! Подробности:" + e.Message.ToString());
                return false;
            }

            return true; 
        }

        public bool Disconnect()
        {
            if (!GetStatusConnect()) return true;

            try { cn.Close(); }
            catch (Exception e)
            {
                MessageBox.Show("Ошибка отключения от БД! Подробности:" + e.Message.ToString());
                return false;
            }
            return true;
        }

        public bool FillDT(String SqlCmd, DataTable dt)
        {
            if (!GetStatusConnect()) return false;

            try
            {
                SqlDataAdapter da = new SqlDataAdapter(SqlCmd, ConStr);
                da.Fill(dt);
            }
            catch (Exception e)
            {
                MessageBox.Show("Ошибка заполнения из БД! Подробности:" + e.Message.ToString());
                return false;
            }
            return true;
        }
        
        public bool FillDataGrid(String SqlCmd, DataGridView dg)
        {
            if (!GetStatusConnect()) return false;

            try
            {
                SqlDataAdapter da = new SqlDataAdapter(SqlCmd, ConStr);
            DataSet ds = new DataSet();
            da.Fill(ds, "tbl");
            dg.AutoGenerateColumns = true;
            dg.DataSource = ds.Tables["tbl"];//.DefaultView;
            dg.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dg.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;

            #if !DEBUG
                 dg.Columns[0].Visible = false;
            #endif
            }
            catch(Exception e)
            {
                MessageBox.Show("Ошибка заполнения таблицы "+dg.Name+" из БД! Подробности:"+e.Message.ToString());
                return false;
            }
            return true;
        }

        public bool FillEditableDataGrid(String SqlCmd, DataGridView dg)
        {
            if (!GetStatusConnect()) return false;

            try
            {
                dataAdepterInfo FinddaInfo = da.Find(dainfo => dainfo.dgv == dg);
                if (FinddaInfo.da != null)
                    da.Remove(FinddaInfo);
                //формируем структуру для добавления в контейнер
                dataAdepterInfo dai=new dataAdepterInfo();
                dai.da = new SqlDataAdapter(SqlCmd, ConStr);
                //запомним обьект
                dai.dgv = dg;

                //делаем команды инсерт, апдейт, делет доступными для адаптера
                SqlCommandBuilder bulder = new SqlCommandBuilder(dai.da);
                dai.da.UpdateCommand = bulder.GetUpdateCommand();
                dai.da.InsertCommand = bulder.GetInsertCommand();
                dai.da.DeleteCommand = bulder.GetDeleteCommand();

                int saveRow = 0;
                if (dg.FirstDisplayedCell!=null)
                    saveRow=dg.FirstDisplayedCell.RowIndex;
                DataSet ds = new DataSet();
                dai.da.Fill(ds);
                dai.ds = ds;
                dai.dt = ds.Tables[0];
                da.Add(dai);

                dg.AutoGenerateColumns = true;
                dg.DataSource = ds.Tables[0];//.DefaultView
                dg.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
                dg.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;

                if (saveRow != 0 && saveRow < dg.Rows.Count)
                {
                    dg.FirstDisplayedScrollingRowIndex = saveRow;
                    dg.Rows[saveRow].Selected = true;
                }

                #if !DEBUG
                 dg.Columns[0].Visible = false;
                #endif
            }
            catch (Exception e)
            {
                MessageBox.Show("Ошибка заполнения таблицы " + dg.Name + " из БД! Подробности:" + e.Message.ToString());
                return false;
            }
            return true;
        }

        public bool FillEditableDataGrid(String SqlCmd, DataGridView dg, List <string> cmdInjected, List <string> aliases, List <string> names)
        {
            if (!GetStatusConnect()) return false;

            if (cmdInjected.Count < 2)
            {
                MessageBox.Show("Недостаточно команд для адаптера данных!");
                return false;
            }

            try
            {
                dataAdepterInfo FinddaInfo = da.Find(dainfo => dainfo.dgv == dg);
                if (FinddaInfo.da != null)
                    da.Remove(FinddaInfo);

                //формируем структуру для добавления в контейнер
                dataAdepterInfo dai = new dataAdepterInfo();
                dai.da = new SqlDataAdapter(SqlCmd, ConStr);
                //запомним обьект
                dai.dgv = dg;

                //делаем команды инсерт, апдейт, делет доступными для адаптера
                SqlCommand cmd = cn.CreateCommand();
                cmd.CommandText = cmdInjected[0];
                dai.da.UpdateCommand = cmd;
                for (int i = 0; i < aliases.Count; i++)
                {
                    SqlParameter parameter = dai.da.UpdateCommand.Parameters.Add(aliases[i], SqlDbType.Int);
                    parameter.SourceColumn = names[i];
                }


                SqlCommand cmd2 = cn.CreateCommand();
                cmd2.CommandText = cmdInjected[1];
                dai.da.InsertCommand = cmd2;
                for (int i = 0; i < aliases.Count; i++)
                {
                    SqlParameter parameter2 = dai.da.InsertCommand.Parameters.Add(aliases[i], SqlDbType.Int);
                    parameter2.SourceColumn = names[i];
                }

                SqlCommand cmd3 = cn.CreateCommand();
                cmd3.CommandText = cmdInjected[2];
                dai.da.DeleteCommand = cmd3;
                for (int i = 0; i < aliases.Count; i++)
                {
                    SqlParameter parameter3 = dai.da.DeleteCommand.Parameters.Add(aliases[i], SqlDbType.Int);
                    parameter3.SourceColumn = names[i];
                }

                int saveRow = 0;
                if (dg.FirstDisplayedCell != null)
                    saveRow = dg.FirstDisplayedCell.RowIndex;
                DataSet ds = new DataSet();
                dai.da.Fill(ds);
                dai.ds = ds;
                dai.dt = ds.Tables[0];
                da.Add(dai);

                dg.AutoGenerateColumns = true;
                dg.DataSource = ds.Tables[0];//.DefaultView


                if (saveRow != 0 && saveRow < dg.Rows.Count)
                {
                    dg.FirstDisplayedScrollingRowIndex = saveRow;
                    dg.Rows[saveRow].Selected = true;
                }

#if !DEBUG
                dg.Columns[0].Visible = false;
#endif
            }
            catch (Exception e)
            {
                MessageBox.Show("Ошибка заполнения таблицы " + dg.Name + " из БД! Подробности:" + e.Message.ToString());
                return false;
            }
            return true;
        }

        public bool UpdateFromDataGrid(DataGridView dg)
        {
            if (!GetStatusConnect()) return false;

            try
            {
                dg.EndEdit();

                // Using lambda expression.. First match only
                dataAdepterInfo FinddaInfo = da.Find(dainfo => dainfo.dgv == dg);

                if (!FinddaInfo.ds.IsInitialized) return false;

                //hotfix
                if (FinddaInfo.ds.Tables[0].GetChanges() == null) return false;

                int saveRow = dg.FirstDisplayedCell.RowIndex;

                FinddaInfo.da.Update(FinddaInfo.ds.Tables[0]);
               
                if (FinddaInfo.ds != null)
                {
                    
                    FinddaInfo.ds.Clear();
                    FinddaInfo.da.Fill(FinddaInfo.ds);

                    if (saveRow != 0 && saveRow < dg.Rows.Count)
                    {
                        dg.FirstDisplayedScrollingRowIndex = saveRow;
                        dg.Rows[saveRow].Selected = true;
                    }
                }

                return true;
            }
            catch (Exception e)
            {
                MessageBox.Show("Изменения в базе данных выполнить не удалось!" + wrapError(e.Message.ToString()) + "Подробности:" + e.Message.ToString(),
                  "Уведомление о результатах", MessageBoxButtons.OK);
            }
            return false;
        }

        public bool RowDeleteInDataGrid(DataGridView dg)
        {
            if (!GetStatusConnect()) return false;

            try
            {
                //Получаем строки, которые были удалены
                DataTable t = ((DataTable)dg.DataSource).GetChanges(DataRowState.Deleted);
                // Using lambda expression.. First match only
                dataAdepterInfo FinddaInfo = da.Find(dainfo => dainfo.dgv == dg);
                FinddaInfo.da.Update(t);

                ((DataTable)dg.DataSource).AcceptChanges();

                return true;
            }
            catch (Exception e)
            {
                MessageBox.Show("Удалить строку в БД не удалось!" + wrapError(e.Message.ToString()) + "Подробности:" + e.Message.ToString(),
                  "Уведомление о результатах", MessageBoxButtons.OK);
            }
            return false;
        }

        public bool EditDataInDataTable(DataGridView dg, int row, int column, string param)
        {
            try
            {
                dataAdepterInfo FinddaInfo = da.Find(dainfo => dainfo.dgv == dg);
                FinddaInfo.ds.Tables[0].Rows[row][column] = param;
                //FinddaInfo.ds.Tables[0].AcceptChanges();
            }
            catch (Exception)
            { return false; }

            return true;
        }

        public bool FillComboBox(String SqlCmd, ComboBox cb, List<String> id)
        {
            if (!GetStatusConnect()) return false;

            try
            {
                cb.Items.Clear();
                id.Clear();
                SqlDataAdapter da = new SqlDataAdapter(SqlCmd, ConStr);
                DataTable ds = new DataTable();
                da.Fill(ds);
                if (ds.Rows.Count == 0) return false;

                for (int i = 0; i < ds.Rows.Count; i++)
                {
                    id.Add(ds.Rows[i][0].ToString());
                    
                    cb.Items.Add(ds.Rows[i][1].ToString());
                }
            }
            catch (Exception e)
            {
                MessageBox.Show("Ошибка заполнения " + cb.Name + " из БД! Подробности:" + e.Message.ToString());
                return false;
            }
            return true;
        }

       
        public bool SqlCmd(String SqlCmd)
        {
            if (!GetStatusConnect()) return false;

            try
            {
                SqlCommand cmd = cn.CreateCommand();
                cmd.CommandText = SqlCmd;
                cmd.ExecuteNonQuery();
            }
            catch (Exception e)
            {
                MessageBox.Show("Ошибка выполнения команды: " + SqlCmd + "! Подробности:" + e.Message.ToString());
                return false;
            }
            return true;
        }

        public string SqlCmdStoredProcedure(String SqlCmd)
        {
            if (!GetStatusConnect()) return "";

            try
            {
                SqlCommand cmd = cn.CreateCommand();
                cmd.CommandText = SqlCmd;

                return cmd.ExecuteScalar().ToString();
            }
            catch (Exception e)
            {
                MessageBox.Show("Ошибка выполнения команды: " + SqlCmd + "! Подробности:" + e.Message.ToString());
                return "";
            }
        }

        public String SqlGetOneData(String SqlCmd, int position)
        {
            if (!GetStatusConnect()) return "";

            try
            {
                SqlDataAdapter da = new SqlDataAdapter(SqlCmd, ConStr);
                DataTable ds = new DataTable();
                da.Fill(ds);
                
                if (ds.Rows.Count==0) return "";

                return ds.Rows[0][position].ToString();
            }
            catch (Exception e)
            {
                MessageBox.Show("Ошибка заполнения получения данных из БД! Подробности:" + e.Message.ToString());
                return "";
            }
        }

    //service
      public  bool checkDgvSelected(DataGridView dgv, int position, string messErr = "", bool errShow = false)
        {
            try
            {
                if (dgv.SelectedRows.Count == 0)
                {
                    if (errShow) MessageBox.Show(messErr);
                    return false;
                }

                if (dgv[0, dgv.SelectedRows[0].Index].Value.ToString() == "")
                {
                    if (errShow) MessageBox.Show(messErr);
                    return false;
                }
            }
            catch (Exception)
            {
                if (errShow) MessageBox.Show(messErr + "\n Ошибка проверки ключа в " + dgv.Name);
                return false;
            }

            return true;
        }
    }
