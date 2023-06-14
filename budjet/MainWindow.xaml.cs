using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Input;

namespace budjet
{
    public partial class MainWindow : Window
    {
        private List<Data_pizda> dataList = new List<Data_pizda>();
        private List<string> coloms = new List<string>();
        private string Text_dla_pidorov;
        private string denga;
        private string tip_chlenov;
        private string Sumka_chlenov;
        private DateTime SelDate;
        private bool chlen;
        private int pizda;

        public MainWindow()
        {
            InitializeComponent();
            LoadDataFromJson();
            List_Grid.ItemsSource = dataList;
        }

        private void LoadDataFromJson()
        {
            string json = File.ReadAllText("file.json");
            dataList = JsonConvert.DeserializeObject<List<Data_pizda>>(json);
        }

        private void SaveDataToJson()
        {
            string json = JsonConvert.SerializeObject(dataList);
            File.WriteAllText("file.json", json);
        }

        private void UpdateDataGrid()
        {
            List_Grid.ItemsSource = null;
            List_Grid.ItemsSource = dataList;
        }

        private void Math_VSEGO_POOPOK(string money)
        {
            int x = Convert.ToInt32(money);
            pizda += x;
            chlen = x < 0;
            Sumka_chlenov = Math.Abs(x).ToString();
            VSEGO_POOPOK.Text = pizda.ToString();
        }

        private void knopka_add_Click(object sender, RoutedEventArgs e)
        {
            Text_dla_pidorov = name_popa3.Text;
            denga = evrei.Text;
            SelDate = Convert.ToDateTime(Date.Text);
            Math_VSEGO_POOPOK(denga);
            dataList.Add(new Data_pizda(Text_dla_pidorov, Sumka_chlenov, tip_chlenov, chlen, SelDate));
            name_popa3.Text = string.Empty;
            evrei.Text = string.Empty;
            SaveDataToJson();
            UpdateDataGrid();
        }

        private void knopka_delet_Click(object sender, RoutedEventArgs e)
        {
            Data_pizda selected = List_Grid.SelectedItem as Data_pizda;
            if (selected != null)
            {
                dataList.Remove(selected);
                SaveDataToJson();
                UpdateDataGrid();
            }
        }

        private void knopka_changer_Click(object sender, RoutedEventArgs e)
        {
            Data_pizda selected = List_Grid.SelectedItem as Data_pizda;
            if (selected != null)
            {
                // Get the updated values from the input fields
                string updatedName = name_popa3.Text;
                string updatedMoney = evrei.Text;

                // Update the selected item with the new values
                selected.Nazv = updatedName;
                selected.Denga = updatedMoney;

                // Save the changes to the JSON file
                SaveDataToJson();

                // Update the data grid
                UpdateDataGrid();
            }
        }


        private void knopka_new_tip_Click(object sender, RoutedEventArgs e)
        {
            novoe_okno novoe_okno = new novoe_okno();
            novoe_okno.ShowDialog();
            coloms.Add(novoe_okno.MyChlen_is_BIG);
            List_Combo.ItemsSource = null;
            List_Combo.ItemsSource = coloms;
        }

        private void List_Grid_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            Data_pizda selected = List_Grid.SelectedItem as Data_pizda;
            if (selected != null)
            {
                name_popa3.Text = selected.Nazv;
                evrei.Text = selected.Denga;
            }
        }

        private void List_Combo_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            tip_chlenov = List_Combo.SelectedItem as string;
        }

        private void Date_SelectedDateChanged(object sender, SelectionChangedEventArgs e)
        {
            DateTime selectedDate = Convert.ToDateTime(Date.Text);
            List<Data_pizda> todayDataList = GetItemsByDate(selectedDate);
            List_Grid.ItemsSource = todayDataList;
        }

        private List<Data_pizda> GetItemsByDate(DateTime date)
        {
            List<Data_pizda> filteredList = new List<Data_pizda>();
            foreach (var item in dataList)
            {
                if (item.Vrema.Date == date.Date)
                {
                    filteredList.Add(item);
                }
            }
            return filteredList;
        }
    }
}
