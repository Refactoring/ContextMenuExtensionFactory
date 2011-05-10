using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace CustomControls
{
    public delegate void ZOrderChangedHandler(int oldIndex, int newIndex, object objects);

    public partial class RowDragDataGridView : DataGridView
    {
        DraggedDataGridRow m_draggedRow;
        Rectangle m_mouseOverRowRect;
        int m_mouseOverRowIndex;

        bool m_showColumnHeaderWhileDragging = true;

        public bool ShowColumnHeaderWhileDragging
        {
            get { return m_showColumnHeaderWhileDragging; }
            set { m_showColumnHeaderWhileDragging = value; }
        }

        #region Parameterless constructor
        public RowDragDataGridView()
            : base()
        {
			
			InitializeComponent();
			
			// Initialize member fields
			ResetMembersToDefault();

			this.SetStyle( ControlStyles.DoubleBuffer, true );

		}

		#endregion

        public event ZOrderChangedHandler ZOrderChanged;
        protected virtual void OnZOrderChanged(int oldIndex, int newIndex, object objects)
        {
            if (ZOrderChanged != null)
                ZOrderChanged(oldIndex,newIndex,objects);
        }

        /// <summary>
        /// Resets all of the member fields to their default values.
        /// </summary>
        private void ResetMembersToDefault()
        {
            if (m_draggedRow != null)
                m_draggedRow.Dispose();

            m_draggedRow = null;
            m_mouseOverRowRect = Rectangle.Empty;
            m_mouseOverRowIndex = -1;
        }


        /// <summary>
        /// 确定被选中的行，并构造DraggedDataGridRow实例
        /// </summary>
        void RowDragDataGrid_CellMouseDown(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                Rectangle rowRect = this.GetRowDisplayRectangle(e.RowIndex, false);

                if (ShowColumnHeaderWhileDragging)
                {
                    Bitmap columnImage = (Bitmap)Tools.ScreenImage.GetScreenshot(this.Handle, rowRect.Location, rowRect.Size);
                    m_draggedRow = new DraggedDataGridRow(e.RowIndex, rowRect, e.Location, columnImage);
                }
                else
                {
                    m_draggedRow = new DraggedDataGridRow(e.RowIndex, rowRect, e.Location);
                }

                m_draggedRow.CurrentRegion = rowRect;
            }
            this.Update();
        }

        void RowDragDataGrid_CellMouseUp(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (m_draggedRow != null && e.RowIndex >= 0 && e.RowIndex != m_draggedRow.Index)
            {
                DataGridViewRow row = this.Rows[m_draggedRow.Index];
                this.Rows.RemoveAt(m_draggedRow.Index);
                this.EndEdit();
                this.SuspendLayout();
                this.Rows.Insert(e.RowIndex, row);
                this.ResumeLayout();

                OnZOrderChanged(m_draggedRow.Index, e.RowIndex, row.Tag);
            }
            ResetMembersToDefault();
        }

        void RowDragDataGrid_CellMouseMove(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (m_draggedRow != null && e.Y >= 0 && e.RowIndex >=0)
            {
                int y = e.Y - m_draggedRow.CursorLocation.Y;
                Rectangle rowRect = this.GetRowDisplayRectangle(e.RowIndex, false);

                if (e.RowIndex >= 0)
                {
                    if (e.RowIndex != m_mouseOverRowIndex)
                    {
                        if (m_mouseOverRowRect != Rectangle.Empty)
                        {
                            this.Invalidate(m_mouseOverRowRect, false);
                        }

                        if (e.RowIndex == m_draggedRow.Index)
                            m_mouseOverRowIndex = -1;
                        else
                            m_mouseOverRowIndex = e.RowIndex;

                        m_mouseOverRowRect = this.GetRowDisplayRectangle(e.RowIndex, false);

                        this.Invalidate(m_mouseOverRowRect, false);
                    }

                    int oldY = m_draggedRow.CurrentRegion.Y;
                    Point oldPoint = Point.Empty;

                    if (oldY < y)
                        oldPoint = new Point(m_draggedRow.InitialRegion.X,oldY - 5);
                    else
                        oldPoint = new Point(m_draggedRow.InitialRegion.X,y - 5);

                    Size sizeOfRectangleToInvalidate = new Size(m_draggedRow.InitialRegion.Width, Math.Abs(y - oldY) + m_draggedRow.InitialRegion.Height + (oldPoint.Y * 2));
                    this.Invalidate(new Rectangle(oldPoint, sizeOfRectangleToInvalidate));
                    //m_draggedRow.CurrentRegion = new Rectangle(m_draggedRow.InitialRegion.X, y, m_draggedRow.InitialRegion.Width, m_draggedRow.InitialRegion.Height);
                    m_draggedRow.CurrentRegion = rowRect;
                }
                else
                {
                    this.Invalidate();
                    ResetMembersToDefault();
                    this.Update();
                }
            }
            else
            {
                this.Invalidate(this.ClientRectangle);
                ResetMembersToDefault();
                this.Update();
            }

        }

        protected override void OnPaint(PaintEventArgs pe)
        {
            base.OnPaint(pe);

            if (m_draggedRow != null)
            {
                //绘制原始数据列
                Graphics g = pe.Graphics;

                int x = m_draggedRow.InitialRegion.X;
                int y = m_draggedRow.InitialRegion.Y;
                int width = m_draggedRow.InitialRegion.Width;
                int height = m_draggedRow.InitialRegion.Height;
                Rectangle region = new Rectangle(x, y, width, height);

                SolidBrush blackBrush = new SolidBrush(Color.FromArgb(255,0,0,0));
                SolidBrush darkGreyBrush = new SolidBrush(Color.FromArgb(150, 50, 50, 50));
                Pen blackPen = new Pen(blackBrush, 2F);

                g.FillRectangle(darkGreyBrush, m_draggedRow.InitialRegion);
                g.DrawRectangle(blackPen, region);

                blackBrush.Dispose();
                darkGreyBrush.Dispose();
                blackPen.Dispose();

                //绘制当前鼠标下的列
                if (this.m_mouseOverRowIndex != -1)
                {
                    using (SolidBrush b = new SolidBrush(Color.FromArgb(100, 100, 100, 100)))
                    {
                        g.FillRectangle(b, m_mouseOverRowRect);
                    }
                }

                //绘制列内容图像
                if (ShowColumnHeaderWhileDragging)
                {
                    Rectangle rect = new Rectangle(
                        m_draggedRow.CurrentRegion.X,
                        m_draggedRow.CurrentRegion.Y,
                        m_draggedRow.ColumnImage.Width,
                        m_draggedRow.ColumnImage.Height);
                    g.DrawImage(
                        m_draggedRow.ColumnImage,
                        rect,
                        0,
                        0,
                        m_draggedRow.ColumnImage.Width,
                        m_draggedRow.ColumnImage.Height,
                        GraphicsUnit.Pixel);
                }

                //为了更好的用户体验
                Pen filmBorder = new Pen(new SolidBrush(Color.FromArgb(255, 200, 200, 230)));
                SolidBrush filmFill = new SolidBrush(Color.FromArgb(100, 200, 200, 255));

                g.FillRectangle(
                    filmFill,
                    m_draggedRow.CurrentRegion.X,
                    m_draggedRow.CurrentRegion.Y,
                    m_draggedRow.CurrentRegion.Width,
                    m_draggedRow.CurrentRegion.Height);
                g.DrawRectangle(
                    filmBorder,
                    new Rectangle(
                        m_draggedRow.CurrentRegion.X + Convert.ToInt16(filmBorder.Width),
                        m_draggedRow.CurrentRegion.Y,
                    width,
                    height));

                filmBorder.Dispose();
                filmFill.Dispose();
            }
        }

        private void RowDragDataGridView_MouseLeave(object sender, EventArgs e)
        {
            ResetMembersToDefault();
            this.Update();
        }

    }
}
