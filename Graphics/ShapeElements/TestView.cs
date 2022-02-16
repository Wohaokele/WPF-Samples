using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Media;

namespace Microsoft.Samples.Graphics
{
    public class TestView : Control
    {
        #region private properties..

        // drawings
        private List<Drawing> drawings = new List<Drawing>();

        #endregion

        #region public properties..

        // Count
        public int Count { get { return drawings.Count; } }

        #endregion

        #region protected methods..

        // OnRender(
        protected override void OnRender(DrawingContext drawingContext)
        {
            base.OnRender(drawingContext);

            foreach (var d in this.drawings)
                drawingContext.DrawDrawing(d);
        }

        #endregion

        #region public methods..

        // Clear
        public void Clear()
        {
            this.drawings.Clear();
        }

        // Add
        public void Add(Drawing shape)
        {
            this.drawings.Add(shape);
        }

        #endregion
    }

}
