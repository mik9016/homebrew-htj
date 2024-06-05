using System;
using System.CommandLine;
using System.CommandLine.Invocation;
using System.IO;
using ImageMagick;

class Program
{
    static async Task<int> Main(string[] args)
    {
        // Define the options
        var inputOption = new Option<string>(
            "--input",
            "The input folder path containing HEIC files.")
        {
            IsRequired = true
        };

        var outputOption = new Option<string>(
            "--output",
            "The output folder path to save converted JPG files.")
        {
            IsRequired = false
        };
       


        // Create the root command
        var rootCommand = new RootCommand
        {
            inputOption,
            outputOption
        };

        rootCommand.Description = "HEIC to JPG Converter";

        // Set the handler for the command
        rootCommand.SetHandler((string input, string output) =>
        {
            if (string.IsNullOrEmpty(input))
            {
                Console.WriteLine("Error: Input folder path is required.");
                Console.WriteLine(rootCommand.Description);
                Console.WriteLine("Usage: htj --input <inputFolderPath> [--output <outputFolderPath>]");
                return;
            }

            if (!IsValidPath(input))
            {
                Console.WriteLine("The provided input path is not valid or does not exist.");
                return;
            }

            string outputFolderPath = string.IsNullOrEmpty(output) ? Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.Desktop), "ConvertedImages") : output;

            // Ensure output folder exists
            Directory.CreateDirectory(outputFolderPath);

            // Process all HEIC files in the input folder
            ProcessFolder(input, outputFolderPath);

            Console.WriteLine("Conversion process completed.");
        }, inputOption, outputOption);

        // Invoke the root command
        return await rootCommand.InvokeAsync(args);
    }

    static bool IsValidPath(string path)
    {
        // Check if the path is in a valid format
        try
        {
            string fullPath = Path.GetFullPath(path);
        }
        catch (Exception)
        {
            return false;
        }

        // Check if the path exists and is either a directory or a file
        return Directory.Exists(path) || File.Exists(path);
    }

    static void ProcessFolder(string inputFolderPath, string outputFolderPath)
    {
        // Get all HEIC files in the folder
        string[] heicFiles = Directory.GetFiles(inputFolderPath, "*.heic", SearchOption.AllDirectories);

        foreach (string heicFilePath in heicFiles)
        {
            ConvertHeicToJpg(heicFilePath, outputFolderPath);
        }
    }

    static void ConvertHeicToJpg(string heicFilePath, string outputFolderPath)
    {
        try
        {
            Console.WriteLine($"Processing file: {heicFilePath}");

            using (MagickImage image = new MagickImage(heicFilePath))
            {
                string fileNameWithoutExtension = Path.GetFileNameWithoutExtension(heicFilePath);
                string outputFilePath = Path.Combine(outputFolderPath, fileNameWithoutExtension + ".jpg");

                image.Write(outputFilePath);

                Console.WriteLine($"Converted to: {outputFilePath}");
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine($"An error occurred while converting {heicFilePath}: {ex.Message}");
        }
    }
}
