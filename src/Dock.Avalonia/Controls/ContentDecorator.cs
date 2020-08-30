using System;
using System.Diagnostics;
using Avalonia;
using Avalonia.Controls;
using Avalonia.LogicalTree;

namespace Dock.Avalonia.Controls
{
    /// <summary>
    /// Content decorator control.
    /// </summary>
    public class ContentDecorator : Decorator
    {
        internal readonly Guid _id = Guid.NewGuid();

        /// <summary>
        /// Initialize the new instance of the <see cref="ContentDecorator"/>.
        /// </summary>
        public ContentDecorator()
        {
            Debug.WriteLine($"[{_id}] ContentDecorator()");

            this.GetObservable(ChildProperty).Subscribe(child =>
            {
                Debug.WriteLine($"[{_id}] Child.Parent={child?.Parent} (Child.Name={child?.Name})");
                if (child?.Parent is ContentDecorator contentDecorator)
                {
                    Debug.WriteLine($"    [{_id}] Child.Parent._id={contentDecorator._id}");
                }
            });
        }

        /// <inheritdoc/>
        protected override void OnAttachedToLogicalTree(LogicalTreeAttachmentEventArgs e)
        {
            base.OnAttachedToLogicalTree(e);
            Debug.WriteLine($"[{_id}] {nameof(OnAttachedToLogicalTree)} (Child.Name={Child?.Name})");
            if (Child?.Parent is ContentDecorator contentDecorator)
            {
                Debug.WriteLine($"   [{_id}] Child.Parent._id={contentDecorator._id}");
            }
        }

        /// <inheritdoc/>
        protected override void OnDetachedFromLogicalTree(LogicalTreeAttachmentEventArgs e)
        {
            base.OnDetachedFromLogicalTree(e);
            Debug.WriteLine($"[{_id}] {nameof(OnDetachedFromLogicalTree)} (Child.Name={Child?.Name})");
            if (Child?.Parent is ContentDecorator contentDecorator)
            {
                Debug.WriteLine($"    [{_id}] Child.Parent._id={contentDecorator._id}");
            }
        }

        /// <inheritdoc/>
        protected override void OnAttachedToVisualTree(VisualTreeAttachmentEventArgs e)
        {
            base.OnAttachedToVisualTree(e);
            Debug.WriteLine($"[{_id}] {nameof(OnAttachedToVisualTree)} (Child.Name={Child?.Name})");
            if (Child?.Parent is ContentDecorator contentDecorator)
            {
                Debug.WriteLine($"    [{_id}] Child.Parent._id={contentDecorator._id}");
            }
        }

        /// <inheritdoc/>
        protected override void OnDetachedFromVisualTree(VisualTreeAttachmentEventArgs e)
        {
            base.OnDetachedFromVisualTree(e);
            Debug.WriteLine($"[{_id}] {nameof(OnDetachedFromVisualTree)} (Child.Name={Child?.Name})");
            if (Child?.Parent is ContentDecorator contentDecorator)
            {
                Debug.WriteLine($"    [{_id}] Child.Parent._id={contentDecorator._id}");
            }
        }
    }
}
