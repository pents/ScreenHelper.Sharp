using System.Diagnostics.CodeAnalysis;
using Pents.ScreenHelper.Sharp.Models;

namespace Pents.ScreenHelper.Sharp.Abstractions;

// TODO: Create methods with inner caching of nint pointers - without marshaling byte arrays

public interface IScreenHelper
{
    /// <summary>
    /// Gets the name of the currently active window.
    /// </summary>
    /// <returns>The name of the currently active window, or null if the operation was not successful.</returns>
    string? GetCurrentActiveWindowName();
    
    /// <summary>
    /// Tries to get the name of the currently active window.
    /// </summary>
    /// <param name="name">If the operation is successful, contains the name of the currently active window; otherwise, null.</param>
    /// <returns>true if the operation was successful; otherwise, false.</returns>
    bool TryGetCurrentActiveWindowName([NotNullWhen(true)] out string? name);

    /// <summary>
    /// Gets the current screen resolution.
    /// </summary>
    /// <returns>A <see cref="ScreenResolutionDto"/> object containing the current screen resolution, or null if the operation was not successful.</returns>
    ScreenResolutionDto GetScreenResolution();
    
    /// <summary>
    /// Tries to get the current screen resolution.
    /// </summary>
    /// <param name="dto">If the operation is successful, contains a <see cref="ScreenResolutionDto"/> object representing the current screen resolution; otherwise, null.</param>
    /// <returns>true if the operation was successful; otherwise, false.</returns>
    bool TryGetScreenResolution([NotNullWhen(true)] out ScreenResolutionDto? dto);
    
    /// <summary>
    /// Takes a screenshot of the entire screen.
    /// </summary>
    /// <returns>A <see cref="ScreenshotDto"/> object containing the screenshot, or null if the operation was not successful.</returns>
    ScreenshotDto GetScreenshot();
    
    /// <summary>
    /// Tries to take a screenshot of the entire screen.
    /// </summary>
    /// <param name="dto">If the operation is successful, contains a <see cref="ScreenshotDto"/> object representing the screenshot; otherwise, null.</param>
    /// <returns>true if the operation was successful; otherwise, false.</returns>
    bool TryGetScreenshot([NotNullWhen(true)] out ScreenshotDto? dto);
    
    /// <summary>
    /// Takes a screenshot of a specified portion of the screen.
    /// </summary>
    /// <param name="args">A PartScreenshotParams object containing the parameters for the screenshot.</param>
    /// <returns>A <see cref="ScreenshotDto"/> object containing the screenshot, or null if the operation was not successful.</returns>
    ScreenshotDto GetPartScreenshot(PartScreenshotParams args);
    
    /// <summary>
    /// Tries to take a screenshot of a specified portion of the screen.
    /// </summary>
    /// <param name="args">A PartScreenshotParams object containing the parameters for the screenshot.</param>
    /// <param name="dto">If the operation is successful, contains a <see cref="ScreenshotDto"/> object representing the screenshot; otherwise, null.</param>
    /// <returns>true if the operation was successful; otherwise, false.</returns>
    bool TryGetPartScreenshot(PartScreenshotParams args, [NotNullWhen(true)] out ScreenshotDto? dto);
    
    /// <summary>
    /// Searches for a specified image in the screen.
    /// </summary>
    /// <param name="template">A byte array representing the image to search for.</param>
    /// <returns>A <see cref="ScreenCoordsDto"/> object containing the coordinates of the found image, or null if the image was not found or if the operation was not successful.</returns>
    ScreenCoordsDto FindImageInScreen(byte[] template);
    
    /// <param name="template">A byte array representing the image to search for.</param>
    /// <param name="dto">If the operation is successful, contains a <see cref="ScreenCoordsDto"/> object representing the coordinates of the found image; otherwise, null.</param>
    /// <returns>true if the operation was successful; otherwise, false.</returns>
    bool TryFindImageInScreen(byte[] template, [NotNullWhen(true)] out ScreenCoordsDto? dto);
    
    /// <summary>
    /// Calculates the similarity between two images.
    /// </summary>
    /// <param name="first">A byte array representing the first image.</param>
    /// <param name="second">A byte array representing the second image.</param>
    /// <returns>The similarity score between the two images, or null if the operation was not successful.</returns>
    double GetImageSimilarity(byte[] first, byte[] second);

    /// <summary>
    /// Tries to calculate the similarity between two images.
    /// </summary>
    /// <param name="first">A byte array representing the first image.</param>
    /// <param name="second">A byte array representing the second image.</param>
    /// <param name="similarity">If the operation is successful, contains the similarity score between the two images; otherwise, null.</param>
    /// <returns>true if the operation was successful; otherwise, false.</returns>
    bool TryGetImageSimilarity(byte[] first, byte[] second, [NotNullWhen(true)]out double? similarity);
}