#
#
# Python 2.7.13
#
# Author: Max Jacobsen
#
#
#
# Purpose: To complete the File Mover -- Python 2.7 -- IDLE drill,
# this drill is meant to be able to figure out which files have been newly created 
# or modified within a days work and move them to a special destination folder.
# 
#
# Please change the file path for your desktop in order for this program to work correctly.
#

import file_mod

desktop_path = 'C:\\Users\\mtjac\\Desktop\\'
watched_folder = desktop_path + 'Folder_Watched'
destination_folder = desktop_path + 'Folder_Modified'
directory_paths = [ watched_folder, destination_folder ]


if __name__ == '__main__' :
    file_mod.create_directories(directory_paths)
    file_mod.empty_directory_files(destination_folder)
    file_mod.copy_modified_files(watched_folder, destination_folder)
