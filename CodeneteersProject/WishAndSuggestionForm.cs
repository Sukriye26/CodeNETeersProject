﻿
using BusinessLayer.Concrete;
using CodeneteersProject.General;
using DataAccesLayer.Repository;
using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CodeneteersProject
{
    public partial class WishAndSuggestionForm : Form
    {
        SuggestionsManager suggestionsManager = new SuggestionsManager(new SuggestionsDAL());
        PermissionsManager permissions = new PermissionsManager(new PermissionsDAL());
        Suggestions suggestion;
        EntityLayer.Concrete.User appUser;

        private void ClearInputs()
        {
            issueTextBox.Text = string.Empty;
            messageTextBox.Text = string.Empty;
        }

        public WishAndSuggestionForm(User appUser)
        {
            InitializeComponent();
            this.appUser = appUser;
        }

        private void WishAndSuggestionForm_Load(object sender, EventArgs e)
        {

        }

        private void sendButton_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(issueTextBox.Text) || !string.IsNullOrEmpty(messageTextBox.Text))
            {
                suggestion = new Suggestions();
                suggestion.title = issueTextBox.Text;
                suggestion.description = messageTextBox.Text;
                suggestion.companyID = 1;
                suggestion.status = true;
                suggestionsManager.add(suggestion);
                MessageBox.Show("İletiniz başarıyla kaydedilmiştir. İlginiz için teşekkür ederiz.", "İşlem Başarılı!", MessageBoxButtons.OK, MessageBoxIcon.Information);

            }

            else
            {
                switch (MessageBox.Show("Konu ya da ileti alanı boş bırakılamaz.", "Uyarı!", MessageBoxButtons.RetryCancel, MessageBoxIcon.Warning))
                {
                    case DialogResult.Cancel:
                        ClearInputs();
                        //goToDashboard
                        break;
                    case DialogResult.Retry:
                        ClearInputs();
                        break;
                }
            }
        }


        private void closeButton_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void dashboardButton_Click(object sender, EventArgs e)
        {
            NavigationHelper.DashboardFormNavigation(appUser);
            this.Hide();
        }

        private void profileButton_Click(object sender, EventArgs e)
        {
            NavigationHelper.ProfileFormNavigation(appUser);
            this.Hide();
        }

        private void restButton_Click(object sender, EventArgs e)
        {
            NavigationHelper.RestFormNavigation(appUser);
            this.Hide();
        }

        private void companyButton_Click(object sender, EventArgs e)
        {
            NavigationHelper.CompaniesFormNavigation(appUser);
            this.Hide();
        }

        private void addsAndEventsButton_Click(object sender, EventArgs e)
        {
            NavigationHelper.AdvertisementsAndEventsFormNavigation(appUser);
            this.Hide();
        }

        private void jobAdvertisementsButton_Click(object sender, EventArgs e)
        {
            NavigationHelper.JobAdvertisementsFormNavigation(appUser);
            this.Hide();
        }

        private void suggestionsButton_Click(object sender, EventArgs e)
        {
            NavigationHelper.WishAndSuggestionFormNavigation(appUser);
            this.Hide();
        }

        private void logOutButton_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}
