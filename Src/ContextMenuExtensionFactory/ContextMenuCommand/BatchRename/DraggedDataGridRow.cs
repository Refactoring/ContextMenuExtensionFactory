
using System;
using System.Drawing;

namespace CustomControls
{
    internal class DraggedDataGridRow : IDisposable
    {
	    #region Private data fields

		// private data fields
		private Rectangle m_initialRegion;
		private Rectangle m_currentRegion;

		private int m_index;
		private Image m_rowImage;
		private Point m_cursorLocation;
		
		private bool disposed = false;
		
		#endregion

		#region Properties
		
		/// <summary>
		/// An integer representing the original column index.
		/// </summary>
		public int Index 
        {
			get { 
				CheckState();
				return m_index; 
			}
		}

		/// <summary>
		/// A Rectangle structure that identifies the region of the column at
		/// the time the drag and drop operation was initiated.
		/// </summary>	
		public Rectangle InitialRegion 
        {
			
			get { 
				
				CheckState();
				return m_initialRegion; 
			
			}
		
		}

		/// <summary>
		/// A Rectangle structure that identifies the current region of the 
		/// column that is being dragged. This is the only member that can be 
		/// modified after an instance has been created.
		/// </summary>
		public Rectangle CurrentRegion 
        {

			get { 

				CheckState();
				return m_currentRegion; 
				
			}
			
			set { 
				
				CheckState();
				m_currentRegion = value; 
			
			}

		}

		/// <summary>
		/// A Bitmap object containing a bitmap representation of the column at 
		/// the time that the drag and drop operation was initiated.
		/// </summary>
		public Image ColumnImage 
        {
			
			get { 
			
				CheckState();
				return m_rowImage; 
				
			}
		
		}

		/// <summary>
		/// A Point structure representing the cursor location relative to the 
		/// origin of m_initialRegion.
		/// </summary>
		public Point CursorLocation 
        {
			
			get { 
				
				CheckState();
				return m_cursorLocation; 
				
			}
		
		}

		#endregion

		#region Constructors
		
		public DraggedDataGridRow( int index, Rectangle initialRegion, Point cursorLocation, Image columnImage ) 
        {
			
			m_index = index;
			m_initialRegion = initialRegion;
			m_currentRegion = initialRegion;
			m_cursorLocation = cursorLocation;
			m_rowImage = columnImage;
				
		}

		public DraggedDataGridRow( int index, Rectangle initialRegion, Point cursorLocation ) : this( index, initialRegion, cursorLocation, null ) {}

		#endregion

		public void Dispose() 
        {
			
			if ( !disposed ) {
			
				m_initialRegion = Rectangle.Empty;
				m_currentRegion = Rectangle.Empty;

				m_index = -1;
				m_cursorLocation = Point.Empty;

				if ( m_rowImage != null ) {
					m_rowImage.Dispose();
				}

				disposed = true;

			} 
					
			// Remove this object from the finalization queue so the 
			// finalizer doesn't invoke this method again.
			GC.SuppressFinalize( this );

		}

		// NOTE: We do not implement the destructor because we are not 
		// explicitly dealing with unmanaged resources.

        // ~DraggedDataGridRow() { }
		
		/// <summary>
		/// Thow an ObjectDisposedException if this object has already been
		/// disposed.
		/// </summary>
		private void CheckState() 
        {
			
			if ( disposed ) {
				throw new ObjectDisposedException( "DraggedDataGridRow object has already been disposed." );
			}
		
		}
	
	} // DraggedDataGridRow
}
