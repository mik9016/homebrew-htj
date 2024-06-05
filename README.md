# HEIC to JPG Converter

## Description

HEIC to JPG Converter is a command-line tool built with .NET 7 that converts HEIC images to JPG format. The tool processes all HEIC files in a specified input folder and saves the converted JPG files to an output folder. If no output folder is specified, the converted images are saved to a "ConvertedImages" folder on the desktop.

## Features

- Convert HEIC images to JPG format.
- Process all HEIC files in a specified input folder.
- Save converted images to a specified output folder or to a default folder on the desktop.
- Command-line interface with support for help and version flags.

## Prerequisites

- [.NET 7 SDK](https://dotnet.microsoft.com/download/dotnet/7.0)
- [ImageMagick](https://imagemagick.org/) and the [Magick.NET](https://github.com/dlemstra/Magick.NET) library.

## Installation

1. Clone the repository:
    ```bash
    git clone https://github.com/<USERNAME>/<REPO>.git
    cd <REPO>
    ```

2. Install the required .NET and ImageMagick libraries.

## Usage

### Build the Project

To build the project, run the following command:

```bash
dotnet build
