## Legal Notice

Please note that this project is under active development and as such, **_no licenses are currently being granted_** for use in any personal, academic or commercial projects. Upon completion of active development in the coming months, the project will be licensed under the MIT license, without any additional commercial licensing available.

---

![image](https://user-images.githubusercontent.com/9104853/169084855-c4de8e04-544d-4007-86dc-92d888238cf5.png)

BetterControls is a set of **enhanced** .NET 6 implementations of various native Windows API controls, including the Windows **split button**, **toolbar**, **Rebar**, **image combo box** among others. **including both client & server implementations**. Better Controls is designed to be **extensible and as easy-to-use** as desired from the ground up, depending on the use cases required. Where a Better control builds on an existing .NET implementation, the control mimics that control similarly.

![Build Passing](https://img.shields.io/badge/build-passing-brightgreen)

## Packages

Better Controls will be available as a binary from NuGet [https://www.nuget.org/packages/BetterControls/](https://www.nuget.org/packages/BetterControls/). The library must be consumed in a project via NuGet - that is, you can't reference the compiled library directly. This is a limitation relating to the .NET 6 Windows Forms designer.

## Project

Better Controls supports the following controls and functionality:

- **Toolbar** - this is a wrapper of the native Windows API toolbar, that existed in the early days of Windows. Despite .NET 5+ dropping support for the built-in wrapper, the native toolbar is still used throughout Windows and commercial applications. This wrapper brings the toolbar back to .NET 6, along with more comprehensive suppor for the underlying API, as well as some performance improvements and designer support.
- **Menu bar** - this is an extension of the native toolbar that creates drop-down menus that look and behaves like a native Windows API menu bar, but with added benefits such as being height adjustable and being able to be placed in a Rebar control. This has full accessbility and hot-tracking support, just as you would get with a traditional menu bar. This was implemented using [guidance from Microsoft](https://docs.microsoft.com/en-us/windows/win32/controls/cc-faq-iemenubar).
![image](https://user-images.githubusercontent.com/9104853/169084083-4aef1622-b763-409a-9dfe-92a422b09fac.png)
- **Menu** - this is a wrapper of the native Windows API menu, that existed in the early days of Windows. Despite .NET 5+ dropping support for the built-in wrapper, the native toolbar is still used throughout Windows and commercial applications. This wrapper brings the toolbar back to .NET 6, along with more comprehensive suppor for the underlying API, such as the ability to add images, as well as some performance improvements and designer support.
- **Rebar** - this is a wrapper of the Windows API rebar control. This was never provided in .NET, but is used throughout Windows and commercial applications. It is a native version of a .NET tool strip container, and allows toolbars and other controls to be moved around inside a set container.
- **Split Button** - this extends the .NET button wrapper and adds support for a native drop-down.
- **Combo Box** - this extends the .NET combo box using various owner-draw techniques to provide a more comprehensive combo box with added features such as images and height adjustable items.
- **Form** - this is a small extension of the .NET form with some small additional features, such as disabling the close button. It is also necessary for some of the above controls to work.

The core logic for all controls (except designer support) can be found in the `BetterControls` project. Because Microsoft Visual Studio still runs using the .NET Framework runtime, this has made design-time support for .NET Core and .NET 5+ controls increasingly convoluted, especially where a custom UI is needed. This project makes use of a pre-release designer framework for .NET 6, that uses a client-server pattern. The server (a .NET 6 project) proxies objects to the client (a .NET Framework project), where those proxied objects can be consumed in any custom UI. These can be found in `BetterControls.Designer.Client` and `BetterControls.Designer.Server`.

### License

Better Controls does not currently have any license attached as it is still under active development. It will be licensed under the MIT license when complete, and as the MIT license is very permissive, there are no commercial licensing options available.

This library makes small references to the .NET Framework Reference Source, that is distributed under the Microsoft Reference Source License (MS-RSL).

## Getting Started

Better Controls must be consumed in a project via NuGet - that is, you can't reference the compiled library directly. This is a limitation relating to the .NET 6 Windows Forms designer. *This project will not currently compile from sources, due to being incomplete. The available sources are here for reference only.*

Once the library is installed via NuGet, all available controls will show in the toolbox. These controls can be dragged and dropped to the parent control (typically a form) in the exact same way as any other control. The controls should be configured using the Property Window, or in code, as deemed appropriate. See the Wiki for guidance on getting started with specific controls.

## Contributors & Contributing

The following have made significant contributions to Better Controls:

<a href="https://github.com/jamiehighfield/jamiehighfield/graphs/contributors">
  <img src="https://contrib.rocks/image?repo=jamiehighfield/jamiehighfield" />
</a>


If you wish to contribute to this project, please see [contributing.md](contributing.md). For more information, please contact [support@sharpvnc.com](mailto:support@sharpvnc.com).
