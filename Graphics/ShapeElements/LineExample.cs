// // Copyright (c) Microsoft. All rights reserved.
// // Licensed under the MIT license. See LICENSE file in the project root for full license information.

using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Shapes;

namespace Microsoft.Samples.Graphics
{
    public partial class LineExample : Page
    {
        public LineExample()
        {
            InitializeComponent();
        }

        private void Border_Loaded(object sender, System.Windows.RoutedEventArgs e)
        {
            Line ln1 = new Line()
            {
                X1 = 10, Y1 = 10,
                X2 = 90, Y2 = 90,
                Stroke = Brushes.Red,
                StrokeThickness = 5
            };

            var ht = this.canvas.Height;
            var wd = this.canvas.Width;

            Line ln2 = new Line()
            {
                X1 = wd - 10, Y1 = 10,
                X2 = 10, Y2 = ht -10,
                Stroke = Brushes.Plum,
                StrokeThickness = 5
            };

            this.canvas.Children.Add(ln1);
            this.canvas.Children.Add(ln2);
        }

        private void Border_ManipulationDelta(object sender, System.Windows.Input.ManipulationDeltaEventArgs e)
        {
            var delta = e.DeltaManipulation;
            Matrix matrix = (this.myGrid.RenderTransform as MatrixTransform).Matrix;
            matrix.Translate(delta.Translation.X, delta.Translation.Y);// �w�̈ړ��ʂ��w�肵�đΏۂ��ړ�

            var scaleDelta = delta.Scale.X;//�㉺�ƍ��E�ɓ����ʊg�傷��Ƃ��́AX�̊g�嗦�����Ƃ��OK
            var orgX = e.ManipulationOrigin.X;//�w�̒��S�_(X)
            var orgY = e.ManipulationOrigin.Y;//�w�̒��S�_(Y)
            matrix.ScaleAt(scaleDelta, scaleDelta, orgX, orgY);//���S���w�肵�đΏۂ��g��
            this.myGrid.RenderTransform = new MatrixTransform(matrix);

        }

        private void ButtonRedraw_Click(object sender, System.Windows.RoutedEventArgs e)
        {
            int dt = 10;
            var ht = this.canvas.Height;
            var wd = this.canvas.Width;
            int o = (this.myView.Count / 4) * dt;
            byte c = (byte)(255 - this.myView.Count);

            LineGeometry ln1 = new LineGeometry()
            {
                StartPoint = new Point(dt, dt + o),
                EndPoint = new Point(dt + o, ht - dt)
            };
            var b1 = new SolidColorBrush(Color.FromRgb(c, 0, 0));
            this.myView.Add(new GeometryDrawing(b1, new Pen(b1, 5.0), ln1));

            LineGeometry ln2 = new LineGeometry()
            {
                StartPoint = new Point(dt + o, ht - dt),
                EndPoint = new Point(wd - dt, ht - dt - o)
            };
            var b2 = new SolidColorBrush(Color.FromRgb(0, c, 0));
            this.myView.Add(new GeometryDrawing(b2, new Pen(b2, 5.0), ln2));

            LineGeometry ln3 = new LineGeometry()
            {
                StartPoint = new Point(wd - dt, ht - dt - o),
                EndPoint = new Point(wd - dt - o, dt)
            };
            var b3 = new SolidColorBrush(Color.FromRgb(0, 0, c));
            this.myView.Add(new GeometryDrawing(b3, new Pen(b3, 5.0), ln3));

            LineGeometry ln4 = new LineGeometry()
            {
                StartPoint = new Point(wd - dt - o, dt),
                EndPoint = new Point(dt, dt + o)
            };
            var b4 = new SolidColorBrush(Color.FromRgb(c, c, 0));
            this.myView.Add(new GeometryDrawing(b4, new Pen(b4, 5.0), ln4));


            this.myView.InvalidateVisual();
        }

        private void ButtonClear_Click(object sender, System.Windows.RoutedEventArgs e)
        {
            this.myView.Clear();
            this.myView.InvalidateVisual();
        }

    }
}