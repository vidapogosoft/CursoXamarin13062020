﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

using Plugin.Media;
using Plugin.Media.Abstractions;

namespace Camara1
{
    // Learn more about making custom code visible in the Xamarin.Forms previewer
    // by visiting https://aka.ms/xamarinforms-previewer
    [DesignTimeVisible(false)]
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();
        }

        private async void BtnTomaFoto_Clicked(object sender, EventArgs e)
        {
            try
            {
                await CrossMedia.Current.Initialize();

                if(!CrossMedia.Current.IsCameraAvailable || !CrossMedia.Current.IsTakePhotoSupported)
                {
                    await DisplayAlert("Camara no habilitada","Revise su dispositivo","Cerrar");
                    return;
                }

                var file = await CrossMedia.Current.TakePhotoAsync(
                    new StoreCameraMediaOptions
                    {
                        SaveToAlbum = true,
                        PhotoSize = PhotoSize.Custom,
                        CustomPhotoSize = 70
                    });


                if (file == null)
                {
                    await DisplayAlert("Camara", "No realizo captura", "Cerrar");
                    return;
                }

                this.Path.Text = file.AlbumPath;

                this.MainImage.Source = ImageSource.FromStream(() =>

                    {
                        var stream = file.GetStream();
                        file.Dispose();
                        return stream;
                    }

                    );

            }
            catch (Exception ex)
            {

                await DisplayAlert("Error",ex.Message,"Cerrar");
            }
        }

        private void BtnSubeFoto_Clicked(object sender, EventArgs e)
        {

        }

        private void BtnGrabaVideo_Clicked(object sender, EventArgs e)
        {

        }

        private void BtnSubeVideo_Clicked(object sender, EventArgs e)
        {

        }
    }
}
