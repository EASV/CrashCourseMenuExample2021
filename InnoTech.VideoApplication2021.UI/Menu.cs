using System;
using System.Data;
using System.Runtime.InteropServices;
using InnoTech.VideoApplication2021.BuinessLogic;
using InnoTech.VideoApplication2021.Models;

namespace InnoTech.VideoApplication2021.UI
{
    internal class Menu
    {
        private readonly VideoManager _videoManager;

        public Menu()
        {
            _videoManager = new VideoManager();
        }
        public void Start()
        {
            ShowWelcomeGreeting();
            StartLoop();
        }

        private void StartLoop()
        {
            int choice;
            while ((choice = GetMainMenuSelection()) != 0)
            {
                if (choice == 1)
                {
                    CreateVideo();
                } 
                else if (choice == 5)
                {
                    SearchVideo();
                }
                else if (choice == -1 )
                {
                    PleaseTryAgain();
                }
            }
        }

        private void Clear()
        {
            Console.Clear();
        }
        private void SearchVideo()
        {
            Print(StringConstants.WhatToSearchFor);
            int choice;
            while ((choice = GetVideoSearchMenuSelection()) != 0)
            {
                if (choice == 1)
                {
                    Print("Type Id to search for");
                    var idToSearchFor = Console.ReadLine();
                    Print($"You searched for Id {idToSearchFor}");
                }
                else if (choice == -1)
                {
                    Print(StringConstants.PleaseSelectCorrectSearchOptions);
                }
            }
        }

        private int GetVideoSearchMenuSelection()
        {
            var selectionString = Console.ReadLine();
            int selection;
            if (int.TryParse(selectionString, out selection))
            {
                return selection;
            }
            return -1;
        }

        private void CreateVideo()
        {
            PrintNewLine();
            Print(StringConstants.CreateVideoGreeting);
            Print(StringConstants.VideoName);
            var videoName = Console.ReadLine();
            Print(StringConstants.VideoStoryLine);
            var videoStoryLine = Console.ReadLine();
            //Call Service
            var video = new Video
            {
                Title = videoName,
                StoryLine = videoStoryLine
            };
            video = _videoManager.Create(video);
            Print($"Video With Following Properties Created - Id: {video.Id.Value} Title: {video.Title} StoryLine: {video.StoryLine}");
            PrintNewLine();
        }

        private void PleaseTryAgain()
        {
            Print(StringConstants.PleaseSelectCorrectItem);
        }

        private int GetMainMenuSelection()
        {
            ShowMainMenu();
            PrintNewLine();
            var selectionString = Console.ReadLine();
            int selection;
            if (int.TryParse(selectionString, out selection))
            {
                return selection;
            }
            return -1;
        }
        
        private void ShowMainMenu()
        {
            PrintNewLine();
            Print(StringConstants.PleaseSelectMain);
            Print(StringConstants.CreateVideoMenuText);
            Print(StringConstants.ShowAllVideosMenuText);
            Print(StringConstants.ExitMainMenuText);
        }

        private void PrintNewLine()
        {
           Console.WriteLine("");
        }

        private void Print(string value)
        {
            Console.WriteLine(value);
        }

        private void ShowWelcomeGreeting()
        {
            Console.WriteLine(StringConstants.WelcomeGreeting);
        }
    }
}