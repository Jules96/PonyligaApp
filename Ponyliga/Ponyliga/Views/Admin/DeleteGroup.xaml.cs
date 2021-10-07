﻿using Ponyliga.Models;
using Ponyliga.Services;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Ponyliga.Views.Admin
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class DeleteGroup : ContentPage
    {
        ObservableCollection<RandomizeGroup> Groups = new ObservableCollection<RandomizeGroup>();
        ObservableCollection<RandomizeGroup> group { get { return Groups; } }
        public DeleteGroup()
        {
            InitializeComponent();
            FillUserList();
        }

        public async void FillUserList()
        {
            ApiService apiService = new ApiService();
            //Task<List<User>> task = apiService.GetAllUser(); 


            listViewRandomTeam.ItemsSource = Groups;
            int p = 0;
            int c = 1;

            List<string> position = new List<string>();
            position.Add("rechts");
            position.Add("mitte");
            position.Add("links");

            List<String> BackgroundList = new List<String>();
            BackgroundList.Add("Red");
            BackgroundList.Add("Blue");
            BackgroundList.Add("Green");
            BackgroundList.Add("Purple");
            BackgroundList.Add("Pink");

            var taskGroup = await apiService.GetAllGroups();

            if (taskGroup != null)
            {

                foreach (var group in taskGroup)
                {
                    foreach (var groups in group.teams)
                    {
                        Groups.Add(new RandomizeGroup() { groupNr = group.id, groupName = groups.name, startingPosition = position[p], BackColour = BackgroundList[c] });

                        if (p >= 2)
                        {
                            p = 0;
                            c++;
                        }
                        p++;
                    }
                }

            }
            /* else
             {
                 DisplayAlert("Achtung!", "Es sind keine Teams vorhanden!", "OK");

             }*/



        }

        private async void click_groupdelete_btn(object sender, EventArgs e)
        {
            ApiService apiService = new ApiService();
            var groups = await apiService.GetAllGroups();

            foreach (var group in groups)
            {
                foreach (var team in group.teams)
                {
                    team.groupId = null;
                    
                    await apiService.UpdateTeam(team.id.ToString(), team);
                }
                    await apiService.DeleteGroup(group.id.ToString());

            }
            Groups.Clear();
            FillUserList();

        }
    }
}