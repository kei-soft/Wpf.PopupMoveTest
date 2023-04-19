using System.Windows.Controls;
using System.Windows.Controls.Primitives;

using Microsoft.Xaml.Behaviors;

namespace Wpf.PopupMoveTest
{
    public class DragMovePopupBehavior : Behavior<Popup>
    {
        protected override void OnAttached()
        {
            if (this.AssociatedObject.Child != null)
            {
                if (this.AssociatedObject.Child is Panel)
                {
                    Thumb thumb = new Thumb() { Width = 0, Height = 0 };

                    var panel = this.AssociatedObject.Child as Panel;
                    if (panel != null)
                    {
                        panel.Children.Add(thumb);
                    }

                    this.AssociatedObject.MouseDown += (s, e) =>
                    {
                        thumb.RaiseEvent(e);
                    };

                    thumb.DragDelta += (s, e) =>
                    {
                        this.AssociatedObject.HorizontalOffset += e.HorizontalChange;
                        this.AssociatedObject.VerticalOffset += e.VerticalChange;
                    };
                }
            }
        }
    }
}
