using System;
using System.Drawing;
using System.Collections.Generic;
using System.Text;
using System.Collections;
using System.Windows.Forms;
using System.IO;

using SunnyChen.Common.Windows;

namespace SunnyChen.Gulu.Win.Helper
{
    internal sealed class FilesIconListManager
    {
        private Hashtable extensionList__ = new Hashtable();
		private System.Collections.ArrayList imageLists__ = new ArrayList();			//will hold ImageList objects
		private IconReader.IconSize iconSize__;
		private bool manageBothSizes__ = false; //flag, used to determine whether to create two ImageLists.


		public FilesIconListManager(ImageList _imageList, IconReader.IconSize _iconSize )
		{
			// Initialise the members of the class that will hold the image list we're
			// targeting, as well as the icon size (32 or 16)
            imageLists__.Add( _imageList );
			iconSize__ = _iconSize;
            
		}
		
        
        public FilesIconListManager(ImageList _smallImageList, ImageList _largeImageList)
		{
			//add both our image lists
			imageLists__.Add( _smallImageList );
			imageLists__.Add( _largeImageList );

			//set flag
			manageBothSizes__ = true;
		}


		private void AddExtension( string _extension, int _imageListPosition )
		{
			extensionList__.Add( _extension, _imageListPosition );
		}


		public int AddFileIcon( string _filePath )
		{
			// Check if the file exists, otherwise, throw exception.
			if (!System.IO.File.Exists( _filePath )) throw new System.IO.FileNotFoundException("File does not exist");
			
			// Split it down so we can get the extension
			string[] splitPath = _filePath.Split(new Char[] {'.'});
			string extension = (string)splitPath.GetValue( splitPath.GetUpperBound(0) );
				
			//Check that we haven't already got the extension, if we have, then
			//return back its index
			if (extensionList__.ContainsKey( extension.ToUpper() ))
			{
				return (int)extensionList__[extension.ToUpper()];		//return existing index
			} 
			else 
			{
				// It's not already been added, so add it and record its position.

				int pos = ((ImageList)imageLists__[0]).Images.Count;		//store current count -- new item's index

				if (manageBothSizes__ == true)
				{
					//managing two lists, so add it to small first, then large
                    Icon small = IconReader.GetFileIcon(_filePath, IconReader.IconSize.Small, false);
					((ImageList)imageLists__[0]).Images.Add( small );
                    Api.DestroyIcon(small.Handle);

                    Icon large = IconReader.GetFileIcon(_filePath, IconReader.IconSize.Large, false);
					((ImageList)imageLists__[1]).Images.Add( large );
                    Api.DestroyIcon(large.Handle);
				} 
				else
				{
					//only doing one size, so use IconSize as specified in _iconSize.
                    Icon small = IconReader.GetFileIcon(_filePath, iconSize__, false);
					((ImageList)imageLists__[0]).Images.Add( small );	//add to image list
                    Api.DestroyIcon(small.Handle);
				}

				AddExtension( extension.ToUpper(), pos );	// add to hash table
				return pos;
			}
		}


		public void ClearLists()
		{
			foreach( ImageList imageList in imageLists__ )
			{
				imageList.Images.Clear();	//clear current imagelist.
			}
			
			extensionList__.Clear();			//empty hashtable of entries too.
		}
    }
}
