#
#
# Python 2.7.13
#
# Author: Max Jacobsen
#
#
#
# Purpose: To complete the File Mover -- Python 2.7 -- IDLE drill,
# this drill is meant to be able to create a program that can move files from
# point A to point B. We will be using the shutil module in order to accomplish 
# this.
# 
#
# Please change the file path for your desktop in order for this program to work correctly.
#

import os
import shutil

desktop_path = 'C:\\Users\\mtjac\\Desktop\\'
folder_a_path = desktop_path + 'Folder_A'
folder_b_path = desktop_path + 'Folder_B'
directory_paths = [ folder_a_path, folder_b_path ] 
txt_files = [ 'cat.txt', 'dog.txt', 'bird.txt', 'fish.txt' ] 



def create_directory(path) :
    try: 
        if not os.path.exists(path):
            os.makedirs(path)
    except OSError:
        print('A error occured while trying to create a directory with file path {}'.format(path))

def create_directories(directories) :
    for path in directories:
        create_directory(path)

def empty_directory_files(directory_path) :
    if os.path.exists(directory_path):
        for file_object in os.listdir(directory_path):
            file_path = os.path.join(directory_path, file_object)
            if(os.path.isfile(file_path)):
               os.unlink(file_path)
    else :
        print('The file path {} does not exist so there is nothing to empty.'.format(path))

def create_txt_file(path) :
    try:
        if not os.path.exists(path):
            file = open(path, 'w')
            file.close()
    except:
        print('Error creating file path.')

def create_all_txt_files(base, paths) :
    for path in paths :
        create_txt_file(os.path.join(base, path))

def move_file(start, end) :
    try:
        shutil.move(start, end)
        print('\n Moved file {} to {}.'.format(start,end))
    except:
        print('Error occured while trying to move file')

def move_all_files(base1, base2, files) :
    for fileName in files:
        move_file(os.path.join(base1, fileName), os.path.join(base2, fileName))
    print('\n \n Successfully moved all files from \n {} to {}.'.format(base1, base2))


if __name__ == '__main__' :
    create_directories(directory_paths)
    empty_directory_files(folder_b_path)
    empty_directory_files(folder_a_path)
    create_all_txt_files(folder_a_path, txt_files)
    move_all_files(folder_a_path, folder_b_path, txt_files)
    
