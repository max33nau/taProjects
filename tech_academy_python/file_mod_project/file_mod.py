#
#
# Python 2.7.13
#
# Author: Max Jacobsen
#
#
# Module used for file creating and manipulation
# 
#
# 
#

import os
import shutil
import time_detail


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
        print('The file path {} does not exist so there is nothing to empty.'.format(directory_path))

def get_all_modified_files(directory_path) :
    if os.path.exists(directory_path):
        changed_files = []
        for file_object in os.listdir(directory_path):
            file_path = os.path.join(directory_path, file_object)
            if(os.path.isfile(file_path) and file_newly_modified(file_path)):
                print('{} file has been modified or created within the last 24 hours.'.format(file_path))
                changed_files.append(file_object)
        return changed_files
    else:
        print('The file path {} does not exist, so no modified files found.'.format(directory_path))
        return []

def file_newly_modified(file_path):
    most_recent_mod = created_or_mod_time(file_path)
    return time_detail.less_than_24_hour(most_recent_mod)
    

def created_or_mod_time(path):
    path_stat = os.stat(path)
    try: 
        created = time_detail.utc_from_timestamp(path_stat.st_ctime)
    except:
        print('created not found')
        created = False
    try:
        modified = time_detail.utc_from_timestamp(path_stat.st_mtime)
    except:
        print('modified not found')
        modified = False
    if(created > modified):
        return created
    else:
        return modified

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


def copy_file(src, dest):
    try:
        shutil.copy(src, dest)
        print('\n Copied file {} to {}.'.format(src, dest))
    except:
        print('Error occured while trying to copy file')
        
def copy_all_files(base1, base2, files) :
    for fileName in files:
        copy_file(os.path.join(base1, fileName), os.path.join(base2, fileName))
    print('\n \n Successfully copied all files from \n {} to {}.'.format(base1, base2))



