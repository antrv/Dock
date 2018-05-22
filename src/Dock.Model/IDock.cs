﻿// Copyright (c) Wiesław Šoltés. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.
using System.Collections.Generic;

namespace Dock.Model
{
    /// <summary>
    /// Navigation service contract.
    /// </summary>
    public interface INavigationService
    {
        /// <summary>
        /// Gets or sets current view.
        /// </summary>
        IDock CurrentView { get; set; }

        /// <summary>
        /// Gets a value that indicates whether there is at least one entry in back navigation history.
        /// </summary>
        bool CanGoBack { get; }

        /// <summary>
        /// Gets a value that indicates whether there is at least one entry in forward navigation history.
        /// </summary>
        bool CanGoForward { get; }

        /// <summary>
        /// Navigates to the most recent entry in back navigation history, if there is one.
        /// </summary>
        void GoBack();

        /// <summary>
        /// Navigate to the most recent entry in forward navigation history, if there is one.
        /// </summary>
        void GoForward();

        /// <summary>
        /// Navigate to content that is contained by an object.
        /// </summary>
        /// <param name="root">An object that contains the content to navigate to.</param>
        void Navigate(object root);
    }

    /// <summary>
    /// Windows service contract.
    /// </summary>
    public interface IWindowsService
    {
        /// <summary>
        /// Gets or sets windows.
        /// </summary>
        IList<IDockWindow> Windows { get; set; }

        /// <summary>
        /// Show windows.
        /// </summary>
        void ShowWindows();

        /// <summary>
        /// Close windows.
        /// </summary>
        void CloseWindows();

        /// <summary>
        /// Adds window.
        /// </summary>
        /// <param name="window">The window to add.</param>
        void AddWindow(IDockWindow window);

        /// <summary>
        /// Removes window.
        /// </summary>
        /// <param name="window">The window to remove.</param>
        void RemoveWindow(IDockWindow window);
    }

    /// <summary>
    /// Dock contract.
    /// </summary>
    public interface IDock : INavigationService, IWindowsService
    {
        /// <summary>
        /// Gets or sets id.
        /// </summary>
        string Id { get; set; }

        /// <summary>
        /// Gets or sets dock.
        /// </summary>
        string Dock { get; set; }

        /// <summary>
        /// Gets or sets width.
        /// </summary>
        double Width { get; set; }

        /// <summary>
        /// Gets or sets height.
        /// </summary>
        double Height { get; set; }

        /// <summary>
        /// Gets view title.
        /// </summary>
        string Title { get; set; }

        /// <summary>
        /// Gets view context.
        /// </summary>
        object Context { get; set; }

        /// <summary>
        /// Gets or sets views.
        /// </summary>
        IList<IDock> Views { get; set; }

        /// <summary>
        /// Gets or sets dock factory.
        /// </summary>
        IDockFactory Factory { get; set; }
    }
}