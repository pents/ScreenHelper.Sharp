using System.Diagnostics.CodeAnalysis;
using Pents.ScreenHelper.Sharp.Models;

namespace Pents.ScreenHelper.Sharp.Abstractions;

/// <summary>
/// Same as the <see cref="IScreenHelper"/>
/// but it does not marshall screenshots and gives deeper control over memory used
/// </summary>
public interface ICachingScreenHelper
{
    /// <summary>
    /// Takes a screenshot of the entire screen.
    /// </summary>
    /// <returns>A <see cref="ScreenshotDto"/> object containing the screenshot, or null if the operation was not successful.</returns>
    ScreenshotCachingDto GetScreenshot();
    
    /// <summary>
    /// Tries to take a screenshot of the entire screen.
    /// </summary>
    /// <param name="dto">If the operation is successful, contains a <see cref="ScreenshotDto"/> object representing the screenshot; otherwise, null.</param>
    /// <returns>true if the operation was successful; otherwise, false.</returns>
    bool TryGetScreenshot([NotNullWhen(true)] out ScreenshotCachingDto? dto);
    
    /// <summary>
    /// Takes a screenshot of a specified portion of the screen.
    /// </summary>
    /// <param name="args">A PartScreenshotParams object containing the parameters for the screenshot.</param>
    /// <returns>A <see cref="ScreenshotDto"/> object containing the screenshot, or null if the operation was not successful.</returns>
    ScreenshotCachingDto GetPartScreenshot(PartScreenshotParams args);
    
    /// <summary>
    /// Tries to take a screenshot of a specified portion of the screen.
    /// </summary>
    /// <param name="args">A PartScreenshotParams object containing the parameters for the screenshot.</param>
    /// <param name="dto">If the operation is successful, contains a <see cref="ScreenshotDto"/> object representing the screenshot; otherwise, null.</param>
    /// <returns>true if the operation was successful; otherwise, false.</returns>
    bool TryGetPartScreenshot(PartScreenshotParams args, [NotNullWhen(true)] out ScreenshotCachingDto? dto);
    
    /// <summary>
    /// Searches for a specified image in the screen.
    /// </summary>
    /// <param name="template">A byte array representing the image to search for.</param>
    /// <returns>A <see cref="ScreenCoordsDto"/> object containing the coordinates of the found image, or null if the image was not found or if the operation was not successful.</returns>
    ScreenCoordsDto FindImageInScreen(ScreenshotCachingDto template);
    
    /// <param name="template">A byte array representing the image to search for.</param>
    /// <param name="dto">If the operation is successful, contains a <see cref="ScreenCoordsDto"/> object representing the coordinates of the found image; otherwise, null.</param>
    /// <returns>true if the operation was successful; otherwise, false.</returns>
    bool TryFindImageInScreen(ScreenshotCachingDto template, [NotNullWhen(true)] out ScreenCoordsDto? dto);
    
    /// <summary>
    /// Calculates the similarity between two images.
    /// </summary>
    /// <param name="first">A byte array representing the first image.</param>
    /// <param name="second">A byte array representing the second image.</param>
    /// <returns>The similarity score between the two images, or null if the operation was not successful.</returns>
    double GetImageSimilarity(ScreenshotCachingDto first, ScreenshotCachingDto second);

    /// <summary>
    /// Tries to calculate the similarity between two images.
    /// </summary>
    /// <param name="first">A byte array representing the first image.</param>
    /// <param name="second">A byte array representing the second image.</param>
    /// <param name="similarity">If the operation is successful, contains the similarity score between the two images; otherwise, null.</param>
    /// <returns>true if the operation was successful; otherwise, false.</returns>
    bool TryGetImageSimilarity(ScreenshotCachingDto first, ScreenshotCachingDto second, [NotNullWhen(true)]out double? similarity);

    /// <summary>
    /// Caches image for further usage in caching methods
    /// </summary>
    /// <param name="image"></param>
    /// <returns></returns>
    ScreenshotCachingDto CacheImage(byte[] image);
}