namespace LiteNinja.GSK.UI
{
  /// <summary>
  /// Interface for a progress bar.
  /// </summary>
  public interface IProgressBar
  {
    /// <summary>
    /// The value of the progress bar.
    /// </summary>
    float Value { get; set; }
    
    float MaxValue { get; set; }
    float MinValue { get; set; }
    
    /// <summary>
    /// Set the value of the progress bar as a percentage.
    /// </summary>
    /// <param name="percentage">The percentage of the progress bar.</param>
    float Percentage { get; set; }
  }
}