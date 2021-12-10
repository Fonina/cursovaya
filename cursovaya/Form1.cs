using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace curs
{
    public partial class formMain : Form
    {
        DBhelper db = new DBhelper();

        public formMain()
        {
            InitializeComponent();// инициализация компонентов
            db.ReadSettings();
            db.Connect();
            
            fillDGV();
        }

        private void fillDGV()
        {
            db.FillDataGrid("select *from data", dgvMain);
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            db.SqlCmd("insert into dish(title,time,description,ID_author,ID_country) values(' ', CAST(N'01:00:00' AS Time), ' ', (select max(ID_author) from author), (select max(ID_country) from country))");
            String idDish=db.SqlGetOneData("Select max(ID_dish) from dish",0);
            Form2 form2 = new Form2(db, idDish);
            form2.ShowDialog();
            fillDGV();
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            if (!db.checkDgvSelected(dgvMain, 0)) return;

            Form2 form2 = new Form2(db, dgvMain[0, dgvMain.SelectedRows[0].Index].Value.ToString(), true);
            form2.ShowDialog();
            fillDGV();
        }

        private void btnDel_Click(object sender, EventArgs e)
        {
             DialogResult result = MessageBox.Show("Удалить выбранный рецепт?", "Подтвердите действие", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (result == DialogResult.Yes)
                if (db.SqlCmd("delete from dish where ID_dish="+dgvMain[0, dgvMain.SelectedRows[0].Index].Value.ToString()))
                    fillDGV();
        }
    }
}
