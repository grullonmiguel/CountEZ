using System.Windows;
using System.Windows.Media.Animation;

namespace CountEZ.Core.Helpers
{
    public enum AnimationType
    {
        None,
        SlideFromRight,
        SlideFromLeft,
        SlideFromTop,
        SlideFromBottom
    }

    public static class AnimationHelper
    {
        #region Public Methods

        /// <summary>
        /// Slides any object that inherits from Framework element
        /// </summary>
        /// <param name="view">The element to animate</param>
        /// <param name="seconds">The time the animation will take</param>
        public static async Task SlideFrom(this FrameworkElement view, AnimationType direction, float seconds, bool setVisibility = true)
        {
            // Get animation
            var animation = await GetThicknessAnimation(direction, seconds, view.ActualWidth);

            // Create the StoryBoard
            var sb = new Storyboard();

            // Add slide from right animation
            await sb.Slide(animation);

            // Add fade in animation
            await sb.Fade(seconds, from: 0, to: 1);

            // Start animating
            sb.Begin(view);

            // Make view visible
            if (setVisibility)
                view.Visibility = Visibility.Visible;

            // Wait for it to finish
            await Task.Delay((int)(seconds * 1000));
        }
        public static async Task SlideOut(this FrameworkElement view, AnimationType direction, float seconds, bool setVisibility = true)
        {
            // Get animation
            var animation = await GetThicknessAnimation(direction, seconds, view.ActualWidth);

            // Create the StoryBoard
            var sb = new Storyboard();

            // Add slide from right animation
            await sb.Slide(animation);

            // Add fade in animation
            await sb.Fade(seconds, from: 1, to: 0);

            // Start animating
            sb.Begin(view);

            // Make view visible
            if (setVisibility)
                view.Visibility = Visibility.Visible;

            // Wait for it to finish
            await Task.Delay((int)(seconds * 1000));
        }

        public static async Task Slide(this Storyboard sb, ThicknessAnimation animation)
        {
            await Task.CompletedTask;

            // Set the target property name
            Storyboard.SetTargetProperty(animation, new PropertyPath("Margin"));

            // Add this the storyboard
            sb.Children.Add(animation);
        }

        public static async Task Fade(this Storyboard storyBoard, float seconds, double from, double to)
        {
            await Task.CompletedTask;

            // Create the margin animate from right
            var animation = new DoubleAnimation()
            {
                Duration = new Duration(TimeSpan.FromSeconds(seconds)),
                From = from,
                To = to
            };

            // Set the target property name
            Storyboard.SetTargetProperty(animation, new PropertyPath("Opacity"));

            // Add this the storyboard
            storyBoard.Children.Add(animation);
        }

        #endregion // Public Methods

        #region Private Methods

        private static Thickness GetThickness(double left, double top, double right, double bottom)
            => new Thickness(left, top, right, bottom);

        private static Duration GetDuration(float seconds)
        => new Duration(TimeSpan.FromSeconds(seconds));

        private static async Task<ThicknessAnimation> GetThicknessAnimation(AnimationType type, float seconds, double offset, float decelerationRatio = 0.09f)
        {
            await Task.CompletedTask;
            Thickness? thickness = null;

            thickness = type switch
            {
                AnimationType.None => (Thickness?)GetThickness(0, 0, 0, 0),
                AnimationType.SlideFromRight => (Thickness?)GetThickness(offset, 0, -offset, 0),
                AnimationType.SlideFromLeft => (Thickness?)GetThickness(-offset, 0, offset, 0),
                AnimationType.SlideFromTop => (Thickness?)GetThickness(0, -offset, 0, offset),
                AnimationType.SlideFromBottom => (Thickness?)GetThickness(0, offset, 0, -offset),
                _ => (Thickness?)GetThickness(0, 0, 0, 0),
            };

            var animation = new ThicknessAnimation
            {
                // Animation duration
                Duration = GetDuration(seconds),

                // Starting point
                From = thickness,

                // Ending point
                To = GetThickness(0, 0, 0, 0),

                // Deceleration 
                DecelerationRatio = decelerationRatio
            };

            return animation;
        }
        #endregion // Private Methods
    }
}