## Legal Notice

Please note that this project is under active development and as such, **_no licenses are currently being granted_** for use in any personal, academic or commercial projects. Upon completion of active development in the coming months, the project will be licensed under the GNU General Public License (version 3), with additional commercial licensing available as required.

---

![image](https://user-images.githubusercontent.com/9104853/169084855-c4de8e04-544d-4007-86dc-92d888238cf5.png)

BetterControls is a set of **enhanced** .NET 6 implementations of various native Windows API controls, including the Windows **split button**, **toolbar**, **Rebar**, **image combo box** among others. **including both client & server implementations**. Better Controls is designed to be **extensible and as easy-to-use** as desired from the ground up, depending on the use cases required. Where a Better control builds on an existing .NET implementation, the control mimics that control similarly.

![Build Passing](https://img.shields.io/badge/build-passing-brightgreen)

The library implements the vast majority of the [Remote Framebuffer Protocol (RFB)](https://tools.ietf.org/html/rfc6143) specification, including well-known and custom encoding algorithms, such as variations of **Tiled Run-Length Encoding (TRLE)**, as well as standard authentication mechanisms. Much of the implementation is easily extensible using specific documented interface implementations; or you can simply use the standard implementation, depending on your individual requirements. Whilst the library is build using cross-platform technology, the current implementations only caters for Windows®. This is due to the complex mechanisms that are needed to efficiently access the framebuffer, and how this and other features are vastly different between platforms.

## Packages

SharpVNC is available as a binary from NuGet [https://www.nuget.org/packages/BetterControls/](https://www.nuget.org/packages/BetterControls/). etter Controls must be consumed in a project via NuGet - that is, you can't reference the compiled library directly. This is a limitation relating to the .NET 6 Windows Forms designer.

## Project

The core logic for both the client and server for SharpVNC Core can be found in the `SharpVNC.Core` project. Any other logic that is specific to a given platform can be found in the `SharpVNC.Core.X` projects, such as `SharpVNC.Core.Windows` for Windows® specific logic. Core logic includes the base implementation of the Remote Framebuffer Protocol (RGB), as well as the necessary abstractions in order to apply the protocol in practise for a given platform. The platform specific projects can then be used against the abstractions to apply operating system specific functionality.

The SharpVNC packages make use of a number of external libraries, including SharpDX (a managed wrapper around DirectX) and LZ4. `ILRepack` package is used (similar to `ILMerge`) to merge the external assemblies in and make its members private. All such uses of external libraries are correctly licensed, and the licenses for which can be found in the `licensing` folder. This is to hepl alleviate any issues surrounding package conflict.

![image](https://user-images.githubusercontent.com/9104853/169084083-4aef1622-b763-409a-9dfe-92a422b09fac.png)

*Better Menu Bar, a toolbar that exhibits the required behavior for a menu bar. This was implemented using [guidance from Microsoft](https://docs.microsoft.com/en-us/windows/win32/controls/cc-faq-iemenubar).*

### License

Better Controls does not currently have any license attached as it is still under active development. It will be licensed under the MIT license when complete, and as the MIT license is very permissive, there are no commercial licensing options available.

This library makes small references to the .NET Framework Reference Source, that is distributed under the Microsoft Reference Source License (MS-RSL).

## Getting Started

Better Controls must be consumed in a project via NuGet - that is, you can't reference the compiled library directly. This is a limitation relating to the .NET 6 Windows Forms designer.

Once the library is installed via NuGet, all available controls will show in the toolbox. These controls can be dragged and dropped to the parent control (typically a form) in the exact same way as any other control. The controls should be configured using the Property Window, or in code, as deemed appropriate. See the Wiki for guidance on getting started with specific controls.

## Contributors & Contributing

The following have made significant contributions to SharpVNC Core:

<a href="https://github.com/jamiehighfield/jamiehighfield/graphs/contributors">
  <img src="https://contrib.rocks/image?repo=jamiehighfield/jamiehighfield" />
</a>


If you wish to contribute to this project, please see [contributing.md](contributing.md). For more information, please contact [support@sharpvnc.com](mailto:support@sharpvnc.com).
