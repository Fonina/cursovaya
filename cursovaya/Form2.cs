using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace curs
{
    public partial class Form2 : Form
    {
        DBhelper db;
        String idDish;
        bool modeEdit;
        List<string> idCountry=new List<string>();
        List<string> idAuthor = new List<string>();
        List<string> idIngridients = new List<string>();
        List<string> idTypes = new List<string>();

        bool canDeleteDish = true;

        public Form2(DBhelper db, String idDish, bool modeEdit=false)
        {
            this.db = db;
            this.idDish = idDish;
            this.modeEdit = modeEdit;

            InitializeComponent();

            if (modeEdit) this.Text = "Редактирование рецепта"; else this.Text = "Добавление рецепта";

            tbName.Text = db.SqlGetOneData("select title from dish where ID_dish=" + idDish, 0);
            tbDescription.Text = db.SqlGetOneData("select description from dish where ID_dish=" + idDish, 0);
            tbTime.Text = db.SqlGetOneData("select time from dish where ID_dish=" + idDish, 0);

            fillCB();
            fillDGV();
        }

        private void fillCB()
        {
            db.FillComboBox("select *from country", cbCountry, idCountry);
            db.FillComboBox("select ID_author, surname+' '+name+' '+patronymic from author", cbAuthor, idAuthor);
            db.FillComboBox("select *from type_dishes", cbType, idTypes);
            db.FillComboBox("select *from ingredients", cbIngridient, idIngridients);

            String idsAuthor = db.SqlGetOneData("select ID_author from dish where ID_dish=" + idDish, 0);
            String idsCountry = db.SqlGetOneData("select ID_country from dish where ID_dish=" + idDish, 0);

            cbCountry.SelectedIndex = idCountry.IndexOf(idsCountry);
            cbAuthor.SelectedIndex = idAuthor.IndexOf(idsAuthor);
        }

        private void fillDGV()
        {
            db.FillDataGrid("select di.ID_dish_ingredients, i.title, di.gram from ingredients i join dish_ingredients di on i.ID_ingredients=di.ID_ingredients and di.ID_dish=" + idDish, dgvIngridients);
            db.FillDataGrid("select td.ID_type, td.title from type_dishes td join dish_type dt on td.ID_type=dt.ID_type and dt.ID_dish=" + idDish, dgvTypes);
        }

        private void cbCountry_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                if (cbCountry.Items.IndexOf(cbCountry.Text)==-1)
                {
                    db.SqlCmd("insert into country(title) values("+cbCountry.Text+")");
                    fillCB();
                }
            }

        }

        private void cbAuthor_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                if (cbAuthor.Items.IndexOf(cbAuthor.Text) == -1)
                {
                    db.SqlCmd("insert into author(surname, name, patronymic) values('" + cbAuthor.Text.Split(' ')[0] + "', '" 
                        + cbAuthor.Text.Split(' ')[1] + "','" + cbAuthor.Text.Split(' ')[2] + "')");
                    fillCB();
                }
            }
        }

        private void cbIngridient_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                if (cbIngridient.Items.IndexOf(cbIngridient.Text) == -1)
                {
                    db.SqlCmd("insert into ingredients(title) values('" + cbIngridient.Text + "')");
                    fillCB();
                }
            }
        }

        private void cbType_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                if (cbType.Items.IndexOf(cbType.Text) == -1)
                {
                    db.SqlCmd("insert into type_dishes(title) values('" + cbType.Text + "')");
                    fillCB();
                }
            }
        }

        private void btnAddIngridient_Click(object sender, EventArgs e)
        {
            if (cbIngridient.FindString(cbIngridient.Text)==-1)
            {
                db.SqlCmd("insert into ingredients(title) values('" + cbIngridient.Text + "')");
                
                fillCB();
                cbIngridient.SelectedIndex = cbIngridient.Items.Count-1;
            }

            if (db.SqlCmd("insert into dish_ingredients(ID_dish, ID_ingredients, gram) values(" + idDish + "," + idIngridients[cbIngridient.SelectedIndex]+","+
                           tbGramm.Text+");"))
            fillDGV();
        }

        private void btnAddType_Click(object sender, EventArgs e)
        {
            if (cbType.FindString(cbType.Text) == -1)
            {
                db.SqlCmd("insert into type_dishes(title) values('" + cbType.Text + "')");

                fillCB();
                cbType.SelectedIndex = cbType.Items.Count - 1;
            }

            if (db.SqlCmd("insert into dish_type(ID_dish, ID_type) values(" + idDish + "," + idTypes[cbType.SelectedIndex]+");"))
                fillDGV();
        }

        private void dgvIngridients_UserDeletingRow(object sender, DataGridViewRowCancelEventArgs e)
        {
            DialogResult result = MessageBox.Show("Удалить выбранный ингридиент?", "Подтвердите действие", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (result == DialogResult.No)
            {
                e.Cancel = true;
                return;
            }

            if (!db.SqlCmd("delete from dish_ingredients where ID_dish_ingredients="+e.Row.Cells[0]))
                e.Cancel = true;
        }

        private void dgvTypes_UserDeletingRow(object sender, DataGridViewRowCancelEventArgs e)
        {
            DialogResult result = MessageBox.Show("Удалить выбранный тип?", "Подтвердите действие", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (result == DialogResult.No)
            {
                e.Cancel = true;
                return;
            }

            if (!db.SqlCmd("delete from dish_type where ID_dish_type=" + e.Row.Cells[0]))
                e.Cancel = true;
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (db.SqlCmd("update dish set title='" + tbName.Text + "', time='" + tbTime.Text + "', description='" + tbDescription.Text +
                      "', ID_author=" + idAuthor[cbAuthor.SelectedIndex] + ", ID_country=" + idCountry[cbCountry.SelectedIndex] + " where ID_dish=" + idDish))
            {
                canDeleteDish = false;
                this.Close();
            }

        }

        private void Form2_FormClosed(object sender, FormClosedEventArgs e)
        {
            if (!modeEdit && canDeleteDish)
                db.SqlCmd("delete from dish where ID_dish=" + idDish);

            if (modeEdit && canDeleteDish) btnSave_Click(null, null);
        }
    }
}
