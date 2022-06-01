using QuizzGUI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace QuizzGUI.Behaviors
{
    public class CarouselViewBehavior: Behavior<CarouselView>
    {
        private int previousIndex;


        private void Animation(CarouselView carousel, int selectedIndex)
        {
            if(carousel != null && carousel.ItemsSource != null && carousel.ItemsSource.Cast<object>().Count() > 0)
            {
                int itemsCount = carousel.ItemsSource.Cast<object>().Count();
                int.TryParse(selectedIndex.ToString(), out int index);

                var items = carousel.ItemsSource.Cast<object>().ToList();

                var CurrentItem = items[index];
                var ChildElement = (((CurrentItem as Boarding).CarouselItem as ContentView).Children[0] as StackLayout).Children.ToList();

                if(ChildElement != null && ChildElement.Count > 0)
                {
                    StartAnimation(ChildElement, CurrentItem as Boarding);
                }

                if (index != previousIndex)
                {
                    var PreviousItem = items[previousIndex];
                    
                    var PreviousChildElement = (((PreviousItem as Boarding).CarouselItem as ContentView).Children[0] as StackLayout).Children.ToList();


                    if(PreviousChildElement != null && PreviousChildElement.Count >0)
                    {
                        PreviousChildElement[0].FadeTo(0, 250);
                        PreviousChildElement[1].FadeTo(0, 250);
                        PreviousChildElement[1].TranslateTo(0, 60,250);
                        PreviousChildElement[1].TranslateTo(0.5, 250);

                        PreviousChildElement[2].FadeTo(0, 250);
                        PreviousChildElement[2].TranslateTo(0,60, 250);

                    }
                }

                previousIndex = index;

            }

        }

        public async void StartAnimation(List<View> childElement, Boarding boarding)
        {
            var fadeAnimationImage = childElement[0].FadeTo(1, 250);
            var fadeAnimationTaskTitle = childElement[1].FadeTo(1, 1000);
            var translateAnimation = childElement[1].TranslateTo(0,0, 500);
            var ScaleAnimationTitle = childElement[1].ScaleTo(1, 500, Easing.SinIn);
            var fadeAnimationTaskDescriptionTime = childElement[2].FadeTo(1, 1000);
            var TranslateDescriptionAnimation = childElement[2].TranslateTo(0,0, 500);

            var animation = new Animation();

            var scaleDownAnimation = new Animation(v => childElement[0].Scale = v, 0.5, 1, Easing.SinIn);
            animation.Add(0, 1, scaleDownAnimation);
            animation.Commit(boarding.CarouselItem as ContentView, "animation", 16, 500);

            await Task.WhenAll(fadeAnimationTaskDescriptionTime, fadeAnimationTaskTitle, translateAnimation,
                ScaleAnimationTitle, fadeAnimationTaskDescriptionTime, fadeAnimationImage);
        }

        protected override void OnAttachedTo(CarouselView carousel)
        {
            base.OnAttachedTo(carousel);
            carousel.PositionChanged += Carousel_PsitionChanged;
            carousel.BindingContextChanged += Carousel_BindinContextChanged;
        }

        protected override void OnDetachingFrom(CarouselView carousel)
        {
            base.OnDetachingFrom(carousel);
            carousel.PositionChanged -= Carousel_PsitionChanged;
            carousel.BindingContextChanged -= Carousel_BindinContextChanged;
        }

        private void Carousel_BindinContextChanged(object sender, EventArgs e)
        {
            Task.Delay(500).ContinueWith(t => Animation(sender as CarouselView, 0));
        }

        private void Carousel_PsitionChanged(object sender, PositionChangedEventArgs e)
        {
            CarouselView carousel = (CarouselView)sender;
            Animation(carousel, e.CurrentPosition);
            
        }
    }
}
