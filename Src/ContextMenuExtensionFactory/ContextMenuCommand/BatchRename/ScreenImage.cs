
using System;	
using System.Drawing;
using System.Runtime.InteropServices;

namespace Tools
{

	public sealed class ScreenImage {

		#region Unmanaged declarations

		[DllImport("gdi32.dll")]
		private static extern bool BitBlt( IntPtr handlerToDestinationDeviceContext, int x, int y, int nWidth, int nHeight, IntPtr handlerToSourceDeviceContext, int xSrc, int ySrc, int opCode);
		
		[DllImport("user32.dll")]
		private static extern IntPtr GetWindowDC( IntPtr windowHandle );
		
		[DllImport("user32.dll")]
		private static extern int ReleaseDC( IntPtr windowHandle, IntPtr dc );

		private static int SRCCOPY = 0x00CC0020;  // dest = source 
		
		#endregion

		public static Image GetScreenshot( IntPtr windowHandle, Point location, Size size ) {
				
			Image myImage = new Bitmap( size.Width, size.Height );

			using ( Graphics g = Graphics.FromImage( myImage ) ) {
		
				IntPtr destDeviceContext = g.GetHdc();
				IntPtr srcDeviceContext = GetWindowDC( windowHandle );
						
				// TODO: throw exception
				BitBlt( destDeviceContext, 0, 0, size.Width, size.Height, srcDeviceContext, location.X, location.Y, SRCCOPY );
		
				ReleaseDC( windowHandle, srcDeviceContext );
				g.ReleaseHdc( destDeviceContext );

			} // dispose the Graphics object

			return myImage;

		}
		
	} // ScreenImage
	
} // Microsoft.Msdn.Article