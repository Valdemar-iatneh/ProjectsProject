using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Essentials;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace ProjectsProject.Pages
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ProjectsPage : ContentPage
    {
        public string pathName;

        public ProjectsPage()
        {
            InitializeComponent();
        }

        protected override void OnAppearing()
        {
            projectList.ItemsSource = App.Database.GetItems();
            base.OnAppearing();
        }

        private void UpdateList()
        {
            projectList.ItemsSource = App.Database.GetItems();
        }

        private async void GetPhotoGal(object sender, EventArgs e)
        {
            try
            {
                var photo = await MediaPicker.PickPhotoAsync();
                pathName = photo.FullPath;
            }

            catch (Exception ex)
            {
                await DisplayAlert("Ошибка получения фото из галереи", ex.Message, "OK");
            }
        }

        private async void GetPhotoCam(object sender, EventArgs e)
        {
            try
            {
                var photo = await MediaPicker.CapturePhotoAsync(new MediaPickerOptions
                {
                    Title = $"xamarin.{DateTime.Now.ToString("dd.MM.yyyy_hh.mm.ss")}.png"
                });

                Database.Model.Image image = new Database.Model.Image();
                image.Name = photo.FileName;
                image.PathImage = photo.FullPath;
            }

            catch (Exception ex)
            {
                await DisplayAlert("Ошибка получения фото из камеры", ex.Message, "OK");
            }
        }

        private void AddImage(object sender, EventArgs e)
        {
            Database.Model.Image image = new Database.Model.Image();
            image.Name = imageName.Text;
            image.PathImage = pathName;

            App.Database.SaveItem(image);
            UpdateList();
        }

        private async void projectList_ItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            Database.Model.Image selectedImage = (Database.Model.Image)e.SelectedItem;
            Pages.ImagePage imagePage = new Pages.ImagePage();
            imagePage.BindingContext = selectedImage;
            await Navigation.PushAsync(imagePage);
        }
    }
}